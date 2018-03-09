using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float maxHealth;
    public float CurrentHealth { get; set; }
    public Slider healthBar;

    public int scoreValue = 10; // 10 Points
    public ScoreController scoreCont;

    // Use this for initialization
    void Start () {
        CurrentHealth = maxHealth;
	}
	
	// Update is called once per frame
	public void Damage(float damageAmt) {
        CurrentHealth -= damageAmt;
        UpdateHealth();
	}

    void UpdateHealth()
    {
        if(CurrentHealth <= 0)
            Die();

        healthBar.value = CurrentHealth / maxHealth;
    }

    void Die()
    {
        scoreCont.UpdateScore(scoreValue);
        Destroy(this.gameObject);
    }
}
