using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button b = this.GetComponent<Button>();
        b.onClick.AddListener(MainMenuManager.ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
