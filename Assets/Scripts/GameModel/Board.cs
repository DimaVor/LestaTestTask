using System;

struct Board
{
    private readonly int _size;
    readonly Type[,] _board;

    public Board(int size)
    {
        _size = size;
        _board = new Type[size, size];
    }
    public void SetBoardItem(Coordinate xy, Type itemType)
    {
        if (xy.IsOnBoard(_size))
            _board[xy.x, xy.y] = itemType;
    }
    public Type GetBoardItem(Coordinate xy)
    {
        if (xy.IsOnBoard(_size))
            return _board[xy.x, xy.y];
        return null;
    }
    public void SetBoardItems()
    {
        SetEmpties();
        SetBlocks();
        SetChips();
    }
    private void SetEmpties()
    {
        for (int y = 0; y < _size; y++)
        {
            for (int x = 0; x < _size; x++)
            {
                _board[x, y] = typeof(Empty);
            }
        }
    }
    private void SetBlocks()
    {
        for (int y = 0; y < _size; y += 2)
        {
            for (int x = 1; x < _size; x += 2)
            {
                _board[x, y] = typeof(Block);
            }
        }
    }
    /// <summary>
    /// Элементы расставляются на доступные позиции случайным образом, но не более 3х в свой столбец, и не больше 5 каждого вида 
    /// </summary>
    private void SetChips()
    {
        Random rnd = new();
        int[] count = new int[] { 0, 0, 0 };
        Type[] chipsTypes = new Type[] { typeof(FirstTypeChip), typeof(SecondTypeChip), typeof(ThirdTypeChip) };
        for (int y = 0; y < _size; y++)
        {
            for (int x = 0; x < _size; x += 2)
            {
                bool isSet = false;
                while (!isSet)
                {
                    int index = rnd.Next(3);
                    if (count[index] < 5)
                    {
                        count[index]++;
                        isSet = true;
                        _board[x, y] = chipsTypes[index];
                    }
                }
            }
        }
        if (!CollectionCheck())
            SetChips();
    }
    private bool CollectionCheck()
    {
        int[] counter = new int[] { 0, 0, 0 };
        for (int y = 0; y < _size; y++)
        {
            if (_board[0, y] == typeof(FirstTypeChip))
                counter[0]++;
            if (_board[2, y] == typeof(SecondTypeChip))
                counter[1]++;
            if (_board[4, y] == typeof(ThirdTypeChip))
                counter[2]++;
        }
        foreach (int c in counter)
        {
            if (c >= 4)
                return false;
        }
        return true;
    }    

    /// <summary>
    /// Проверяется, находятся ли два элемента на одной линии и свободны ли поля между ними,
    /// тернарные операторы использованы ради избежания повторения кода
    /// </summary>
    public bool IsOnLIne(Coordinate first, Coordinate second)
    {
        if (first.x == second.x)
            return IsOnLine(true, first, second);
        if (first.y == second.y)
            return IsOnLine(false, first, second);
        return false;
    }

    private bool IsOnLine(bool isXAxis, Coordinate first, Coordinate second)
    {
        int count = 0;
        for (int i = isXAxis ? Math.Min(first.y, second.y) + 1 : Math.Min(first.x, second.x) + 1;
            i < (isXAxis ? Math.Max(first.y, second.y) : Math.Max(first.x, second.x)); i++)
            if (_board[isXAxis ? first.x : i, isXAxis ? i : first.y] == typeof(Empty)) count++;
        return (count == (isXAxis ? (Math.Abs(first.y - second.y) - 1) : (Math.Abs(first.x - second.x) - 1)));
    }
}