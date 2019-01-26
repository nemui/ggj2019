using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomMovement());
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude >= 2)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private IEnumerator RandomMovement()
    {
        target = new Vector2(Random.Range(-20,10),Random.Range(-10,0));
        GetComponent<Rigidbody2D>().AddForce(target * 20f);
        yield return new WaitForSeconds(Random.Range(0, 3));
    }

    private IEnumerator Timer()
    {
        int i = 0;
        if(i >= 5)
        {
            Destroy(this.gameObject);
        }
        yield return new WaitForSeconds(1);
        i++;
    }
}
