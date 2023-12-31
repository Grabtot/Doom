using UnityEngine;
using Zenject;

public class LookAtPlayer : MonoBehaviour
{
    [Inject] private Player _player;

    private void Update()
    {
        transform.LookAt(_player.transform);
    }
}
