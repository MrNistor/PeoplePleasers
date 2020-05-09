using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to access btn with text

public class PersonSpawner : MonoBehaviour
{   
    public List<WaveInterface> waveInterfaces;
    private int startingWave = 0;

    public Button spawnButton;
    public Text spawnNumberIndicator;
    // Start is called before the first frame update
    public void Start()
    {
        // StartCoroutine(SpawnAllWaves());
        //spawnButton = GameObject.Find("SpawnButton").GetComponent<Button>();
        //spawnNumberIndicator = GameObject.Find("Path1Indicator").GetComponent<Text>();
        SpawnButtonIndicator();
        spawnNumberIndicator.text = "X" + waveInterfaces[0].GetNumberOfPerson();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void StartCoroutine()
    {
        StartCoroutine(SpawnAllWaves());
        // I have to enable the button after the method above is called
        spawnButton.enabled = false;
        ButtonClicked();
    }
    
    private void ButtonClicked()
    {
        spawnButton.gameObject.SetActive(false);
    }
    
    private void SpawnButtonIndicator()
    {
        Debug.Log(waveInterfaces[0].GetPerson()[0]);
        if (waveInterfaces[0].GetPerson()[0].name.Contains("Hungry"))
        {
            spawnButton.GetComponent<Image>().color = Color.red;
        }
        else if (waveInterfaces[0].GetPerson()[0].name.Contains("Thirsty"))
        {
            spawnButton.GetComponent<Image>().color = Color.blue;
        }
        else if (waveInterfaces[0].GetPerson()[0].name.Contains("Hot"))
        {
            spawnButton.GetComponent<Image>().color = new Color(255f, 174f, 0);
        }
        else if (waveInterfaces[0].GetPerson()[0].name.Contains("Bored"))
        {
            spawnButton.GetComponent<Image>().color = new Color(206f, 0, 255f);
        }
        else
        {
            Debug.Log("humm");
        }
    }



    private IEnumerator SpawnAllWaves()
    {
        for (var curWave = startingWave; curWave < waveInterfaces.Count; curWave++)
        {
            var current = waveInterfaces[curWave];
            // for distinguish
            // DistinguishPerson(current);

            yield return StartCoroutine(SpawnAllEnemiesByWave(current));
            
        }
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
        int generateRandomPerson = 0;
        if (_waveInterface.GetPerson().Count > 1)
        {
            generateRandomPerson = Random.Range(0, 4);
        }
        else
        {
            generateRandomPerson = 0;
        }
        int generateRandomTargetPos = Random.Range(0, 2);
        GameObject personObj = Instantiate(_waveInterface.GetPerson()[generateRandomPerson],
            _waveInterface.GetWaypoint()[0].transform.position,
            Quaternion.identity);
        personObj.GetComponent<PersonPathing>().SetWave(_waveInterface);
    }
}
