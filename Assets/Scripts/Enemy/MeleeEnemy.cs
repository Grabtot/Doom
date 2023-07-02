using UnityEngine;

namespace Enemy
{

    public class MeleeEnemy : Enemy
    {

        private void Update()
        {
            MoveToPlayer();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Attack(() => Random.Range(0, 3) == 1, 20);
            }
        }
    }
}