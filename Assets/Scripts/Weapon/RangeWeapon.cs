using System;
using UnityEngine;
using Zenject;

public abstract class RangeWeapon : Weapon
{
    [Inject] protected SpriteRenderer _shootPoint;
    [SerializeField] protected int _ammoCount;
    [SerializeField] protected int _maxAmmoCount;
    [SerializeField] protected int _ammoPerShoot;

    public int MaxAmmoCount => _maxAmmoCount;

    public virtual void AddAmmo(int ammoCount)
    {
        if (ammoCount < 0)
            throw new ArgumentOutOfRangeException(nameof(ammoCount));

        if (ammoCount + _ammoCount >= MaxAmmoCount)
        {
            _ammoCount = MaxAmmoCount;
        }
        else
        {
            _ammoCount += ammoCount;
        }
    }
    protected override void Attack()
    {
        print("RangeWeapon: Attack");
    }

}
