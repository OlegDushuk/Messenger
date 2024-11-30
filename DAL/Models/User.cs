using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.DAL.Models;

public class User
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public Guid Id { get; set; }
  
  [Required]
  [EmailAddress]
  [MaxLength(255)]
  public string? Email { get; set; }
  
  [Required]
  [MaxLength(50)]
  public string? Username { get; set; }
  
  [Required]
  [MaxLength(256)]
  public string? PasswordHash { get; set; }
  
  [MaxLength(100)]
  public string? Name { get; set; }
  
  public DateTime CreatedAd { get; set; }
}