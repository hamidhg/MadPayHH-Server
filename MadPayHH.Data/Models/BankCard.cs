using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MadPayHH.Data.Models
{
   public class BankCard:BaseEntity<string>
    {
        public BankCard()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated=DateTime.Now;
            DateModified=DateTime.Now;
        }
        [Required]
        public string Bankname { get; set; }

        public string Shaba { get; set; }
        [Required]
        [Range(16,16)]
        public string CardNumber { get; set; }
        [Required]
        [StringLength(2,MinimumLength = 2)]
        public string ExpireDatesMonth { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string ExpireDateYear { get; set; }

        [Required]
        public string UserId { get; set; }
        [Required]
        public User User { get; set; }


    }
}
