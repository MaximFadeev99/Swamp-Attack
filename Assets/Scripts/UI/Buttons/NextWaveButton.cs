using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _button;

    private RectTransform _rectTransform;
    private Tween _buttonScaleTween;

    private void Awake()
    {
        float newScale = 1.1f;
        float tweenDuration = 1f;

        _rectTransform = _button.GetComponent<RectTransform>();
        _buttonScaleTween = _rectTransform.DOScale(newScale, tweenDuration)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnEnable()
    {       
        _spawner.WaveEnded += OnWaveEnded;
        _button.onClick.AddListener(ReleaseNextWave);
        _buttonScaleTween.Play();
    }

    private void OnDisable()
    {
        _spawner.WaveEnded -= OnWaveEnded;
        _button.onClick?.RemoveListener(ReleaseNextWave);
        _buttonScaleTween.Kill();
    }

    private void Start()
    {
        _button.gameObject.SetActive(false);
    }

    private void OnWaveEnded() 
    {
        _button.gameObject.SetActive(true);
    }

    private void ReleaseNextWave() 
    {
        _spawner.TrySetNextWave();
        _button.gameObject.SetActive(false);
    }   
}