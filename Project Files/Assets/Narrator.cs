using Fungus;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    public Flowchart flowchart;

    public int systemCount;
    public int wakedSystems;

    public void WakedASystem()
    { 
        if ( ++wakedSystems == systemCount )
        {
            flowchart.SetBooleanVariable("WakedAllSystems", true);
        }

    }
}
