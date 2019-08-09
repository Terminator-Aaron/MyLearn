using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Db.Models.Mapping
{
    public class EnergyCellTickMap : EntityTypeConfiguration<EnergyCellTick>
    {
        public EnergyCellTickMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EnergyCellID, t.Tick, t.Energy, t.IsHotPot });

            // Properties
            this.Property(t => t.EnergyCellID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Tick)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("EnergyCellTick");
            this.Property(t => t.EnergyCellID).HasColumnName("EnergyCellID");
            this.Property(t => t.Tick).HasColumnName("Tick");
            this.Property(t => t.Energy).HasColumnName("Energy");
            this.Property(t => t.IsHotPot).HasColumnName("IsHotPot");

            // Relationships
            this.HasRequired(t => t.EnergyCell)
                .WithMany(t => t.EnergyCellTicks)
                .HasForeignKey(d => d.EnergyCellID);

        }
    }
}
