using UnityEngine;
namespace Enemy
{
    public class RangeEnemy : Enemy
    {
        private void Update()
        {
            MoveToPlayer();
            if (Vector3.Distance(transform.position, Player.transform.position) < _visionRange)
            {

            }
        }
    }
}