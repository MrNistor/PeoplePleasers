using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonPathing : MonoBehaviour
{
    WaveInterface waveInterface;
    List<Transform> waypoints;
    int waypointIndex = 0;

    public ScoreManager scoreManager;  // used to get variables from GameManager
    private double scoringHappinessPercent;  // happiness percent required to earn a point

    private Text moneyAmount;  // required to update the money
    private int moneyAmountValue = 0;
    private int moneyIncrease = 10;

    public float personSpeed;

    // testing on store happiness values
    private List<float> happinessStorer;
    PersonHappiness _personHappiness;
    // testing on store happiness value
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        scoringHappinessPercent = scoreManager.happinessPercent;

        moneyAmount = GameObject.Find("Money").GetComponent<Text>();

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
            personSpeed = waveInterface.GetPersonMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, personSpeed);
            _personHappiness.happyDecreaseAmount = personSpeed;

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

            // update number of people who reached exit
            scoreManager.peopleCount++;
            if (happinessStorer[0] >= scoringHappinessPercent)
            {
                scoreManager.score++;
            }
            if (happinessStorer[0] > 0)
            {
                int.TryParse(moneyAmount.text, out moneyAmountValue);
                moneyAmountValue += moneyIncrease;
                moneyAmount.text = moneyAmountValue.ToString();
            }

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
