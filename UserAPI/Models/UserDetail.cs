using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class UserDetails
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; } = "";

    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; } = "";

    [Column(TypeName = "nvarchar(100)")]
    public string Email { get; set; } = "";

    public int Age { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string MobileNumber { get; set; } = "";

    [Column(TypeName = "nvarchar(255)")]
    public string Address { get; set; } = "";

    [Column(TypeName = "nvarchar(255)")]
    public string Password { get; set; } = "";

    [Column(TypeName = "varbinary(max)")]
    public byte[] ProfilePhoto { get; set; } = new byte[0];

    [NotMapped]
    public string ProfilePhotoBase64 { get; set; } // Helper property for base64 string
}
