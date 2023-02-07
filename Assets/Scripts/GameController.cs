using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int DiskCount = 3;

    private GameObject _diskTemplate;
    private GameObject _towerTemplate;
    private GameObject _towerContainer;
    private GameObject _wrapper;
    private GameObject _diskStartingLocation;

    void Start()
    {
        _diskTemplate = gameObject.transform.Find("Templates/Disk").gameObject;
        // _towerTemplate = gameObject.transform.Find("Templates/Tower").gameObject;
        _towerContainer = gameObject.transform.Find("Wrapper/Towers").gameObject;
        _wrapper = gameObject.transform.Find("Wrapper").gameObject;
        _diskStartingLocation = gameObject.transform.Find("Wrapper/DiskStartingLocation").gameObject;
        
        StartCoroutine(InitializeDisks());
    }

    IEnumerator InitializeDisks()
    {
        for (int i = DiskCount; i > 0; i--)
        {
            var _disk = GameObject.Instantiate(_diskTemplate);
            var _diskController = _disk.GetComponent<DiskController>();
            
            // Set specific properties here
            _diskController.SetDiskSize(i);
            _disk.name = $"Disk({i})";

            _disk.transform.localPosition = new Vector3(-6, 4, 0);
            _disk.transform.SetParent(_diskStartingLocation.transform);
            // Utils.SetCoroutine(.5f);

            yield return new WaitForSeconds(.5f);
        }
    }
    

    void InitializeTowers()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
