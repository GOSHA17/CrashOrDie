using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    [Header("Systems")]
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] private LVLSystem _lvlSystem;

    [Header("HealthUI")]
    [SerializeField] private Image _healthBar;

    [Header("LevelUI")]
    [SerializeField] private Image _levelBar;
    [SerializeField] private Text _levelText;

    private void Start()
    {
        _healthSystem.HealthChanged += UpdateHealthBar;
        _lvlSystem.LVLChanged += UpdateLevelBar;
    }

    private void UpdateHealthBar(float value)
    {
        _healthBar.fillAmount = value;
    }

    private void UpdateLevelBar(float value, int lvlNum)
    {
        _levelBar.fillAmount = value;
        _levelText.text = lvlNum.ToString();
    }

    private void OnDisable()
    {
        _healthSystem.HealthChanged -= UpdateHealthBar;
        _lvlSystem.LVLChanged -= UpdateLevelBar;
    }
}
