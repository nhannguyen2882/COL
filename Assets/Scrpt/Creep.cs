using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealt;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealt = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;
        animator.SetTrigger("Hit");
        healthBar.SetHealth(currentHealt);

        if(currentHealt <= 0)
        {
            healthBar.SetHealth(0);
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
        animator.SetBool("isDead",true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
