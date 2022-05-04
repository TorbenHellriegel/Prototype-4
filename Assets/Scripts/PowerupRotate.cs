using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRotate : MonoBehaviour
{
    private float rotationSpeed = 100;
    private float levitate = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levitate += Time.deltaTime;

        // Rotates the powerup
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);

        // Makes the powerup float up and down
        transform.position = new Vector3(transform.position.x, Mathf.Sin(levitate)/3 + 0.4f, transform.position.z);
    }
}
