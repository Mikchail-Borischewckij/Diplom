using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Impl
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("HomeFinanceConnectionString")
        {
            Database.SetInitializer<DatabaseContext>(new Initializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Token> Tokens { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<CostsCategory> CostsCategories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencys { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Cost> Сonsumptions { get; set; }
		public DbSet<CostsPlaning> CostsPlaning { get; set; }
		public DbSet<IncomePlaning> IncomePlaning { get; set; }
       
    }
}
