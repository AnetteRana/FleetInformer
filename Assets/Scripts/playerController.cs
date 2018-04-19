using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour
{
    public int health;

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
        //forward movement
        float moveV = Input.GetAxis("Vertical");
        transform.Translate(0, moveV / 3, 0, Space.Self);

        // visual
        if (moveV > 0)
        {
            forward.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            forward.GetComponent<Renderer>().enabled = false;
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
        }
        // A
        else if (moveH < 0)
        {
            // visual
            left.GetComponent<Renderer>().enabled = true;
            left0.GetComponent<Renderer>().enabled = true;
            right.GetComponent<Renderer>().enabled = false;
            right0.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            //visual
            right.GetComponent<Renderer>().enabled = false;
            right0.GetComponent<Renderer>().enabled = false;
            left.GetComponent<Renderer>().enabled = false;
            left0.GetComponent<Renderer>().enabled = false;
        }

        float moveV = Input.GetAxis("Vertical");
        transform.Rotate(0, 0, (Mathf.Abs(moveV) *5 +1) * -moveH / 2);
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
