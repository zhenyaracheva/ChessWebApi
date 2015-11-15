namespace Chess.Server.App_Start
{
    using Chess.Data;
    using Chess.Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChessDbContext, Configuration>());
            ChessDbContext.Create().Database.Initialize(true);
        }
    }
}