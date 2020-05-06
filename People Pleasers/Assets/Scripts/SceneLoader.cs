﻿using System.Collections;
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

    private void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


}