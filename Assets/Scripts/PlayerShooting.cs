using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Game Components")]
    //location of the gun point 
    [SerializeField] private Transform _bulletShotUpLoc;
    [SerializeField] private Transform _bulletShotStraightLoc;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _biggerBullet;

    [Header("Bullet adjustables")]
    [SerializeField] private float _cooldown = 0.5f;
    [SerializeField] private float _nextShootTime = 0f;
    private float _bulletSpawnDelay = 0.1f;

    private void Update()
    {
        //when pressed left mouse btn. and enough time has passed to avoid spawning multiple bullets 
        if(PlayerInputHandler.Instance.ShootUpTriggered && Time.time >= _nextShootTime)
        {
            PlayerEvents.ShootUp();
            _nextShootTime = Time.time + _cooldown;
            StartCoroutine(HandleShootingUp());
        }
        if(PlayerInputHandler.Instance.ShootStraightTriggered && Time.time >= _nextShootTime)
        {
            PlayerEvents.ShootStraight();
            _nextShootTime = Time.time + _cooldown;
            StartCoroutine(HandleShootingStraight());
        }    

    }

    private IEnumerator HandleShootingUp()
    {
        yield return new WaitForSeconds(_bulletSpawnDelay);
        Instantiate(_bullet, _bulletShotUpLoc.position, _bulletShotUpLoc.rotation);
    }
    private IEnumerator HandleShootingStraight()
    {
        yield return new WaitForSeconds(_bulletSpawnDelay);
        Instantiate(_biggerBullet, _bulletShotStraightLoc.position, _bulletShotStraightLoc.rotation);
    }
}
