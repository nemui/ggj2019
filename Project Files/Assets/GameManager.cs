using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float endGameTime;
    public float gameTimer;

    public CombatTest combatScript;
    public Mothership shipScript;

    public float shipShields;
    public float moveSpeed;
    public float fuelRegenSpeed;

    public int destroyedAsteroids;

    public float finalHealth;

    public static GameManager instance = null;

    public enum Challenges {none, damage, asteroids }
    public Challenges activeChallenge = Challenges.none;

    bool challenge1Won = false;
    bool challenge2Won = false;

    public Text timerText;

    string sceneName;

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        Debug.Log("Should have registered the event!");
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    
    void SceneLoaded(Scene curScene, LoadSceneMode loadMode)
    {
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);

        if(sceneName == "PaulScene")
        {
            combatScript = GameObject.Find("Player").GetComponent<CombatTest>();
            shipScript = GameObject.Find("Mothership").GetComponent<Mothership>();
            destroyedAsteroids = 0;
            finalHealth = 100;
            gameTimer = endGameTime;
            Debug.Log("timer set");
            timerText = GameObject.Find("Timer Text").GetComponent<Text>();
            StartCoroutine(GameTimer());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerText != null)
        {
            timerText.text = gameTimer.ToString();
        }
        
    }

    public void IncreaseStat(string stat, float increase)
    {
        if(shipScript != null)
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

    public void StartChallenge(string challenge)
    {
        switch (challenge)
        {
            case "Take No Damage":
                activeChallenge = Challenges.damage;
                break;
            case "Destroy 20 Asteroids":
                activeChallenge = Challenges.asteroids;
                break;
        }

    }

    private IEnumerator GameTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            gameTimer -= 1;

            if (shipScript != null)
            {
                if (gameTimer <= 0)
                {
                    finalHealth = shipScript.health;
                    if (activeChallenge == Challenges.asteroids)
                    {
                        if (destroyedAsteroids >= 20)
                        {
                            challenge2Won = true;
                        }
                    }

                    if (activeChallenge == Challenges.damage)
                    {
                        if (finalHealth >= 100)
                        {
                            challenge1Won = true;
                        }
                    }

                    SceneManager.LoadScene("Narrative");
                }
                else
                {
                    continue;
                }
            }

        }        
    }

    public void LoadScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    private void OnApplicationQuit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }
}
