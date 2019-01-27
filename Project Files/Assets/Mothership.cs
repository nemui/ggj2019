using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mothership : MonoBehaviour
{
    public float health = 100;
    public Text shieldText;

    GameManager instance;

    public SpriteRenderer shieldVisual;

    private float shieldMax = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // instance = GameObject.Find("GameManager").GetComponent<GameManager>();
        // health = instance.shipShields;

        shieldMax = shieldVisual.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        shieldText.text = health.ToString();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            health -= 10;

            ChangeShieldVisual();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with mothership");
        if (collision.gameObject.tag == "Obstacle")
        {
            health -= 10;

            ChangeShieldVisual();

            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
            Destroy(collision.gameObject);
        }
        
    }

    void ChangeShieldVisual ()
    {
        Color curShieldCol = shieldVisual.color;

        Debug.Log("Current health is " + health + ", current alpha is " + curShieldCol.a);

        curShieldCol.a = health * 0.01f;

        //curShieldCol.a = Mathf.MoveTowards(curShieldCol.a, 0.0f, health * 0.001f);
        // curShieldCol.a = Mathf.Lerp(curShieldCol.a, 0.0f, health * 0.001f);


        shieldVisual.color = curShieldCol;
    }
}
