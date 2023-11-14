using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(_camera);
    }
}
