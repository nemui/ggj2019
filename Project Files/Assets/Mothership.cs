using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mothership : MonoBehaviour
{
    public float health = 100;
    public Text shieldText;

    GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();
        health = instance.shipShields;
    }

    // Update is called once per frame
    void Update()
    {
        shieldText.text = health.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            health -= 20;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
            Destroy(collision.gameObject);
        }
        
    }
}
