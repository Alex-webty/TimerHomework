using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private KeyCode _key = KeyCode.Mouse0;
    private bool _isTimerRunning;
    private float _timerInterval = 0.5f;
    private float _currentTime = 0f;

    private void Update()
    {
        WorkTimer();
    }

    private void WorkTimer()
    {
        if (Input.GetKeyDown(_key))
        {
            if (_isTimerRunning)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }
    }

    private void StartTimer()
    {
        _isTimerRunning = true;

        StartCoroutine(IncreaseTime());
        Debug.Log("таймер запущен");
    }

    private void StopTimer()
    {
        _isTimerRunning = false;

        StopCoroutine(IncreaseTime());
        Debug.Log("таймер остановлен");
    }

    private IEnumerator IncreaseTime()
    {
        while (_isTimerRunning)
        {
            yield return new WaitForSeconds(_timerInterval);

            _currentTime += 1;

            Display(_currentTime);
        }
    }

    private void Display(float count)
    {
        _text.text = count.ToString("");
    }
}
