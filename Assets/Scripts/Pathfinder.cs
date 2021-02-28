using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public WayPoint2 startWayPoint, endWayPoint;
    Dictionary<Vector2Int, WayPoint2> grid = new Dictionary<Vector2Int, WayPoint2>();
    Queue<WayPoint2> queue = new Queue<WayPoint2>();
    bool isRunning = true;
    WayPoint2 searchCenter;
    List<WayPoint2> path = new List<WayPoint2>();

    Vector2Int[] directions ={
        //NOTE:
        // new Vector2Int(0,1),//Top
        // new Vector2Int(0,-1),//Down
        // new Vector2Int(1,0),//right
        // new Vector2Int(-1,0)//left
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<WayPoint2> GetPath()
    {
        if(path.Count==0)//沒有被存取過
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreathFirstSearch();            
        CreatePath();
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
            }

        }
    }

    private void BreathFirstSearch()
    {
        queue.Enqueue(startWayPoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
            
        }
    }

    private void CreatePath()
    {
        SetAsPath(endWayPoint);
        WayPoint2 previous = endWayPoint.exploredFrom;
        while(previous != startWayPoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }
        SetAsPath(startWayPoint);
        path.Reverse();
    }

    private void SetAsPath(WayPoint2 wayPoint)
    {
        path.Add(wayPoint);
        wayPoint.isPlaceable = false;
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWayPoint)
        {
            isRunning = false;
        }
    }
    
    private void ExploreNeighbours()//找到點的上下左右
    {
        if(!isRunning){return;}
        foreach (Vector2Int direction in directions)
        {
            //NOTE:
            //這邊會特地新增一個Vector2Int變數的原因是
            //如果單純用print("Exploring" +startWayPoint.GetGridPos() + direction);
            //系統會判定他是 "Exploring" + "startWayPoint.GetGridPos()" +"direction" 共三個字串連接
            //但這樣不是我們想要的結果，故改成下面這樣
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        WayPoint2 neighbour = grid[neighbourCoordinates];
        if(neighbour.isExplored || queue.Contains(neighbour)){}
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;//判斷該點是被誰找到的
        }
    }
}
