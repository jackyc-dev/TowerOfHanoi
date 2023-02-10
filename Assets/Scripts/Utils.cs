using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    // Still experimental, casting is still causing problems for me
    public static IEnumerable<T> FindObjectsOfTypeFromParentObject<T>(GameObject parentObj)
    {
        var typedObjects = GameObject.FindObjectsOfType<GameObject>().OfType<T>();
        Debug.Log($"FindObjectsOfTypeFromParentObject count: {typedObjects.Count()}");
        return typedObjects.Where(x => (x as GameObject).transform.IsChildOf(parentObj.transform)); // TODO: Casting might be slow perf-wise
    }
}