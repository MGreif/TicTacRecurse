

public class Slot
{
    public int content = 0; // 0 = empty; 1 = X; 2 = O
    private readonly int row;
    private readonly int place;
    public Slot(int row, int place)
    {
        this.content = 0;
        this.row = row;
        this.place = place;
    }

    public int getRow() { return this.row; }
    public int getPlace() { return this.place; }
    public Slot SetX()
    {
        this.content = 1;
        return this;
    }

    public Slot SetO()
    {
        this.content = 2;
        return this;
    }
    public Slot SetEmpty()
    {
        this.content = 0;
        return this;
    }
}