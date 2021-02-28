using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]//編輯模式也持續運行
[SelectionBase]
[RequireComponent(typeof(WayPoint2))]
public class CubeEditor : MonoBehaviour
{
    WayPoint2 waypoint ;
    private void Awake() 
    {
        waypoint = GetComponent<WayPoint2>();
    }

    void Update()
    {

        SnapToGrid();
        UpdateLabel();
    
    }

    private void SnapToGrid()
    {   //自定義Unity內移動
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize,
            0,
            waypoint.GetGridPos().y * gridSize
            );
    }

    private void UpdateLabel()
    {
        //取得子物件裡的textMesh 把座標文字關掉會報錯但不影響運行
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        //物體名稱
        string labelText = 
            waypoint.GetGridPos().x  + 
            "," + 
            waypoint.GetGridPos().y ;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}