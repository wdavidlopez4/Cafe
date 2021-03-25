using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe.Web.Api.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        [Route("Cuenta")]
        [HttpPost]
        public async Task<IActionResult> CrearCuenta(string nombre, string correo, string contraseña)
        {
            return await Task.FromResult(Ok($"registrado: {nombre}, {correo}, {contraseña}"));
        }

        [Route("Logear")]
        [HttpPost]
        public async Task<IActionResult> Logearse([FromBody] string correo, string contraseña)
        {
            return await Task.FromResult(Ok($"logeado: {correo}, {contraseña}"));
        }
    }
}
