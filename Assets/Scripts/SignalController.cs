using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalController : MonoBehaviour {

    public AudioSource audio;

    public Renderer rend;
    public bool isSounding = false;

    void active()
    {
        rend.enabled = true;
    }

    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();
        audio = GetComponent<AudioSource>();
        rend.enabled = false;
    }

    public void mysound()
    {
        
       // audio.Play();

    //Sounding = false;

}
	

	void FixedUpdate ()
    {
        // activate signals
        if (Input.GetKey("space"))
        {
            //GetComponentInParent<playerController>().decelerate();
            rend.enabled = true;
            
            if (isSounding == false)
            {
                isSounding = true;
                mysound();
            }
        }
        else
        {
            rend.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy") && (GetComponent<SignalController>().rend.enabled == true))
        {
            collision.GetComponent<enemyController>().myRad.GetComponent<EnemyRadiusController>().informed();
        }
        else if ((collision.gameObject.tag == "Ally") && (GetComponent<SignalController>().rend.enabled == true))
        {
            collision.GetComponent<AllyController>().myRad.GetComponent<AllyRadiusController>().informed();
        }
    }
}

