using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAction : MonoBehaviour, IPlayerAction
{
   [SerializeField] private GameObject PauseCV;
    public void ExecuteAction(PlayerController playerController)
    {
       PauseCV.gameObject.SetActive(true);
    }
}
