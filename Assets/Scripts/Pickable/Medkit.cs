using UnityEngine;

public class Medkit : MonoBehaviour, IPickable
{
    [SerializeField] private int _hp;
    public void Drop(Player player)
    {
        throw new System.NotImplementedException();
    }

    public void PickUp(Player player)
    {
        player.Hitable.Heal(_hp);
        gameObject.SetActive(false);
    }
}
