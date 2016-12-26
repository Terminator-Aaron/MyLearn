using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Db.Models.Mapping
{
    public class EnergyCellMap : EntityTypeConfiguration<EnergyCell>
    {
        public EnergyCellMap()
        {
            // Primary Key
            this.HasKey(t => t.EnergyCellID);

            // Properties
            // Table & Column Mappings
            this.ToTable("EnergyCell");
            this.Property(t => t.EnergyCellID).HasColumnName("EnergyCellID");
            this.Property(t => t.ExperimentID).HasColumnName("ExperimentID");
            this.Property(t => t.Order).HasColumnName("Order");
            this.Property(t => t.CellX).HasColumnName("CellX");
            this.Property(t => t.CellY).HasColumnName("CellY");

            // Relationships
            this.HasRequired(t => t.Experiment)
                .WithMany(t => t.EnergyCells)
                .HasForeignKey(d => d.ExperimentID);

        }
    }
}
