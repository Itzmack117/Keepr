using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
    public class DTOVaultedKeep
    {
        public int VaultId { get; set; }
        [Required]
        public int KeepId { get; set; }
        public int Id { get; set; }
        public string UserId {get; set;}
    }
}