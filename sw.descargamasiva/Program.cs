using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Windows.Forms;
using sw.descargamasiva;

namespace sw.descargamasiva
{
    public class Program
    {

        static string urlAutentica = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc";
        static string urlAutenticaAction = "http://DescargaMasivaTerceros.gob.mx/IAutenticacion/Autentica";

        static string urlSolicitud = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc";
        static string urlSolicitudAction = "http://DescargaMasivaTerceros.sat.gob.mx/ISolicitaDescargaService/SolicitaDescarga";

        static string urlVerificarSolicitud = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc";
        static string urlVerificarSolicitudAction = "http://DescargaMasivaTerceros.sat.gob.mx/IVerificaSolicitudDescargaService/VerificaSolicitudDescarga";

        static string urlDescargarSolicitud = "https://cfdidescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc";
        static string urlDescargarSolicitudAction = "http://DescargaMasivaTerceros.sat.gob.mx/IDescargaMasivaTercerosService/Descargar";
        static string rfcSolicitante = "";

        //METODO PRINCIPAL
        public static void Main(string[] args)
        {

        }

        public X509Certificate2 ObtenerX509Certificado(byte[] pfx, string password)
        {
            return new X509Certificate2(pfx, password, X509KeyStorageFlags.MachineKeySet |
                            X509KeyStorageFlags.PersistKeySet |
                            X509KeyStorageFlags.Exportable);
        }

        public static string ObtenerToken(X509Certificate2 certifcate)
        {
            Autenticacion service = new Autenticacion(urlAutentica, urlAutenticaAction);
            string xml = service.Generate(certifcate);
            var data = service.Send();
            string resultado = data.Item1;
            return resultado;
        }

        public static string GenerarSolicitud(X509Certificate2 certifcate, string autorization, string tiposol, string fechaIn, string horaInicial, string fechaFin, string horaFinal, string rfc, string tipoSolicitud)
        {
            Solicitud solicitud = new Solicitud(urlSolicitud, urlSolicitudAction);

            //validar si la solicitud es 0.emitidas 1.recibidas y tipo de Solicitud
            if (tipoSolicitud == "Metadata" && tiposol == "1")
            {
                string RfcEmisor = "";
                string RfcReceptor = rfc;
                string rfcSolicitante = rfc;
                string xmlSolicitud = solicitud.Generate(certifcate, RfcEmisor, RfcReceptor, rfcSolicitante, fechaIn, horaInicial, fechaFin, horaFinal, tipoSolicitud);
            }
            if (tipoSolicitud == "CFDI" && tiposol == "0")
            {
                //xmlSolicitud emitidas
                string RfcEmisor = rfc;
                string RfcReceptor = "";
                string rfcSolicitante = rfc;
                string xmlSolicitud = solicitud.Generate(certifcate, RfcEmisor, RfcReceptor, rfcSolicitante, fechaIn, horaInicial, fechaFin, horaFinal, tipoSolicitud);
            }
            if (tipoSolicitud == "CFDI" && tiposol == "1")
            {
                //xmlSolicitud recibidas
                string RfcEmisor = "";
                string RfcReceptor = rfc;
                string rfcSolicitante = rfc;
                string xmlSolicitud = solicitud.Generate(certifcate, RfcEmisor, RfcReceptor, rfcSolicitante, fechaIn, horaInicial, fechaFin, horaFinal, tipoSolicitud);
            }

            var data = solicitud.Send(autorization);
            string resultado = data.Item1;
            return resultado;
        }

        public static Tuple<string, int, int, string> ValidarSolicitud(X509Certificate2 certifcate, string autorization, string idSolicitud, string rfc)
        {
            rfcSolicitante = rfc;
            VerificaSolicitud verifica = new VerificaSolicitud(urlVerificarSolicitud, urlVerificarSolicitudAction);
            string xmlVerifica = verifica.Generate(certifcate, rfcSolicitante, idSolicitud);
            var data = verifica.Send(autorization);
            string resultado = data.Item1;
            int estado = data.Item2;
            int CodigoEstadoSolicitud = data.Item3;
            string Mensaje = data.Item4;
            return Tuple.Create(resultado, estado, CodigoEstadoSolicitud, Mensaje);
        }

        public static string DescargarSolicitud(X509Certificate2 certifcate, string autorization, string idPaquete, string rfc)
        {
            rfcSolicitante = rfc;
            DescargarSolicitud descargarSolicitud = new DescargarSolicitud(urlDescargarSolicitud, urlDescargarSolicitudAction);
            string xmlDescarga = descargarSolicitud.Generate(certifcate, rfcSolicitante, idPaquete);
            var data = descargarSolicitud.Send(autorization);
            string resultado = data.Item1;
            return resultado;
        }

        public static void GuardarSolicitud(string idPaquete, string descargaResponse, string prefijoFile)
        {
            string path = Application.StartupPath + "\\Recursos\\Peticiones Descargadas\\";
            byte[] file = Convert.FromBase64String(descargaResponse);
            Directory.CreateDirectory(path);
            
            //Validamos si existe un archivo con el mismo nombre, en caso de ser asi le agregamos la terminacion del ID
            if (File.Exists(path+prefijoFile))
            {
                prefijoFile = prefijoFile +" ID:" +idPaquete;
            }

            using (FileStream fs = File.Create(path + prefijoFile+ ".zip", file.Length))
            {
                fs.Write(file, 0, file.Length);
            }
        }
    }
}
