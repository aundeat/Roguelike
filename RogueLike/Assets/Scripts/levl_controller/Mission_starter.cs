using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mission_starter : MonoBehaviour
{
     public parameter_mission CurrentMission;

    private void OnTriggerEnter(Collider other)
    {
        if (CurrentMission.MissionMap != null)
        {
            SceneManager.LoadScene(CurrentMission.MissionMap);
        }else { Debug.Log("error mission not found"); }
    }
}
