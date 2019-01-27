using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Narrator : MonoBehaviour
{
    public InfoDump infoDump;

    private Flowchart introFlowchart;
    private Flowchart talkFlowchart;

    void Awake()
    {
        introFlowchart = GameObject.Find("IntroFlowchart").GetComponent<Flowchart>();
        talkFlowchart = GameObject.Find("TalksFlowchart").GetComponent<Flowchart>();
        infoDump.firstTime = true;
        if (infoDump.firstTime)
        {
            introFlowchart.enabled = true;
            infoDump.firstTime = false;
        }
        else
        {
            talkFlowchart.enabled = true;
            talkFlowchart.SetIntegerVariable("DroneSpeed", infoDump.droneSpeed);
            talkFlowchart.SetIntegerVariable("PhobosPower", infoDump.phobosPower);
            talkFlowchart.SetIntegerVariable("DeimosPower", infoDump.deimosPower);

            talkFlowchart.SetBooleanVariable("HasQInfo", infoDump.hasQInfo);
            talkFlowchart.SetBooleanVariable("HasQAdvice", infoDump.hasQAdvice);
            talkFlowchart.SetStringVariable("WeaponsStatus", infoDump.weaponSystemStatus);

            talkFlowchart.SetBooleanVariable("TalkedToQ", infoDump.talkedToQ);
            talkFlowchart.SetBooleanVariable("TalkedToAresa", infoDump.talkedToAresa);
            talkFlowchart.SetBooleanVariable("TalkedToPD", infoDump.talkedToPD);
        }
    }

    public void WakedASystem()
    { 
        if ( ++infoDump.wakedSystems == infoDump.systemCount)
        {
            introFlowchart.SetBooleanVariable("WakedAllSystems", true);
            infoDump.wakedSystems = 0;
        }
    }

    public void GameOver()
    {
        Application.Quit();
    }

    public void LeaveScene()
    {
        infoDump.droneSpeed = talkFlowchart.GetIntegerVariable("DroneSpeed");
        infoDump.phobosPower = talkFlowchart.GetIntegerVariable("PhobosPower");
        infoDump.deimosPower = talkFlowchart.GetIntegerVariable("DeimosPower");

        infoDump.hasQInfo = talkFlowchart.GetBooleanVariable("HasQInfo");
        infoDump.hasQAdvice = talkFlowchart.GetBooleanVariable("HasQAdvice");
        infoDump.weaponSystemStatus = talkFlowchart.GetStringVariable("WeaponsStatus");

        infoDump.talkedToQ = talkFlowchart.GetBooleanVariable("TalkedToQ");
        infoDump.talkedToAresa = talkFlowchart.GetBooleanVariable("TalkedToAresa");
        infoDump.talkedToPD = talkFlowchart.GetBooleanVariable("TalkedToPD");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
