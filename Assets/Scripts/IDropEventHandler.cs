using UnityEngine;
public interface IDropEventHandler
{
    void HandleDropEvent(GameObject containerObject, GameObject droppedObject);
}