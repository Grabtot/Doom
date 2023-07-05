using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class MeleeWeapon : Weapon
{
    protected override void Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _attackRange);
        IEnumerable<Collider> enemies = colliders.Where(collider => collider.CompareTag("Enemy"));
        foreach (Collider enemy in enemies)
        {
            if (enemy.TryGetComponent(out Hitable hitable))
            {
                hitable.GetDamage(_damage);
            }
        }
    }
}
