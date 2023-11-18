using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRun;
    [SerializeField] private float _rotationSped;
    [SerializeField] private Transform _camera;

    private Rigidbody _rigidbody;
    private Animator _animator;
    private float _previousSpeed;
    private bool _running;

    private Vector3 _cameraForward;
    private Vector3 _cameraRight;

    private IPlayerAction _currentAction;
    public IPlayerAction CurrentAction
    {
        get { return _currentAction; }
        set { _currentAction = value; }
    }

    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("Camera").transform;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _previousSpeed = _speed;
    }

    private void Update()
    {
        OptimizeCamera();
        PlayerMove();
        MakeAction();

    }
    private void OnMouseDown()
    {// work for Oleg = combat it for swich controller to combat 
        _animator.SetBool("combat", true);
    }

    private void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 directionVector = (_cameraForward * vertical + _cameraRight * horizontal).normalized;
        _animator.SetFloat("movementSpeed", directionVector.magnitude * (_speed / 10));
        _rigidbody.velocity = directionVector * _speed;
        if (directionVector != Vector3.zero)
        {
            float rotationSpeed = Time.deltaTime * _rotationSped;
            Quaternion targetRotation = Quaternion.LookRotation((_cameraForward * vertical + _cameraRight * horizontal).normalized);
            _rigidbody.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);

        }
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

    private void MakeAction()
    {

        if (Input.GetKey(KeyCode.LeftShift) && _currentAction == null)
        {
            _currentAction = GetComponent<RunAction>();
            _currentAction.ExecuteAction(this);
        }
        if (Input.GetKey(KeyCode.Space) && _currentAction == null)
        {
            _currentAction = GetComponent<StrafeAction>();
            _currentAction.ExecuteAction(this);
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetMouseButtonUp(0) || !Input.GetKey(KeyCode.LeftShift))
        {
            if (_currentAction != null)
            {
                _currentAction = null;
                _speed = _previousSpeed;
            }
        }
    }

    public void SetRunning(float speed)
    {
        if (speed >= 0)
        {
            _speed = speed;
        }
        else
        {
            Debug.LogError("Speed lower than 0");
        }
    }
}
