using APMS.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace APMS.Data.Entities
{
    public class User : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(128)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }
    }
}
