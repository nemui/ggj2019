using UnityEngine;

[CreateAssetMenu(fileName = "InfoDum", menuName = "InfoDump")]
public class InfoDump : ScriptableObject
{
    public bool firstTime;
    public int systemCount;
    public int wakedSystems;

    public bool talkedToQ;
    public bool talkedToAresa;
    public bool talkedToPD;

    public int droneSpeed;
    public bool repurposedAres;
    public int phobosPower;
    public int deimosPower;
}
