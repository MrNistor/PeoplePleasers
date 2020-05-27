using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;  // keeps track of score
    public int winningScore = 5;  // score required to win, change using Unity Interface
    public int peopleCount = 0;  // used to track number of people who have crossed the exit
    public int totalPeople = 8;  // used to determine end of level, change using Unity Interface
    public GameObject winScreen;  // requires winning screen object (make sure it is disabled by default)
    public GameObject loseScreen;  // requires losing screen object (make sure it is disabled by default)
    public GameObject scoreBoard;  // requires SpawnCanvas object with Score component
    // pause
    public GameObject pauseBoard;
    private bool isPasuse;
    // end of pause
    public float happinessPercent = 0.4f;  // happiness level required to earn a point

    // Start is called before the first frame update
    void Start()
    {
        isPasuse = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyUp("space"))
        {
            if (isPasuse == false)
            {
                isPasuse = true;
                pauseBoard.SetActive(true);
                 OnPause();
            }
            else if (isPasuse == true)
            {
                isPasuse = false;
                pauseBoard.SetActive(false);
                OnStart();
            }
        }
            
       

        scoreBoard.GetComponent<Text>().text = "Score: " + score.ToString() + "/" + winningScore;  // update score board
        // check if level has ended
        if (peopleCount >= totalPeople)
        {
            // check if level won or lost
            if (score >= winningScore)
                winScreen.SetActive(true);
            else
                loseScreen.SetActive(true);
        }

    }

    private void OnPause()
    {
        Time.timeScale = 0f;
    }
    private void OnStart()
    {
        Time.timeScale = 1f;
    }
}
