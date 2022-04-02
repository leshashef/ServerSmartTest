using Microsoft.EntityFrameworkCore;

namespace ServerSmartTest.Model.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Quests> Quests { get; set; } = null!;
        public virtual DbSet<ResultTest> ResultTests { get; set; } = null!;
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
                    .HasConstraintName("FK__Quests__SmartTes__3E52440B");
            });

            modelBuilder.Entity<ResultTest>(entity =>
            {
                entity.ToTable("ResultTest");

                entity.Property(e => e.ResultName).HasMaxLength(255);

                entity.HasOne(d => d.SmartTests)
                    .WithMany(p => p.ResultTests)
                    .HasForeignKey(d => d.SmartTestsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ResultTes__Smart__3B75D760");
            });

            modelBuilder.Entity<SmartTests>(entity =>
            {
                entity.Property(e => e.ImgPath).HasColumnType("text");

                entity.Property(e => e.TestName).HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SmartTests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SmartTest__UserI__38996AB5");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
