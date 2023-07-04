using UnityEngine;
using Zenject;

public abstract class RangeWeapon : Weapon
{
    [Inject] protected SpriteRenderer _shootPoint;
    protected override void Attack()
    {
        print("RangeWeapon");
    }
}
