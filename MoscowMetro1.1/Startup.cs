﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoscowMetro1._1.Startup))]
namespace MoscowMetro1._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
