using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAction : MonoBehaviour, IPlayerAction
{
    [SerializeField] private float _energyLoseOnBlock;
    [SerializeField] private float _nergyLoseOnHitBlockAction;
    public float EnergyLoseOnHitBlockAction
    {
        get { return _nergyLoseOnHitBlockAction; }
        set { _nergyLoseOnHitBlockAction = value; }
    }
    public void ExecuteAction(PlayerController playerController)
    {
        playerController.LoseEnergy(_energyLoseOnBlock);
        playerController._animator.SetBool("block", true);
    }
}
