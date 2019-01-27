using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform camera;

    public float lifeTime = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Transform>();

        StartCoroutine(DestroyMe());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 heading = camera.position - transform.position;

        transform.rotation = Quaternion.LookRotation(heading);
    }

    IEnumerator DestroyMe ()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }
}
