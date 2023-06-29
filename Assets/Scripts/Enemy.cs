using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Hitable))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _attackRange;

    [Header("Movement")]
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected float _speed;
    [SerializeField] protected Hitable _hitable;

    private void Start()
    {
        _hitable.ReceivedFatalDamage.AddListener(OnFatalDamageReceived);
    }

    private void OnFatalDamageReceived()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        MoveToPlayer();

    }

    protected virtual void MoveToPlayer()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) < _attackRange)
        {
            Vector3 direction = Player.Instance.transform.position - transform.position;
            direction.Normalize();
            _rigidbody.velocity = direction * _speed;
        }
    }

    protected virtual void Atack()
    {
        print("Atack");
    }
}
