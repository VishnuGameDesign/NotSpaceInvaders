using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BiggerBullet : Bullet
{

    protected override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        _rigidbody.AddForce(transform.right * _bulletForce, ForceMode2D.Impulse);
    }

    
}
