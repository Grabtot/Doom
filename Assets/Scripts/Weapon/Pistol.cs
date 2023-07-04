using UnityEngine;

public class Pistol : RangeWeapon
{
    protected override void Attack()
    {
        Ray ray = Camera.main.ViewportPointToRay(new(.5f, .5f, 0));

        if (Physics.Raycast(ray, out RaycastHit hit, _attackRange))
        {
            _shootPoint.transform.position = hit.point;
            if (hit.transform.TryGetComponent(out Hitable hitable))
            {
                hitable.GetDamage(50);
            }
            print(hit.transform);

        }
    }
}
