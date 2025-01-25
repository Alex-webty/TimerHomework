using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private KeyCode _key = KeyCode.Mouse0;
    private bool _isRunning;
    private float _interval = 0.5f;
    private float _currentTime = 0f;
    private Coroutine _coroutine;

    public event UnityAction Displayed;
    public float CurrentTime => _currentTime;
    
    
    private void Update()
    {
        WorkTimer();
    }

    private void WorkTimer()
    {
        if (Input.GetKeyDown(_key))
        {
            if (_isRunning)
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
        _isRunning = true;

        _coroutine = StartCoroutine(IncreaseTime());
        Debug.Log("таймер запущен");
    }

    private void StopTimer()
    {
        _isRunning = false;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            Debug.Log("таймер остановлен");
        }
    }

    private IEnumerator IncreaseTime()
    {
        WaitForSeconds wait = new WaitForSeconds(_interval);

        while (_isRunning)
        {
            yield return wait;

            _currentTime += 1;

            Displayed?.Invoke();
        }
    }
}
