using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;
public class CharacterAnimator : MonoBehaviour
{
    private const float _locomotionAnimationSmoothTime = .1f;
    private Animator _animator;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float speedPercent = _agent.velocity.magnitude / _agent.speed;
        _animator.SetFloat("speedPercent", speedPercent, _locomotionAnimationSmoothTime, Time.deltaTime);
    }
}
