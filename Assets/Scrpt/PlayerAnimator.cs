using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anima;
    private int status;
    private bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0)
        {
            status = 1;
            //anima.SetInteger("status", 1);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //anima.SetInteger("status", 4);
                status = 4;
                if (Input.GetKey(KeyCode.Space))
                {
                    //anima.SetInteger("status", 2);
                    status = 2;
                    jump = true;
                }
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    //anima.SetInteger("status", 3);
                    status = 3;
                }

            }

            if (Input.GetKey(KeyCode.Space))
            {
                //anima.SetInteger("status", 2);
                status = 2;
                jump = true;
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //anima.SetInteger("status", 3);
                status = 3;
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            //anima.SetInteger("status", 2);
            status = 2;
            jump = true;
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            //anima.SetInteger("status", 3);
            status = 3;
        }
        else
        {
            //anima.SetInteger("status", 0);
            status = 0;
        }
    }

    private void FixedUpdate()
    {
        anima.SetInteger("status", status);
        jump = false;
    }
}