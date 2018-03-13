using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    public float speed;
    public float angle;
    public AudioClip paddleSound;
    public AudioClip wallSound;
    

    private Rigidbody2D rBody;
    private AudioSource source;
    private Vector2 movement;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start () {

        float rand = Random.Range(0, 2);
        if (rand < 1)
            movement = new Vector2(1, -0.2f);
        else
            movement = new Vector2(-1, -0.2f);

        rBody = this.gameObject.GetComponent<Rigidbody2D>();
        rBody.velocity = movement * speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "PaddleRight")
        {
            float y = (transform.position.y - other.transform.position.y) * angle;
            movement = new Vector2(-1, y);
            rBody.velocity = movement * speed;
        }
        else if (other.gameObject.name == "PaddleLeft")
        {
            float y = (transform.position.y - other.transform.position.y) * angle;

            movement = new Vector2(1, y);
            rBody.velocity = movement * speed;
        }
        else
        {
            float y = rBody.velocity.y;
            movement = new Vector2(rBody.velocity.x, 0 - y);
            rBody.velocity = movement;
        }

        // Plays sound effects
        if (other.gameObject.tag == "Player")
            source.PlayOneShot(paddleSound, 1);
        else if (other.gameObject.tag == "Wall")
            source.PlayOneShot(wallSound, 1);
    }
}
