using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class EndOfMission : MonoBehaviour
{
   [SerializeField] private GameObject EndGameCanvas;

   [SerializeField] private Text Reward;
    
    private void UIUpdate()
    {
        Reward.text = SaveData.current.CurrentMission.Reward;

        if (SaveData.current.CurrentMission.Reward != "")
        { Reward.text = SaveData.current.CurrentMission.Reward; }
        else
        { Reward.text = "you get Nothing"; }
        
    }
    private void Start()
 
    {
        UIUpdate();
    }







    public void ClanLoad()

    {
        SceneManager.LoadScene("Clan");
    }

    private void OnTriggerEnter(Collider other)
    {
        EndGameCanvas.SetActive(true);
        UIUpdate();
       
    }
}




