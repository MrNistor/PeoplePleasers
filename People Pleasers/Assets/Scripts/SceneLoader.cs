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
        
    }

    private void AddLoadTime()
    {
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForSeconds());
        } 
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadScene()
    {
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
        SceneManager.LoadScene("Level 1");
    }


}
