using System.Linq;
using TMPro;
using UnityEngine;

public class ComplexGameState : GameState
{
    public int activeGame = 4;
    public int lastTouchedFieldInGame = -1;
    public SimpleGameState[] games = new SimpleGameState[9];
    public ComplexGameState(int gameId): base(gameId)
    {
        setActiveGame(activeGame);
        this.onWin = (int winner) =>
        {
            Debug.Log("BIG WIN: " + winner);
        };
    }

    public void setActiveGame(int activeGame)
    {
        this.activeGame = activeGame;
        this.validators = new IValidator[] { new ActiveGameValidator(activeGame) };
    }
    public override bool isValidated(int gameId, int id, int value)
    {
        bool validated = true;
        foreach (IValidator validator in validators)
        {
            validated &= validator.Validate(gameId, id, value);
        }

        return validated;
    }

}

public class ComplexGame : MonoBehaviour
{
    public GameObject background;
    public int gameId = 0;
    public ComplexGameState state = new ComplexGameState(0);
    public GameObject[] levels = new GameObject[9];
    public TextMeshProUGUI nextTurnText;
    void Start()
    {
        this.state = new ComplexGameState(this.gameId);
        this.state.onWin += (int winner) =>
        {
            this.background.GetComponent<SpriteRenderer>().color = this.state.gameCustomization.backgroundColorOnWin;
            MainState.winner = winner;
            MainMenuManager.LoadScene("EndMenu");
        };

        for (int i = 0; i < this.levels.Length; i++) {
            this.state.games[i] = this.levels[i].GetComponentInChildren<SecondaryGame>().state;
         }

        foreach (SimpleGameState state in this.state.games)
        {
            IValidator[] vals = new IValidator[] { new GameFinishedValidator(this.state.winner != 0), new ComplexGameStateValidator((int a, int b, int c) => this.state.isValidated(a, b, c)) };

            state.validators = vals;
            state.isMainGame = false;

            state.onValueChange += (int gameId, int id, int value) =>
            {
                this.state.setActiveGame(id);
                if (this.state.games.First(s => s.gameId == id).winner != 0)
                {
                    this.state.setActiveGame(-1);
                }
                // Update turn for each childgame
                foreach (SimpleGameState state in this.state.games)
                {
                    state.nextTurn = value == 1 ? 2 : 1;
                    state.gameOver = this.state.gameOver;
                    this.state.values[state.gameId] = state.winner;
                }
                this.state.nextTurn = value == 1 ? 2 : 1;
                this.nextTurnText.text = (value == 1 ? "O" : "X") + " is next turn!";
                this.state.CheckWin(this.state.values);
            };
        }
    }

    void Update()
    {


    }
}
