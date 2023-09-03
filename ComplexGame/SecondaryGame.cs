
using UnityEngine;

public class SecondaryGame : Game
{
    public override void initialize()
    {
        this.state = new SimpleGameState(this.id);
        this.state.onWin += (int winner) =>
        {
            this.background.GetComponent<SpriteRenderer>().color = this.state.gameCustomization.backgroundColorOnWin;
        };
    }

    void Awake()
    {
        initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.state.isActive)
        {
            this.background.GetComponent<SpriteRenderer>().color = Color.white;
        } else
        {
            this.background.GetComponent<SpriteRenderer>().color = Color.black;

        }
    }
}
