﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Afore2020.Startup))]
namespace Afore2020
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
