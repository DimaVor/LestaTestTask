using UnityEngine;
public abstract class Chip : OnboardItem
{
    [SerializeField] protected Material _defaultMaterial;
    [SerializeField] protected Material _selectedMaterial;

    [SerializeField] protected AudioClip _selectedClip;
    [SerializeField] protected AudioClip _unselectedClip;
    [SerializeField] protected AudioClip _longClip;

    private ParticleSystem _selectedParticles;
    private ParticleSystem _unselectedParticles;

    private bool _isSelected = false;
    private Renderer _renderer;
    private AudioSource _audioSource;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _selectedParticles = transform.GetChild(0).GetComponent<ParticleSystem>();
        _unselectedParticles = transform.GetChild(1).GetComponent<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
    }
    public void ChangeSellect()
    {
        _isSelected = !_isSelected;
        if (_isSelected)
        {
            Select();
            return;
        }
        Unselect();
    }

    private void Select()
    {
        _renderer.material = _selectedMaterial;
        _selectedParticles.Play();
        if (_selectedClip)
            _audioSource.PlayOneShot(_selectedClip);
        _audioSource.clip = _longClip;
        _audioSource.Play();
    }
    private void Unselect()
    {
        _renderer.material = _defaultMaterial;
        _unselectedParticles.Play();
        _audioSource.clip = _unselectedClip;
        if (_unselectedClip)
            _audioSource.PlayOneShot(_unselectedClip);
    }
}
