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
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(co.tag == "FallWall")
        {
            healthBar.SetMaxHealth(0);
        }
    }*/
}