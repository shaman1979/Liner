using UnityEngine;
using Zenject;

public class ConfigsInstaller : ScriptableObjectInstaller
{
    [SerializeField]
    private GameConfig gameConfig;
    public override void InstallBindings()
    {
        Container.BindInstance(gameConfig).AsSingle();
    }
}