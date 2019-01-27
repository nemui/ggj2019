using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotator : MonoBehaviour
{
    private Rigidbody rb;

    public Transform testPos;

    public Vector3 heading;

    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        rb.MovePosition(direction * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            heading = testPos.position - transform.position;
        }

        rb.MoveRotation(Quaternion.LookRotation(testPos.position * Time.deltaTime * speed));
    }
}
