using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform world;
    public override void InstallBindings()
    {
        Container.Bind<Publisher>().To<Publisher>().AsSingle();
        Container.Bind<EndGameValue>().To<EndGameValue>().AsSingle();
        Container.Bind<ScoreValue>().To<ScoreValue>().AsSingle();

        if (player != null)
        {
            Container.BindInstance(player).WithId(TransformType.Player).AsSingle();
        }

        if (world != null)
        {
            Container.BindInstance(world).WithId(TransformType.World).AsSingle();
        }
    }
}

public enum TransformType
{
    Player,
    World
}