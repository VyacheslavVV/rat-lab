using System.ComponentModel.DataAnnotations;

namespace Billing_API.Classes;

public class RedisOptions
{
    [Required]
    public bool Enabled { get; set; }

    [Required]
    public string Host { get; set; } = string.Empty;

    [Required]
    public int DefaultDatabase { get; set; }

    [Required]
    public string User { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string KeyPrefix { get; set; } = string.Empty;
}
