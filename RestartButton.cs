using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button button = this.GetComponent<Button>();
        button.onClick.AddListener(() => MainMenuManager.LoadScene(MainState.playedScene));
    }


    // Update is called once per frame
    void Update()
    {

    }
}
