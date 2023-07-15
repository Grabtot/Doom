using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private List<Hitable> _enemiesToKill;
    private int _killedCount;
    private void Start()
    {
        foreach (Hitable enemy in _enemiesToKill)
        {
            enemy.ReceivedFatalDamage += () => _killedCount++;
        }
    }

    private void Update()
    {
        if (_killedCount == _enemiesToKill.Count)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
