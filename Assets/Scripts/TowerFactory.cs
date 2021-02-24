using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimits = 5;
    // Start is called before the first frame update
    public void AddTower(WayPoint2 baseWaypoint)
    {
        var towers = FindObjectsOfType<Tower>();
        int numTowers = towers.Length;
        if (numTowers < towerLimits)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }

    }
    private void InstantiateNewTower(WayPoint2 baseWaypoint)
    {
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
    }
    private static void MoveExistingTower()
    {
        Debug.Log("Not add More Tower");

    }
}
