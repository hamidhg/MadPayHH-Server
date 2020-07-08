using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MadPayHH.Data.Dto.Site.Admin
{
    public class UserForRegsiterDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نمی باشد")]
        public string Username { get; set; }
        [Required]
        [StringLength(10,MinimumLength = 4,ErrorMessage = "رمز عبور بین 4 الی 10 کاراکتر باشد")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }








    }
}
