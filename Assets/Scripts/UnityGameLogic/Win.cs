using UnityEngine;

public class Win : MonoBehaviour
{
    private UIController _uiController;
    [SerializeField] private ParticleSystem _winParticles;
    [SerializeField] private AudioClip _winSounds;
    private AudioSource _audioSource;
    private void Start()
    {
        _uiController = GetComponent<UIController>();
        _audioSource = GetComponent<AudioSource>();
    }
    public void WinEffects(int steps)
    {
        GetComponent<MouseInput>().SetClick(false);
        _uiController.ShowWinAttributes(true);
        if (steps != -1)
        {
            _uiController.ShowRecordText(steps);
            _uiController.UpdateBestSteps(steps);
        }
        ParticleSystem particles = Instantiate(_winParticles, new Vector3(0, 9, -2), Quaternion.Euler(90, 0, 0));
        particles.Play();
        _audioSource.PlayOneShot(_winSounds);
    }
}
