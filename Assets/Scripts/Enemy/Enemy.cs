using System;
using System.Collections;
using UnityEngine;

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


        protected bool _canAttack = true;


        protected virtual void Start()
        {
            _hitable.ReceivedFatalDamage.AddListener(OnFatalDamageReceived);
        }

        private void OnFatalDamageReceived()
        {
            gameObject.SetActive(false);
        }



        protected virtual void MoveToPlayer()
        {
            if (Vector3.Distance(transform.position, Player.Instance.transform.position) < _visionRange)
            {
                Vector3 direction = Player.Instance.transform.position - transform.position;
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
                    Player.Instance.Hitable.GetDamage(damage);
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