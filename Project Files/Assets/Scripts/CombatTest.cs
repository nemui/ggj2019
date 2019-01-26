using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTest : MonoBehaviour
{
    public List<InputKey> inputList = new List<InputKey>();

    void OnGUI()
    {
        if (Input.anyKeyDown)
        {

            if (Event.current.isKey)
            {
                Event e = Event.current;

                if (e.isKey)
                {
                    Debug.Log("Detected key code: " + e.keyCode);
                    string eString = e.keyCode.ToString();
                    if (eString != "None")
                    {
                        InputKey thisKey = new InputKey();
                        thisKey.keyCode = eString;
                      
                        RunLoop(thisKey);
                    }
                }

            }
        }
    }

    private void Start()
    {
        StartCoroutine(Decay());
    }

    private void RunLoop(InputKey key)
    {
       bool keyInList = false;

       foreach(InputKey inputKey in inputList)
        {
            if (inputKey.keyCode == key.keyCode)
            {
                inputKey.timesPressed++;
                Debug.Log("Iterate" + inputKey.keyCode + inputKey.timesPressed);
                keyInList = true;
            }
        }

        if (!keyInList)
        {
            // Add key to list.
            Debug.Log("Not in list. Adding");
            inputList.Add(key);
            key.timesPressed++;
            Debug.Log(key.keyCode + key.timesPressed);
        }
    }

    private IEnumerator Decay()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);

            Debug.Log("Starting decay");
            if (inputList.Count > 0)
            {
                foreach (InputKey inputKey in inputList)
                {
                    inputKey.timesPressed--;
                    Debug.Log("Decreased " + inputKey.keyCode + " to " + inputKey.timesPressed);
                    
                }
                foreach (InputKey key2 in inputList)
                {
                    if (key2.timesPressed <= 0)
                    {
                        inputList.Remove(key2);
                        Debug.Log("Removed" + key2.keyCode);
                        break;
                    }
                }

            }
        }
    }
}

public class InputKey
{
    public string keyCode;
    public int timesPressed;
    public bool isEntered;
}

