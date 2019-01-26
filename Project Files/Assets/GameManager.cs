using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float endGameTime;

    CombatTest combatScript;
    Mothership shipScript;

    public float shipShields;
    public float moveSpeed;
    public float fuelRegenSpeed;

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

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "PaulScene")
        {

        }
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

    private IEnumerator GameTimer()
    {
        int i = 0;
        yield return new WaitForSeconds(1);
        i++;
        if(i >= endGameTime)
        {
            
        }
    }


}
