using UnityEngine;
using UnityEngine.UI;

public class EnymyScript : MonoBehaviour
{
    [SerializeField] private float HP;
    [SerializeField] private Animator _animator;
    [SerializeField] private Slider _healthBar;

    private void Update()
    {
        _healthBar.value = HP;
    }

    public void TakeDamage(float damageCount)
    {
        Debug.Log("ins");
        HP -= damageCount;
        if (HP <= 0)
        {
            Destroy(gameObject);
            _animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            _healthBar.gameObject.SetActive(false);
        }
        else
        {
            _animator.SetTrigger("Damage");
        }
    }
}
