using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint2> path;

    void Start()
    {
        StartCoroutine(watToPath());
    }
    IEnumerator watToPath()
    {
        //print("Strat Patrolling");
        foreach (WayPoint2 waypoint in path)
        {
            transform.position = waypoint.transform.position; //new Vector3(waypoint.transform.position.x, waypoint.transform.position.y + 10f, waypoint.transform.position.z);
            //print("Visiting Block :" +waypoint.name);
            yield return new WaitForSecondsRealtime(1);
        }
        //print("End Patrol");
        
    }

    void Update()
    {

    }
}
