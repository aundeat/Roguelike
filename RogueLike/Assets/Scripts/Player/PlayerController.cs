using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSped;
    [SerializeField] private float _energyLossRateOnSpeed = 0.1f;
    [SerializeField] private float _energyRegenRate = 5f;
    private float _currentEnergyRegen = 0f;
    private float _time;
    private Transform _camera;
    private Rigidbody _rigidbody;
    private float _previousSpeed;

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
        GetCurrentMode();
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
        Debug.Log(_currentAction);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentAction = GetComponent<RunAction>();
            _currentAction.ExecuteAction(this);
        }
        if (Input.GetKey(KeyCode.Space) && _currentAction == null)
        {
            _currentAction = GetComponent<StrafeAction>();
            _currentAction.ExecuteAction(this);
        }
        if (Input.GetButtonDown("Fire1") && _currentAction == null)
        {
            _currentAction = GetComponent<AttackAction>();
            _currentAction.ExecuteAction(this);
        }
        if (Input.GetButtonUp("Fire1") && _currentAction == null)
        {
            _animator.SetBool("attack", false);
        }
        if (Input.GetButton("Fire2"))
        {
            _currentAction = GetComponent<BlockAction>();
            _currentAction.ExecuteAction(this);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            Debug.Log("Inside");
            _animator.SetBool("block", false);
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetMouseButtonUp(0) || !Input.GetKey(KeyCode.LeftShift) && !Input.GetButton("Fire2"))
        {
            if (_currentAction != null)
            {
                _currentAction = null;
                _speed = _previousSpeed;
                _time = 0f;
            }
            _currentEnergyRegen += _energyRegenRate * Time.deltaTime;
            if (_currentEnergyRegen >= 1)
            {
                PlayerManager.GainEnergy(_currentEnergyRegen);
                _currentEnergyRegen = 0f;
            }
        }
        if (Input.GetButtonDown("Cancel")) 
        {
            _currentAction = GetComponent<PauseAction>();
            _currentAction.ExecuteAction(this);
        }
    }

    public void SetRunning(float speed)
    {

        if (speed >= 0 && PlayerManager._energy > 0)
        {
            _speed = speed;
            LoseEnergy(_energyLossRateOnSpeed);
        }
        else
        {
            _speed = _previousSpeed;
            Debug.LogError("Speed lower than 0 or not energy");
        }
    }
    private void GetCurrentMode()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != "Clan")
        {
            _animator.SetBool("combat", true);
        }
    }
    public void LoseEnergy(float loseEnergy)
    {
        _time += Time.deltaTime;
        if (_time >= 0.1)
        {
            PlayerManager.LostEnergy(loseEnergy);
            _time = 0f;
        }
    }
    private void Awake()
    {
    
      
    }
}
