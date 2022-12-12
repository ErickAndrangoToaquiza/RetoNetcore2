
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autentificacion.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize] 
public class VerificacionAutorizacionController : ControllerBase
{
   

    [HttpGet("nombre")]
    public string ObtenerNombre (){
        return "Cesar Garcia";
    }

[AllowAnonymous] 
    [HttpGet("obtener-cabecera-autorizacion")]
    public bool CabeceraAutorizacion(){
    
            string autorizacionCabecera = Request.Headers["Authorization"].Single();
           
            string auth = autorizacionCabecera.Split(new char[] { ' ' })[1];
            var encoding = Encoding.GetEncoding("UTF-8");
            
            var usernameAndPassword = encoding.GetString(Convert.FromBase64String(auth));
            
            string username = usernameAndPassword.Split(new char[] { ':' })[0];
            string password = usernameAndPassword.Split(new char[] { ':' })[1];

           
            if (username == "Cesar Garcia" && password == "1717007000")
            {
                return true;
            }

            return false;

        }
    
    

}



