using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTest : MonoBehaviour
{
    public List<string> inputString = new List<string>();

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
                    if(eString != "None")
                    {
                        inputString.Add(eString);
                    }
                }

            }
        }
    }

    private void Update()
    {

        
    }
}
