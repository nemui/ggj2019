using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSMover : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 heading = new Vector3(inputX, 0.0f, inputY);

        rb.MovePosition(rb.position + heading * Time.deltaTime * speed);

        // rb.MoveRotation(Quaternion.LookRotation(heading));

        rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(heading), Time.deltaTime * speed));


    }
}
