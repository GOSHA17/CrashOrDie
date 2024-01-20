using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    public event UnityAction<float> HealthChanged;
    public event UnityAction Hitted;
    public event UnityAction Healed;
    public event UnityAction Died;

    [SerializeField] private float _maxHealth;
    [SerializeField] private GameObject _healEffect;
    [SerializeField] private GameObject _hitEffect;
    private float _currentHealth;

    private void Start()
    {
        SetMaxHealth();
    }

    public void ChangeHealth(float value)
    {
        if (value == 0) return;

        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealth/_maxHealth);

        if (value > 0)
        {
            Healed?.Invoke();
            Instantiate(_healEffect, transform);
        }
        else
        {
            Hitted?.Invoke();
            Instantiate(_hitEffect, transform);
        }

        if (_currentHealth == 0)
        {
            Died?.Invoke();
        }
    }

    private void SetMaxHealth()
    {
        _currentHealth = _maxHealth;
    }
}
