using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent<Transform> OnClick = new();
}
