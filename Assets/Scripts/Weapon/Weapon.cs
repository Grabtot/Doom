using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _attackRange;

    [SerializeField] private bool _equiped = false;
    protected abstract void Attack();
    public void Equip()
    {
        _equiped = true;
        gameObject.SetActive(true);
    }

    public void Unequip()
    {
        _equiped = false;
        gameObject.SetActive(false);
    }

    protected virtual void Update()
    {
        if (Input.GetMouseButton(0) && _equiped)
            Attack();
    }
}
