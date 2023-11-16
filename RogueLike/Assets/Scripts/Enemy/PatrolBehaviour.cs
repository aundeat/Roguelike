using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    private float _timer;
    private List<Transform> _points = new List<Transform>();
    private NavMeshAgent _agent;
    [SerializeField] private float _timeEndPatrol;

    private Transform _player;
    [SerializeField] private float _chaseRange;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform point in pointsObject)
        {
            _points.Add(point);
        }
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.SetDestination(_points[0].position);
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _agent.SetDestination(_points[Random.Range(0, _points.Count)].position);
        }
        _timer += Time.deltaTime;
        if (_timer > _timeEndPatrol)
        {
            animator.SetBool("isPatrolling", false);
        }

        float distance = Vector3.Distance(animator.transform.position, _player.position);
        if(distance < _chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }
}
