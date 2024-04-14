using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;

namespace ayudantia_IDWM.Src.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhoto(IFormFile photo);

        Task<DeletionResult> DeletePhoto(string publicId);
    }
}