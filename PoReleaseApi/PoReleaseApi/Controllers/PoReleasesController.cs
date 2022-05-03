#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoReleaseApi.Models;

namespace PoReleaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoReleasesController : ControllerBase
    {
        private readonly PoReleaseContext _context;

        public PoReleasesController(PoReleaseContext context)
        {
            _context = context;
        }

        // GET: api/PoReleases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoRelease>>> GetPoReleases()
        {
            return await _context.PoReleases.ToListAsync();
        }

        // GET: api/PoReleases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PoRelease>> GetPoRelease(int id)
        {
            var poRelease = await _context.PoReleases.FindAsync(id);

            if (poRelease == null)
            {
                return NotFound();
            }

            return poRelease;
        }

        // PUT: api/PoReleases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoRelease(int id, PoRelease poRelease)
        {
            if (id != poRelease.Id)
            {
                return BadRequest();
            }

            _context.Entry(poRelease).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoReleaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost("UploadFile")]
        public IActionResult UploadFile()
        {
            
            
            try
            {
                // 1. get the file form the request
                var postedFile = Request.Form.Files[0];

                // 2. set the file uploaded folder
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
                // 3. check for the file length, if it is more than 0 the save it
                if (postedFile.Length > 0)
                {
                    // 3a. read the file name of the received file
                    var fileName = ContentDispositionHeaderValue.Parse(postedFile.ContentDisposition)
                        .FileName.Trim('"');
                    // 3b. save the file on Path
                    var finalPath = Path.Combine(uploadFolder, fileName);
                    using(var fileStream = new FileStream(finalPath, FileMode.Create))
                    {
                        postedFile.CopyTo(fileStream);
                    }

                    var responseContent = new UploadResult
                    {
                        fileName = fileName,
                        uploadedPath = finalPath
                    }; 

                    return Ok(responseContent);
                }
                else
                {
                    return BadRequest("The File is not received.");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Some Error Occcured while uploading File {ex.Message}");
            }
        }

        // POST: api/PoReleases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PoRelease>> PostPoRelease(PoRelease poRelease)
        {
            _context.PoReleases.Add(poRelease);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoRelease", new { id = poRelease.Id }, poRelease);
        }

        // DELETE: api/PoReleases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoRelease(int id)
        {
            var poRelease = await _context.PoReleases.FindAsync(id);
            if (poRelease == null)
            {
                return NotFound();
            }

            _context.PoReleases.Remove(poRelease);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoReleaseExists(int id)
        {
            return _context.PoReleases.Any(e => e.Id == id);
        }
    }
    class UploadResult
    {
        public string fileName { get; set; }
        public string uploadedPath { get; set; }
    }
}
