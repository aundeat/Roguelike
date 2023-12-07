using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TackSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Mission;

    [Header("Missioncount")]
    [SerializeField] private int MissionCount;


    
    void Start()
    {



        for (int i = 0; i < MissionCount; i++)
        {
           Instantiate(Mission, SpawnMissionLocation(), gameObject.transform.rotation,gameObject.transform) ;
        }


    }

    private Vector3 SpawnMissionLocation()
    {
        Vector3 position = gameObject.transform.position;
       
     position.x =  gameObject.transform.position.x + Random.Range(-0.3f, 0.3f) ;
        position.y = gameObject.transform.position.y + Random.Range(-0.3f, 0.3f);
        return position;
    }
   

  
}
