using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Models;
using Movie.Domain.Services;
using System.Text;

namespace Movie.App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileUploadController : Controller
    {
        private IFilePrcoessService _fileService;
        public FileUploadController(IFilePrcoessService fileService) 
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> ImportData(IFormFile file)
        {
            try
            {
                using(var reader = new StreamReader(file.OpenReadStream()))
                {
                    //invariant is uk and it gets used if any langauge gets translated
                    using(var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<MovieRecordModel>();
                  
                        var result =  _fileService.ImportMovies(records);
                    }
                }
            }catch (Exception ex)
            {
                return BadRequest();

            }
            return Ok();
        }
    }
}
