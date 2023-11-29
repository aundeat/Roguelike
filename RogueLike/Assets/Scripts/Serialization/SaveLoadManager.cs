using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    [SerializeField] SaveData saveData;
    public void LoadGame()
    {
       
        
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Save.save");
        SceneManager.LoadScene("Clan");

    }
    public void NewGame()
    {
        SceneManager.LoadScene("TraningScene");
    }
    public void SaveGame()
    {
       SerializationManager.Save("Save",SaveData.current);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
       
    }


}
