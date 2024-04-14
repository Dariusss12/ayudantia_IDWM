using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantia_IDWM.Src.DTOs;
using ayudantia_IDWM.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ayudantia_IDWM.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(IFormFile photo){
            var result = await _photoService.AddPhoto(photo);
            if(result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }

            PhotoDto photoDto = new PhotoDto
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            return Ok(photoDto);
        }
    }
}