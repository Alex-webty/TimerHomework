using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.Displayed += Display;
    }

    private void OnDisable()
    {
        _timer.Displayed -= Display;
    }

    public void Display()
    {
        float currentTime = _timer.CurrentTime;

        _text.text = currentTime.ToString("");
    }
}
