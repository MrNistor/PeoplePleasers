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
    
    public float timeAutomaticClick = 20.0f;
    private float maxFillAmount = 1.0f;

    private Coroutine coroutineForBtnNotClicked;
    // Start is called before the first frame update
    public void Start()
    {
        coroutineForBtnNotClicked = StartCoroutine(AutomaticClick());
        spawnButton.GetComponent<Image>().fillAmount = maxFillAmount;
        SpawnButtonIndicator();
        spawnNumberIndicator.text = "X" + waveInterfaces[0].GetNumberOfPerson();
        
    }

    // Update is called once per frame
    void Update()
    {
        AutomaticStartIndicator();
    }
    
    // create a method that if the btn is not click
    // in certain amount of time it will get click automatically
    private IEnumerator AutomaticClick()
    {
        yield return new WaitForSeconds(timeAutomaticClick);
        spawnButton.onClick.Invoke();
        spawnButton.gameObject.SetActive(false);  
    }

    private void AutomaticStartIndicator()
    {
        // fill amout is one
        var decreaseAmount = maxFillAmount / timeAutomaticClick;      
        spawnButton.GetComponent<Image>().fillAmount -= decreaseAmount * Time.deltaTime;
        if (spawnButton.GetComponent<Image>().fillAmount == 0)
        {
            spawnButton.gameObject.SetActive(false);  
        }
    }

    public void StartCoroutine()
    {
        StartCoroutine(SpawnAllWaves());
        // I have to enable the button after the method above is called
        ButtonClicked();
        spawnButton.enabled = false;
        StopCoroutine(coroutineForBtnNotClicked);
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
            //Debug.Log("humm");
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        for (var curWave = startingWave; curWave < waveInterfaces.Count; curWave++)
        {
            var current = waveInterfaces[curWave];
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
