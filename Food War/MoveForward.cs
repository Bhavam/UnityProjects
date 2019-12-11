using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{ 
    private Vector3 foodmask=new Vector3(0,0,1);
    public float speed=10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     transform.Translate(foodmask*Time.deltaTime*speed);   
    }
}
