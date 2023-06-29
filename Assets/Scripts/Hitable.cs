using UnityEngine;
using UnityEngine.Events;

public class Hitable : MonoBehaviour
{

    public int HP { get => _hP; private set => _hP = value; }
    public int MaxHP { get => _maxHP; private set => _maxHP = value; }

    [HideInInspector] public UnityEvent ReceivedFatalDamage;
    [HideInInspector] public UnityEvent<int, int> ReceivedDamage;
    [HideInInspector] public UnityEvent<int, int> Healed;
    [Header("HP")]
    [SerializeField] private int _hP;
    [SerializeField] private int _maxHP;

    public void GetDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            ReceivedFatalDamage.Invoke();
        }
        ReceivedDamage.Invoke(damage, HP);
    }

    public void Heal(int hp)
    {
        if (HP + hp > MaxHP)
        {
            HP = MaxHP;
        }
        else
        {
            HP += hp;
        }
        Healed.Invoke(hp, HP);
    }
}
