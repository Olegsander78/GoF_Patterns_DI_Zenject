//using UnityEngine;
//using System.Collections;
//using Zenject;

//public class CoroutineRunner_Zenject : MonoBehaviour
//{
//    private DiContainer _container;

//    [Inject]
//    public void Construct(DiContainer container)
//    {
//        _container = container;
//    }

//    public Coroutine StartCoroutine(IEnumerator routine)
//    {
//        return _container.Resolve<MonoBehaviour>().StartCoroutine(routine);
//    }

//    public void StopCoroutine(Coroutine routine)
//    {
//        _container.Resolve<MonoBehaviour>().StopCoroutine(routine);
//    }
//}
