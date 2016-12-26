using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Db.Models.Mapping
{
    public class AtomTickMap : EntityTypeConfiguration<AtomTick>
    {
        public AtomTickMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AtomID, t.Tick, t.Velocity, t.DirectionX, t.DirectionY, t.PositionX, t.PositionY });

            // Properties
            this.Property(t => t.AtomID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Tick)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DirectionX)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DirectionY)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PositionX)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PositionY)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("AtomTick");
            this.Property(t => t.AtomID).HasColumnName("AtomID");
            this.Property(t => t.Tick).HasColumnName("Tick");
            this.Property(t => t.Velocity).HasColumnName("Velocity");
            this.Property(t => t.DirectionX).HasColumnName("DirectionX");
            this.Property(t => t.DirectionY).HasColumnName("DirectionY");
            this.Property(t => t.PositionX).HasColumnName("PositionX");
            this.Property(t => t.PositionY).HasColumnName("PositionY");

            // Relationships
            this.HasRequired(t => t.Atom)
                .WithMany(t => t.AtomTicks)
                .HasForeignKey(d => d.AtomID);

        }
    }
}
