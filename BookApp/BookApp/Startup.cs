﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BookApp.Startup))]

namespace BookApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
