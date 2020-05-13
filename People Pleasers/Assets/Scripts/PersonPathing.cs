using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonPathing : MonoBehaviour
{
    WaveInterface waveInterface;
    List<Transform> waypoints;
    int waypointIndex = 0;

    // testing on store happiness values
    private List<float> happinessStorer;
    PersonHappiness _personHappiness;
    // testing on store happiness value
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveInterface.GetWaypoint();
        transform.position = waypoints[waypointIndex].transform.position;
        Debug.Log("theGameObj" + waveInterface.GetPerson()[0].name);

        // testing on store happiness values
        happinessStorer = new List<float>();
        _personHappiness = GetComponent<PersonHappiness>();
        // testing on store happiness value
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
            // testing on store happiness value
            happinessStorer.Add(_personHappiness.GetHappinessValue());
            Debug.Log(happinessStorer[0]);
            // testing on store happiness value

            // for now just destroy
            DestroyGameObj();
        }
        
    }
    private void DestroyGameObj()
    {
        Destroy(gameObject);
    }
    // testing on store happiness value
    public List<float> GetHappinessValue()
    {
        return happinessStorer;
    }
    // testing on store happiness value
}
