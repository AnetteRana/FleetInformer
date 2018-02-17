using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour
{
    public int health;

    static public float minForwardSpeed;
    public float currentForwardSpeed = minForwardSpeed;
    public float maxForwardSpeed;

    public float maxTurnSpeed;
    public float curTurnSpeed;

    // engine lights
    public GameObject left;
    public GameObject right;
    public GameObject left0;
    public GameObject right0;
    public GameObject forward;

    private Rigidbody2D rb2d;

    private Vector3 startposition = new Vector3(0, 0, 0);

    //////////////////////////////////////////////

    void Forward()
    {
        float moveV = Input.GetAxis("Vertical");

        //forward movement
        transform.Translate((Mathf.Exp(currentForwardSpeed) - 1) * Vector3.up * Time.deltaTime, Space.Self);
        // pressing forward
        if (moveV > 0)
        {
            // forward
            //transform.Translate(currentForwardSpeed * Vector3.up * Time.deltaTime, Space.Self);
            forward.GetComponent<Renderer>().enabled = true;

            // accelerate
            if (currentForwardSpeed < maxForwardSpeed)
            {
                currentForwardSpeed = (currentForwardSpeed + 0.02f);
            }
        }
        // pressing backward
        else if (moveV < 0)
        {
            // break
            //transform.Translate((currentForwardSpeed) * Vector3.up * Time.deltaTime, Space.Self);
            forward.GetComponent<Renderer>().enabled = false;
            currentForwardSpeed = (currentForwardSpeed - 0.02f);
        }
        else
        {
            forward.GetComponent<Renderer>().enabled = false;

            if (currentForwardSpeed > minForwardSpeed)
            {
                currentForwardSpeed = (currentForwardSpeed - 0.02f);
            }
        }
    }

    void Turning()
    {
        float moveH = Input.GetAxis("Horizontal");

        // D
        if (moveH > 0)
        {
            // visual
            right.GetComponent<Renderer>().enabled = true;
            right0.GetComponent<Renderer>().enabled = true;
            left.GetComponent<Renderer>().enabled = false;
            left0.GetComponent<Renderer>().enabled = false;

            // right (negative speed)
            if (curTurnSpeed < maxTurnSpeed)
            {
                curTurnSpeed = curTurnSpeed + 0.03f; ;
            }
        }
        // A
        else if (moveH < 0)
        {
            // visual
            left.GetComponent<Renderer>().enabled = true;
            left0.GetComponent<Renderer>().enabled = true;
            right.GetComponent<Renderer>().enabled = false;
            right0.GetComponent<Renderer>().enabled = false;

            // left (positive)
            if (curTurnSpeed > -maxTurnSpeed)
            {
                curTurnSpeed = curTurnSpeed - 0.03f;
            }
        }
        else
        {
            //visual
            right.GetComponent<Renderer>().enabled = false;
            right0.GetComponent<Renderer>().enabled = false;
            left.GetComponent<Renderer>().enabled = false;
            left0.GetComponent<Renderer>().enabled = false;

            // slow down turn
            if (curTurnSpeed > 0)
            {
                curTurnSpeed = curTurnSpeed - (curTurnSpeed / 40);
            }
            else if (curTurnSpeed < 0)
            {
                curTurnSpeed = curTurnSpeed - (curTurnSpeed / 40);
            }

        }

        float test = 0;
        if (curTurnSpeed < 0)
        {
            test = (curTurnSpeed * curTurnSpeed* curTurnSpeed);
        }
        else if (curTurnSpeed > 0)
        {
            test = (curTurnSpeed* curTurnSpeed* curTurnSpeed);
        }

        transform.Rotate(0, 0, -test);
        print(test);
    }

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        //  print(health);
        if (health <= 0)
        {
            // GAME OVER
            print("GAME OVER");

        }

        Forward();
        Turning();
    }
}
