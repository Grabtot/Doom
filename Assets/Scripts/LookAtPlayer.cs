using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Player.Instance.transform);
    }
}
