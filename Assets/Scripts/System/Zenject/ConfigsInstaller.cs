using UnityEngine;
using Zenject;

public class ConfigsInstaller : ScriptableObjectInstaller
{
    [SerializeField]
    private GameConfig gameConfig;

    [SerializeField]
    private Libriary libriary;        
    public override void InstallBindings()
    {
        Container.BindInstance(gameConfig).AsSingle();
        Container.BindInstance(libriary).AsSingle();
    }
}