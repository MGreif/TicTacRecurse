using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Init : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    // Start is called before the first frame update
    void Start()
    {
        winnerText.text = (MainState.winner == 1 ? "X" : "O") + " Won!!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
