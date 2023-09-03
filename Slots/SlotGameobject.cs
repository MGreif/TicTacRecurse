using TMPro;
using UnityEngine;


public class SlotGameobject : MonoBehaviour
{
    public Slot slot;
    public int row, col;
    public TextMeshProUGUI text;
    public Game game;
    public int id = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.slot = new Slot(row, col);
        this.text = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.slot.content == 0)
        {
            this.text.text = "?";
        } else if(this.slot.content == 1)
        {
            this.text.text = "X";
        }
        else if (this.slot.content == 2)
        {
            this.text.text = "O";
        }
    }

    public int getNextTurn(int currentTurn)
    {
        return currentTurn == 1 ? 2 : 1;
    }
    public void toggleContent()
    {
        if (!this.game.state.isMainGame)
        {
            this.slot.content = getNextTurn(this.game.state.nextTurn);
        } else
        {
            this.slot.content = this.game.state.toggleTurn();
        }
    }
    public void OnMouseDown()
    {
        if (this.slot.content != 0) return;
        bool isValidated = game.state.requestValueChange(id, game.state.nextTurn);
        if (isValidated)
        {
            toggleContent();
        }
    }
}
