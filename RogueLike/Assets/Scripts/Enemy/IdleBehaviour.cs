using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    private float _timer;
    [SerializeField] private float _timeEndIdle;
    private Transform _player;
    [SerializeField] private float _chaseRange;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer += Time.deltaTime;
        if (_timer > _timeEndIdle)
        {
            animator.SetBool("isPatrolling", true);
        }
        float distance = Vector3.Distance(animator.transform.position, _player.position);
        if (distance < _chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
