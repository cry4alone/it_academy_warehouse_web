namespace Storage.DAL.Models;

public partial class RefreshToken
{
    public int RefreshTokenId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public int? UserId { get; set; }

    public virtual SystemUser? User { get; set; }
}
