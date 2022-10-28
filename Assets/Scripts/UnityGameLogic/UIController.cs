using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private GameObject _visualAdditions;
    [SerializeField] private Button _replayButton;
    [SerializeField] private TextMeshProUGUI _currentStepsText;
    [SerializeField] private TextMeshProUGUI _bestStepsText;
    [SerializeField] private TextMeshProUGUI _recordText;
    [SerializeField] private GameObject _winBackGround;

    private const float _animDuration = 2f;

    public void ShowWinAttributes(bool value)
    {
        _winBackGround.SetActive(value);
        _winText.gameObject.SetActive(value);
        _replayButton.gameObject.SetActive(false);
        if (value)
        {
            Action showButton = ShowReplayButton;
            StartCoroutine(TextColorLerp(_winText, Color.clear, _winText.color, _animDuration, showButton));
            return;
        }
        _recordText.gameObject.SetActive(value);
    }
    private void ShowReplayButton() => _replayButton.gameObject.SetActive(true);

    public void ShowRecordText(int steps)
    {
        _recordText.gameObject.SetActive(true);
        _recordText.text = "NEW RECORD\n" + steps + " STEPS!";
        StartCoroutine(TextColorLerp(_recordText, Color.clear, _recordText.color, _animDuration, null));
    }
    public void UpdateSteps(int steps) => _currentStepsText.text = "STEPS\nNOW:\n" + steps;
    public void UpdateBestSteps(int bestSteps) => _bestStepsText.text = "FEWEST\nSTEPS:\n" + bestSteps;
    public void ShowVisualAdditions(bool value) => _visualAdditions.SetActive(value);
    
    private IEnumerator TextColorLerp(TextMeshProUGUI text, Color startColor, Color finishColor, float animDuration, Action endCoroutineAction)
    {
        float t = 0;
        while (t < 1)
        {
            text.color = Color.Lerp(startColor, finishColor, t);
            t += Time.fixedDeltaTime / animDuration;
            yield return null;
        }
        if (endCoroutineAction!=null)
            endCoroutineAction.Invoke();
    }
}
