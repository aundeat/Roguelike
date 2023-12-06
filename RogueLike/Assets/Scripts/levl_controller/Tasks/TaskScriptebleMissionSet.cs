using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScriptebleMissionSet : MonoBehaviour
{
    [SerializeField] private parameter_mission[] ScriptblMission;





    private GameObject[] Task;
    private void Update()
    {
        TaskSet();
        ScriptblMissionSet();
    }
    void Start()
    {
        TaskSet();
        ScriptblMissionSet();

    }
    private void ScriptblMissionSet()
    {
        for (int i = 0; i < 3; i++)
        {
            Task[i].GetComponent<Task>().Scriptebl_Mission = ScriptblMission[i];
        }
    }
    private void TaskSet()
    {
        for (int i = 0; i < 3; i++)
        {
            Task[i] = gameObject.GetComponentsInChildren<GameObject>()[i];
        }
    }
}
