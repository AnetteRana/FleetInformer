﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public int health = 100;

    public GameObject bullet;

    public GameObject radiusPrefab;
    public GameObject myRad;
    public float shotCooldown = 2f;
    private float currentShotCooldown = 2f;

    public bool hasTarget = false;
    public GameObject target;

    public float Speed;
    public float turnSpeed = 5f;

    private int edgeCooldown = 0;

    public float boardWidth;
    public float boardHeight;

    //////////////////////////////////////////////

    // stay within board
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Edge")
        {
            if (edgeCooldown > 0)
            {
                //dont rotate
                edgeCooldown--;
            }
            else
            {
                transform.Rotate(0, 0, -1);

                //randomly make cooldown
                if (Random.Range(0, 20) == 0)
                {
                    edgeCooldown = 30;
                }
            }

        }
    }

    // Use this for initialization
    void Start()
    {
        myRad = Instantiate(radiusPrefab, this.transform.position, this.transform.rotation, gameObject.transform);
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));

        // go to a random place without sight
        bool searchingForPosition = true;
        while (searchingForPosition)
        {
            transform.position = new Vector3(Random.Range(boardWidth, -boardWidth), Random.Range(boardHeight, -boardHeight), 0.0f);

            // make sure enemy does not sense player or ally
            if (hasTarget && (target != null))
            {
                
            }
            else
            {
                searchingForPosition = false;
            }
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Object.Destroy(this.gameObject);
        }

        if (hasTarget && (target != null))
        {
            //print("has");
            Speed = 2;
            Vector3 myForward = new Vector3(0, 0, 1);

            Vector3 targetDir = target.transform.position - transform.position;
            float step = turnSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.position - transform.position);

            // shoot
            if (currentShotCooldown >= shotCooldown)
            {
                currentShotCooldown = 0;
                Vector3 bullPos = transform.position + 2.3f*transform.up;
                Instantiate(bullet, bullPos, transform.rotation, null);
            }
            else
            {
                currentShotCooldown++;
            }

        }
        else
        {
            //print("not");
            Speed = 1;

        }

        // forward
        transform.Translate(Speed * Vector3.up * Time.deltaTime, Space.Self);
        if (false)
        {
            // turn right
            transform.Rotate(0, 0, -1);
        }

    }
}
