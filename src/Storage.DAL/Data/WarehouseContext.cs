using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Storage.DAL.Models;

public partial class WarehouseContext : DbContext
{
    
    public WarehouseContext()
    {
    }

    public WarehouseContext(DbContextOptions<WarehouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcceptanceInvoice> AcceptanceInvoices { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<ControlScheme> ControlSchemes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DocumentReversal> DocumentReversals { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Label> Labels { get; set; }

    public virtual DbSet<ManualWeighingInvoice> ManualWeighingInvoices { get; set; }

    public virtual DbSet<ManualWeighingInvoiceMelt> ManualWeighingInvoiceMelts { get; set; }

    public virtual DbSet<Melt> Melts { get; set; }

    public virtual DbSet<MeltStatus> MeltStatuses { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Printer> Printers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<ReasonForReturn> ReasonForReturns { get; set; }

    public virtual DbSet<RedistributionOfMelting> RedistributionOfMeltings { get; set; }
    
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<ReturnInvoice> ReturnInvoices { get; set; }

    public virtual DbSet<ReturnInvoiceMelt> ReturnInvoiceMelts { get; set; }

    public virtual DbSet<ReturnType> ReturnTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<ShipmentInvoice> ShipmentInvoices { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    public virtual DbSet<SystemUser> SystemUsers { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<Weigher> Weighers { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Warehouse;User ID=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcceptanceInvoice>(entity =>
        {
            entity.HasKey(e => e.AcceptanceInvoiceId).HasName("PK__Acceptan__BF4D0D2B1A1915F7");

            entity.ToTable("AcceptanceInvoice");

            entity.HasIndex(e => e.CertificateId, "IX_AcceptanceInvoice_CertificateID");

            entity.HasIndex(e => e.InvoiceId, "IX_AcceptanceInvoice_InvoiceID");

            entity.HasIndex(e => e.RecipientWarehouseId, "IX_AcceptanceInvoice_RecipientWarehouseID");

            entity.HasIndex(e => e.SignedDate, "IX_AcceptanceInvoice_SignedDate");

            entity.HasIndex(e => e.UserId, "IX_AcceptanceInvoice_UserID");

            entity.Property(e => e.AcceptanceInvoiceId).HasColumnName("AcceptanceInvoiceID");
            entity.Property(e => e.CertificateId).HasColumnName("CertificateID");
            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.RecipientWarehouseId).HasColumnName("RecipientWarehouseID");
            entity.Property(e => e.SignedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Certificate).WithMany(p => p.AcceptanceInvoices)
                .HasForeignKey(d => d.CertificateId)
                .HasConstraintName("FK_AcceptanceInvoice_Certificate");

            entity.HasOne(d => d.Invoice).WithMany(p => p.AcceptanceInvoices)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcceptanceInvoice_Invoice");

            entity.HasOne(d => d.RecipientWarehouse).WithMany(p => p.AcceptanceInvoices)
                .HasForeignKey(d => d.RecipientWarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcceptanceInvoice_Warehouse");

            entity.HasOne(d => d.User).WithMany(p => p.AcceptanceInvoices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcceptanceInvoice_SystemUser");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brand__DAD4F3BE9F51836B");

            entity.ToTable("Brand");

            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.CertificateId).HasName("PK__Certific__BBF8A7E148A303B3");

            entity.ToTable("Certificate");

            entity.HasIndex(e => e.ControlSchemeId, "IX_Certificate_ControlSchemeID");

            entity.HasIndex(e => e.CreatedByUserId, "IX_Certificate_CreatedByUserID");

            entity.HasIndex(e => e.CreatedDate, "IX_Certificate_CreatedDate");

            entity.HasIndex(e => e.DeletedByUserId, "IX_Certificate_DeletedByUserID");

            entity.HasIndex(e => e.DeletedDate, "IX_Certificate_DeletedDate");

            entity.HasIndex(e => e.PurchaseOrderId, "IX_Certificate_PurchaseOrderID");

            entity.HasIndex(e => e.UpdatedByUserId, "IX_Certificate_UpdatedByUserID");

            entity.HasIndex(e => e.UpdatedDate, "IX_Certificate_UpdatedDate");

            entity.HasIndex(e => e.UserId, "IX_Certificate_UserID");

            entity.HasIndex(e => e.WarehouseId, "IX_Certificate_WarehouseID");

            entity.Property(e => e.CertificateId).HasColumnName("CertificateID");
            entity.Property(e => e.ControlSchemeId).HasColumnName("ControlSchemeID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedByUserId).HasColumnName("DeletedByUserID");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");
            entity.Property(e => e.UpdatedByUserId).HasColumnName("UpdatedByUserID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.HasOne(d => d.ControlScheme).WithMany(p => p.Certificates)
                .HasForeignKey(d => d.ControlSchemeId)
                .HasConstraintName("FK_Certificate_ControlScheme");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.CertificateCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Certificate_SystemUserCreatedByUserID");

            entity.HasOne(d => d.DeletedByUser).WithMany(p => p.CertificateDeletedByUsers)
                .HasForeignKey(d => d.DeletedByUserId)
                .HasConstraintName("FK_Certificate_SystemUserDeletedByUserID");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.Certificates)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Certificate_PurchaseOrder");

            entity.HasOne(d => d.UpdatedByUser).WithMany(p => p.CertificateUpdatedByUsers)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK_Certificate_SystemUserUpdatedByUserID");

            entity.HasOne(d => d.User).WithMany(p => p.CertificateUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Certificate_SystemUserUserID");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Certificates)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Certificate_Warehouse");
        });

        modelBuilder.Entity<ControlScheme>(entity =>
        {
            entity.HasKey(e => e.ControlSchemeId).HasName("PK__ControlS__11C3944835D040DF");

            entity.ToTable("ControlScheme");

            entity.HasIndex(e => e.BrandId, "IX_ControlScheme_BrandID");

            entity.HasIndex(e => e.ProductId, "IX_ControlScheme_ProductID");

            entity.HasIndex(e => e.SpecificationId, "IX_ControlScheme_SpecificationID");

            entity.Property(e => e.ControlSchemeId).HasColumnName("ControlSchemeID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SpecificationId).HasColumnName("SpecificationID");

            entity.HasOne(d => d.Brand).WithMany(p => p.ControlSchemes)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ControlScheme_Brand");

            entity.HasOne(d => d.Product).WithMany(p => p.ControlSchemes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ControlScheme_Product");

            entity.HasOne(d => d.Specification).WithMany(p => p.ControlSchemes)
                .HasForeignKey(d => d.SpecificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ControlScheme_Specification");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8A7FCA58C");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<DocumentReversal>(entity =>
        {
            entity.HasKey(e => e.DocumentReversalId).HasName("PK__Document__318C92244786685D");

            entity.ToTable("DocumentReversal");

            entity.HasIndex(e => e.CreatedByUserId, "IX_DocumentReversal_CreatedByUserID");

            entity.HasIndex(e => e.CreatedDate, "IX_DocumentReversal_CreatedDate");

            entity.HasIndex(e => e.ShipmentInvoiceId, "IX_DocumentReversal_ShipmentInvoiceID");

            entity.Property(e => e.DocumentReversalId).HasColumnName("DocumentReversalID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Reason).HasMaxLength(250);
            entity.Property(e => e.ShipmentInvoiceId).HasColumnName("ShipmentInvoiceID");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.DocumentReversals)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentReversal_SystemUser");

            entity.HasOne(d => d.ShipmentInvoice).WithMany(p => p.DocumentReversals)
                .HasForeignKey(d => d.ShipmentInvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentReversal_ShipmentInvoice");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoice__D796AAD59FDACED1");

            entity.ToTable("Invoice");

            entity.HasIndex(e => e.CreatedByUserId, "IX_Invoice_CreatedByUserID");

            entity.HasIndex(e => e.CreatedDate, "IX_Invoice_CreatedDate");

            entity.HasIndex(e => e.DeletedByUserId, "IX_Invoice_DeletedByUserID");

            entity.HasIndex(e => e.DeletedDate, "IX_Invoice_DeletedDate");

            entity.HasIndex(e => e.UpdatedByUserId, "IX_Invoice_UpdatedByUserID");

            entity.HasIndex(e => e.UpdatedDate, "IX_Invoice_UpdatedDate");

            entity.HasIndex(e => e.WarehouseId, "IX_Invoice_WarehouseID");

            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedByUserId).HasColumnName("DeletedByUserID");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedByUserId).HasColumnName("UpdatedByUserID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.InvoiceCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_SystemUserCreatedByUserID");

            entity.HasOne(d => d.DeletedByUser).WithMany(p => p.InvoiceDeletedByUsers)
                .HasForeignKey(d => d.DeletedByUserId)
                .HasConstraintName("FK_Invoice_SystemUserDeletedByUserID");

            entity.HasOne(d => d.UpdatedByUser).WithMany(p => p.InvoiceUpdatedByUsers)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK_Invoice_SystemUserUpdatedByUserID");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Warehouse");
        });

        modelBuilder.Entity<Label>(entity =>
        {
            entity.HasKey(e => e.LabelId).HasName("PK__Label__397E2BA3F2A190B4");

            entity.ToTable("Label");

            entity.HasIndex(e => e.CertificateId, "IX_Label_CertificateID");

            entity.HasIndex(e => e.MeltId, "IX_Label_MeltID");

            entity.Property(e => e.LabelId).HasColumnName("LabelID");
            entity.Property(e => e.CertificateId).HasColumnName("CertificateID");
            entity.Property(e => e.GrossB).HasColumnType("decimal(10, 1)");
            entity.Property(e => e.MeltId).HasColumnName("MeltID");
            entity.Property(e => e.NetB).HasColumnType("decimal(10, 1)");
            entity.Property(e => e.SizeInch).HasMaxLength(50);
            entity.Property(e => e.SizeMm).HasMaxLength(50);

            entity.HasOne(d => d.Certificate).WithMany(p => p.Labels)
                .HasForeignKey(d => d.CertificateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Label_Certificate");

            entity.HasOne(d => d.Melt).WithMany(p => p.Labels)
                .HasForeignKey(d => d.MeltId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Label_Melt");
        });

        modelBuilder.Entity<ManualWeighingInvoice>(entity =>
        {
            entity.HasKey(e => e.ManualWeighingInvoiceId).HasName("PK__ManualWe__C078FB318A9C256B");

            entity.ToTable("ManualWeighingInvoice");

            entity.Property(e => e.ManualWeighingInvoiceId).HasColumnName("ManualWeighingInvoiceID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.WeigherId).HasColumnName("WeigherID");

            entity.HasOne(d => d.Author).WithMany(p => p.ManualWeighingInvoices)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManualWeighingInvoice_SystemUser");

            entity.HasOne(d => d.Weigher).WithMany(p => p.ManualWeighingInvoices)
                .HasForeignKey(d => d.WeigherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManualWeighingInvoice_Weigher");
        });

        modelBuilder.Entity<ManualWeighingInvoiceMelt>(entity =>
        {
            entity.HasKey(e => e.ManualWeighingInvoiceMeltId).HasName("PK__ManualWe__EFD6374C76A7E163");

            entity.ToTable("ManualWeighingInvoice_Melt");

            entity.HasIndex(e => e.MeltId, "IX_ManualWeighingInvoiceMelt_MeltID");

            entity.Property(e => e.ManualWeighingInvoiceMeltId).HasColumnName("ManualWeighingInvoice_MeltID");
            entity.Property(e => e.ManualWeighingInvoiceId).HasColumnName("ManualWeighingInvoiceID");
            entity.Property(e => e.MeltId).HasColumnName("MeltID");

            entity.HasOne(d => d.ManualWeighingInvoice).WithMany(p => p.ManualWeighingInvoiceMelts)
                .HasForeignKey(d => d.ManualWeighingInvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManualWeighingInvoiceMelt_ManualWeighingInvoice");

            entity.HasOne(d => d.Melt).WithMany(p => p.ManualWeighingInvoiceMelts)
                .HasForeignKey(d => d.MeltId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManualWeighingInvoiceMelt_Melt");
        });

        modelBuilder.Entity<Melt>(entity =>
        {
            entity.HasKey(e => e.MeltId).HasName("PK__Melt__86037FF31AB77D25");

            entity.ToTable("Melt");

            entity.HasIndex(e => e.BrandId, "IX_Melt_BrandID");

            entity.HasIndex(e => e.CertificateId, "IX_Melt_CertificateID");

            entity.HasIndex(e => e.MeltStatusId, "IX_Melt_MeltStatusID");

            entity.HasIndex(e => e.ProductId, "IX_Melt_ProductID");

            entity.HasIndex(e => e.ProductionDate, "IX_Melt_ProductionDate");

            entity.HasIndex(e => e.SpecificationId, "IX_Melt_SpecificationID");

            entity.Property(e => e.MeltId).HasColumnName("MeltID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.CertificateId).HasColumnName("CertificateID");
            entity.Property(e => e.MeltStatusId).HasColumnName("MeltStatusID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SpecificationId).HasColumnName("SpecificationID");

            entity.HasOne(d => d.Brand).WithMany(p => p.Melts)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Melt_Brand");

            entity.HasOne(d => d.Certificate).WithMany(p => p.Melts)
                .HasForeignKey(d => d.CertificateId)
                .HasConstraintName("FK_Melt_Certificate");

            entity.HasOne(d => d.MeltStatus).WithMany(p => p.Melts)
                .HasForeignKey(d => d.MeltStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Melt_MeltStatus");

            entity.HasOne(d => d.Product).WithMany(p => p.Melts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Melt_Product");

            entity.HasOne(d => d.Specification).WithMany(p => p.Melts)
                .HasForeignKey(d => d.SpecificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Melt_Specification");
        });

        modelBuilder.Entity<MeltStatus>(entity =>
        {
            entity.HasKey(e => e.MeltStatusId).HasName("PK__MeltStat__8F9A30B760D1A21D");

            entity.ToTable("MeltStatus");

            entity.Property(e => e.MeltStatusId).HasColumnName("MeltStatusID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB0FD2C59D15");

            entity.ToTable("Permission");

            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Printer>(entity =>
        {
            entity.HasKey(e => e.PrinterId).HasName("PK__Printer__D452AB21436E464B");

            entity.ToTable("Printer");

            entity.Property(e => e.PrinterId).HasColumnName("PrinterID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED3987EAE0");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.SizeId).HasColumnName("SizeID");

            entity.HasOne(d => d.Size).WithMany(p => p.Products)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Size");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderId).HasName("PK__Purchase__036BAC44A545714D");

            entity.ToTable("PurchaseOrder");

            entity.HasIndex(e => e.CreatedByUserId, "IX_PurchaseOrder_CreatedByUserID");

            entity.HasIndex(e => e.CreatedDate, "IX_PurchaseOrder_CreatedDate");

            entity.HasIndex(e => e.CustomerId, "IX_PurchaseOrder_CustomerID");

            entity.HasIndex(e => e.DeletedByUserId, "IX_PurchaseOrder_DeletedByUserID");

            entity.HasIndex(e => e.DeletedDate, "IX_PurchaseOrder_DeletedDate");

            entity.HasIndex(e => e.UpdatedByUserId, "IX_PurchaseOrder_UpdatedByUserID");

            entity.HasIndex(e => e.UpdatedDate, "IX_PurchaseOrder_UpdatedDate");

            entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeletedByUserId).HasColumnName("DeletedByUserID");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.TransportId).HasColumnName("TransportID");
            entity.Property(e => e.UpdatedByUserId).HasColumnName("UpdatedByUserID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.PurchaseOrderCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseOrder_SystemUserCreatedByUserID");

            entity.HasOne(d => d.Customer).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseOrder_Customer");

            entity.HasOne(d => d.DeletedByUser).WithMany(p => p.PurchaseOrderDeletedByUsers)
                .HasForeignKey(d => d.DeletedByUserId)
                .HasConstraintName("FK_PurchaseOrder_SystemUserDeletedByUserID");

            entity.HasOne(d => d.Transport).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.TransportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseOrder_Transport");

            entity.HasOne(d => d.UpdatedByUser).WithMany(p => p.PurchaseOrderUpdatedByUsers)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK_PurchaseOrder_SystemUserUpdatedByUserID");
        });

        modelBuilder.Entity<ReasonForReturn>(entity =>
        {
            entity.HasKey(e => e.ReasonForReturnId).HasName("PK__ReasonFo__2742A4C050249FB2");

            entity.ToTable("ReasonForReturn");

            entity.Property(e => e.ReasonForReturnId).HasColumnName("ReasonForReturnID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<RedistributionOfMelting>(entity =>
        {
            entity.HasKey(e => e.RedistributionOfMeltingId).HasName("PK__Redistri__28C3F9D191D7AC96");

            entity.ToTable("RedistributionOfMelting");

            entity.HasIndex(e => e.CertificateFromId, "IX_RedistributionOfMelting_CertificateFromID");

            entity.HasIndex(e => e.CertificateToId, "IX_RedistributionOfMelting_CertificateToID");

            entity.HasIndex(e => e.CreatedByUserId, "IX_RedistributionOfMelting_CreatedByUserID");

            entity.HasIndex(e => e.CreatedDate, "IX_RedistributionOfMelting_CreatedDate");

            entity.HasIndex(e => e.MeltId, "IX_RedistributionOfMelting_MeltID");

            entity.Property(e => e.RedistributionOfMeltingId).HasColumnName("RedistributionOfMeltingID");
            entity.Property(e => e.CertificateFromId).HasColumnName("CertificateFromID");
            entity.Property(e => e.CertificateToId).HasColumnName("CertificateToID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MeltId).HasColumnName("MeltID");

            entity.HasOne(d => d.CertificateFrom).WithMany(p => p.RedistributionOfMeltingCertificateFroms)
                .HasForeignKey(d => d.CertificateFromId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RedistributionOfMelting_CertificateFrom");

            entity.HasOne(d => d.CertificateTo).WithMany(p => p.RedistributionOfMeltingCertificateTos)
                .HasForeignKey(d => d.CertificateToId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RedistributionOfMelting_CertificateTo");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.RedistributionOfMeltings)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RedistributionOfMelting_SystemUser");

            entity.HasOne(d => d.Melt).WithMany(p => p.RedistributionOfMeltings)
                .HasForeignKey(d => d.MeltId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RedistributionOfMelting_Melt");
        });
        
        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.RefreshTokenId).HasName("PK__RefreshT__F5845E593752DA6A");

            entity.ToTable("RefreshToken");

            entity.Property(e => e.RefreshTokenId).HasColumnName("RefreshTokenID");
            entity.Property(e => e.ExpiresAt).HasColumnType("datetime");
            entity.Property(e => e.Token)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ReturnInvoice>(entity =>
        {
            entity.HasKey(e => e.ReturnInvoiceId).HasName("PK__ReturnIn__FBEC68D083102C43");

            entity.ToTable("ReturnInvoice");

            entity.HasIndex(e => e.InvoiceId, "IX_ReturnInvoice_InvoiceID");

            entity.HasIndex(e => e.RecipientWarehouseId, "IX_ReturnInvoice_RecipientWarehouseID");

            entity.Property(e => e.ReturnInvoiceId).HasColumnName("ReturnInvoiceID");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.ReasonForReturnId).HasColumnName("ReasonForReturnID");
            entity.Property(e => e.RecipientWarehouseId).HasColumnName("RecipientWarehouseID");
            entity.Property(e => e.ReturnTypeId).HasColumnName("ReturnTypeID");

            entity.HasOne(d => d.Invoice).WithMany(p => p.ReturnInvoices)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReturnInvoice_Invoice");

            entity.HasOne(d => d.ReasonForReturn).WithMany(p => p.ReturnInvoices)
                .HasForeignKey(d => d.ReasonForReturnId)
                .HasConstraintName("FK_ReturnInvoice_ReasonForReturn");

            entity.HasOne(d => d.RecipientWarehouse).WithMany(p => p.ReturnInvoices)
                .HasForeignKey(d => d.RecipientWarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReturnInvoice_Warehouse");

            entity.HasOne(d => d.ReturnType).WithMany(p => p.ReturnInvoices)
                .HasForeignKey(d => d.ReturnTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReturnInvoice_ReturnType");
        });

        modelBuilder.Entity<ReturnInvoiceMelt>(entity =>
        {
            entity.HasKey(e => e.ReturnInvoiceMeltId).HasName("PK__ReturnIn__D2574FD7D66BAC8B");

            entity.ToTable("ReturnInvoice_Melt");

            entity.HasIndex(e => e.MeltId, "IX_ReturnInvoiceMelt_MeltID");

            entity.HasIndex(e => e.ReturnInvoiceId, "IX_ReturnInvoiceMelt_ReturnInvoiceID");

            entity.Property(e => e.ReturnInvoiceMeltId).HasColumnName("ReturnInvoice_MeltID");
            entity.Property(e => e.MeltId).HasColumnName("MeltID");
            entity.Property(e => e.ReturnInvoiceId).HasColumnName("ReturnInvoiceID");

            entity.HasOne(d => d.Melt).WithMany(p => p.ReturnInvoiceMelts)
                .HasForeignKey(d => d.MeltId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReturnInvoice_Melt");

            entity.HasOne(d => d.ReturnInvoice).WithMany(p => p.ReturnInvoiceMelts)
                .HasForeignKey(d => d.ReturnInvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReturnInvoiceMelt_ReturnInvoice");
        });

        modelBuilder.Entity<ReturnType>(entity =>
        {
            entity.HasKey(e => e.ReturnTypeId).HasName("PK__ReturnTy__A2DEAE18AF5C96BB");

            entity.ToTable("ReturnType");

            entity.Property(e => e.ReturnTypeId).HasColumnName("ReturnTypeID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3ADDC9C2DC");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Role_Permission");

            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Permission).WithMany()
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Permission");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Role");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Section__80EF08922DA0F002");

            entity.ToTable("Section");

            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Sections)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Section_Warehouse");
        });

        modelBuilder.Entity<ShipmentInvoice>(entity =>
        {
            entity.HasKey(e => e.ShipmentInvoiceId).HasName("PK__Shipment__FD87BED5D0D73A17");

            entity.ToTable("ShipmentInvoice");

            entity.HasIndex(e => e.CertificateId, "IX_ShipmentInvoice_CertificateID");

            entity.HasIndex(e => e.InvoiceId, "IX_ShipmentInvoice_InvoiceID");

            entity.HasIndex(e => e.PurchaseOrderId, "IX_ShipmentInvoice_PurchaseOrderID");

            entity.Property(e => e.ShipmentInvoiceId).HasColumnName("ShipmentInvoiceID");
            entity.Property(e => e.CertificateId).HasColumnName("CertificateID");
            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

            entity.HasOne(d => d.Certificate).WithMany(p => p.ShipmentInvoices)
                .HasForeignKey(d => d.CertificateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShipmentInvoice_Certificate");

            entity.HasOne(d => d.Invoice).WithMany(p => p.ShipmentInvoices)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShipmentInvoice_Invoice");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.ShipmentInvoices)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShipmentInvoice_PurchaseOrder");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK__Size__83BD095A653146FD");

            entity.ToTable("Size");

            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.Height).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Length).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Radius).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Width).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.HasKey(e => e.SpecificationId).HasName("PK__Specific__A384CC1DEC41A671");

            entity.ToTable("Specification");

            entity.Property(e => e.SpecificationId).HasColumnName("SpecificationID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<SystemUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__SystemUs__1788CCAC1A986395");

            entity.ToTable("SystemUser");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedByUserId).HasColumnName("DeletedByUserID");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.MiddleName).HasMaxLength(30);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Surname).HasMaxLength(30);
            entity.Property(e => e.UpdatedByUserId).HasColumnName("UpdatedByUserID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(30);

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.InverseCreatedByUser)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK_SystemUser_SystemUserCreatedByUserID");

            entity.HasOne(d => d.DeletedByUser).WithMany(p => p.InverseDeletedByUser)
                .HasForeignKey(d => d.DeletedByUserId)
                .HasConstraintName("FK_SystemUser_SystemUserDeletedByUserID");

            entity.HasOne(d => d.UpdatedByUser).WithMany(p => p.InverseUpdatedByUser)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK_SystemUser_SystemUserUpdatedByUserID");
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.TransportId).HasName("PK__Transpor__19E9A17D2FD6BC9D");

            entity.ToTable("Transport");

            entity.Property(e => e.TransportId).HasColumnName("TransportID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User_Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_Role");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_SystemUser");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__Warehous__2608AFD9A0947A9B");

            entity.ToTable("Warehouse");

            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Weigher>(entity =>
        {
            entity.HasKey(e => e.WeigherId).HasName("PK__Weigher__9596FC4BB91BE414");

            entity.ToTable("Weigher");

            entity.Property(e => e.WeigherId).HasColumnName("WeigherID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
