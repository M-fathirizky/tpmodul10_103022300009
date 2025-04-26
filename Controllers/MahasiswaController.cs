using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace tpmodul10_103022300009.Controllers
{
    [Route("api/mahasiswa")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa("Muhammad Fathir Rizky Salam", "103022300009"),
            new Mahasiswa("Hafizryandin Haykal M", "103022300158"),
            new Mahasiswa("Hafidz Naufal Pradana", "103022300163"),
            new Mahasiswa("Haidar Zahran Haryono", "103022330140"),
        };

        //mengembalikan output berupa list/array dari semua objek mahasiswa yang tersimpan
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAllMahasiswa()
        {
            return Ok(mahasiswaList);
        }

        //mengembalikan output berupa objek mahasiswa untuk index ke-‘index'
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();

            return Ok(mahasiswaList[index]);
        }

        // menambahkan objek mahasiswa baru dengan menyertakan nama dan nim
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa newMahasiswa)
        {
            if (newMahasiswa == null)
                return BadRequest("Data mahasiswa tidak boleh kosong.");

            mahasiswaList.Add(newMahasiswa);

            return CreatedAtAction(nameof(GetMahasiswaByIndex), new { index = mahasiswaList.Count - 1 }, newMahasiswa);
        }

        // Melakukan Penghapusan objek mahasiswa dengan index ke-‘index’
        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();

            mahasiswaList.RemoveAt(index);
            return NoContent();
        }
    }
}
