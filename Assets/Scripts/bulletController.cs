using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{

    public int bulletLifetime = 120;
    public float speed = 5f;

    public AudioSource hitSound;

    GameObject cameraRef;

    private void Start()
    {
        cameraRef = GameObject.FindGameObjectWithTag("MainCamera");
        //hitSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<playerController>().health = collision.gameObject.GetComponent<playerController>().health - 1;
            Object.Destroy(this.gameObject);

            //cameraRef.GetComponent<cameraController>().screenshake();
            cameraRef.GetComponent<cameraController>().shakeDuration = 0.1f;

            //hitSound.Play();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyController>().health = collision.gameObject.GetComponent<enemyController>().health - 1;
            Object.Destroy(this.gameObject);
            //hitSound.Play();
        }
        if (collision.gameObject.tag == "Ally")
        {
            collision.gameObject.GetComponent<AllyController>().health = collision.gameObject.GetComponent<AllyController>().health - 1;
            Object.Destroy(this.gameObject);
            //hitSound.Play();
        }



    }

    // Update is called once per frame
    void Update()
    {
        bulletLifetime--;

        // forward
        transform.Translate(speed * Vector3.up * Time.deltaTime, Space.Self);
    }
}
