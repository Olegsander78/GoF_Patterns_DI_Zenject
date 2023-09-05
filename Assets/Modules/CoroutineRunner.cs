using System;
using System.Collections;
using UnityEngine;

public class CoroutineRunner
{
    private static readonly Lazy<CoroutineRunner> _instance = new Lazy<CoroutineRunner>(() => new CoroutineRunner());
    public static CoroutineRunner Instance => _instance.Value;

    private GameObject _coroutineHost;
    private CoroutineHost _coroutineHostComponent;

    private CoroutineRunner()
    {
        _coroutineHost = new GameObject("CoroutineRunner");
        _coroutineHostComponent = _coroutineHost.AddComponent<CoroutineHost>();
    }

    public Coroutine StartCoroutine(IEnumerator coroutine) => CoroutineHostComponent.StartCoroutine(coroutine);

    public void StopCoroutine(Coroutine coroutine) => CoroutineHostComponent.StopCoroutine(coroutine);

    public void Dispose()
    {
        if (_coroutineHost != null)
        {
            GameObject.Destroy(_coroutineHost);
            _coroutineHost = null;
            _coroutineHostComponent = null;
        }
    }

    private CoroutineHost CoroutineHostComponent
    {
        get
        {
            if (_coroutineHostComponent == null)
            {
                _coroutineHostComponent = _coroutineHost.GetComponent<CoroutineHost>();
            }
            return _coroutineHostComponent;
        }
    }

    private class CoroutineHost : MonoBehaviour { }
}
