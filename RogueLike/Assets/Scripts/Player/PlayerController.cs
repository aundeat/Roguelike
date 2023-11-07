using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _speedAtack;
    [SerializeField] private Transform _camera;

    private Rigidbody _rigidbody;
    private Animator _animator;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = _camera.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        Vector3 cameraRight = _camera.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 directionVector = (cameraForward * vertical + cameraRight * horizontal).normalized;
        _animator.SetFloat("movementSpeed", directionVector.magnitude);
        _rigidbody.velocity = directionVector * _speed;
    }
}
