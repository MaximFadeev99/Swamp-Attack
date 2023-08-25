using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public abstract class Bar : MonoBehaviour
{
    protected Slider Slider;

    private Coroutine _runningCoroutine;

    private void Awake()
    {
       Slider = GetComponent<Slider>(); 
    }

    protected virtual void ChangeValue(float newValue) 
    {
        if (_runningCoroutine != null)
            StopCoroutine(_runningCoroutine);

        _runningCoroutine = StartCoroutine(ChangeGradually(newValue));
    }

    private IEnumerator ChangeGradually(float newValue) 
    {
        while (Slider.value != newValue) 
        {
            Slider.value = Mathf.Lerp(Slider.value, newValue, 0.1f);
            yield return null;
        }           
    }
}
