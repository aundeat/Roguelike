using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCreater : MonoBehaviour
{
    [SerializeField]
    private List<parameter_mission> ScriptblMission = new List<parameter_mission>();

    private static bool[] missioncount = new bool[6];
    private void Start()
    {
        for (int i = 0; i < missioncount.Length; i++) { missioncount[i] = false;}
    }
    public void CreateMission(GameObject Mission)
    {

          Mission.gameObject.GetComponent<Task>().Scriptebl_Mission = ScriptblMission[missionCountfree()];
          missioncount[missionCountfree()] = true;
    }

    private int missionCountfree() 
        {
        int notoccupied = -1 ;

        for (int i = 0; i < missioncount.Length; i++)
        {
            if (missioncount[i] != true) { if (notoccupied == -1 ) { notoccupied = i; break; } }
        }
        return notoccupied ;
        } 
}
