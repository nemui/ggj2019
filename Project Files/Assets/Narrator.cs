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
        if (infoDump.firstTime)
        {
            introFlowchart.enabled = true;
            infoDump.firstTime = false;
        }
        else
        {
            talkFlowchart.enabled = true;
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
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
