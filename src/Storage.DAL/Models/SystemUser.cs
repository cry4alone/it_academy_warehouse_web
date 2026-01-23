using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

/// <summary>
/// Пользователь системы.
/// Представляет запись из таблицы WAREHOUSE.SYSTEM_USER — содержит учётные данные и служебные поля аудита.
/// </summary>
public partial class SystemUser
{
    /// <summary>
    /// Идентификатор пользователя (PK).
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Логин пользователя (username), уникальный в рамках системы.
    /// </summary>
    public string Username { get; set; } = null!;

    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    public string Surname { get; set; } = null!;

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Отчество пользователя.
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// Хеш пароля пользователя.
    /// </summary>
    public string PasswordHash { get; set; } = null!;

    /// <summary>
    /// Идентификатор пользователя, который создал эту запись (FK на SYSTEM_USER).
    /// </summary>
    public int? CreatedByUserId { get; set; }

    /// <summary>
    /// Дата и время создания записи пользователя.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Идентификатор пользователя, который последний обновил эту запись (FK на SYSTEM_USER), если применимо.
    /// </summary>
    public int? UpdatedByUserId { get; set; }

    /// <summary>
    /// Дата и время последнего обновления записи.
    /// </summary>
    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    /// Идентификатор пользователя, который удалил эту запись (FK на SYSTEM_USER), если запись отмечена как удалённая.
    /// </summary>
    public int? DeletedByUserId { get; set; }

    /// <summary>
    /// Дата и время удаления записи.
    /// </summary>
    public DateTime? DeletedDate { get; set; }

    /// <summary>
    /// Связанные записи накладных приёмки, созданные пользователем.
    /// </summary>
    public virtual ICollection<AcceptanceInvoice> AcceptanceInvoices { get; set; } = new List<AcceptanceInvoice>();

    /// <summary>
    /// Коллекция сертификатов, созданных этим пользователем.
    /// </summary>
    public virtual ICollection<Certificate> CertificateCreatedByUsers { get; set; } = new List<Certificate>();

    /// <summary>
    /// Коллекция сертификатов, отмеченных этим пользователем как удалённые.
    /// </summary>
    public virtual ICollection<Certificate> CertificateDeletedByUsers { get; set; } = new List<Certificate>();

    /// <summary>
    /// Коллекция сертификатов, обновлённых этим пользователем.
    /// </summary>
    public virtual ICollection<Certificate> CertificateUpdatedByUsers { get; set; } = new List<Certificate>();

    /// <summary>
    /// Коллекция сертификатов, связанных с пользователем (например, пользователи-подписанты).
    /// </summary>
    public virtual ICollection<Certificate> CertificateUsers { get; set; } = new List<Certificate>();
    
    /// <summary>
    /// Коллекция refresh-токенов, выданных этому пользователю.
    /// </summary>
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    /// <summary>
    /// Пользователь, который создал эту запись (навигационное свойство).
    /// </summary>
    public virtual SystemUser? CreatedByUser { get; set; }

    /// <summary>
    /// Пользователь, который удалил эту запись (навигационное свойство).
    /// </summary>
    public virtual SystemUser? DeletedByUser { get; set; }

    /// <summary>
    /// Связанные записи о сторнировании документов, сделанные этим пользователем.
    /// </summary>
    public virtual ICollection<DocumentReversal> DocumentReversals { get; set; } = new List<DocumentReversal>();

    /// <summary>
    /// Обратная навигация — пользователи, созданные этим пользователем.
    /// </summary>
    public virtual ICollection<SystemUser> InverseCreatedByUser { get; set; } = new List<SystemUser>();

    /// <summary>
    /// Обратная навигация — пользователи, удалённые этим пользователем.
    /// </summary>
    public virtual ICollection<SystemUser> InverseDeletedByUser { get; set; } = new List<SystemUser>();

    /// <summary>
    /// Обратная навигация — пользователи, обновлённые этим пользователем.
    /// </summary>
    public virtual ICollection<SystemUser> InverseUpdatedByUser { get; set; } = new List<SystemUser>();

    /// <summary>
    /// Накладные (Invoice), созданные этим пользователем.
    /// </summary>
    public virtual ICollection<Invoice> InvoiceCreatedByUsers { get; set; } = new List<Invoice>();

    /// <summary>
    /// Накладные (Invoice), удалённые этим пользователем.
    /// </summary>
    public virtual ICollection<Invoice> InvoiceDeletedByUsers { get; set; } = new List<Invoice>();

    /// <summary>
    /// Накладные (Invoice), обновлённые этим пользователем.
    /// </summary>
    public virtual ICollection<Invoice> InvoiceUpdatedByUsers { get; set; } = new List<Invoice>();

    /// <summary>
    /// Накладные ручного взвешивания, созданные этим пользователем.
    /// </summary>
    public virtual ICollection<ManualWeighingInvoice> ManualWeighingInvoices { get; set; } = new List<ManualWeighingInvoice>();

    /// <summary>
    /// Заказы (PurchaseOrder), созданные этим пользователем.
    /// </summary>
    public virtual ICollection<PurchaseOrder> PurchaseOrderCreatedByUsers { get; set; } = new List<PurchaseOrder>();

    /// <summary>
    /// Заказы (PurchaseOrder), удалённые этим пользователем.
    /// </summary>
    public virtual ICollection<PurchaseOrder> PurchaseOrderDeletedByUsers { get; set; } = new List<PurchaseOrder>();

    /// <summary>
    /// Заказы (PurchaseOrder), обновлённые этим пользователем.
    /// </summary>
    public virtual ICollection<PurchaseOrder> PurchaseOrderUpdatedByUsers { get; set; } = new List<PurchaseOrder>();

    /// <summary>
    /// Перераспределения плавок, инициированные этим пользователем.
    /// </summary>
    public virtual ICollection<RedistributionOfMelting> RedistributionOfMeltings { get; set; } = new List<RedistributionOfMelting>();

    /// <summary>
    /// Пользователь, который последний обновил эту запись.
    /// </summary>
    public virtual SystemUser? UpdatedByUser { get; set; }
}
