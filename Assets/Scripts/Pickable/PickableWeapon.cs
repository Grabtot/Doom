using UnityEngine;

public class PickableWeapon : MonoBehaviour, IPickable
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _weaponGameObject;
    [SerializeField] private int _ammoToAdd;

    public void Drop(Player player)
    {
        throw new System.NotImplementedException();
    }

    public void PickUp(Player player)
    {

        if (!player.Weapons.Contains(_weapon))
        {
            player.Weapons.Add(_weapon);
        }
        if (_weapon is RangeWeapon rangeWeapon)
        {
            rangeWeapon.AddAmmo(_ammoToAdd);
        }
        gameObject.SetActive(false);
    }
}
