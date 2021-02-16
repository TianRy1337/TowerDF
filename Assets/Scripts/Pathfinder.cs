using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public WayPoint2 startWayPoint,endWayPoint;
    Dictionary<Vector2Int,WayPoint2> grid = new Dictionary<Vector2Int, WayPoint2>();
    Vector2Int[] directions = {
        // new Vector2Int(0,1),//Top
        // new Vector2Int(0,-1),//Down
        // new Vector2Int(1,0),//right
        // new Vector2Int(-1,0)//left
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.right,
        Vector2Int.left
    };

    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbours();
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
                //waypoint.SetTopColor(Color.black);
            }
            
        }
    }
    //改變起點與終點顏色
    private void ColorStartAndEnd()
    {
        startWayPoint.SetTopColor(Color.green);
        endWayPoint.SetTopColor(Color.red);
    }
    //找到點的上下左右
    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            //這邊會特地新增一個Vector2Int變數的原因是
            //如果單純用print("Exploring" +startWayPoint.GetGridPos() + direction);
            //系統會判定他是 "Exploring" + "startWayPoint.GetGridPos()" +"direction" 共三個字串連接
            //但這樣不是我們想要的結果，故改成下面這樣
            Vector2Int explorationCoordinates = startWayPoint.GetGridPos() + direction;
            //print("Exploring" + explorationCoordinates);
            try
            {
            grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch
            {
                //do nothing
            }
        }
    }

    void Update()
    {
        
    }
}
