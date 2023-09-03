using System.Collections;
using TMPro;
using UnityEngine;


public class SlotGameobject : MonoBehaviour
{
    public Slot slot;
    public int row, col;
    public TextMeshProUGUI text;
    public Game game;
    public int id = 0;
    public GameObject Cross;
    public GameObject Circle;
    private bool isHovered = false; 

    // Start is called before the first frame update
    void Start()
    {
        this.slot = new Slot(row, col);
        this.text = this.GetComponent<TextMeshProUGUI>();
        this.Cross = this.transform.GetChild(0).gameObject;
        this.Circle = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (slot.content == 0 && isHovered) return;
        if (this.slot.content == 0)
        {
            Cross.SetActive(false);
            Circle.SetActive(false);
        }
        else if(this.slot.content == 1)
        {
            Cross.SetActive(true);
            Circle.SetActive(false);

        }
        else if (this.slot.content == 2)
        {
            Circle.SetActive(true);
            Cross.SetActive(false);
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
        this.OnMouseExit();
        isHovered = false;
        if (isValidated)
        {
            toggleContent();
        }
    }

    public void OnMouseOver()
    {
        isHovered = true && this.slot.content == 0;
        if (this.slot.content != 0) return;
        Cross.SetActive(false);
        Circle.SetActive(false);
        if (this.game.state.nextTurn == 1) 
        {
            Cross.SetActive(true);
            Color c = Cross.GetComponent<SpriteRenderer>().color;
            c.a = 0.5f;
            Cross.GetComponent<SpriteRenderer>().color = c;
        }
        if (this.game.state.nextTurn == 2)
        {
            Circle.SetActive(true);
            Color c = Circle.GetComponent<SpriteRenderer>().color;
            c.a = 0.5f;
            Circle.GetComponent<SpriteRenderer>().color = c;
        }
    }
    public void OnMouseExit()
    {
        isHovered = false;
        Cross.GetComponent<SpriteRenderer>().color = game.state.gameCustomization.fontColor;
        Circle.GetComponent<SpriteRenderer>().color = game.state.gameCustomization.fontColor;
    }
}
