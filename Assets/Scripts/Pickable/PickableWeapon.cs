using System.Linq;
using UnityEngine;

public class PickableWeapon : MonoBehaviour, IPickable
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private int _ammoToAdd;

    public void Drop(Player player)
    {
        throw new System.NotImplementedException();
    }

    public void PickUp(Player player)
    {
        if (!player.Weapons.Any(weapon => weapon.GetType() == _weapon.GetType()))
        {
            Weapon newWeapon = Instantiate(_weapon, player.EquipedWeapon.transform.position,
                new Quaternion(), player.transform);

            player.EquipedWeapon.Unequip();
            newWeapon.Equip();
            player.Weapons.Add(newWeapon);
        }
        else if (_weapon is RangeWeapon rangeWeapon)
        {
            player.Weapons.OfType<RangeWeapon>().First(weapon => weapon.GetType() == _weapon.GetType()).AddAmmo(_ammoToAdd);
        }
        gameObject.SetActive(false);
    }
}
