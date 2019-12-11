using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    private float horizontalInput;
    private float speed=10.0f;

    private float xrange=10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Launch Projectile
            Instantiate(projectilePrefab,transform.position,projectilePrefab.transform.rotation);
        }
        if(transform.position.x > xrange)
        {
            transform.position=new Vector3(xrange,transform.position.y,transform.position.z);
        }
        
        if(transform.position.x < -xrange)
        {
            transform.position=new Vector3(-xrange,transform.position.y,transform.position.z);
        }
        horizontalInput=Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*Time.deltaTime*speed*horizontalInput);
    }
}