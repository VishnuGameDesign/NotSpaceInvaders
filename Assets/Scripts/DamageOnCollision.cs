using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 10;
    
    //team to decide between player and enemy
    [SerializeField] private int _team;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryDamage(collision.gameObject);
    }

    public void TryDamage(GameObject gameObject)
    {
        if(gameObject.TryGetComponent(out Health target))
        {
            if(target.Team != this._team)
            {
                target.TakeDamage(_damageAmount);
            }
        }
    }
}
