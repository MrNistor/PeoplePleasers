using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Configuration")]
public class WaveInterface : ScriptableObject
{
    public GameObject personPrefabs;
    public GameObject pathPrefabs;
    // this time time will be randomize?
    public float timeBetweenSpawns = 0.5f;
    // 10 just things to start
    public int numberOfPerson = 10;
    public float pMoveSpeed = 2f;

    public List<Transform> GetWaypoint()
    {
        var myListWaypoint = new List<Transform>();
        foreach(Transform waypoint in pathPrefabs.transform)
        {
            myListWaypoint.Add(waypoint);
        }
        return myListWaypoint;
    }

    public List<GameObject> GetPerson()
    {
        var myPersonList = new List<GameObject>();
        foreach (Transform person in personPrefabs.transform)
        {
            myPersonList.Add(person.gameObject);
        }
        return myPersonList;
    }

    //public GameObject GetPerson()
    //{
    //    return personPrefabs;
    //}

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public int GetNumberOfPerson()
    {
        return numberOfPerson;
    }

    public float GetPersonMoveSpeed()
    {
        return pMoveSpeed;
    }
    
}
