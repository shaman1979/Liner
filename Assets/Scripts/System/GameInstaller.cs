using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IPublisher>().To<Publisher>().AsSingle();
        Container.Bind<EndGameValue>().To<EndGameValue>().AsSingle();
    }
}