using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static IEnumerable<GameObject> GetChildGameObjects(GameObject parentObj)
    {
        var childObjList = new List<GameObject>();
        for(int i = 0; i < parentObj.transform.childCount; i++)
        {
            childObjList.Add(parentObj.transform.GetChild(i).gameObject);
        }
        return childObjList;
    }
}