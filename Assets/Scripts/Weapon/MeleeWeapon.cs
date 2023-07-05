using UnityEngine;
public class MeleeWeapon : Weapon
{
    protected override void Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _attackRange);

        foreach (Collider enemy in colliders)
        {
            if (enemy.TryGetComponent(out Hitable hitable))
            {
                hitable.GetDamage(_damage);
            }
        }
    }
}
