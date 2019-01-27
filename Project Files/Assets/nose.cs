using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nose : MonoBehaviour
{
    public GameObject parent;
    public Rigidbody2D parentRB;

    GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Player");
        parentRB = parent.GetComponent<Rigidbody2D>();
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            if(parentRB.velocity.magnitude >= 2f)
            {
                if(parent.GetComponent<CombatTest>().fuel > 0)
                {
                    Destroy(collision.gameObject);
                    instance.destroyedAsteroids++;
                }
                
            }

        }
    }
}
