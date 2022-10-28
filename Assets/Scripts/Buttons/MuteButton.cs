using UnityEngine;
using UnityEngine.UI;

public abstract class MuteButton : MonoBehaviour
{
    [SerializeField] protected Sprite _muteSprite;
    [SerializeField] protected Sprite _unmuteSprite;

    protected bool _isMuted;
    protected Renderer _renderer;

    public void ChangeMute()
    {        
        _isMuted = !_isMuted;
        GetComponent<Image>().sprite = _isMuted ? _muteSprite : _unmuteSprite;
        MuteComponent();
    }

    protected abstract void MuteComponent();
    protected abstract void MuteCheck();

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        MuteCheck();
    }
}
