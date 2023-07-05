using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangeWeapon
{
    protected override void Attack()
    {
        List<Ray> rays = new();
        for (int i = 0; i < _ammoPerShoot; i++)
        {
            Ray ray = Camera.main.ViewportPointToRay(new(Random.Range(.1f, 1f), Random.Range(.1f, 1f), 0));
            rays.Add(ray);
        }
        foreach (Ray ray in rays)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, _attackRange))
            {
                _shootPoint.transform.position = hit.point;
                if (hit.transform.TryGetComponent(out Hitable hitable))
                {
                    hitable.GetDamage(50);
                }
                //   print($"Shotgun {_guid} hits {hit.transform}");
            }
        }
    }
}
