//using UnityEngine;
//using Zenject;

//public class BootstrapInstaller : MonoInstaller
//{
//    [SerializeField] private Bootstrap _bootstrapPrefab;
//    [SerializeField] private Transform _parent;
//    [SerializeField] private float _totalEnemiesWeight;

//    public override void InstallBindings()
//    {
//        BindInstance();
//    }

//    private void BindInstance()
//    {
//        var bootstrap = Container.InstantiatePrefabForComponent<Bootstrap>(_bootstrapPrefab, _parent);
//        Container.Bind<Bootstrap>().FromInstance(bootstrap).AsSingle().NonLazy();
//        Container.Bind<float>().FromInstance(_totalEnemiesWeight).WhenInjectedInto<Bootstrap>();
//    }
//}
