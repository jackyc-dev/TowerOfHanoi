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

        // Disable drag and drop function on all pre-existing disks
        foreach(var existingDisk in existingDiskObjects)
        {
            existingDisk.GetComponent<IDraggableObjectEventHandler>().SetEnable(false);
        }

        // Add to list of disks
        droppedObject.transform.SetParent(_diskContainer.transform);
    }

    void IDropContainerEventHandler.HandleStayEvent(GameObject containerObject, GameObject droppedObject)
    {
        // throw new System.NotImplementedException();
    }

    void IDropContainerEventHandler.HandleExitEvent(GameObject containerObject, GameObject droppedObject)
    {
        // throw new System.NotImplementedException();
    }
}
