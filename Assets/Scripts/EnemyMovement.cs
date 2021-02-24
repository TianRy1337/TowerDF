using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //[SerializeField] List<WayPoint2> path;

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }


    IEnumerator FollowPath(List<WayPoint2>path)
    {

        foreach (WayPoint2 waypoint in path)
        {
            transform.position = waypoint.transform.position; //new Vector3(waypoint.transform.position.x, waypoint.transform.position.y + 10f, waypoint.transform.position.z);
            //print("Visiting Block :" +waypoint.name);
            yield return new WaitForSecondsRealtime(3);
        }
    }


}
