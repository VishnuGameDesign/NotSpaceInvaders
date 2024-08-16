using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigidbody;
    [SerializeField] protected float _bulletForce;
    [SerializeField] protected float _bulletLifeSpan;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        //calls a fn. to run for a specified time
        Invoke("DestroyBullet", _bulletLifeSpan);
    }
    
    private void FixedUpdate()
    {
        OnFixedUpdate();
    }

    protected virtual void OnFixedUpdate()
    {
        _rigidbody.AddForce(transform.up * _bulletForce, ForceMode2D.Impulse);

    }

    protected void OnCollisionEnter2D()
    {
        Destroy(this.gameObject);
    }

    protected void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
