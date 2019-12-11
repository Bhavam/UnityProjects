using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float topbound=30;
    private float lowerbound=-10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.z > topbound)
       {
           Destroy(gameObject);

       } else if(transform.position.z <lowerbound)
       {   Debug.Log("Game Over");
           Destroy(gameObject);
       }
    }
}
