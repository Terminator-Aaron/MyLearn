using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Db.Models.Mapping
{
    public class AtomMap : EntityTypeConfiguration<Atom>
    {
        public AtomMap()
        {
            // Primary Key
            this.HasKey(t => t.AtomID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Atom");
            this.Property(t => t.AtomID).HasColumnName("AtomID");
            this.Property(t => t.ExperimentID).HasColumnName("ExperimentID");
            this.Property(t => t.Order).HasColumnName("Order");
            this.Property(t => t.VolumeRadius).HasColumnName("VolumeRadius");
            this.Property(t => t.AttractionRadius).HasColumnName("AttractionRadius");
            this.Property(t => t.AttractionForce).HasColumnName("AttractionForce");

            // Relationships
            this.HasRequired(t => t.Experiment)
                .WithMany(t => t.Atoms)
                .HasForeignKey(d => d.ExperimentID);

        }
    }
}
