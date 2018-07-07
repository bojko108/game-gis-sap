using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealthScript : MonoBehaviour
{
    [Tooltip("Tank health when the game starts")]
    public int StartingHealth = 200;

    private int currentHealth;
    
    [Tooltip("Reference to health slider - will display current health level")]
    public Slider HealthSlider;

    private bool isDead = false;
    
    private void Awake()
    {
        this.currentHealth = this.StartingHealth;

        this.HealthSlider.maxValue = this.StartingHealth;
        this.HealthSlider.minValue = 0;
        this.HealthSlider.value = this.currentHealth;
    }
    
    public void TakeDamage(int amount)
    {
        this.currentHealth -= amount;
        this.HealthSlider.value = this.currentHealth;

        if (this.currentHealth <= 0 && this.isDead == false)
        {
            this.Dead();
        }
    }
    
    private void Dead()
    {
        this.isDead = true;

        EventManager.Emit(Resources.Events.PlayerDead);

        // play explosion

        Destroy(this.gameObject, 2f);
    }
}
