using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Narrator : MonoBehaviour
{
    public InfoDump infoDump;

    private Flowchart introFlowchart;
    private Flowchart talkFlowchart;
    private Flowchart goodEndingFlowchart;
    private Flowchart badEndingFlowchart;

    void Awake()
    {
        introFlowchart = GameObject.Find("IntroFlowchart").GetComponent<Flowchart>();
        talkFlowchart = GameObject.Find("TalksFlowchart").GetComponent<Flowchart>();
        goodEndingFlowchart = GameObject.Find("GoodEndingFlowchart").GetComponent<Flowchart>();
        badEndingFlowchart = GameObject.Find("BadEndingFlowchart").GetComponent<Flowchart>();

        if (infoDump.runtimeFirstTime)
        {
            introFlowchart.enabled = true;
            infoDump.runtimeFirstTime = false;
            GetComponent<AudioSource>().mute = true;
        }
        else if (infoDump.runtimeGoodEnding)
        {
            goodEndingFlowchart.enabled = true;
        }
        else if (infoDump.runtimeBadEnding)
        {
            badEndingFlowchart.enabled = true;
        }
        else {
            talkFlowchart.enabled = true;
            talkFlowchart.SetIntegerVariable("DroneSpeed", infoDump.runtimeDroneSpeed);
            talkFlowchart.SetIntegerVariable("PhobosPower", infoDump.runtimePhobosPower);
            talkFlowchart.SetIntegerVariable("DeimosPower", infoDump.runtimeDeimosPower);
            talkFlowchart.SetIntegerVariable("FuelRegen", infoDump.runtimeFuelRegen);

            talkFlowchart.SetBooleanVariable("HasQInfo", infoDump.runtimeHasQInfo);
            talkFlowchart.SetBooleanVariable("HasQAdvice", infoDump.runtimeHasQAdvice);
            talkFlowchart.SetStringVariable("WeaponsStatus", infoDump.runtimeWeaponSystemStatus);

            talkFlowchart.SetBooleanVariable("TalkedToQ", infoDump.runtimeTalkedToQ);
            talkFlowchart.SetBooleanVariable("TalkedToAresa", infoDump.runtimeTalkedToAresa);
            talkFlowchart.SetBooleanVariable("TalkedToPD", infoDump.runtimeTalkedToPD);
        }
    }

    public void WakedASystem()
    { 
        if ( ++infoDump.runtimeWakedSystems == infoDump.runtimeSystemCount)
        {
            introFlowchart.SetBooleanVariable("WakedAllSystems", true);
        }
    }

    public void GameOver()
    {
        Application.Quit();
    }

    public void LeaveScene()
    {
        infoDump.runtimeDroneSpeed = talkFlowchart.GetIntegerVariable("DroneSpeed");
        infoDump.runtimePhobosPower = talkFlowchart.GetIntegerVariable("PhobosPower");
        infoDump.runtimeDeimosPower = talkFlowchart.GetIntegerVariable("DeimosPower");
        infoDump.runtimeFuelRegen = talkFlowchart.GetIntegerVariable("FuelRegen");

        infoDump.runtimeHasQInfo = talkFlowchart.GetBooleanVariable("HasQInfo");
        infoDump.runtimeHasQAdvice = talkFlowchart.GetBooleanVariable("HasQAdvice");
        infoDump.runtimeWeaponSystemStatus = talkFlowchart.GetStringVariable("WeaponsStatus");

        infoDump.runtimeTalkedToQ = talkFlowchart.GetBooleanVariable("TalkedToQ");
        infoDump.runtimeTalkedToAresa = talkFlowchart.GetBooleanVariable("TalkedToAresa");
        infoDump.runtimeTalkedToPD = talkFlowchart.GetBooleanVariable("TalkedToPD");
        SceneManager.LoadScene("PaulScene", LoadSceneMode.Single);
    }
}
