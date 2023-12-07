using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mission_starter : MonoBehaviour
{
  

    private void OnTriggerEnter(Collider other)
    {
        if (SaveData.current.CurrentMission != null)
        {
            SceneManager.LoadScene(SaveData.current.CurrentMission.MissionMap);
        }
        else Debug.LogError("you dant have mission now. take one please");
    }
}
