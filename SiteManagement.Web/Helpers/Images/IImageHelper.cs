using Microsoft.AspNetCore.Http;
using SiteManagement.Entity.DTOs.Images;
using SiteManagement.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadedDto> Upload(string imageName, IFormFile file, ImageType imageType, string folderName = null);
        void Delete(string imageName);
    }
}
