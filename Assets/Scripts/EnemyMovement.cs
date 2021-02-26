using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //[SerializeField] List<WayPoint2> path;
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;
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
            yield return new WaitForSecondsRealtime(movementPeriod);
        }
        SelfDestruct();
    }

    void SelfDestruct()
    {
        var vfx = Instantiate(goalParticle,transform.position,Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject,destroyDelay);
        Destroy(gameObject);
    }
}
