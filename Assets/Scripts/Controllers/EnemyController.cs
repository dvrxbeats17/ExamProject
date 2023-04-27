using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float LookRadus = 10f;

    private Transform _target;
    private NavMeshAgent _agent;
    private CharacterCombat _combat;


    private void Start()
    {
        _target = PlayerManager.Instance.Player.transform;
        _agent = GetComponent<NavMeshAgent>();
        _combat = GetComponent<CharacterCombat>();  
    }

    private void Update()
    {
        float _distaance = Vector3.Distance(_target.position, transform.position);

        if(_distaance <= LookRadus)
        {
            _agent.SetDestination(_target.position);

            if(_distaance <= _agent.stoppingDistance)
            {
                CharacterStats targetStats = _target.GetComponent<CharacterStats>();
                if(targetStats != null)
                {
                _combat.Attack(targetStats);
                }
                FaceTarget();
            }
        }
    }
    
    private void FaceTarget()
    {
        Vector3 _direction = (_target.position - transform.position).normalized;
        Quaternion _lookRotation = Quaternion.LookRotation(new Vector3(_direction.x, 0, _direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadus);
    }
}
