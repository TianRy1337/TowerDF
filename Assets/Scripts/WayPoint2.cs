using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint2 : MonoBehaviour
{
    [SerializeField] Color exploredColor;

    //public ok here as is a data class
    public bool isExplored = false;
    public WayPoint2 exploredFrom;//協助判斷該點是被誰找到的，以便加入路徑
    

    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    //FIXME:設定被尋找過的顏色但也會將起點與終點的顏色也蓋過
    // private void Update() 
    // {
    //     if(isExplored)
    //     {
    //         SetTopColor(exploredColor);
    //     } 
    // }


    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}


