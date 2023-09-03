using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateForLevel : MonoBehaviour
{
    public SimpleGame game; 
    // Start is called before the first frame update
    void Awake()
    {
        this.game = this.GetComponent<SimpleGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
