using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    // Update is called once per frame
    void Update()
    {   float nextPress=2;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
