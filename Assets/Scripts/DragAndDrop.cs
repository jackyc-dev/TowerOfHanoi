using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : BaseBehaviour, IDraggableObjectEventHandler
{
    private Vector3 _originalPosition;
    public bool Enabled;

    void Start() 
    {
        // Debug.Log("DragAndDrop: Start");
    }

    public void OnMouseDown()
    {
        if(!Enabled) return;
        // Debug.Log("DragAndDrop: OnMouseDown");
        _originalPosition = gameObject.transform.position;
    }

    public void OnMouseDrag() 
    {
        if(!Enabled) return;
        // Debug.Log("DragAndDrop: OnMouseDrag");
        transform.position = GetMousePos();
    }

    public void OnMouseUp()
    {
        
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    public void HandleInvalidDragAndDropEvent()
    {
        gameObject.transform.position = _originalPosition;
    }
    public void SetEnable(bool IsEnabled) => Enabled = IsEnabled;

    public bool IsEnabled() => Enabled;
}
