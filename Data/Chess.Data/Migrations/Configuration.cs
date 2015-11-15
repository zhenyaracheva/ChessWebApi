namespace Chess.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ChessDbContext>
    {
        public Configuration()
        {
            ContextKey = "Chess.Data.ChessDbContext";
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ChessDbContext context)
        {
        }
    }
}
