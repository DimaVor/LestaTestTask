using System.Collections;
using UnityEngine;

public class SceneChangeEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private AudioClip _sound;
    [SerializeField] private AudioSource _backgroundMusic;
    
    public void PlayParticles() => Instantiate(_particles, transform.position, Quaternion.identity);    
    public void MuteMusic() => StartCoroutine(MutingMusic(_backgroundMusic.volume, 3f));    
    public void PlaySound() => GetComponent<AudioSource>().PlayOneShot(_sound);

    private IEnumerator MutingMusic(float startValue, float animDuration)
    {
        float t = 0;
        while (t < 1)
        {
            _backgroundMusic.volume = Mathf.Lerp(startValue, 0, t);
            t += Time.fixedDeltaTime / animDuration;
            yield return null;
        }
        _backgroundMusic.mute = true;
    }
}
