using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Vector2 target;

    public float xSpeedMin;
    public float xSpeedMax;
    public float ySpeedMin;
    public float ySpeedMax;

    public GameObject explosion;
    
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude >= 2 || collision.gameObject.GetComponent<CombatTest>().varMoveSpeed >= 1f)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Debug.Log("Instantiated explosion?");
                Destroy(this.gameObject);
            }
        }
    }

    public void DestroyThisObstacle()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Debug.Log("Instantiated explosion?");
        Destroy(this.gameObject);
    }
    
    private IEnumerator RandomMovement()
    {
        target = new Vector3(Random.Range(-10,5),Random.Range(-5,0),0);
        GetComponent<Rigidbody>().AddForce(target * Random.Range(5,8));
        yield return new WaitForSeconds(Random.Range(0, 2));
    }

    private IEnumerator Timer()
    {
        //while (true)
        //{
        //    int i = 0;
        //    if (i >= 5)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //    yield return new WaitForSeconds(1);
        //    i++;
        //}
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
