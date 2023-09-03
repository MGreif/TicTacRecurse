
using UnityEngine;

public class GameCustomization
{
    public Color backgroundColor = Color.white;
    public Color backgroundColorOnWin = Color.red;

    public Color fontColor = Color.green;
    public GameCustomization(Color backgroundColor, Color backgroundColorOnWin, Color fontColor)
    {
        this.backgroundColor = backgroundColor;
        this.backgroundColorOnWin = backgroundColorOnWin;
        this.fontColor = fontColor;
    }
    public GameCustomization()
    {

    }
}

public delegate void onWinDelegate(int winner);
public delegate void onValueChangeDelegate(int gameId, int id, int value);
public abstract class GameState
{
    public IValidator[] validators = new IValidator[0];
    public int[] values = new int[9];
    public bool gameOver = false;
    public GameCustomization gameCustomization = new GameCustomization();

    public int winner = 0;
    public int nextTurn = 1; // X
    public int gameId;
    public bool isMainGame = false;

    public onWinDelegate onWin;
    public onValueChangeDelegate onValueChange;

    public GameState(int gameId) {
        this.gameId = gameId;
        this.onValueChange += (int gameId, int id, int value) =>
        {
            this.values[id] = value;
            this.winner = CheckWin(this.values);
        };
    }
    public abstract bool isValidated(int gameId, int id, int value);

    public int toggleTurn()
    {
        int oldTurn = this.nextTurn;
        int nextTurn;
        if (this.nextTurn == 1)
        {
            nextTurn = 2;
        } else
        {
            nextTurn = 1;
        }
        this.nextTurn = nextTurn;
        return oldTurn;
    }

    public bool requestValueChange(int id, int value)
    {
        if (winner != 0 || gameOver)
        {
            return false;
        };
        if (!isValidated(this.gameId, id, value))
        {
            return false;
        };

        this.onValueChange(this.gameId, id, value);
        return true;
    }

    public int CheckWin(int[] values)
    {

        int[,] winPatterns = new int[,]
        {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8},
            {0, 3, 6},
            {1, 4, 7},
            {2, 5, 8},
            {0, 4, 8},
            {2, 4, 6}
        };

        for (int i = 0; i < winPatterns.GetLength(0); i++)
        {
            int a = winPatterns[i, 0];
            int b = winPatterns[i, 1];
            int c = winPatterns[i, 2];

            if (values[a] != 0 && values[a] == values[b] && values[a] == values[c])
            {
                this.gameOver = true;
                this.winner = values[a];
                onWin(values[a]);
                return values[a]; // Return the player who won (1 for X, 2 for O)
            }
        }

        return 0;
    }

}


public class SimpleGameState : GameState
{
    public SimpleGameState(int gameId): base(gameId)
    { 
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


public abstract class Game: MonoBehaviour
{
    public int id = 0;

    public GameObject background;
    public SimpleGameState state = new SimpleGameState(0);
    public abstract void initialize();

}


public class SimpleGame: Game
{
    public override void initialize()
    {
        this.state = new SimpleGameState(this.id);
        this.state.isMainGame = true;
        this.state.onWin += (int winner) =>
        {
            this.background.GetComponent<SpriteRenderer>().color = this.state.gameCustomization.backgroundColorOnWin;
        };
        this.state.onWin += (int winner) =>
        {
            if (!this.state.isMainGame) return;
            MainState.winner = winner;
            MainMenuManager.LoadScene("EndMenu");
        };
    }
    void Start()
    {
        initialize();
    }

    // Update is called once per frame
    void Update()
    {


    }
}
