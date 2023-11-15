using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private float _damageCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnymyScript>().TakeDamage(_damageCount);
        }
    }
}