using UnityEngine;
using UnityEngine.Events;

public class LVLSystem : MonoBehaviour
{
    public event UnityAction<float, int> LVLChanged;
    public event UnityAction LVLIncreased;

    [SerializeField] private GameObject _buffEffect;
    [SerializeField] private float _levelXPNeed;

    private float _currentLevelXP;
    private int _currentLevelNum = 0;

    public void AddXP(float value)
    {
        if (value <= 0) return;

        _currentLevelXP += value;

        if (_currentLevelXP >= _levelXPNeed)
        {
            int earnedLevel = Mathf.FloorToInt(_currentLevelXP / _levelXPNeed);
            _currentLevelNum += earnedLevel;
            _currentLevelXP = _currentLevelXP % _levelXPNeed;

            for (int i = 0; i < earnedLevel; i++)
            {
                LVLIncreased?.Invoke();
                Instantiate(_buffEffect, transform);
            }
        }

        LVLChanged?.Invoke(_currentLevelXP / _levelXPNeed, _currentLevelNum);
    }
}
