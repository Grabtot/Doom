using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody), typeof(Hitable))]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float _visionRange;

        [Header("Movement")]
        [SerializeField] protected Rigidbody _rigidbody;
        [SerializeField] protected float _speed;
        [SerializeField] protected Hitable _hitable;
        [SerializeField] private float _attackDelay;

        protected Player Player;
        protected bool _canAttack = true;

        [Inject]
        private void Construct(Player player)
        {
            Player = player;
        }

        protected virtual void Start()
        {
            _hitable.ReceivedFatalDamage += OnFatalDamageReceived;
            _hitable.ReceivedDamage += (damage, hp) =>
                print($"{transform} received {damage} damage. {hp} Hp left");
        }

        private void OnFatalDamageReceived()
        {
            gameObject.SetActive(false);
            print($"{transform} is dead");
        }



        protected virtual void MoveToPlayer()
        {
            if (Vector3.Distance(transform.position, Player.transform.position) < _visionRange)
            {
                Vector3 direction = Player.transform.position - transform.position;
                direction.Normalize();
                _rigidbody.velocity = direction * _speed;
            }
        }
        protected virtual void Attack(Func<bool> HitPlayer, int damage)
        {
            if (_canAttack)
            {
                StartCoroutine(nameof(AttackReload));
                if (HitPlayer())
                    Player.Hitable.GetDamage(damage);
            }
        }

        private IEnumerator AttackReload()
        {
            _canAttack = false;
            yield return new WaitForSeconds(_attackDelay);
            _canAttack = true;
        }
    }
}