using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public float jump;
    public float gmod;
    public bool isOnGround=true;
    public bool gameOver=false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    // Start is called before the first frame update
    void Start()
    {
      playerRb=GetComponent<Rigidbody>();
      playerAnim=GetComponent<Animator>();
      playerAudio=GetComponent<AudioSource>();
      Physics.gravity*=gmod; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !(gameOver))
        {
          playerRb.AddForce(Vector3.up*jump,ForceMode.Impulse); 
          isOnGround=false;
          playerAnim.SetTrigger("Jump_trig");
          dirtParticle.Stop();
          playerAudio.PlayOneShot(jumpSound,1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround=true;
            dirtParticle.Play();
        }
        else 
        if(collision.gameObject.CompareTag("Obstacle"))
        {
           gameOver=true;
           Debug.Log("Game Over");
           playerAnim.SetBool("Death_b",true);
           playerAnim.SetInteger("DeathType_int",1);
           explosionParticle.Play();
           dirtParticle.Stop();
           playerAudio.PlayOneShot(crashSound,1.0f);
        }
    }
}
