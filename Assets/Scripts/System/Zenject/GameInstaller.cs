using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private Transform player;

    public override void InstallBindings()
    {
        Container.Bind<Publisher>().To<Publisher>().AsSingle();
        Container.Bind<EndGameValue>().To<EndGameValue>().AsSingle();
        Container.Bind<ScoreValue>().To<ScoreValue>().AsSingle();

        if (player != null)
        {
            Container.BindInstance(player).WithId(TransformType.Player).AsSingle();
        }
    }
}

public enum TransformType
{
    Player
}