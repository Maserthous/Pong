using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroyer : MonoBehaviour {

    public AudioClip goalSound;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ball")
        {
            if (other.transform.position.x < 0)
                GameController.game.Score(0);
            else
                GameController.game.Score(1);

            Destroy(other.gameObject);

            source.PlayOneShot(goalSound, 1);
        }
    }
}
