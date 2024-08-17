using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //state pattern for enemy behaviour 
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
        //initial state of the enemy is set to roaming
        state = State.Roaming;
    }

    private void InitializePlayer()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        _originPosition = transform.position;

        //get random position for the enemy to roam around 
        _roamPostion = GetRandomRoamPosition();
        InitializePlayer();
    }

    private void Update()
    {
        //switch case to consider between Roaming and Chasing the player
        switch (state)
        {
            default:
            case State.Roaming:
                RoamAround();

                //gets the distance from the original position of the enemy to the received random position
                float reachedPostionDistance = 1f;
                if (Vector2.Distance(_originPosition, _roamPostion) < reachedPostionDistance)
                    _roamPostion = GetRandomRoamPosition();

                //looks for the player
                FindTarget();
                break;

            case State.ChasePlayer:
                //moves towards the player
                MoveToPlayer();
                break;

        }
    }

    
    //gets random postion and random distance values
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

    //checks if the distance between the current position and the player's position is under detection range and switches the state from roaming to chasing 
    private void FindTarget()
    {
        if (player != null && Vector2.Distance(transform.position, player.transform.position) < _detectionRange)
        {
            state = State.ChasePlayer;
        }
    }
}
