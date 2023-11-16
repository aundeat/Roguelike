using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] float _damage = 5;
    private void OnCollisionEnter(Collision collision)
    {
        PlayerManager.GetDamege(_damage);
    }
}
