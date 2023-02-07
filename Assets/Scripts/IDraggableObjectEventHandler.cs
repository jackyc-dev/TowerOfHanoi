using UnityEngine;
public interface IDraggableObjectEventHandler
{
    void HandleInvalidDragAndDropEvent();
    void SetEnable(bool IsEnabled);
    bool IsEnabled();
}
