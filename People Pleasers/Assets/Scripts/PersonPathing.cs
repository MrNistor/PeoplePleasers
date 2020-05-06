using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonPathing : MonoBehaviour
{
    public WaveInterface waveInterface;
    List<Transform> waypoints;
    int waypointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveInterface.GetWaypoint();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPos = waypoints[waypointIndex].transform.position;
            var personSpeed = waveInterface.GetPersonMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, personSpeed);

            if (transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
            //Reached at the end
            Debug.Log("Reached End");
        }
        
    }
}
