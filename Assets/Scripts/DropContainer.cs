using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropContainer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("DropContainer: Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("DropContainer: OnTriggerEnter2D");
        
        var snapPosition = col.gameObject.transform.position;
        snapPosition.x = gameObject.transform.position.x;
        col.gameObject.transform.position = snapPosition;
        
        IDropContainerEventHandler towerController = gameObject.GetComponent<TowerController>();
        towerController.HandleEnterEvent(gameObject, col.gameObject);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("DropContainer: OnTriggerExit2D");

        IDropContainerEventHandler towerController = gameObject.GetComponent<TowerController>();
        towerController.HandleExitEvent(gameObject, col.gameObject);
    }
}
