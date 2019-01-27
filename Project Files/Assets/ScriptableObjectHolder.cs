using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectHolder : MonoBehaviour
{
    public InfoDump infoDump;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
