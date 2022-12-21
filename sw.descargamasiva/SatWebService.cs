using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Xml;
using System.Windows.Forms;
using sw.descargamasiva;

namespace sw.descargamasiva
{
    public class SatWebService
    {
        static byte[] pfxB;
        static string password = "";

        public Tuple<string, string , X509Certificate2> obtenerCredenciales (string passwordPa, string pfxPa)
        {
            password = passwordPa;

            Program program = new Program ();
            //1 Obtener Certificados
            pfxB = File.ReadAllBytes(pfxPa);
            var certifcate = program.ObtenerX509Certificado(pfxB,password);

            //2 Obtener Token
            string token = Program.ObtenerToken(certifcate);
            string autorization = String.Format("WRAP access_token=\"{0}\"", HttpUtility.UrlDecode(token));

            return Tuple.Create(token, autorization,certifcate);
        }

        public static string crearPeticion (X509Certificate2 certificate, string autorization,string tiposol, string fechaIn, string horaInicial, string fechaFin, string horaFinal, string rfc, string tipoSolicitud)
        {
            //3 Generar Solicitud
            string idSolicitud = Program.GenerarSolicitud(certificate, autorization, tiposol, fechaIn, horaInicial, fechaFin, horaFinal, rfc, tipoSolicitud);
            return idSolicitud;
        }

        public static Tuple<string, int, int, string> validarSolicitud (X509Certificate2 certificate, string autorization, string idSolicitud, string rfc)
        {
            //4 Validar Solicitud
            var data = Program.ValidarSolicitud(certificate, autorization, idSolicitud, rfc);
            string idPaquete = data.Item1;
            int estado = data.Item2;
            int CodigoEstadoSolicitud = data.Item3;
            string Mensaje = data.Item4;
            return Tuple.Create(idPaquete, estado, CodigoEstadoSolicitud, Mensaje);
        }

        public static int descargarSolicitud (X509Certificate2 certificate, string autorization, string idPaquete, string prefijoFile, string rfc)
        {
            //5 Descargar Paquete
            int descargado = 0;            
            if (!string.IsNullOrEmpty(idPaquete))
            {
                string descargaResponse = Program.DescargarSolicitud(certificate, autorization, idPaquete, rfc);
                Program.GuardarSolicitud(idPaquete, descargaResponse, prefijoFile);
                descargado = 1;
            }
            return descargado;
        }
    }
}
