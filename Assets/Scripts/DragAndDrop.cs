using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDraggableObjectEventHandler
{
    private Vector3 _originalPosition;
    public bool IsEnabled;

    void Start() 
    {
        Debug.Log("DragAndDrop: Start");
    }

    public void OnMouseDown()
    {
        if(!IsEnabled) return;
        Debug.Log("DragAndDrop: OnMouseDown");
        _originalPosition = gameObject.transform.position;
    }

    public void OnMouseDrag() 
    {
        if(!IsEnabled) return;
        Debug.Log("DragAndDrop: OnMouseDrag");
        transform.position = GetMousePos();
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
    public void SetEnable(bool IsEnabled)
    {
        this.IsEnabled = IsEnabled;
    }
}
