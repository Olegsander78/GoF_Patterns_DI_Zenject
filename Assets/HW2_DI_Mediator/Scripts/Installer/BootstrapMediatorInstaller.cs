using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BootstrapMediatorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindBootstrap();
    }

    private void BindBootstrap()
    {
        throw new NotImplementedException();
    }
}
