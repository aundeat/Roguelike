using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [SerializeField] private Text Name;
    [SerializeField] private Text Description;
    [SerializeField] GameObject Canvas_description;

    [SerializeField] private Text Reward;


    [Header("Mission")]
    [SerializeField] parameter_mission Scriptebl_Mission;

   
    private Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();



       

    }
   private void OnMouseEnter()
    {
        rend.material.color = Color.red;
        Canvas_description.SetActive(true);
        Name.text = Scriptebl_Mission.LvlName;
        Description.text = Scriptebl_Mission.LvlDescription;
        Reward.text = Scriptebl_Mission.Reward;


    }
    private void OnMouseExit()
    {
        rend.material.color = Color.green;
        Canvas_description.SetActive(false);
    }
    private void OnMouseDown()
    {
       if (Scriptebl_Mission.ItOpen)
        {
            if (Scriptebl_Mission.MissionMap != null)
            {
                SceneManager.LoadScene(Scriptebl_Mission.MissionMap);
            }
        
        }



    }







}
