using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerController : MonoBehaviour, IDropContainerEventHandler
{
    public Color TowerColor;
    public Vector3 TowerPosition;

    public Stack<GameObject> StoredDisks;

    private GameObject _diskContainer;

    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = TowerPosition;
        _diskContainer = gameObject.transform.Find("DiskContainer").gameObject;
        StoredDisks = new Stack<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        ToggleEnableDisksInTower();
    }

    private bool IsDroppedDiscValidToBeAddedInTower(GameObject droppedDiskObject, IEnumerable<GameObject> existingDiskObjects) 
    {
        if(existingDiskObjects.Count() == 0) return true;

        var droppedDiskSize = droppedDiskObject.GetComponent<DiskController>().DiskSize;
        var maxDiskSize = existingDiskObjects.Select(d => d.GetComponent<DiskController>().DiskSize).Max();

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
        droppedObject.transform.SetParent(_diskContainer.transform);
        ToggleEnableDisksInTower();
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
        Debug.Log($"{gameObject.name} - ToggleEnableDisksInTower()");
        var disks = Utils.GetChildGameObjects(_diskContainer);
        var disksCount = disks.Count();
        
        if(disksCount == 0) return;
        if(disksCount > 1 )
        {
            foreach(var disk in disks)
            {
                disk.transform.GetComponent<IDraggableObjectEventHandler>().SetEnable(false);
                Debug.Log($"{gameObject.name} - ToggleEnableDisksInTower(): disabled {disk.name}");
            }
        }
        
        var minDisk = disks
            .FirstOrDefault(x => x.transform.GetComponent<DiskController>().DiskSize == disks.Min(y => y.transform.GetComponent<DiskController>().DiskSize));
        minDisk.transform.GetComponent<IDraggableObjectEventHandler>().SetEnable(true);
        Debug.Log($"{gameObject.name} - ToggleEnableDisksInTower(): enabled {minDisk.name}");
    }
}
