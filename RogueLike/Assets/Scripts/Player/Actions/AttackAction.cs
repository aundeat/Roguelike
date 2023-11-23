using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : MonoBehaviour, IPlayerAction
{
    [SerializeField] private float _energyLoseOnAttack;
    public void ExecuteAction(PlayerController playerController)
    {
        if (PlayerManager._energy > _energyLoseOnAttack)
        {
            playerController._animator.SetBool("attack", true);
            PlayerManager.LostEnergy(_energyLoseOnAttack);
        }
    }
}
