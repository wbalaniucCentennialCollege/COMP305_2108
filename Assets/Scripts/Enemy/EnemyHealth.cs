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

    public AudioClip damageAudio;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        CurrentHealth = maxHealth;
	}
	
	// Update is called once per frame
	public void Damage(float damageAmt) {
        CurrentHealth -= damageAmt;
        audioSource.clip = damageAudio;
        audioSource.Play();
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
