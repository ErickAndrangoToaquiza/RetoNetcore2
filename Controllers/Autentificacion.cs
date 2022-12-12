using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autentificacion.Controllers;

public class Usuario{
    public string User {get;set;}
    public string Cedula {get;set;}
}

[ApiController]
[Route("[controller]")]
[Authorize]
public class AutorizacionController : ControllerBase
{
      
      public static List<Usuario> usuarios =new List<Usuario>{

            new Usuario{User="Cesar Garcia",Cedula ="1717007000"},
           
        };


    [AllowAnonymous] 
    [HttpGet("obtenercabecera")]
     
    public Usuario ObtenerCabecera (){


        //Recuperar valor de las cabecera Authorization
           string obtenerCabecera = Request.Headers["Authorization"].SingleOrDefault();
           if (obtenerCabecera ==null){
            throw new Exception ("Error al obtener la cabecera");
           }
           
            //Separar valores
            string auth = obtenerCabecera.Split(new char[] { ' ' })[1];
            var encoding = Encoding.GetEncoding("UTF-8");
            
            //Los valores se encuentran en Base64
            var usernameAndPassword = encoding.GetString(Convert.FromBase64String(auth));
            
            //Separar los valores usuario y clave
            string username = usernameAndPassword.Split(new char[] { ':' })[0];
            string cedula = usernameAndPassword.Split(new char[] { ':' })[1];

            //Verificar valores
            var usuario = usuarios.Where(x =>x.User == username && x.Cedula== cedula).SingleOrDefault();
            if (usuario !=null)
            {
                return usuario;
            }
            throw new Exception ($"Persona no encontrada");
        }

}



