public class StepsController
{
    private int _bestSteps = -1;
    private int _currentSteps = 0;    

    public int Step(int steps) => _currentSteps+=steps;
    public void ResetSteps() => _currentSteps = 0;
    public bool IsCurrentLess()
    {
        if (_bestSteps == -1)
            return true;
        return _currentSteps < _bestSteps;
    }
    public int GetBestSteps()
    {
        _bestSteps = _currentSteps;
        return _bestSteps;
    }
    public int GetSteps() => _currentSteps; 
}
