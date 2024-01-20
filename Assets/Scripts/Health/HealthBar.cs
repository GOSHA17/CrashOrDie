using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] private Slider _hpBar;
    private Transform _playerCamera;

    private void OnEnable()
    {
        _healthSystem.HealthChanged += ChangeSliderValue;
    }

    private void Start()
    {
        _playerCamera = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(_playerCamera);
    }

    private void ChangeSliderValue(float value)
    {
        _hpBar.value = value;
    }

    private void OnDisable()
    {
        _healthSystem.HealthChanged -= ChangeSliderValue;
    }
}
