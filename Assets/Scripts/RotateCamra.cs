using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamra : MonoBehaviour
{
    public float rotationSpeed; // created variable 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // setting the rotation of the camera to rotate on Horizontalaxis only
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime); // calling the method to rotate camera
    }
}
