using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using Chess.Data;
using Chess.Data.Migrations;

[assembly: OwinStartup(typeof(Chess.Server.Startup))]

namespace Chess.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChessDbContext, Configuration>(true));
            ConfigureAuth(app);

        }
    }
}
