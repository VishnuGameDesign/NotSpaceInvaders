using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Game Components")]
    //location of the gun point 
    [SerializeField] private Transform _gunHolderLocation;
    [SerializeField] private GameObject _bullet;

    [Header("Bullet adjustables")]
    [SerializeField] private float _cooldown = 0.5f;
    [SerializeField] private float _nextShootTime = 0f;
    private float _bulletSpawnDelay = 0.1f;

    private void Update()
    {
        //when pressed left mouse btn. and enough time has passed to avoid spawning multiple bullets 
        if(PlayerInputHandler.Instance.ShootUpTriggered && Time.time >= _nextShootTime)
        {
            PlayerEvents.Shoot();
            _nextShootTime = Time.time + _cooldown;
            StartCoroutine(HandleShooting());
        }

    }

    private IEnumerator HandleShooting()
    {
        yield return new WaitForSeconds(_bulletSpawnDelay);
        Instantiate(_bullet, _gunHolderLocation.position, _gunHolderLocation.rotation);
    }
}
