using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class EndOfMissionCondition : MonoBehaviour
{
    [SerializeField] GameObject CanvasEnd;

    
    void Start()
    {
        


    }


    private void Update()
    {
        if (SaveData.current.CurrentMission.NeedToEnd <= SaveData.current.PlayerCurrentKills) { CanvasEnd.SetActive(true); }
    }

}
