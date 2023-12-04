using UnityEngine;

public class Healthbar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeValue;
    }

    private void Start()
    {
        Slider.maxValue = _player.CurrentHealth;
        Slider.value = Slider.maxValue;
    }
}