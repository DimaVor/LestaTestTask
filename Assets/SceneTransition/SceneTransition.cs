using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loadingText;
    private Animator _animator;
    private AsyncOperation _loadSceneAsync;

    private static bool _shouldPlayOpeningAnimation = false; 

    public void SwitchToScene(string name)
    {
        _animator.SetTrigger("ClosingScene");
        _loadSceneAsync = SceneManager.LoadSceneAsync(name);
        _loadSceneAsync.allowSceneActivation = false;
    }
    public void OnSceneCLosed()
    {
        _shouldPlayOpeningAnimation = true;
        _loadSceneAsync.allowSceneActivation = true;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        if (_shouldPlayOpeningAnimation) _animator.SetTrigger("OpeningScene");
    }

    private void Update()
    { 
        if(_loadSceneAsync != null){
            _loadingText.text = "Loading.. " + Mathf.Round(_loadSceneAsync.progress * 1000) / 10 + "%";
        }        
    }    
}