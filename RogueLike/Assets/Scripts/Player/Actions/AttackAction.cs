using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : MonoBehaviour, IPlayerAction
{
    private PlayerController _playerController;
    public void ExecuteAction(PlayerController playerController)
    {
        Debug.Log("Attack");
        _playerController = playerController;
        Animator animator = playerController.GetComponent<Animator>();
        animator.SetBool("attack", true);
    }
}
