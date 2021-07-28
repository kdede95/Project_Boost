using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 50f;
    [SerializeField]
    private float _thrustSpeed = 1000f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust(_thrustSpeed);
        ProcessRotation(_rotationSpeed);
    }

    void ProcessThrust(float thrustSpeed)
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed*Time.deltaTime,ForceMode.Acceleration);
        }
        
    }
    void ProcessRotation(float rotationSpeed)
    {


        if (Input.GetKey(KeyCode.D))
        {
            Rotating(-rotationSpeed);
        }
        else if ( Input.GetKey(KeyCode.A))
        {
            Rotating(rotationSpeed);
        }
    }

    private void Rotating(float rotationSpeed)
    {

        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
