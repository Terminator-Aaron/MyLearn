using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Db.Models.Mapping;

namespace Db.Models
{
    public partial class EnergyContext : DbContext
    {
        static EnergyContext()
        {
            Database.SetInitializer<EnergyContext>(null);
        }

        public EnergyContext()
            : base("Name=EnergyContext")
        {
        }

        public DbSet<Atom> Atoms { get; set; }
        public DbSet<AtomTick> AtomTicks { get; set; }
        public DbSet<EnergyCell> EnergyCells { get; set; }
        public DbSet<EnergyCellTick> EnergyCellTicks { get; set; }
        public DbSet<Experiment> Experiments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AtomMap());
            modelBuilder.Configurations.Add(new AtomTickMap());
            modelBuilder.Configurations.Add(new EnergyCellMap());
            modelBuilder.Configurations.Add(new EnergyCellTickMap());
            modelBuilder.Configurations.Add(new ExperimentMap());
        }
    }
}
