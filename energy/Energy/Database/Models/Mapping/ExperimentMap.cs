using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Db.Models.Mapping
{
    public class ExperimentMap : EntityTypeConfiguration<Experiment>
    {
        public ExperimentMap()
        {
            // Primary Key
            this.HasKey(t => t.ExperimentID);

            // Properties
            this.Property(t => t.ByWho)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Experiment");
            this.Property(t => t.ExperimentID).HasColumnName("ExperimentID");
            this.Property(t => t.MaxX).HasColumnName("MaxX");
            this.Property(t => t.MaxY).HasColumnName("MaxY");
            this.Property(t => t.StartCells).HasColumnName("StartCells");
            this.Property(t => t.StartHotPots).HasColumnName("StartHotPots");
            this.Property(t => t.StartAtoms).HasColumnName("StartAtoms");
            this.Property(t => t.InitStartTime).HasColumnName("InitStartTime");
            this.Property(t => t.InitEndTime).HasColumnName("InitEndTime");
            this.Property(t => t.ExpStartTime).HasColumnName("ExpStartTime");
            this.Property(t => t.ExpEndTime).HasColumnName("ExpEndTime");
            this.Property(t => t.ByWho).HasColumnName("ByWho");
            this.Property(t => t.Remark).HasColumnName("Remark");
        }
    }
}
