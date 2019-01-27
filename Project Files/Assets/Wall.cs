using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public enum direction { up, down, left, right }
    public direction bounceDir;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody tempRB = collision.gameObject.GetComponent<Rigidbody>();
        if (tempRB != null)
        {
            switch (bounceDir)
            {
                case direction.up:
                    tempRB.AddForce(Vector3.up * 100f);
                    break;
                case direction.down:
                    tempRB.AddForce(-Vector3.up * 100f);
                    break;
                case direction.left:
                    tempRB.AddForce(-Vector3.right * 100f);
                    break;
                case direction.right:
                    tempRB.AddForce(Vector3.right * 100f);
                    break;

            }


        }
    }
}
