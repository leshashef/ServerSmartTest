using Microsoft.EntityFrameworkCore;

namespace ServerSmartTest.Model.Context
{
    public class AppDBContext : DbContext
    {
        public virtual DbSet<Quests> Quests { get; set; } = null!;
        public virtual DbSet<SmartTests> SmartTests { get; set; } = null!;
        public virtual DbSet<Users> Users { get; set; } = null!;

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=DESKTOP-QFHLJ6R;Initial Catalog=apphax;Integrated Security=True");
        //            }
        //        }
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quests>(entity =>
            {
                entity.Property(e => e.Jsontext)
                    .HasColumnType("text")
                    .HasColumnName("JSONText");

                entity.Property(e => e.NameQuests).HasMaxLength(255);

                entity.HasOne(d => d.SmartTests)
                    .WithMany(p => p.Quests)
                    .HasForeignKey(d => d.SmartTestsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Quests__SmartTes__2F10007B");
            });

            modelBuilder.Entity<SmartTests>(entity =>
            {
                entity.Property(e => e.TestName).HasMaxLength(255);

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.SmartTests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SmartTest__UserI__2C3393D0");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            //OnModelCreatingPartial(modelBuilder);
        }

       // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
