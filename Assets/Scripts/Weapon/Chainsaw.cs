using UnityEngine;

public class Chainsaw : MeleeWeapon, IPickable
{


    protected override void Update()
    {
        while (Input.GetMouseButton(0))
            Attack();
    }
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
