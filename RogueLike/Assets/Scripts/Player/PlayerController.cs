using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _speedAttack;
    [SerializeField] private Transform _camera;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private Vector3 _cameraForward;
    private Vector3 _cameraRight;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
      
 
        
    }

    private void Update()
    {
        OptimizeCamera();
        PlayerMove();
    }

    private void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 directionVector = (_cameraForward * vertical + _cameraRight * horizontal).normalized;
        _animator.SetFloat("movementSpeed", directionVector.magnitude);
        _rigidbody.velocity = directionVector * _speed;
    }
    private void OptimizeCamera()
    {
        _cameraForward = _camera.forward;
        _cameraForward.y = 0;
        _cameraForward.Normalize();
        _cameraRight = _camera.right;
        _cameraRight.y = 0;
        _cameraRight.Normalize();
    }
}
