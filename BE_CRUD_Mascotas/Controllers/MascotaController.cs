using AutoMapper;
using BE_CRUD_Mascotas.Models;
using BE_CRUD_Mascotas.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal.TypeHandlers.DateTimeHandlers;
using NpgsqlTypes;
using Npgsql;
using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BE_CRUD_Mascotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        private readonly IMapper _mapper;

        public MascotaController(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                Thread.Sleep(1000);
                var listMascotas = await _context.Mascotas.ToListAsync();

                var listMascotasDto = _mapper.Map<IEnumerable <MascotaDTO>>(listMascotas);

                return Ok(listMascotasDto);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                // Thread.Sleep(1000);
                var mascota = await _context.Mascotas.FindAsync(id);
                if (mascota == null)
                {
                    return NotFound();
                }
                var mascotaDto = _mapper.Map<MascotaDTO>(mascota);

                return Ok(mascotaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(MascotaDTO mascotaDto)

        {
            try
            {      

                var mascota = _mapper.Map<Mascota>(mascotaDto);
             
              //  mascota.FechaCreacion = DateTime.Now.Date;              

               // string fechaMascota = mascota.FechaCreacion.ToString();
                         
                _context.Add(mascota);
                await _context.SaveChangesAsync();

                var mascotaItemDto = _mapper.Map<MascotaDTO>(mascota);
                return CreatedAtAction("Get", new { id = mascotaItemDto.Id }, mascotaItemDto);

            }
            catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Thread.Sleep(1000);
                var mascota = await _context.Mascotas.FindAsync(id);
                if (mascota == null)
                {
                    return NotFound();
                }
                _context.Mascotas.Remove(mascota);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, MascotaDTO mascotaDto)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDto);

                if (id != mascota.Id)
                {
                    return BadRequest();
                }
                var mascotaItem = await _context.Mascotas.FindAsync(id);

                if (mascotaItem == null)
                {
                    return NotFound();
                }
                mascotaItem.Nombre = mascota.Nombre;
                mascotaItem.Edad = mascota.Edad;
                mascotaItem.Raza = mascota.Raza;
                mascotaItem.Color = mascota.Color;
                mascotaItem.Peso = mascota.Peso;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}