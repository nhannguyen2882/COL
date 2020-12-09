using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    public CharacterController2D controller;

    private float horizontalMove = 0f;
    public float speed = 30f;
    private bool jump = false;

    public int maxHealth = 100;
    int currentHealt;

    public HealthBar healthBar;

    public Rigidbody2D rb;
    void Start()
    {
        currentHealt = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetButtonDown("Jump")){
            jump = true;
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed * 1.5f;
            Debug.Log("Is moving");
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

        if(rb.position.y < -10f || currentHealt <= 0)
        {
            RestartMenu.isDead = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "enemy")
        {
            currentHealt -= 5;
            healthBar.SetHealth(currentHealt);
        }
    }

}