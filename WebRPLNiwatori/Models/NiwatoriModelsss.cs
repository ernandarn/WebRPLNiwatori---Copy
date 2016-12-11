namespace WebRPLNiwatori.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NiwatoriModelsss : DbContext
    {
        public NiwatoriModelsss()
            : base("name=NiwatoriModelsss")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Barang> Barang { get; set; }
        public virtual DbSet<Detail_Pemesanan> Detail_Pemesanan { get; set; }
        public virtual DbSet<Formulir_Order> Formulir_Order { get; set; }
        public virtual DbSet<Keranjang_Belanja> Keranjang_Belanja { get; set; }
        public virtual DbSet<Master_Kecamatan> Master_Kecamatan { get; set; }
        public virtual DbSet<Metode_Bayar> Metode_Bayar { get; set; }
        public virtual DbSet<Nota_Pemesanan> Nota_Pemesanan { get; set; }
        public virtual DbSet<Pengguna> Pengguna { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Barang>()
                .Property(e => e.Nama_Barang)
                .IsUnicode(false);

            modelBuilder.Entity<Barang>()
                .Property(e => e.Gambar)
                .IsUnicode(false);

            modelBuilder.Entity<Barang>()
                .Property(e => e.Satuan)
                .IsUnicode(false);

            modelBuilder.Entity<Barang>()
                .Property(e => e.Harga)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Barang>()
                .HasMany(e => e.Detail_Pemesanan)
                .WithRequired(e => e.Barang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Barang>()
                .HasMany(e => e.Keranjang_Belanja)
                .WithRequired(e => e.Barang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Detail_Pemesanan>()
                .Property(e => e.Harga)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Formulir_Order>()
                .Property(e => e.Alamat)
                .IsUnicode(false);

            modelBuilder.Entity<Formulir_Order>()
                .Property(e => e.No_Hp)
                .IsUnicode(false);

            modelBuilder.Entity<Keranjang_Belanja>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Master_Kecamatan>()
                .Property(e => e.Nama_Kec)
                .IsUnicode(false);

            modelBuilder.Entity<Master_Kecamatan>()
                .Property(e => e.Nama_Kab)
                .IsUnicode(false);

            modelBuilder.Entity<Master_Kecamatan>()
                .HasMany(e => e.Formulir_Order)
                .WithRequired(e => e.Master_Kecamatan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nota_Pemesanan>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Nota_Pemesanan>()
                .HasOptional(e => e.Detail_Pemesanan)
                .WithRequired(e => e.Nota_Pemesanan);

            modelBuilder.Entity<Pengguna>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Pengguna>()
                .Property(e => e.Nama_pengguna)
                .IsUnicode(false);

            modelBuilder.Entity<Pengguna>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Pengguna>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<Pengguna>()
                .HasMany(e => e.Nota_Pemesanan)
                .WithRequired(e => e.Pengguna)
                .WillCascadeOnDelete(false);
        }
    }
}
