using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public class Creep : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealt;

    public HealthBar healthBar;
    public int creepScore;
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
            scoreText.score += creepScore;
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead",true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Onstay");
        healthBar.SetMaxHealth(0);
       
    }*/

}
