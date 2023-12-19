using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    
    public void LoadGame()
    {
        SceneManager.LoadScene("Clan");

        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Save.save");
        



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
