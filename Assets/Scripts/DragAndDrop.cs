using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 _originalPosition;

    void Start() 
    {
        Debug.Log("DragAndDrop: Start");
    }

    public void OnMouseDown()
    {
        Debug.Log("DragAndDrop: OnMouseDown");
        _originalPosition = Input.mousePosition;
    }

    public void OnMouseDrag() 
    {
        Debug.Log("DragAndDrop: OnMouseDrag");
        transform.position = GetMousePos();
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
