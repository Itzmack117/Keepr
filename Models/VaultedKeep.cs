using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
    public class DTOVaultedKeep
    {
        public int VaultId { get; set; }
        [Required]
        public int CarId { get; set; }
        public string UserId { get; set; }
    }
}