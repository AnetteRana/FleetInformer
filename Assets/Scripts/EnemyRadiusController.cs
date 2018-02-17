using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadiusController : MonoBehaviour {

    public float currentSize = 2;
    public float minSize = 2;
    public float maxSize = 4;
    private float counter = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        // or tagged as fighter
        if ((collision.gameObject.name == "Player") || (collision.gameObject.tag == "Ally"))
        {
            // set parents target
            this.transform.parent.GetComponent<enemyController>().target = collision.gameObject;
            this.transform.parent.GetComponent<enemyController>().hasTarget = true;
        }
        else
        {
            //this.transform.parent.GetComponent<enemyController>().hasTarget = false;
        }
        
        //// only when rend.enable == true
        //if ((collision.gameObject.name == "Signal") && (collision.gameObject.GetComponent<SignalController>().rend.enabled == true))
        //{
        //    if (currentSize < maxSize)
        //    {
        //        counter = 5;
        //        currentSize = (currentSize + 0.04f);
        //    }
        //}
    }

    private void FixedUpdate()
    {
        // rotate
        transform.Rotate(0.0f, 0.0f, Time.deltaTime * 200);

        transform.localScale = new Vector3(currentSize, currentSize, currentSize);

        counter = counter - 1;
        if (counter < 0)
        {
            this.transform.parent.GetComponent<enemyController>().hasTarget = false;
            if(currentSize > minSize)
            {
                currentSize = currentSize - 0.02f;
            }
        }
    }


    // call method from ship
    public void informed()
    {
        if (currentSize < maxSize)
        {
            counter = 5;
            currentSize = (currentSize + 0.04f);
        }
    }


}
