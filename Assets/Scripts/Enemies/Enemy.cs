using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IMovable
{
    [SerializeField] private float _xp;
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _offset;

    private AttackScript _attackScript;
    private HealthSystem _healthSystem;
    private LVLSystem _lvlSystem;
    private NavMeshAgent _agent;
    private Transform _playerTransform;
    private float _speed;

    public bool IsMoving()
    {
        return _agent.velocity.magnitude > 0;
    }

    protected void Init()
    {
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        _lvlSystem = FindObjectOfType<LVLSystem>();

        _agent = GetComponent<NavMeshAgent>();
        _attackScript = GetComponent<AttackScript>();
        _healthSystem = GetComponent<HealthSystem>();

        _healthSystem.Died += Die;
        _speed = _normalSpeed;
        _agent.speed = _speed;
    }

    protected void Move()
    {
        if (_playerTransform == null) return;

        if (Vector3.Distance(transform.position, _playerTransform.position) > _offset)
        {
            Vector3 directionFromPlayer = transform.position - _playerTransform.position;
            _agent.SetDestination(_playerTransform.position + directionFromPlayer * _offset);
        }
        else
        {
            _attackScript.Attack();
        }
    }

    private void Die()
    {
        _healthSystem.Died -= Die;
        _lvlSystem.AddXP(_xp);
        Destroy(gameObject);
    }
}
