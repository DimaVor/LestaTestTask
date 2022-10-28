using System;
public class Game
{
    private readonly int _size = 5;
    private readonly Board _board;

    private bool _isSelectedItem = false;
    private Coordinate _selectedItemXY;

    public enum RequestCode
    {
        none,
        select,
        unselect,
        swipe,
        win,
    }

    public Game(int size)
    {
        _size = size;
        _board = new Board(size);
        _board.SetBoardItems();
    }
    public Type GetBoardItemAt(Coordinate xy) => _board.GetBoardItem(xy);
    public void Replay()
    {
        _isSelectedItem = false;
        _board.SetBoardItems();        
    }

    /// <summary>
    /// Основная игровая логика, RequestCode используется для связи модели с компонентами Unity
    /// </summary>   
    public RequestCode ClickAt(Coordinate xy)
    {
        Type clickedItem = GetBoardItemAt(xy);
        if (!_isSelectedItem)
        {
            if (clickedItem == typeof(Block) || clickedItem == typeof(Empty))
            {
                return RequestCode.none; //no selected Chip, click on empty or block
            }
            _isSelectedItem = true;
            _selectedItemXY = xy;
            return RequestCode.select; // sellect item
        }
        if (clickedItem == typeof(Block))
        {
            return RequestCode.none; // try to move selected item on block
        }
        if (xy.Equals(_selectedItemXY)) //unsellect item
        {
            _isSelectedItem = false;
            return RequestCode.unselect;
        }
        if (clickedItem.BaseType == typeof(Chip))
        {
            return RequestCode.none; // click on other chip
        }
        if (_board.IsOnLIne(_selectedItemXY, xy)) // move chip on empty place
        {
            _board.SetBoardItem(xy, GetBoardItemAt(_selectedItemXY));
            _board.SetBoardItem(_selectedItemXY, typeof(Empty));
            _isSelectedItem = false;
            if (CheckWin())
                return RequestCode.win;  // the last swipe was victorious
            return RequestCode.swipe; // just swipe
        }
        return RequestCode.none;  // empty place not on the line 
    }

    private bool CheckWin()
    {
        int counter = 0;
        for (int y = 0; y < _size; y++)
        {
            if (GetBoardItemAt(new Coordinate(0, y)) == typeof(FirstTypeChip))
                counter++;
            if (GetBoardItemAt(new Coordinate(2, y)) == typeof(SecondTypeChip))
                counter++;
            if (GetBoardItemAt(new Coordinate(4, y)) == typeof(ThirdTypeChip))
                counter++;
        }
        return (counter == 15);
    }
}
