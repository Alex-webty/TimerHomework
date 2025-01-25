using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _stopwatch;

    private void OnEnable()
    {
        _stopwatch.Displayed += Display;
    }

    private void OnDisable()
    {
        _stopwatch.Displayed -= Display;
    }

    public void Display(float count)
    {
        float currentCount = _stopwatch.CurrentTime;

        _text.text = currentCount.ToString("");
    }
}
