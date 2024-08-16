using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming,
        ChasePlayer
    }
    private State state;
    private Vector2 _originPosition;
    private Vector2 _roamPostion;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _detectionRange;

    private GameObject player;

    private void Awake()
    {
        state = State.Roaming;
    }

    private void InitializePlayer()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        _originPosition = transform.position;
        _roamPostion = GetRandomRoamPosition();
        InitializePlayer();
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Roaming:
                RoamAround();

                float reachedPostionDistance = 1f;
                if (Vector2.Distance(transform.position, _roamPostion) < reachedPostionDistance)
                    _roamPostion = GetRandomRoamPosition();

                FindTarget();
                break;

            case State.ChasePlayer:
                MoveToPlayer();
                break;

        }
    }


    private Vector2 GetRandomRoamPosition()
    {
        var randomPosition = new Vector2(Random.Range(-1f, 0f), Random.Range(-1f, 0f)).normalized;
        var randomDistance = Random.Range(2f, 4f);

        return _originPosition + randomPosition * randomDistance;
    }

    private void RoamAround()
    {
        transform.position = Vector2.MoveTowards(transform.position, _roamPostion, _moveSpeed * Time.deltaTime);
    }

    private void MoveToPlayer()
    {
        if(player != null)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _moveSpeed * Time.deltaTime);
    }

    private void FindTarget()
    {
        if (player != null && Vector2.Distance(transform.position, player.transform.position) < _detectionRange)
        {
            state = State.ChasePlayer;
        }
    }
}
