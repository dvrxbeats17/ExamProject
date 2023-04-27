using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float AttackSpeed = 1f;
    public event System.Action OnAttack;

    [SerializeField] private float attackDelay = 0.6f;

    private float _attackCooldown = 0f;
    private CharacterStats _myStats;

    private void Start()
    {
        _myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        _attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if(_attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            if(OnAttack != null)
                OnAttack();
            _attackCooldown = 1f / AttackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(_myStats.Damage.GetValue());
    }
}
