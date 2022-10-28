public struct Coordinate
{
    public int x;
    public int y;
    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool IsOnBoard(int size)
    {
        return !(x < 0 || x > size - 1 || y < 0 || y > size - 1);
    }
}