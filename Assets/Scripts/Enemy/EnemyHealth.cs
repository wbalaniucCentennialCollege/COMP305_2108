using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float maxHealth;
    public float CurrentHealth { get; set; }

    public Slider healthBar;

    // Use this for initialization
    void Start () {
        CurrentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Damage(float damageAmt) {
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
        Destroy(this.gameObject);
    }
}
