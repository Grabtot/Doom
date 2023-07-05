using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangeWeapon
{
    protected override void Attack()
    {
        List<Ray> rays = new();
        for (int i = 0; i < _ammoPerShoot; i++)
        {
            Ray ray
        }
        if (Physics.Raycast(ray, out RaycastHit hit, _attackRange))
        {
            _shootPoint.transform.position = hit.point;
            if (hit.transform.TryGetComponent(out Hitable hitable))
            {
                hitable.GetDamage(50);
            }
            //   print($"Pistol {_guid} hits {hit.transform}");
        }
    }
}
