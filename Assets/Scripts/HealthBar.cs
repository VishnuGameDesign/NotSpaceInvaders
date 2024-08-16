using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _healthBarSlider;
    [SerializeField] private Health _playerHealth;
    void Start()
    {
        _healthBarSlider = GetComponent<Slider>();
        _healthBarSlider.minValue = 0;
        _healthBarSlider.maxValue = _playerHealth.MaxHealth;
        _healthBarSlider.value = _playerHealth.MaxHealth;

        PlayerEvents.OnHealthUpdated += DisplayHealth;
    }

    private void DisplayHealth(Health health, int currentHealth)
    {
        if(health == _playerHealth)
        {
            _healthBarSlider.value = currentHealth;
        }
    }
}
