using System.Collections;
using UnityEngine;

public class Block : OnboardItem
{
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private GameObject _warningPrefab;
    private AudioSource _audioSource;

    private void Start() => _audioSource = GetComponent<AudioSource>(); 

    public override void OnClick() 
    {
        EventManager.OnClick.Invoke(transform);
        _audioSource.PlayOneShot(_clickSound);
        StartCoroutine(Warning());
    }

    private IEnumerator Warning()
    {
        GameObject warning = Instantiate(_warningPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.7f);
        Destroy(warning);
    }
}