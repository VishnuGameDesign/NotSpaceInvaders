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
        //sets the min and max based on players health values (100)
        _healthBarSlider.minValue = 0;
        _healthBarSlider.maxValue = _playerHealth.MaxHealth;
        //sets the slider value corressponding to the players max health
        _healthBarSlider.value = _playerHealth.MaxHealth;

        //susbcribes to health updates and adjusts the health bar slider
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
