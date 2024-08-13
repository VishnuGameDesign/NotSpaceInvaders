using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _bulletForce;
    [SerializeField] private float _bulletLifeSpan;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        //calls a fn. with to run for a specified time
        Invoke("DestroyBullet", _bulletLifeSpan);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Vector2.up * _bulletForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
        Debug.Log(collider.gameObject);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
