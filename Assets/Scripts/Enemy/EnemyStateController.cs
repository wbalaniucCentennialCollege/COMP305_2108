using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour {
    [Header("Enemy Stats")]
    public EnemyStats stats;

    [Header("State Information")]
    public State currentState;
    public State sameState; // Dummy state to remain in current state;

    [Header("Movement Information")]
    public Transform eyes;
    public LayerMask playerLayer;
    public List<Transform> waypoints;

    [HideInInspector] public EnemyAttack enemyAttack;
    [HideInInspector] public EnemyMovementController enemyMovementController;
    [HideInInspector] public int nextWaypoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    void Start()
    {
        // waypoints = new List<Transform>();
        enemyAttack = GetComponent<EnemyAttack>();
        enemyMovementController = GetComponent<EnemyMovementController>();
        currentState.InitState(this);
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    public void TransitionToState(State nextState)
    {
        if(nextState != sameState)
        {
            currentState = nextState;

            // Initialize state
            currentState.InitState(this);
        }
    }

    public bool CheckIfCountdownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    void OnDrawGizmos()
    {
        if(eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColour;
            Gizmos.DrawWireSphere(eyes.position, 0.2f);
        }
    }
}
