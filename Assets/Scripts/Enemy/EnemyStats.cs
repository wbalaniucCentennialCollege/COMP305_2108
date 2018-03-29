using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "PluggableAI/EnemyStats")]
public class EnemyStats : ScriptableObject {
    [Header("General Information")]
    public int scoreValue = 10;

    [Header("Audio Information")]
    public AudioClip[] generalGrunt;
    public AudioClip[] attackGrunt;
    public AudioClip[] damagedGrunt;

    [Header("Health Information")]
    public float maxHealth = 20;
    public Slider healthBar;

    [Header("State Information")]
    [Header("State - PATROL")]
    public float moveSpeed = 1;
    public float patrolSpeed = 0.5f;

    [Header("State - CHASE")]
    public float chaseRange = 5.0f;
    public float chaseSpeed = 1;

    [Header("State - ATTACK")]
    public float attackRange = 0.1f;
    public float attackRate = 1f;
    public float attackDamage = 5;
}
