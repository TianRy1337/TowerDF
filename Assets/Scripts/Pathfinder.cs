using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public WayPoint2 startWayPoint, endWayPoint;
    Dictionary<Vector2Int, WayPoint2> grid = new Dictionary<Vector2Int, WayPoint2>();
    Queue<WayPoint2> queue = new Queue<WayPoint2>();
    [SerializeField]bool isRunning = true;


    Vector2Int[] directions = {
        // new Vector2Int(0,1),//Top
        // new Vector2Int(0,-1),//Down
        // new Vector2Int(1,0),//right
        // new Vector2Int(-1,0)//left
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
        //ExploreNeighbours();
    }

    private void PathFind()
    {
        queue.Enqueue(startWayPoint);

        while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            print("Serching From :" + searchCenter);
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
            searchCenter.isExplored = true;
            
        }
        print("Finished Pathfinding ?");
    }

    private void HaltIfEndFound(WayPoint2 searchCenter)
    {
        if (searchCenter == endWayPoint)
        {
            print("Searching From end node ,therefore stopping");
            isRunning = false;
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint2>();
        foreach (WayPoint2 waypoint in waypoints)
        {
            //寫入及判斷方塊是否重疊
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverlapping)
            {
                Debug.Log("Overlapping Block" + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
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
    private void ExploreNeighbours(WayPoint2 from)
    {
        if(!isRunning){return;}
        foreach (Vector2Int direction in directions)
        {
            //這邊會特地新增一個Vector2Int變數的原因是
            //如果單純用print("Exploring" +startWayPoint.GetGridPos() + direction);
            //系統會判定他是 "Exploring" + "startWayPoint.GetGridPos()" +"direction" 共三個字串連接
            //但這樣不是我們想要的結果，故改成下面這樣
            
            Vector2Int neighbourCoordinates = from.GetGridPos() + direction;
            //print("Exploring" + neighbourCoordinates);
            try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch
            {
                //do nothing
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        WayPoint2 neighbour = grid[neighbourCoordinates];
        if(neighbour.isExplored)
        {
        }
        else
        {
            neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
            print("Queueing " + neighbour);
        }
    }
}
