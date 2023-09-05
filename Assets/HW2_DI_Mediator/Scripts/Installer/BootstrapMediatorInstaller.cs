using Zenject;

public class BootstrapMediatorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindBootstrap();
        BindMediator();
        BindUIPanel();
    }

    private void BindBootstrap()
    {
        Container.BindInterfacesAndSelfTo<MediatorBootstrap>().AsSingle().NonLazy();        
    }

    private void BindUIPanel()
    {
        Container.Bind<DefeatPanel>().FromComponentInHierarchy().AsSingle();
    }

    private void BindMediator()
    {
        Container.Bind<GameplayMediator>().FromComponentInHierarchy().AsSingle();        
    }
}
