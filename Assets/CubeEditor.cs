using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]//編輯模式也持續運行

public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;
    TextMesh textMesh;

    void Start()
    {

    }

    void Update()
    {
        //自定義移動
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
        textMesh = GetComponentInChildren<TextMesh>();

        //物體名稱
        string labelText = textMesh.text;
        labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        gameObject.name = labelText;
        


    }
}
