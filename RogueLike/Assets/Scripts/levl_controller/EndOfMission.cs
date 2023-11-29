using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using TMPro;

public class EndOfMission : MonoBehaviour
{
   [SerializeField] private GameObject EndGameCanvas;

    private TextMeshProUGUI Reward;
    private void UIUpdate()
    {
        
        Reward = EndGameCanvas.GetComponentInChildren<TextMeshProUGUI>();
        
        if (Reward != null)
        {    Reward.text = SaveData.current.CurrentMission.Reward;}
        else
            Reward.text = "you get Nothing";
    }
    
    

    




    public void ClanLoad()

    {
        SceneManager.LoadScene("Clan");
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(EndGameCanvas);
        UIUpdate();
       
    }
}




