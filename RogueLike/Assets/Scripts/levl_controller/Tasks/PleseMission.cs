using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleseMission : MonoBehaviour
{



    [SerializeField] MissionCreater MissionCreater;


    private void Start()
    {
        MissionCreater.CreateMission(gameObject);
    }
}
