using UnityEngine;
public interface IDropContainerEventHandler
{
    void HandleEnterEvent(GameObject containerObject, GameObject droppedObject);
    void HandleStayEvent(GameObject containerObject, GameObject droppedObject);
    void HandleExitEvent(GameObject containerObject, GameObject droppedObject);
}