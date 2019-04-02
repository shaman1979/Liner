using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Publisher>().To<Publisher>().AsSingle();
        Container.Bind<EndGameValue>().To<EndGameValue>().AsSingle();
        Container.Bind<ScoreValue>().To<ScoreValue>().AsSingle();
    }
}