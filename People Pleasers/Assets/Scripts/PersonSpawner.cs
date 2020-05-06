using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{   
    public List<WaveInterface> waveInterfaces;
    private int startingWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveInterfaces[startingWave];
        StartCoroutine(SpawnAllEnemiesByWave(currentWave));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllEnemiesByWave(WaveInterface _waveInterface)
    {
        for (int i = 0; i < _waveInterface.GetNumberOfPerson(); i++)
        {
            GeneratePerson(_waveInterface);
            yield return new WaitForSeconds(_waveInterface.GetTimeBetweenSpawns());
        }
        
    }
    private void GeneratePerson(WaveInterface _waveInterface)
    {
        Instantiate(_waveInterface.GetPerson(),
            _waveInterface.GetWaypoint()[0].transform.position,
            Quaternion.identity);
    }
}
