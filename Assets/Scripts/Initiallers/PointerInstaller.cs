using UnityEngine;
using Zenject;

public class PointerInstaller : MonoInstaller
{
    [SerializeField] private SpriteRenderer _pointer;

    public override void InstallBindings()
    {
        SpriteRenderer pointer = Container.InstantiatePrefabForComponent<SpriteRenderer>(_pointer, Vector3.zero,
            Quaternion.identity, null);

        Container
        .Bind<SpriteRenderer>()
          .FromInstance(pointer)
          .AsSingle();
    }
}
