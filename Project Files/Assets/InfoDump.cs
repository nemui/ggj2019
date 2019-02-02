using System;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "InfoDum", menuName = "InfoDump")]
public class InfoDump : ScriptableObject, ISerializationCallbackReceiver
{
    public bool firstTime;
    public int systemCount;
    public int wakedSystems;

    public bool talkedToQ;
    public bool talkedToAresa;
    public bool talkedToPD;

    public int droneSpeed;
    public int phobosPower;
    public int deimosPower;
    public string weaponSystemStatus;
    public int fuelRegen;

    public bool hasQInfo;
    public bool hasQAdvice;

    public bool goodEnding;
    public bool badEnding;

    [NonSerialized]
    public bool runtimeFirstTime;
    [NonSerialized]
    public int runtimeSystemCount;
    [NonSerialized]
    public int runtimeWakedSystems;
    [NonSerialized]
    public bool runtimeTalkedToQ;
    [NonSerialized]
    public bool runtimeTalkedToAresa;
    [NonSerialized]
    public bool runtimeTalkedToPD;
    [NonSerialized]
    public int runtimeDroneSpeed;
    [NonSerialized]
    public int runtimePhobosPower;
    [NonSerialized]
    public int runtimeDeimosPower;
    [NonSerialized]
    public string runtimeWeaponSystemStatus;
    [NonSerialized]
    public int runtimeFuelRegen;
    [NonSerialized]
    public bool runtimeHasQInfo;
    [NonSerialized]
    public bool runtimeHasQAdvice;
    [NonSerialized]
    public bool runtimeGoodEnding;
    [NonSerialized]
    public bool runtimeBadEnding;


    public void OnAfterDeserialize()
    {
        runtimeFirstTime = firstTime;
        runtimeSystemCount = systemCount;
        runtimeWakedSystems = wakedSystems;
        runtimeTalkedToQ = talkedToQ;
        runtimeTalkedToAresa = talkedToAresa;
        runtimeTalkedToPD = talkedToPD;
        runtimeDroneSpeed = droneSpeed;
        runtimePhobosPower = phobosPower;
        runtimeDeimosPower = deimosPower;
        runtimeWeaponSystemStatus = weaponSystemStatus;
        runtimeFuelRegen = fuelRegen;
        runtimeHasQInfo = hasQInfo;
        runtimeHasQAdvice = hasQAdvice;
        runtimeGoodEnding = goodEnding;
        runtimeBadEnding = badEnding;
    }

    public void OnBeforeSerialize()
    {
        // zilch
    }
}
