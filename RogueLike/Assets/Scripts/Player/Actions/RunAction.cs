using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAction : MonoBehaviour, IPlayerAction
{
    [SerializeField] private float runSpeed = 10f;

    public void ExecuteAction(PlayerController playerController)
    {
        playerController.SetRunning(runSpeed);
    }
}
