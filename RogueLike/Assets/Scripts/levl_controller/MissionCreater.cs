using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCreater : MonoBehaviour
{
    [SerializeField]
    private List<parameter_mission> ScriptblMission = new List<parameter_mission>();

    private bool[] missioncount;
    public void CreateMission(GameObject Mission)
    {
        ScriptblMission[missionCountfree()] = Mission.gameObject.GetComponent<Task>().Scriptebl_Mission;
    }

    private int missionCountfree() 
        {
        int notoccupied = 0;

        for (int i = 0; i < missioncount.Length; i++)
        {
            if (missioncount[i] != true) { notoccupied = i; }
        }
        return notoccupied ;
        } 
}
