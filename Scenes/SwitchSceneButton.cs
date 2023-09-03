using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class MainMenuManager
{
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);

    }
    public static void LoadGame()
    {
        LoadScene("SimpleGame");
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}

public class SwitchSceneButton : MonoBehaviour
{
    public string sceneToStart;
    // Start is called before the first frame update
    void Start() {
        Button button = this.GetComponent<Button>();
        button.onClick.AddListener(() => MainMenuManager.LoadScene(sceneToStart));
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
