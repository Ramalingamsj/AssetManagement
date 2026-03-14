using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Models;

public partial class AssetManagementContext : DbContext
{
    public AssetManagementContext()
    {
    }

    public AssetManagementContext(DbContextOptions<AssetManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssetDefinition> AssetDefinitions { get; set; }

    public virtual DbSet<AssetMaster> AssetMasters { get; set; }

    public virtual DbSet<AssetType> AssetTypes { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-PQT26L7\\SQLEXPRESS; Initial Catalog = AssetManagement; Integrated Security = True; Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssetDefinition>(entity =>
        {
            entity.HasKey(e => e.AssetDid).HasName("PK__AssetDef__ADBB1FBE50326FEA");

            entity.ToTable("AssetDefinition");

            entity.Property(e => e.AssetDid).HasColumnName("AssetDId");
            entity.Property(e => e.AssetDclass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AssetDClass");
            entity.Property(e => e.AssetDname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AssetDName");

            entity.HasOne(d => d.AssetType).WithMany(p => p.AssetDefinitions)
                .HasForeignKey(d => d.AssetTypeId)
                .HasConstraintName("foreginKeyAssetType");
        });

        modelBuilder.Entity<AssetMaster>(entity =>
        {
            entity.HasKey(e => e.AssetMid).HasName("PK__AssetMas__B3857470C8A2AB53");

            entity.ToTable("AssetMaster");

            entity.Property(e => e.AssetMid).HasColumnName("AssetMId");
            entity.Property(e => e.Amfrom).HasColumnName("AMfrom");
            entity.Property(e => e.Amto).HasColumnName("AMto");
            entity.Property(e => e.AssetDid).HasColumnName("AssetDId");
            entity.Property(e => e.Model)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Snumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SNumber");
            entity.Property(e => e.Warranty)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("warranty");
            entity.Property(e => e.Years)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.AssetD).WithMany(p => p.AssetMasters)
                .HasForeignKey(d => d.AssetDid)
                .HasConstraintName("ForeignKeyMAssetD");

            entity.HasOne(d => d.AssetType).WithMany(p => p.AssetMasters)
                .HasForeignKey(d => d.AssetTypeId)
                .HasConstraintName("ForeignKeyMAssetType");

            entity.HasOne(d => d.Vendor).WithMany(p => p.AssetMasters)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("ForeignKeyMVendor");
        });

        modelBuilder.Entity<AssetType>(entity =>
        {
            entity.HasKey(e => e.AssetTypeId).HasName("PK__AssetTyp__FD33C2C2153DFB6F");

            entity.ToTable("AssetType");

            entity.Property(e => e.AssetName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Lid).HasName("PK__Logins__C6555741C7EEC1FE");

            entity.Property(e => e.Lid).HasColumnName("LId");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.UserType).WithMany(p => p.Logins)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName("FK__Logins__UserType__38996AB5");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__Purchase__6B0A6BBE7A7D6FD1");

            entity.ToTable("PurchaseOrder");

            entity.Property(e => e.AssetDid).HasColumnName("AssetDId");
            entity.Property(e => e.OrderNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PurchaseDate).HasColumnName("Purchase_Date");
            entity.Property(e => e.PurchaseStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Purchase_Status");

            entity.HasOne(d => d.AssetD).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.AssetDid)
                .HasConstraintName("ForeignKeyAssetD");

            entity.HasOne(d => d.AssetType).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.AssetTypeId)
                .HasConstraintName("ForeignKeyAssetType");

            entity.HasOne(d => d.Vendor).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("ForeignKeyVendor");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C9F1206BA");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Lid).HasColumnName("LId");

            entity.HasOne(d => d.LidNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Lid)
                .HasConstraintName("ForeignKey");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.UserTypeId).HasName("PK__UserType__40D2D816951C891D");

            entity.ToTable("UserType");

            entity.Property(e => e.UserType1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UserType");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendor__FC8618F3F9BBFC13");

            entity.ToTable("Vendor");

            entity.Property(e => e.VendorAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.VendorFrom).HasColumnName("Vendor_From");
            entity.Property(e => e.VendorName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VendorTo).HasColumnName("Vendor_To");
            entity.Property(e => e.VendorType)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.AssetType).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.AssetTypeId)
                .HasConstraintName("foreginKeyVAssetType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
