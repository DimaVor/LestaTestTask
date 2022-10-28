using UnityEngine;
public abstract class OnboardItem : MonoBehaviour, IClickable
{
    public virtual void OnClick() => EventManager.OnClick.Invoke(transform);  
}

public interface IClickable
{
    public void OnClick();
}