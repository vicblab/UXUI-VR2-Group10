using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time = 10f;
    public float interval = 1f;
    public TMP_Text timeText;
    private Coroutine routine;

    public UnityEvent OnTimerStart;
    public UnityEvent OnTimerEnd;
    public UnityEvent OnTimerInterval;


    public void StartTimer()
    {
        if (routine == null)
        {
            OnTimerStart?.Invoke();
            routine = StartCoroutine(TimerRoutine());
            Debug.Log("StartTimer");
        }
    }
    private IEnumerator TimerRoutine()
    {
        float t = time;
        float it = 0;
        while (t > 0)
        {
            t -= Time.deltaTime;
            it += Time.deltaTime;
            if (it >= interval)
            {
                it = 0;
                OnTimerInterval?.Invoke();
                UpdateTimeText(t);
            }
            yield return null;
        }
        OnTimerEnd?.Invoke();
        routine = null;

    }
    private void UpdateTimeText(float value)
    {
        timeText.text = $"{value:F1}s";
    }
}
