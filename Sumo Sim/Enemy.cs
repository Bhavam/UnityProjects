using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    public float speed=3.0f;
    public GameObject player;
    private float outBound=-2.0f;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player");
        enemyRb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection=(player.transform.position-transform.position).normalized;
        enemyRb.AddForce(lookDirection*speed);
        if(transform.position.y < outBound)
        {
            Destroy(gameObject);
        }
    }
}
