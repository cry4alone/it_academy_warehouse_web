using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

/// <summary>
/// Сертификат — документ, связанный с поставкой (заказом) и содержащий набор плавок.
/// Представляет запись из таблицы WAREHOUSE.CERTIFICATE.
/// </summary>
public partial class Certificate
{
    /// <summary>
    /// Идентификатор сертификата (PK).
    /// </summary>
    public int CertificateId { get; set; }

    /// <summary>
    /// Идентификатор заказа / поставки (FK на PurchaseOrder).
    /// </summary>
    public int PurchaseOrderId { get; set; }

    /// <summary>
    /// Идентификатор склада, для которого оформлен сертификат (FK на Warehouse).
    /// </summary>
    public int WarehouseId { get; set; }

    /// <summary>
    /// Идентификатор схемы контроля (FK на ControlScheme).
    /// </summary>
    public int? ControlSchemeId { get; set; }

    /// <summary>
    /// Идентификатор подписанта.
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// Идентификатор пользователя, создавшего сертификат.
    /// </summary>
    public int CreatedByUserId { get; set; }

    /// <summary>
    /// Дата и время создания сертификата.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Идентификатор пользователя, который обновил сертификат.
    /// </summary>
    public int? UpdatedByUserId { get; set; }

    /// <summary>
    /// Дата и время последнего обновления сертификата.
    /// </summary>
    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    /// Идентификатор пользователя, который удалил сертификат.
    /// </summary>
    public int? DeletedByUserId { get; set; }

    /// <summary>
    /// Дата и время удаления сертификата.
    /// </summary>
    public DateTime? DeletedDate { get; set; }

    /// <summary>
    /// Накладные приёмки, связанные с данным сертификатом.
    /// </summary>
    public virtual ICollection<AcceptanceInvoice> AcceptanceInvoices { get; set; } = new List<AcceptanceInvoice>();

    /// <summary>
    /// Схема контроля, привязанная к сертификату.
    /// </summary>
    public virtual ControlScheme? ControlScheme { get; set; }

    /// <summary>
    /// Пользователь, создавший сертификат.
    /// </summary>
    public virtual SystemUser CreatedByUser { get; set; } = null!;

    /// <summary>
    /// Пользователь, удаливший сертификат .
    /// </summary>
    public virtual SystemUser? DeletedByUser { get; set; }

    /// <summary>
    /// Этикетки, связанные с сертификатом.
    /// </summary>
    public virtual ICollection<Label> Labels { get; set; } = new List<Label>();

    /// <summary>
    /// Плавки, входящие в сертификат.
    /// </summary>
    public virtual ICollection<Melt> Melts { get; set; } = new List<Melt>();

    /// <summary>
    /// Связанный заказ (PurchaseOrder).
    /// </summary>
    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;

    /// <summary>
    /// Перераспределения плавок, где этот сертификат выступает как источник.
    /// </summary>
    public virtual ICollection<RedistributionOfMelting> RedistributionOfMeltingCertificateFroms { get; set; } = new List<RedistributionOfMelting>();

    /// <summary>
    /// Перераспределения плавок, где этот сертификат выступает назначением.
    /// </summary>
    public virtual ICollection<RedistributionOfMelting> RedistributionOfMeltingCertificateTos { get; set; } = new List<RedistributionOfMelting>();

    /// <summary>
    /// Накладные отгрузки, связанные с сертификатом.
    /// </summary>
    public virtual ICollection<ShipmentInvoice> ShipmentInvoices { get; set; } = new List<ShipmentInvoice>();

    /// <summary>
    /// Пользователь, который обновил сертификат.
    /// </summary>
    public virtual SystemUser? UpdatedByUser { get; set; }

    /// <summary>
    /// Пользователь-подписант.
    /// </summary>
    public virtual SystemUser? User { get; set; }

    /// <summary>
    /// Склад, для которого оформлен сертификат.
    /// </summary>
    public virtual Warehouse Warehouse { get; set; } = null!;
}
