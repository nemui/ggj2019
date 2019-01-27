using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTest : MonoBehaviour
{

    public List<InputKey> inputList = new List<InputKey>();

    public List<Transform> destinations = new List<Transform>();

    public float moveSpeed;

    public int decayValue;

    private Transform target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    public float offset;

    public bool isDocked = false;

    public float fuel = 100f;
    public float fuelps = 2f;
    public float fuelRestoreRate = 5f;

    public Text fuelValue;

    GameManager instance;

    public Rigidbody rb;

    public Transform testSpace;

    public Vector3 heading;

    public float rotSpeed = 1;

    void OnGUI()
    {
      
            if (Input.anyKeyDown)
            {

                if (Event.current.isKey)
                {
                    Event e = Event.current;

                    if (e.isKey)
                    {
                        //Debug.Log("Detected key code: " + e.keyCode);
                        string eString = e.keyCode.ToString();
                        if (eString != "None")
                        {
                            InputKey thisKey = new InputKey();
                            thisKey.keyCode = eString;
                            Debug.Log(thisKey.keyCode);
    
                            RunLoop(thisKey);
                        }
                    }

                }
            }
        
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // instance = GameObject.Find("GameManager").GetComponent<GameManager>();
        //moveSpeed = instance.moveSpeed;
        //fuelRestoreRate = instance.fuelRegenSpeed;

        decayValue = 100;
        StartCoroutine(Decay());
        StartCoroutine(BurnFuel());

        
    }

    private void Update()
    {
        Quaternion newRot = Quaternion.LookRotation(heading);

        rb.MoveRotation(Quaternion.Slerp(rb.rotation, newRot, Time.deltaTime * rotSpeed));
        // rb.MoveRotation(Quaternion.LookRotation(heading * rotSpeed * Time.deltaTime));
        rb.MovePosition(new Vector3(rb.position.x, rb.position.y, 0));
    }

    

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Quaternion newRot = Quaternion.LookRotation(testSpace.position - transform.position);

            rb.MoveRotation(Quaternion.Slerp(rb.rotation, newRot, Time.deltaTime * rotSpeed));
        }

        if (isDocked)
        {
            fuel += fuelRestoreRate * Time.deltaTime;
            fuel = Mathf.Clamp(fuel, 0, 100);
            fuelps = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(5, 0, 0) * 20);
                isDocked = false;
                fuelps = 5;
            }
        }

        
      
        fuelValue.text = fuel.ToString();
      
    }

    private void RunLoop(InputKey key)
    {
        foreach (Transform des in destinations)
        {
            if(!isDocked)
            {
                //Debug.Log("Iterating through Inputs");
                if (key.keyCode == des.name)
                {
                    heading = des.position - transform.position;
                
                    // transform.rotation = Quaternion.LookRotation(lookTarget);
                    // rb.MoveRotation(Quaternion.LookRotation(heading));
                    rb.AddForce(transform.forward * moveSpeed);
                }
            }

        }
    }

    private void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.DrawLine(transform.position, target.position);
        }

    }

    private IEnumerator Decay()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            //Debug.Log("Starting decay");
            if (inputList.Count > 0)
            {
                foreach (InputKey inputKey in inputList)
                {
                    inputKey.timesPressed = Mathf.Clamp(inputKey.timesPressed - decayValue, 0, 2000);
                }
                foreach (InputKey key2 in inputList)
                {
                    if (key2.timesPressed <= 0)
                    {
                        inputList.Remove(key2);
                        //Debug.Log("Removed" + key2.keyCode);
                        break;
                    }
                }


            }
        }
    }

    private IEnumerator BurnFuel()
    {
        while(true)
        {
           
             yield return new WaitForSeconds(1);
             fuel -= GetComponent<Rigidbody>().velocity.magnitude * fuelps * Time.deltaTime;
            
            
        }      
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "SlowDown")
        {
            //Debug.Log("Entering speed zone");
            decayValue = 100;
        }
        if (collision.tag == "ShipEntrance")
        {
            GetComponent<Rigidbody>().velocity = Vector2.zero;
            isDocked = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            if(GetComponent<Rigidbody>().velocity.magnitude >= 2f)
            {
                if(fuel > 0)
                {
                    Destroy(collision.gameObject);
                    // instance.destroyedAsteroids++;
                }               
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "SlowDown")
        {
            //Debug.Log("Entering speed zone");
            decayValue *= 100;
        }
    }
}

public class InputKey
{
    public string keyCode;
    public int timesPressed;
    public bool isEntered;
}

public class Destination
{
    public string id;
    public Transform location;
}



