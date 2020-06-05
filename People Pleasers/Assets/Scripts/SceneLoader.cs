using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentSceneIndex;

    void Start()
    {
        // grab the scene
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        AddLoadTime();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKey(KeyCode.K))
        {
            LoadNextScene();
        }

        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForSeconds());
        }

    }

    private void AddLoadTime()
    {
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForSeconds());
            
            LoadNextScene();
        }
        
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Current Scene index is: " + currentSceneIndex);
    }

    public void LoadNextScene()
    {
        PauseChecker();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("From LoadNextScene: " + currentSceneIndex);
        if (currentSceneIndex == 11)
            currentSceneIndex = 1;
        else if (currentSceneIndex == 13)
            currentSceneIndex = 2;
        else
            currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        PauseChecker();
        currentSceneIndex = 0;
        SceneManager.LoadScene(currentSceneIndex);
        Debug.Log("Current Scene is: " + currentSceneIndex);
       
    }

    public void ReloadScene()
    {
        PauseChecker();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    
    public void LoadHowToPlay2()
    {
        SceneManager.LoadScene("HowToPlay2");
    }

    public void LoadLevel1Scene()
    {
        PauseChecker();
        SceneManager.LoadScene("Level 1");
    }

    private void PauseChecker()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }
    }

}
