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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager.GetDamege(_damage);
        }
    }
}
