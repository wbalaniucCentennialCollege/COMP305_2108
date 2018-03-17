using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour {

    public State currentState;
    public EnemyData enemyData;
    public Transform eyes;
    public State sameState; // Dummy state to remain in current state;
    public LayerMask playerLayer;

    public List<Transform> waypoints;
    [HideInInspector] public EnemyAttack enemyAttack;
    [HideInInspector] public int nextWaypoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    void Start()
    {
        // waypoints = new List<Transform>();
        enemyAttack = GetComponent<EnemyAttack>();
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
