﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.CrossCutting.IOC
{
    public class ModuleIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIOC.LoadConfiguration(builder);
        }
    }
}