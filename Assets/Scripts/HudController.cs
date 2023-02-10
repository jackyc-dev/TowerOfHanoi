using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public int MinDiskSize;
    public int MaxDiskSize;
    public GameController GameEventHandler;

    public Dropdown DiskSizeSelect;
    public Text WinLabel;
    public Button ResetButton;

    private IGameEventHandler _gameEventHandler;

    // Start is called before the first frame update
    void Start()
    {
        _gameEventHandler = GameEventHandler.transform.GetComponent<IGameEventHandler>();
        InitializeDropDown();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWinLabel();
    }

    private void InitializeDropDown()
    {
        DiskSizeSelect.options.Clear();
        for(var size = MinDiskSize; size <= MaxDiskSize; size++)
        {
            DiskSizeSelect.options.Add(new Dropdown.OptionData($"{size}"));
        }
        DiskSizeSelect.onValueChanged.AddListener(delegate { OnDiskSizeValueChanged(DiskSizeSelect); });
    }

    private void UpdateWinLabel()
    {
        WinLabel.enabled = _gameEventHandler.IsGameWon();
    }

    public void OnDiskSizeValueChanged(Dropdown dropDown)
    {
        var selectedValue = dropDown.options[dropDown.value].text;
        // Debug.Log($"Disk Value Changed: {selectedValue}");
        _gameEventHandler.SetDiskCount(int.Parse(selectedValue));
    }

    public void OnResetButtonClicked(Button button)
    {
        // Debug.Log($"Reset Button clicked");
        _gameEventHandler.Reset();
    }
}
