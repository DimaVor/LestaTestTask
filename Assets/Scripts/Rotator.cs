using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float _moveValue = 0f;

    private readonly float _speed = .5f;
    private readonly float _radius = 3f;

    private readonly float _defaultX = 0;
    private readonly float _defaultY = 0f;

    private readonly int _phases = 9;
    [SerializeField] private int _phase;
    private void Round()
    {
        _moveValue += Time.fixedDeltaTime * _speed;
        float radius = _radius + Mathf.PingPong(_moveValue / 4, 1f);
        var x = Mathf.Sin(_moveValue + _phase * 2 * Mathf.PI / _phases) * radius + _defaultX;
        var y = Mathf.Cos(_moveValue + _phase * 2 * Mathf.PI / _phases) * radius + _defaultY;
        transform.position = new Vector3(x, y, 0);
    }

    private void FixedUpdate() => Round();   
}