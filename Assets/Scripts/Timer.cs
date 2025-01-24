using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private KeyCode _key = KeyCode.Mouse0;
    private bool _isTimerRunning;
    private float _timerInterval = 0.5f;
    private float _currentTime = 0f;

    public float CurrentTime => _currentTime;
    public event UnityAction Displayed;
    
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
        WaitForSeconds wait = new WaitForSeconds(_timerInterval);

        while (_isTimerRunning)
        {
            yield return wait;

            _currentTime += 1;

            Displayed?.Invoke();
        }
    }
}
