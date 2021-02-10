using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int,WayPoint2> grid = new Dictionary<Vector2Int, WayPoint2>();
    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint2>();
        foreach (WayPoint2 waypoint in waypoints)
        {
            //寫入及判斷方塊是否重疊
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if(isOverlapping)
            {
                Debug.Log("Overlapping Block" + waypoint);
            }else
            {
                grid.Add(waypoint.GetGridPos(),waypoint);
            }
            
        }
       // print(grid.Count);
    }
    void Update()
    {
        
    }
}
