using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageDisplayer : MonoBehaviour
{
    Scene currentScene;
    public Text displaySceneLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        GetSceneLevelName();
    }

    private void GetSceneLevelName()
    {
        switch(currentScene.name)
        {
            case "Level 1":
                displaySceneLevel.text = "Level 1";
                break;
            case "Level 2":
                displaySceneLevel.text = "Level 2";
                break;
            case "Level 3":
                displaySceneLevel.text = "Level 3";
                break;
            case "Level 4":
                displaySceneLevel.text = "Level 4";
                break;
            case "Level 5":
                displaySceneLevel.text = "Level 5";
                break;
            case "Level 6":
                displaySceneLevel.text = "Level 6";
                break;
            case "Level 7":
                displaySceneLevel.text = "Level 7";
                break;
            case "Level 8":
                displaySceneLevel.text = "Level 8";
                break;
            case "Level 9":
                displaySceneLevel.text = "Level 9";
                break;
            default:
                displaySceneLevel.text = "Unknown";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
