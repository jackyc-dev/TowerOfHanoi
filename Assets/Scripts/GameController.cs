using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour, IGameEventHandler
{
    public int DiskCount = 3;
    public GameObject EndTower;
    public GameObject DiskTemplate;
    public GameObject DiskStartingLocation;

    public GameObject TowerList;

    private bool _isGameWon;

    void Start()
    {
        _isGameWon = false;
        ResetDisks();
    }

    IEnumerator InitializeDisks()
    {
        for (int i = DiskCount; i > 0; i--)
        {
            var _disk = GameObject.Instantiate(DiskTemplate);
            var _diskController = _disk.GetComponent<IDiskPropertyManager>();
            
            // Set specific properties here
            _diskController.SetDiskSize(i);
            _disk.name = $"Disk({i})";

            _disk.transform.localPosition = new Vector3(-6, 4, 0);
            _disk.transform.SetParent(DiskStartingLocation.transform);

            yield return new WaitForSeconds(.5f);
        }
    }
    
    private void ResetDisks()
    {
        StartCoroutine(InitializeDisks());
    }

    private void ResetTowers()
    {
        // Slightly sloppy approach to avoid circular dependency on the interfaces
        for(int i = 0; i < TowerList.transform.childCount; i++)
        {
            var towerManager = TowerList.transform.GetChild(i).GetComponent<ITowerPropertyManager>();
            towerManager.ResetTower();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Interface Implementations
    public void TowerStackUpdated(GameObject towerObject)
    {
        if(towerObject.name == EndTower.name)
        {
            _isGameWon = towerObject.transform.Find("DiskContainer").childCount == DiskCount;
        }
    }

    public bool IsGameWon() => _isGameWon;

    public void SetDiskCount(int newSize)
    {
        DiskCount = newSize;
        Reset();
    }

    public void Reset()
    {
        _isGameWon = false;
        ResetTowers();
        ResetDisks();
    }
}
