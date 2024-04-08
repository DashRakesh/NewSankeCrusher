using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanekMovement : MonoBehaviour
{

    public float speed = 3.5f;
    public float currentRotation;
    public float rotationSensitivity = 50.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            currentRotation += rotationSensitivity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentRotation -= rotationSensitivity * Time.deltaTime;
        }

    }
    public void MoveForward()
    {
        transform.position += transform.up * speed * Time.deltaTime;

    }
    private void FixedUpdate()
    {
        MoveForward();
        Rotation();
    }
    public void Rotation()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentRotation));
    }
}
