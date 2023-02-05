using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour, IDropEventHandler
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
        foreach(Transform childObject in _diskContainer.transform)
        {
            Destroy(childObject.gameObject);
        }
        foreach(var disk in StoredDisks)
        {
            var dupe = GameObject.Instantiate(disk);
            dupe.transform.SetParent(_diskContainer.transform);
        }
    }

    private bool IsDroppedDiscValidToBeAddedInTower() 
    {
        return true;
    }

    public void HandleDropEvent(GameObject containerObject, GameObject droppedObject)
    {
        // Check if Drop Event is valid

        // Add to list of disks
        // StoredDisks.Push(droppedObject);

        
    }
}
