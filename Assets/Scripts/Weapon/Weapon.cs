using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _attackRange;
    protected abstract void Attack();

    protected virtual void Update()
    {
        if (Input.GetMouseButton(0))
            Attack();
    }
}
