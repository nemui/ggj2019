using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float endGameTime;

    CombatTest combatScript;
    Mothership shipScript;

    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        combatScript = GameObject.Find("Player").GetComponent<CombatTest>();
        shipScript = GameObject.Find("Mothership").GetComponent<Mothership>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseStat(string stat, float increase)
    {
        switch (stat)
        {
            case "Fuel Recovery":
                combatScript.fuelRestoreRate += increase;
                break;
            case "Shield Health":
                shipScript.health += increase;
                break;
            case "Movement Speed":
                combatScript.moveSpeed += increase;
                break;

        }

    }
}
