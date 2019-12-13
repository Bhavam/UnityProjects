using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speedForce;
    public GameObject focalPoint;
    public bool hasPowerup=false;
    public float forceImpulse=10.0f;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();
        focalPoint=GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset=new Vector3(0,-0.5f,0);
        float verticalInput=Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward*verticalInput*speedForce);
        powerupIndicator.transform.position=transform.position+offset;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
       {
         hasPowerup=true;
         powerupIndicator.gameObject.SetActive(true);
         Destroy(other.gameObject);
         StartCoroutine(PowerupCountdownRoutine());
       }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup=false;
        powerupIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb=collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer=collision.gameObject.transform.position-transform.position;
            enemyRb.AddForce(awayFromPlayer*forceImpulse,ForceMode.Impulse);
            Debug.Log("Player has collided with:"+collision.gameObject.name+"with powerup value:"+hasPowerup);
        }
    }
}
