using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _team;
    private int _currentHealth;

    public int MaxHealth => _maxHealth; 
    public int Team => _team;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    //damage is taken upon the player's health and is passed as a parameter
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        //sends a message to update the health to the UI health bar
        PlayerEvents.UpdateHealth(this, _currentHealth);

        if(_currentHealth <= 0)
        {
            //sends a message to update the enemies kill count to the UI
            PlayerEvents.Dead(this);
            //sends a message when the player is dead 
            PlayerEvents.PlayerDeath(this);
            Destroy(this.gameObject);
        }
    }

}
