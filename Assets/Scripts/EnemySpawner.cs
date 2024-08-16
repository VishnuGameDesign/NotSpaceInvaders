using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private float _xLoc;
    private float _yLoc;
    private int _enemyCount;

    void Start()
    {
        _enemyCount = 0;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        
        while (_enemyCount < 10)
        {
            _xLoc = UnityEngine.Random.Range(-8f, 8f);
            _yLoc = UnityEngine.Random.Range(4f, 0f);
            if(_enemy != null)
            {
                Instantiate(_enemy, new Vector2(_xLoc,_yLoc), Quaternion.identity);
            }
            else
            {
                break;
            }

            yield return new WaitForSeconds(0.5f);
            _enemyCount++;
        }
    }
}
