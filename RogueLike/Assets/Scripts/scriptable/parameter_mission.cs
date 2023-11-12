using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Lvl",menuName ="lvl/CreateNew")]
public class parameter_mission : ScriptableObject
{
    [SerializeField] public string LvlName;
    [SerializeField] public string LvlDescription;
    [SerializeField] public  int Lvl;
    [SerializeField] public float Complexity;
    [SerializeField] public bool ItOpen;

    [SerializeField] public string Reward;



    [SerializeField] public string MissionMap;


}
