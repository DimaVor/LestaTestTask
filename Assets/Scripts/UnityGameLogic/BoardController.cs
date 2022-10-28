using System;
using System.Collections;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    private const int _size = 5;
    private Game _game;
    private Transform _selectedChip;
    [SerializeField] private GameObject _board;

    private UIController _uiController;
    private MouseInput _mouseInput;
    private BoardItemSpawner _itemSpawner;
    private StepsController _stepsController;

    private void Start()
    {
        _stepsController = new StepsController();
        _uiController = GetComponent<UIController>();
        _mouseInput = GetComponent<MouseInput>();
        _itemSpawner = GetComponent<BoardItemSpawner>();
        EventManager.OnClick.AddListener(Click);

        _game = new Game(_size);
        DrawBoardElements();
    }

    public void DrawBoardElements()
    {
        for (int y = 0; y < _size; y++)
        {
            for (int x = 0; x < _size; x++)
            {
                _itemSpawner.CreateItem(_game.GetBoardItemAt(new Coordinate(x, y)), BoardToWorldPosition(new Coordinate(x, y)));
            }
        }
        _uiController.ShowVisualAdditions(true);
    }

    private void ClearBoard()
    {
        for (int i = 0; i < _board.transform.childCount; i++)
            Destroy(_board.transform.GetChild(i).gameObject);
    }

    public void Replay()
    {
        _uiController.ShowWinAttributes(false);
        _uiController.ShowVisualAdditions(false);
        _uiController.UpdateSteps(0);
        ClearBoard();
        _selectedChip = null;
        _stepsController.ResetSteps();

        _game.Replay();
        DrawBoardElements();
        _mouseInput.SetClick(true);
    }

    
    /// <summary>
    /// Прослойка между моделью и Unity, принимает RequestCode'ы 
    /// </summary>
    public void Click(Transform item)
    {
        Game.RequestCode code = _game.ClickAt(WorldToBoardPosition(item.localPosition));
        if (code == Game.RequestCode.select)
        {
            _selectedChip = item;
            _selectedChip.GetComponent<Chip>().ChangeSellect();
        }
        if (code == Game.RequestCode.unselect)
        {
            _selectedChip.GetComponent<Chip>().ChangeSellect();
            _selectedChip = null;
        }
        if (code == Game.RequestCode.win)
        {
            Swipe(item, true);
            return;
        }
        if (code == Game.RequestCode.swipe)
            Swipe(item, false);
    }
    private void Swipe(Transform empty, bool isLastSwipe)
    {
        _uiController.UpdateSteps(_stepsController.Step((int)MathF.Abs((empty.localPosition - _selectedChip.localPosition).magnitude)));
        StartCoroutine(SwipeAnimation(_selectedChip, empty.position, isLastSwipe));
        empty.position = _selectedChip.position;

    }
    private void Win() => GetComponent<Win>().WinEffects(_stepsController.IsCurrentLess() ? _stepsController.GetBestSteps() : -1);
    
    private IEnumerator SwipeAnimation(Transform chip, Vector2 target, bool isLastSwipe)
    {
        _mouseInput.SetClick(false);
        Vector2 startPosition = chip.position;
        float t = 0;
        const float animDuration = .4f;
        while (t < 1)
        {
            chip.position = Vector2.Lerp(startPosition, target, t);
            t += Time.fixedDeltaTime / animDuration;
            yield return null;
        }
        chip.position = target;
        _mouseInput.SetClick(true);
        _selectedChip.GetComponent<Chip>().ChangeSellect();
        _selectedChip = null;
        if (isLastSwipe)
            Win();
    }

    private Coordinate WorldToBoardPosition(Vector2 xy) => new((int)(xy.x + 2), (int)(-xy.y + 2));
    private Vector2 BoardToWorldPosition(Coordinate xy) => new(xy.x - 2, -xy.y + 2);
}
