using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    [SerializeField] SaveData saveData;
    public void LoadGame()
    {
       
        
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Save.save");
    }
    public void NewGame()
    {
        SceneManager.LoadScene("TraningScene");
    }
        
}
