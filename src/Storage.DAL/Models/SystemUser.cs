using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class SystemUser
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string PasswordHash { get; set; } = null!;

    public int? CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedByUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<AcceptanceInvoice> AcceptanceInvoices { get; set; } = new List<AcceptanceInvoice>();

    public virtual ICollection<Certificate> CertificateCreatedByUsers { get; set; } = new List<Certificate>();

    public virtual ICollection<Certificate> CertificateDeletedByUsers { get; set; } = new List<Certificate>();

    public virtual ICollection<Certificate> CertificateUpdatedByUsers { get; set; } = new List<Certificate>();

    public virtual ICollection<Certificate> CertificateUsers { get; set; } = new List<Certificate>();
    
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual SystemUser? CreatedByUser { get; set; }

    public virtual SystemUser? DeletedByUser { get; set; }

    public virtual ICollection<DocumentReversal> DocumentReversals { get; set; } = new List<DocumentReversal>();

    public virtual ICollection<SystemUser> InverseCreatedByUser { get; set; } = new List<SystemUser>();

    public virtual ICollection<SystemUser> InverseDeletedByUser { get; set; } = new List<SystemUser>();

    public virtual ICollection<SystemUser> InverseUpdatedByUser { get; set; } = new List<SystemUser>();

    public virtual ICollection<Invoice> InvoiceCreatedByUsers { get; set; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceDeletedByUsers { get; set; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceUpdatedByUsers { get; set; } = new List<Invoice>();

    public virtual ICollection<ManualWeighingInvoice> ManualWeighingInvoices { get; set; } = new List<ManualWeighingInvoice>();

    public virtual ICollection<PurchaseOrder> PurchaseOrderCreatedByUsers { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<PurchaseOrder> PurchaseOrderDeletedByUsers { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<PurchaseOrder> PurchaseOrderUpdatedByUsers { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<RedistributionOfMelting> RedistributionOfMeltings { get; set; } = new List<RedistributionOfMelting>();

    public virtual SystemUser? UpdatedByUser { get; set; }
}
