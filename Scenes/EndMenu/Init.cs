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
        string winner;
        switch(MainState.winner)
        {
            case 1:
                winner = "X";
                break;
            case 2: winner = "O";
                break;
            default:
                winner = "No One";
                break;
        }
        winnerText.text =string.Format("{0} won!!", winner);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
