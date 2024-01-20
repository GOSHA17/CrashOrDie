using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public const int NUMBER_ATTACK_ANIMATIONS = 3; 

    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackRadius;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _whoIsEnemy;
    [SerializeField] private float _attackSpeed;

    private float _timer = 0;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();   
    }

    private void Update()
    {
        if (_timer < _attackSpeed)
            _timer += Time.deltaTime;
    }

    public void Attack()
    {
        if (_timer >= _attackSpeed)
        {
            int numberAttack = Random.Range(1, NUMBER_ATTACK_ANIMATIONS + 1);
            _anim.SetTrigger($"Attack{numberAttack}");
            _timer = 0;
        }
    }

    private void GiveDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(_attackPoint.position, _attackRadius, _whoIsEnemy);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<HealthSystem>(out HealthSystem health))
            {
                health.ChangeHealth(-_attackDamage);
            }
        }
    }
}
