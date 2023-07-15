using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody), typeof(Hitable))]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float _visionRange;

        [Header("Movement")]
        [SerializeField] protected Hitable _hitable;
        [SerializeField] private float _attackDelay;
        [SerializeField] private NavMeshAgent _nawMeshAgent;

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
                _nawMeshAgent.SetDestination(Player.transform.position);
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