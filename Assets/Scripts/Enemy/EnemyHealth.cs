using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] private EnemyStats stats;
    [SerializeField] private ScoreController scoreCont;

    private float currentHealth;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        currentHealth = stats.maxHealth;
        stats.healthBar = transform.GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	public void Damage(float damageAmt) {
        currentHealth -= damageAmt;
        audioSource.clip = stats.damagedGrunt[0];
        audioSource.Play();
        UpdateHealth();
	}

    void UpdateHealth()
    {
        if(currentHealth <= 0)
            Die();

        stats.healthBar.value = currentHealth / stats.maxHealth;
    }

    void Die()
    {
        scoreCont.UpdateScore(stats.scoreValue);
        Destroy(this.gameObject);
    }
}
