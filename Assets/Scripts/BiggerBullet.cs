using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerBullet : Bullet
{
    protected override void OnFixedUpdate()
    {
        this._rigidbody.AddForce(Vector2.right * _bulletForce, ForceMode2D.Impulse);
    }
}
