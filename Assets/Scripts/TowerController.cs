using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerController : BaseBehaviour, IDropContainerEventHandler, ITowerPropertyManager
{
    public Color TowerColor;
    public Vector3 TowerPosition;
    public GameController GameEventHandler; // Unsure how we can expose an interface as part of the wiring, probably referenced by code
    public GameObject DiskContainer;

    private IGameEventHandler _gameEventHandler;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = TowerPosition;
        DiskContainer = gameObject.transform.Find("DiskContainer").gameObject;
        _gameEventHandler = GameEventHandler.transform.GetComponent<IGameEventHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        ToggleEnableDisksInTower();
    }

    private bool IsDroppedDiscValidToBeAddedInTower(GameObject droppedDiskObject, IEnumerable<GameObject> existingDiskObjects) 
    {
        if(existingDiskObjects.Count() == 0) return true;

        var droppedDiskSize = droppedDiskObject.GetComponent<IDiskPropertyManager>().GetDiskSize();
        var maxDiskSize = existingDiskObjects.Select(d => d.GetComponent<IDiskPropertyManager>().GetDiskSize()).Max();

        return droppedDiskSize < maxDiskSize;
    }

    public void HandleEnterEvent(GameObject containerObject, GameObject droppedObject)
    {
        var existingDiskObjects = Utils.GetChildGameObjects(containerObject.transform.Find("DiskContainer").gameObject);
        // Check if Drop Event is valid
        if(!IsDroppedDiscValidToBeAddedInTower(droppedObject, existingDiskObjects)) 
        {
            var droppedObjectEventHandler = droppedObject.GetComponent<IDraggableObjectEventHandler>();
            droppedObjectEventHandler.HandleInvalidDragAndDropEvent();
            return;
        }

        // Add to list of disks
        droppedObject.transform.SetParent(DiskContainer.transform);
        ToggleEnableDisksInTower();

        if(_gameEventHandler != null)
        {
            _gameEventHandler.TowerStackUpdated(containerObject);
        }
    }

    void IDropContainerEventHandler.HandleStayEvent(GameObject containerObject, GameObject droppedObject)
    {
        // throw new System.NotImplementedException();
        // ToggleEnableDisksInTower();
    }

    void IDropContainerEventHandler.HandleExitEvent(GameObject containerObject, GameObject droppedObject)
    {
        // var removedDisk = droppedObject.GetComponent<DiskController>();
        // // throw new System.NotImplementedException();
        // var remainingDisks = 
        //     Utils.GetChildGameObjects(containerObject.transform.Find("DiskContainer").gameObject)
        //     .Where(d => d.GetComponent<DiskController>().DiskSize != removedDisk.DiskSize);
        // if(remainingDisks.Count() > 0) 
        // {
        //     remainingDisks.LastOrDefault().GetComponent<IDraggableObjectEventHandler>().SetEnable(true);
        // }
        // ToggleEnableDisksInTower();
    }

    void ToggleEnableDisksInTower()
    {
        // Debug.Log($"{gameObject.name} - ToggleEnableDisksInTower()");
        var disks = Utils.GetChildGameObjects(DiskContainer);
        var disksCount = disks.Count();
        
        if(disksCount == 0) return; // Nothing to check if the list is empty

        foreach(var disk in disks)
        {
            SetEnabledFn(disk, false);
            // Debug.Log($"{gameObject.name} - ToggleEnableDisksInTower(): disabled {disk.name}");
        }

        var minDisk = disks.FirstOrDefault(x => GetDiskSizeFn(x) == disks.Min(y => GetDiskSizeFn(y)));
        SetEnabledFn(minDisk, true);
        // Debug.Log($"{gameObject.name} - ToggleEnableDisksInTower(): enabled {minDisk.name}");
    }

    public void ResetTower()
    {
        Debug.Log($"TowerController: ResetTower");
        var diskCount = DiskContainer.transform.childCount;
        for(int i = diskCount; i > 0; i--)
        {
            var toBeDestroyed = DiskContainer.transform.GetChild(i-1);
            Destroy(toBeDestroyed.gameObject);
        }
    }

    // Utils
    private float GetDiskSizeFn(GameObject g) => g.transform.GetComponent<IDiskPropertyManager>().GetDiskSize();
    private void SetEnabledFn(GameObject g, bool enabled) => g.transform.GetComponent<IDraggableObjectEventHandler>().SetEnable(enabled);
}
