using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   private float speed=20.0f;
    private float turnspeed=45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Vector3 inertia=new Vector3(0,0,1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      horizontalInput=Input.GetAxis("Horizontal");
      forwardInput=Input.GetAxis("Vertical");
      //code to move the vehicle forward
      transform.Translate(Vector3.forward*Time.deltaTime*speed*forwardInput);
      transform.Rotate(Vector3.up,Time.deltaTime*speed*horizontalInput);
    }
}
