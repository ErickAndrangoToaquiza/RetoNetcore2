namespace Autentificacion.Controllers;

    public class JwtConfiguration {

        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expires { get; set; } = TimeSpan.FromMinutes(10);

    } 
