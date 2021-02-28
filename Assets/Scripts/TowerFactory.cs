using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimits = 5;
    [SerializeField] Transform towerParentTransform;
    Queue<Tower> towerQueue = new Queue<Tower>();
    
    public void AddTower(WayPoint2 baseWaypoint)
    {
        int numTowers = towerQueue.Count;

        if (numTowers < towerLimits)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }

    }

    private void InstantiateNewTower(WayPoint2 baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform.transform;
        baseWaypoint.isPlaceable = false;
        newTower.baseWayPoint = baseWaypoint;
        towerQueue.Enqueue(newTower);
        
    }
    
    private void MoveExistingTower(WayPoint2 newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();
        towerQueue.Enqueue(oldTower);
        oldTower.baseWayPoint.isPlaceable= true;
        newBaseWaypoint.isPlaceable = false;

        oldTower.baseWayPoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;
    }
}
