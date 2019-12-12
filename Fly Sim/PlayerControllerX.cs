using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    public GameObject player;
    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public float bounceForce=5;
    public float upBound;
    private bool upFlag=true;
    public float lowBound;
    private bool lowFlag=true;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb=GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
         upFlag=true;
         lowFlag=true;
        if(player.transform.position.y > upBound)
        {
            upFlag=false;
        }
        if(player.transform.position.y < lowBound)
        {
            lowFlag=false;
        }
        
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && (upFlag) && lowFlag)
        {
            playerRb.AddForce(Vector3.up * floatForce);
           
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up*bounceForce,ForceMode.Impulse);
        }

    }

}
