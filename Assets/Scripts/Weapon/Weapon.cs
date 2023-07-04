using UnityEngine;

public abstract class Weapon : MonoBehaviour, IPickable
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _attackRange;
    protected abstract void Attack();
    protected bool _picked;
    public void Drop() => _picked = true;

    public void PickUp() => _picked = false;
    protected virtual void Update()
    {
        if (Input.GetMouseButton(0) && _picked)
            Attack();
    }
}
