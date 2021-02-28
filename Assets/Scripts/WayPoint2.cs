using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint2 : MonoBehaviour
{
    //public ok here as is a data class
    public bool isExplored = false;
    public WayPoint2 exploredFrom;//協助判斷該點是被誰找到的，以便加入路徑
    public bool isPlaceable = true;

    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    private void OnMouseOver() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                print("Can't not place here");
            }
        }
    }

    // public void SetTopColor(Color color)
    // {
    //     NOTE:find a child of a game object the current script is attached to by name, looking only one level deep 
    //     MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>(); 
    //     topMeshRenderer.material.color = color;
    // }
    //上面這段程式碼當初是拿來設定被尋找過的路徑的，更新WayPoint外觀後就沒用了

}


