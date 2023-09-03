using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{
    public string playedScene = "RecurseGame";
    // Start is called before the first frame update
    void Start()
    {
        MainState.playedScene = playedScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
