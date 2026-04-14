using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Users
{
    public class UserAddDto
    {
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim alanı zorunludur.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-posta alanı zorunludur.")]
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        // UI'dan dosya seçmek için (Veritabanına kaydedilmez)
        public IFormFile? ProfileImage { get; set; }

        // Veritabanına gidecek olan dosya yolu (AutoMapper için)
        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Rol seçimi zorunludur.")]
        public Guid RoleId { get; set; }
    }
}
