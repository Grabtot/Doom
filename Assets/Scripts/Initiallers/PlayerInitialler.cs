using UnityEngine;
using Zenject;

public class PlayerInitialler : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPoint;
    public override void InstallBindings()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(
            _player, _spawnPoint.position, Quaternion.identity, null);

        Container
            .Bind<Player>()
            .FromInstance(player)
            .AsSingle();
    }
}

