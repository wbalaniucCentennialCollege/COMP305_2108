using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/EnemyStats")]
public class EnemyData : ScriptableObject {
    public float moveSpeed = 1;
    public float lookRange = 10f;

    public float patrolSpeed = 0.5f;

    public float chaseRange = 5.0f;
    public float chaseSpeed = 1;

    public float attackRange = 0.1f;
    public float attackRate = 1f;
    public float attackDamage = 5;
}
