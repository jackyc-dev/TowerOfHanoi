using UnityEngine;
public interface IGameEventHandler
{
    void TowerStackUpdated(GameObject towerObject);
    bool IsGameWon();
    void SetDiskCount(int newSize);
    void Reset();
}