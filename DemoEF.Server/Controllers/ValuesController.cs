using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DemoEF.Core.Entity;
using DemoEF.Data.DemoDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoEF.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly string location = @"C:\Users\shsh\Storage\000\DemoEF\";
        DemoContext _data = new DemoContext();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null)
            {
                if (!Directory.Exists(location))
                {
                    Directory.CreateDirectory(location);
                }

                var addFile = Path.Combine(location, Path.GetFileName(file.FileName));
                using (FileStream addfil = new FileStream(addFile, FileMode.Create))
                {
                    await file.CopyToAsync(addfil);
                }

                FileMaster fl = new FileMaster
                {
                    Id = 0,
                    FileName = Path.GetFileName(file.FileName),
                    ClientFilePath = Path.GetFullPath(file.FileName),
                    DateUploaded = DateTime.Today,
                    DateUpdated = DateTime.Today,
                    Location = location,
                    Type = Path.GetExtension(file.FileName),
                    Size = file.Length

                }; 

                await _data.Files.AddAsync(fl);
                await _data.SaveChangesAsync();

                
                return Ok();
            }
            return BadRequest();
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                FileMaster oldFile = (from fil in await _data.Files.ToListAsync()
                                      where fil.Id == id
                                      select fil).FirstOrDefault();


                if (oldFile != null)
                {
                    System.IO.File.Delete(oldFile.Location + "\\" + oldFile.FileName);

                    _data.Remove(oldFile);
                    await _data.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest();
            }
            return BadRequest();
        }

        #region get the name of file from the id passed by client
        private async Task<IActionResult> ConvertIdToString(string name)
        {
            if (name != null)
            {
                var theFile = (from f in await _data.Files.ToListAsync()
                               where f.FileName == name
                               select f.Id).FirstOrDefault();
                //await Delete(theFile);

            }
            return BadRequest();
        }
        #endregion
    }
}
