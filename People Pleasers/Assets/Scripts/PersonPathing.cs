using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonPathing : MonoBehaviour
{
    WaveInterface waveInterface;
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

    // it will be used for spawn enemy
    public void SetWave(WaveInterface _waveInterface)
    {
        waveInterface = _waveInterface;
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
            // for now just destroy
            DestroyGameObj();
        }
        
    }
    private void DestroyGameObj()
    {
        Destroy(gameObject);
    }
}
