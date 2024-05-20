using AutoMapper;
using BE_CRUD_App_Allied.Models;
using BE_CRUD_App_Allied.Models.DTO;
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

namespace BE_CRUD_App_Allied.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario_AlliedController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        private readonly IMapper _mapper;

        public Usuario_AlliedController(AplicationDbContext context, IMapper mapper)
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
                var usuario_Allied = await _context.Usuarios.ToListAsync();

                var usuario_AlliedDto = _mapper.Map<IEnumerable <Usuario_AlliedDTO>>(usuario_Allied);

                return Ok(usuario_AlliedDto);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex);
            }
        }

        [HttpGet("{ced}")]

        public async Task<IActionResult> Get(int ced)
        {
            try
            {
                // Thread.Sleep(1000);
                var usuario_Allied = await _context.Usuarios.FindAsync(ced);
                if (usuario_Allied == null)
                {
                    return NotFound();
                }
                var usuario_AlliedDto = _mapper.Map<Usuario_AlliedDTO>(usuario_Allied);

                return Ok(usuario_AlliedDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(Usuario_AlliedDTO usuario_AlliedDto)
        {
            try
            {      
                var usuario_Allied = _mapper.Map<Usuario_Allied>(usuario_AlliedDto);
             
              //  mascota.FechaCreacion = DateTime.Now.Date;              

               // string fechaMascota = mascota.FechaCreacion.ToString();
                         
                _context.Add(usuario_Allied);
                await _context.SaveChangesAsync();

                var usuario_AlliedItemDto = _mapper.Map<Usuario_AlliedDTO>(usuario_Allied);
                return CreatedAtAction("Get", new { ced = usuario_AlliedItemDto.Cedula }, usuario_AlliedItemDto);

            }
            catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{ced}")]

        public async Task<IActionResult> Delete(int ced)
        {
            try
            {
                // Thread.Sleep(1000);
                var usuario_Allied = await _context.Usuarios.FindAsync(ced);
                if (usuario_Allied == null)
                {
                    return NotFound();
                }
                _context.Usuarios.Remove(usuario_Allied);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        [HttpPut("{ced}")]

        public async Task<IActionResult> Put(int ced, Usuario_AlliedDTO usuario_AlliedDto)
        {
            try
            {
                var usuario_Allied = _mapper.Map<Usuario_Allied>(usuario_AlliedDto);

                if (ced != usuario_Allied.Cedula)
                {
                    return BadRequest();
                }
                var usuario_AlliedItem = await _context.Usuarios.FindAsync(ced);

                if (usuario_AlliedItem == null)
                {
                    return NotFound();
                }
                usuario_AlliedItem.Nombre = usuario_AlliedItem.Nombre;
                usuario_AlliedItem.Apellido = usuario_AlliedItem.Apellido;
                usuario_AlliedItem.Cargo = usuario_AlliedItem.Cargo;
                usuario_AlliedItem.Empresa = usuario_AlliedItem.Empresa;
               // usuario_AlliedItem.Fecha_Ingreso = usuario_AlliedItem.Fecha_Ingreso;
                usuario_AlliedItem.Genero = usuario_AlliedItem.Genero;
                usuario_AlliedItem.Eps = usuario_AlliedItem.Eps;
                usuario_AlliedItem.Arl = usuario_AlliedItem.Arl;
                usuario_AlliedItem.Celular = usuario_AlliedItem.Celular;
               // usuario_AlliedItem.Fecha_Nacimiento = usuario_AlliedItem.Fecha_Nacimiento;
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