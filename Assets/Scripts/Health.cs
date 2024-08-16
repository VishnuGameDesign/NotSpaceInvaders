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

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        PlayerEvents.UpdateHealth(this, _currentHealth);

        if(_currentHealth <= 0)
        {
            PlayerEvents.Dead(this);
            PlayerEvents.PlayerDeath(this);
            Destroy(this.gameObject);
        }
    }

}
