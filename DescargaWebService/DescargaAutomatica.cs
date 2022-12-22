using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using sw.descargamasiva;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static DescargaWebService.Form1;

namespace DescargaWebService
{
    public class DescargaAutomatica
    {
        string archivoPeticiones = Application.StartupPath + "\\Recursos\\Archivo_Peticiones\\peticiones_";
        string CarpetaPFX = Application.StartupPath + "\\Recursos\\Archivos PFX\\";
        SatWebService WebServiceSAT = new SatWebService();
        string psw = ConfigurationManager.AppSettings["psw"];
        
        StringBuilder MensajeBuilder = new StringBuilder();
        FechasPeticiones datosPeticiones = new FechasPeticiones();

        public Tuple< string, bool> CrearPeticionesDiarias(String RFC, X509Certificate2 certificate, string autorization)
        {
            bool PeticionesTerminadas = false;
            string tipoFactura = "1";
            string tipoSolicitud = "CFDI";
            string HoraFn = "23:59:59";
            string HoraIn;
            string idSolicitud;
            string Mensaje = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " No se realizaron las Peticiones del RFC: " +RFC+", porque ya Existen";
            string RutaXML = archivoPeticiones + RFC + ".xml";

            string FechaActual = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime ahora = Convert.ToDateTime(FechaActual);
            string ClaveLote = Regex.Replace(FechaActual, "[-]", string.Empty);

            //FechasPeticiones
            string FechaHoy = ahora.AddDays(0).ToString("yyyy-MM-dd");
            string FechaAyer = ahora.AddDays(-1).ToString("yyyy-MM-dd");
            string FechaAntier = ahora.AddDays(-2).ToString("yyyy-MM-dd");
            string FechaAnteAntier = ahora.AddDays(-3).ToString("yyyy-MM-dd");

            datosPeticiones = RevisaPeticionesRealizadas(FechaAnteAntier, FechaAntier, FechaAyer, FechaHoy, RutaXML, ClaveLote);

            if (datosPeticiones.FechaFaltantes == null && datosPeticiones.RealizarPeticion == true)
            {
                //Si FechasFaltantes es Null faltan todas las Peticiones del dia
                //Fecha AnteAntier
                int NFechasAnteAntier = NumIntentosDescarga(RFC, FechaAnteAntier);
                HoraIn = AsignaHoraInicial(NFechasAnteAntier);
                idSolicitud = SatWebService.crearPeticion(certificate, autorization, tipoFactura, FechaAnteAntier, HoraIn, FechaAnteAntier, HoraFn, RFC, tipoSolicitud);
                guardarPeticiones(idSolicitud, "Recibidas", FechaAnteAntier, HoraIn, FechaAnteAntier, HoraFn, RFC, ClaveLote);

                //Fecha Antier
                int NFechasAntier = NumIntentosDescarga(RFC, FechaAntier);
                HoraIn = AsignaHoraInicial(NFechasAntier);
                idSolicitud = SatWebService.crearPeticion(certificate, autorization, tipoFactura, FechaAntier, HoraIn, FechaAntier, HoraFn, RFC, tipoSolicitud);
                guardarPeticiones(idSolicitud, "Recibidas", FechaAntier, HoraIn, FechaAntier, HoraFn, RFC, ClaveLote);

                //Fecha Ayer
                int NFechasAyer = NumIntentosDescarga(RFC, FechaAyer);
                HoraIn = AsignaHoraInicial(NFechasAyer);
                idSolicitud = SatWebService.crearPeticion(certificate, autorization, tipoFactura, FechaAyer, HoraIn, FechaAyer, HoraFn, RFC, tipoSolicitud);
                guardarPeticiones(idSolicitud, "Recibidas", FechaAyer, HoraIn, FechaAyer, HoraFn, RFC, ClaveLote);

                //Fecha Hoy
                int NFechasHoy = NumIntentosDescarga(RFC, FechaHoy);
                HoraIn = AsignaHoraInicial(NFechasHoy);
                idSolicitud = SatWebService.crearPeticion(certificate, autorization, tipoFactura, FechaHoy, HoraIn, FechaHoy, HoraFn, RFC, tipoSolicitud);
                guardarPeticiones(idSolicitud, "Recibidas", FechaHoy, HoraIn, FechaHoy, HoraFn, RFC, ClaveLote);

                Mensaje = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ")+ RFC + " - Peticiones Terminadas";
            }
            if (datosPeticiones.FechaFaltantes != null && datosPeticiones.RealizarPeticion == true)
            {
                RealizaPeticionesFaltantes(RFC, certificate, autorization, ClaveLote);
                Mensaje = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") +RFC + " - Peticiones Faltantes han sido Terminadas";
            }
            else
            {
                PeticionesTerminadas = true;
            }
            return Tuple.Create( Mensaje, PeticionesTerminadas) ;
        }

        public void RealizaPeticionesFaltantes(String RFC, X509Certificate2 certificate, string autorization, string ClaveLote)
        {
            string tipoSolicitud = "CFDI";
            var FechasFaltantes = datosPeticiones.FechaFaltantes;
            foreach (var Fecha in FechasFaltantes)
            {
                int NFechas = NumIntentosDescarga(RFC, Fecha);
                string HoraIn = AsignaHoraInicial(NFechas);
                string idSolicitud = SatWebService.crearPeticion(certificate, autorization, "1", Fecha, HoraIn, Fecha, "23:59:59", RFC, tipoSolicitud);
                guardarPeticiones(idSolicitud, "Recibidas", Fecha, HoraIn, Fecha, "23:59:59", RFC, ClaveLote);
            }
        }

        public string peticionesMetadata(String RFC, X509Certificate2 certificate, string autorization, string FechaInicio, string horaInicio, string FechaFinal, string horaFinal)
        {
            //Crear Clave Lote
            string FechaActual = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime ahora = Convert.ToDateTime(FechaActual);
            string ClaveLote = Regex.Replace(FechaActual, "[-]", string.Empty);

            string mensaje = "";
            string idSolicitud = SatWebService.crearPeticion(certificate, autorization, "1", FechaInicio, horaInicio, FechaFinal, horaFinal, RFC, "Metadata");
            guardarPeticionesMetadata(idSolicitud, "Metadata_Recibidas", FechaInicio, horaInicio, FechaFinal, horaFinal, RFC, ClaveLote);
            if (idSolicitud != "")
            {
                mensaje = "Peticion Metadata del RFC " + RFC + " Terminada";
            }
            return mensaje;
        }

        public CredencialSAT ObtieneToken(string RFC)
        {
            var credencial = new CredencialSAT();
            string RutaPfx = asignaRutaPfx(RFC);
            if (RutaPfx != null)
            {
                var data = WebServiceSAT.obtenerCredenciales(psw, RutaPfx);
                credencial.Token = data.Item1;
                credencial.Autorizacion = data.Item2;
                credencial.Certificado = data.Item3;
                credencial.Mensaje = null;
                return credencial;
            }
            else
            {
                credencial.Mensaje = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Archivo PFX del RFC: " + RFC + " NO ENCONTRADO,  Favor de Colocar en la siguiente \r\nRuta: " + CarpetaPFX;
                return credencial;
            }
        }

        public void guardarPeticiones(string peticion, string tipo, string fechaInicial, string HoraIn, string fechaFinal, string HoraFin, string _RFC, string ClaveLote)
        {
            string carpetaPeticiones = Application.StartupPath + "\\Recursos\\Archivo_Peticiones\\";
            string archivoPeticiones = carpetaPeticiones + "peticiones_" + _RFC + ".xml";
            XmlDocument doc = new XmlDocument();
            XmlNode Peticiones;

            //validamos si existe la carpeta para guardar el archivo peticiones, si no la creamos
            if (!Directory.Exists(carpetaPeticiones))
            {
                Directory.CreateDirectory(carpetaPeticiones);
            }

            //validamos si existe el archivo de peticiones, si no la creamos para registrar las peticiones creadas
            if (!File.Exists(archivoPeticiones))
            {
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);
                Peticiones = doc.CreateElement("Peticiones");
                doc.AppendChild(Peticiones);
                doc.Save(archivoPeticiones);
            }

            doc.Load(archivoPeticiones);
            Peticiones = doc.DocumentElement;
            XmlNode Peticion = doc.CreateElement("Peticion");

            XmlAttribute PeticionID = doc.CreateAttribute("id");
            PeticionID.Value = peticion;
            Peticion.Attributes.Append(PeticionID);

            XmlAttribute PeticionDescargada = doc.CreateAttribute("descargada");
            PeticionDescargada.Value = "0";
            Peticion.Attributes.Append(PeticionDescargada);

            XmlAttribute PeticionTipo = doc.CreateAttribute("tipo");
            PeticionTipo.Value = tipo;
            Peticion.Attributes.Append(PeticionTipo);

            XmlAttribute PeticionFechaInicial = doc.CreateAttribute("fechaInicial");
            PeticionFechaInicial.Value = fechaInicial;
            Peticion.Attributes.Append(PeticionFechaInicial);

            XmlAttribute PeticionHoraInicial = doc.CreateAttribute("HoraInicial");
            PeticionHoraInicial.Value = HoraIn;
            Peticion.Attributes.Append(PeticionHoraInicial);

            XmlAttribute PeticionFechaFinal = doc.CreateAttribute("fechaFinal");
            PeticionFechaFinal.Value = fechaFinal;
            Peticion.Attributes.Append(PeticionFechaFinal);

            XmlAttribute PeticionHoraFinal = doc.CreateAttribute("HoraFinal");
            PeticionHoraFinal.Value = HoraFin;
            Peticion.Attributes.Append(PeticionHoraFinal);

            XmlAttribute PeticionClaveLote = doc.CreateAttribute("ClaveLote");
            PeticionClaveLote.Value = ClaveLote;
            Peticion.Attributes.Append(PeticionClaveLote);

            XmlAttribute PeticionEstadoSolicitud = doc.CreateAttribute("estadoSolicitud");
            PeticionEstadoSolicitud.Value = "Solicitud Aceptada";
            Peticion.Attributes.Append(PeticionEstadoSolicitud);

            Peticiones.PrependChild(Peticion);
            //Peticiones.AppendChild(Peticion);
            doc.Save(archivoPeticiones);
        }
        
        public void guardarPeticionesMetadata(string peticion, string tipo, string fechaInicial, string HoraIn, string fechaFinal, string HoraFin, string RFC, string ClaveLote)
        {
            string archivoPeticiones = Application.StartupPath + "\\Recursos\\Archivo_Peticiones\\Metadata_" + RFC + ".xml";
            XmlDocument doc = new XmlDocument();
            XmlNode Peticiones;

            if (!File.Exists(archivoPeticiones))
            {
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);
                Peticiones = doc.CreateElement("Peticiones");
                doc.AppendChild(Peticiones);
                doc.Save(archivoPeticiones);
            }

            doc.Load(archivoPeticiones);
            Peticiones = doc.DocumentElement;
            XmlNode Peticion = doc.CreateElement("Peticion");

            XmlAttribute PeticionID = doc.CreateAttribute("id");
            PeticionID.Value = peticion;
            Peticion.Attributes.Append(PeticionID);

            XmlAttribute PeticionDescargada = doc.CreateAttribute("descargada");
            PeticionDescargada.Value = "0";
            Peticion.Attributes.Append(PeticionDescargada);

            XmlAttribute PeticionTipo = doc.CreateAttribute("tipo");
            PeticionTipo.Value = tipo;
            Peticion.Attributes.Append(PeticionTipo);

            XmlAttribute PeticionFechaInicial = doc.CreateAttribute("fechaInicial");
            PeticionFechaInicial.Value = fechaInicial;
            Peticion.Attributes.Append(PeticionFechaInicial);

            XmlAttribute PeticionHoraInicial = doc.CreateAttribute("HoraInicial");
            PeticionHoraInicial.Value = HoraIn;
            Peticion.Attributes.Append(PeticionHoraInicial);

            XmlAttribute PeticionFechaFinal = doc.CreateAttribute("fechaFinal");
            PeticionFechaFinal.Value = fechaFinal;
            Peticion.Attributes.Append(PeticionFechaFinal);

            XmlAttribute PeticionHoraFinal = doc.CreateAttribute("HoraFinal");
            PeticionHoraFinal.Value = HoraFin;
            Peticion.Attributes.Append(PeticionHoraFinal);

            XmlAttribute PeticionClaveLote = doc.CreateAttribute("ClaveLote");
            PeticionClaveLote.Value = ClaveLote;
            Peticion.Attributes.Append(PeticionClaveLote);

            XmlAttribute PeticionEstadoSolicitud = doc.CreateAttribute("estadoSolicitud");
            PeticionEstadoSolicitud.Value = "Solicitud Aceptada";
            Peticion.Attributes.Append(PeticionEstadoSolicitud);

            Peticiones.PrependChild(Peticion);
            //Peticiones.AppendChild(Peticion);
            doc.Save(archivoPeticiones);
        }
        private int NumIntentosDescarga(string Rfc, string Fecha)
        {
            string archivoPeticiones = Application.StartupPath + "\\Recursos\\Archivo_Peticiones\\peticiones_";
            int NFechas = 0;
            archivoPeticiones = archivoPeticiones + Rfc + ".xml";
            XmlDocument doc = new XmlDocument();
            
            // Validamos si existe el archivo XML peticiones
            if (File.Exists(archivoPeticiones))
            {
                doc.Load(archivoPeticiones);
                XmlNode peticiones = doc.DocumentElement;

                foreach (XmlNode peticion in peticiones)
                {
                    string FechaIn = peticion.Attributes[3].Value;
                    if (FechaIn == Fecha)
                    {
                        NFechas++;
                    }
                }
            }
            return NFechas;
        }

        private string AsignaHoraInicial(int NFechas)
        {
            string HoraIn = "00:00:00";
            if (NFechas > 0)
            {
                if (NFechas >= 10)
                {
                    HoraIn = "00:00:" + NFechas;
                }
                else
                {
                    HoraIn = "00:00:0" + NFechas;
                }
            }
            return HoraIn;
        }

        private string asignaRutaPfx(string Rfc)
        {
            string RutaPfx = CarpetaPFX + Rfc + ".pfx";
            if (File.Exists(RutaPfx))
            {
                return RutaPfx;
            }
            else
            {
                RutaPfx = null;
                return RutaPfx;
            }
        }

        public IEnumerable<XElement> ObtieneXMLPeticiones(string RutaArchivoXML)
        {
            XElement PeticionesXML = XElement.Load(RutaArchivoXML);
            var Peticiones = from datos in PeticionesXML.Elements("Peticion")
                             select datos;
            return Peticiones;
        }

        public IEnumerable<XElement> obtienePeticionesMetadata(string RutaArchivoXML)
        {
            XElement PeticionesXML = XElement.Load(RutaArchivoXML);
            var Peticiones = from datos in PeticionesXML.Elements("Peticion")
                             select datos;
            return Peticiones;
        }

        public IEnumerable<XElement> RecuperaXMLPeticiones(string RutaArchivoXML, string ClaveLote)
        {
            XElement PeticionesXML = XElement.Load(RutaArchivoXML);
            var Peticiones = from datos in PeticionesXML.Elements("Peticion")
                             where datos.Attribute("ClaveLote").Value == ClaveLote
                             select datos;
            return Peticiones;
        }

        public FechasPeticiones RevisaPeticionesRealizadas(string FechaAnteAntier, string FechaAntier, string FechaAyer, string FechaHoy, string RutaArchivoXML, string ClaveLote)
        {
            //Fechas Peticiones Diarias
            List<String> FechasPeticionesHoy = new List<String>();
            FechasPeticionesHoy.Add(FechaAnteAntier);
            FechasPeticionesHoy.Add(FechaAntier);
            FechasPeticionesHoy.Add(FechaAyer);
            FechasPeticionesHoy.Add(FechaHoy);

            //Validamos que exista un archivo de Peticiones
            if (File.Exists(RutaArchivoXML))
            {
                //Fechas Recuperadas del Archivo XML
                List<string> FechasPeticionesRealizadas = new List<string>();
                var DatosXML = RecuperaXMLPeticiones(RutaArchivoXML, ClaveLote);
                int numeroFechas = DatosXML.Count();

                if (numeroFechas == 4)
                {
                    List<string> fechasRechazadas = new List<string>();
                    //Si ya fueron realizadas las peticiones, se debe revisar que no hayan peticiones rechazadas

                    foreach (var peticion in DatosXML)
                    {
                        string estado = peticion.Attribute("estadoSolicitud").Value;
                        if (estado == "Rechazado")
                        {
                            fechasRechazadas.Add(peticion.Attribute("fechaInicial").Value);
                            string id = peticion.Attribute("id").Value;
                            actualizarXMLPeticiones(id, "Rechazado-1", RutaArchivoXML);
                        }
                    }
                    datosPeticiones.FechaFaltantes = fechasRechazadas;
                    if (fechasRechazadas.Count() != 0)
                    {
                        datosPeticiones.RealizarPeticion = true;
                    }

                }
                else
                {
                    //Ya fueron realizadas las peticiones y ninguna peticion fue rechazada
                    datosPeticiones.RealizarPeticion = false;
                }

                if (numeroFechas == 0)
                {
                    //Faltan por hacer todas las peticiones de todas las fechas del dia
                    datosPeticiones.RealizarPeticion = true;
                }

                if (numeroFechas == 1 || numeroFechas == 2 || numeroFechas == 3)
                {
                    datosPeticiones.RealizarPeticion = true;
                    foreach (var atributos in DatosXML)
                    {
                        string Fecha = atributos.Attribute("fechaInicial").Value;
                        FechasPeticionesRealizadas.Add(Fecha);
                    }
                    int NumeroPeticionesRealizadas = FechasPeticionesRealizadas.Count();

                    //Encontrar diferencia entre las 2 listas de Fechas
                    datosPeticiones.FechaFaltantes = FechasPeticionesHoy.Except(FechasPeticionesRealizadas);
                    datosPeticiones.NumeroPeticionesRealizadas = datosPeticiones.FechaFaltantes.Count();
                }
            }
            else
            {
                //No se encontro archivo XML de peticiones
                datosPeticiones.RealizarPeticion = true;
            }
            return datosPeticiones;
        }

        public string DescargaItem(string id, string Rfc, string fechaInicial, CredencialSAT credencial, string RutaXML, string claveLote)
        {
            string prefijoFile = Rfc + "_LOTE "+claveLote +"_Fecha " + fechaInicial;
            var data = SatWebService.validarSolicitud(credencial.Certificado, credencial.Autorizacion, id, Rfc);
            string Idpaq = data.Item1;
            int estado = data.Item2;
            int CodigoEstadoSolicitud = data.Item3;
            string Mensaje = data.Item4;
            string peticionInicial = "";
            string MensajeDeDescarga = "";

            if (estado == 5)
            {
                peticionInicial = actualizarXMLPeticiones(id, "Rechazado", RutaXML);
                MensajeDeDescarga = "Solicitud Rechazado ID: "+id;
            }
            else
            {
                peticionInicial = actualizarXMLPeticiones(id, Mensaje, RutaXML);
            }

            if (peticionInicial != Mensaje || Mensaje != "Solicitud Aceptada")
            {
                if (CodigoEstadoSolicitud == 5004)
                {
                    MensajeDeDescarga= "No se encontro la informacion solicitada"; 
                }
                else
                {
                    if (Idpaq != "")
                    {
                        int descargado = SatWebService.descargarSolicitud(credencial.Certificado, credencial.Autorizacion, Idpaq, prefijoFile, Rfc);
                        if (descargado == 1)
                        {
                            actualizarXMLExitoso(id, RutaXML);
                            string carpeta = Application.StartupPath + "\\Recursos\\Peticiones Descargadas\\";
                            MensajeDeDescarga ="Paquete descargado, Se encuentra en la siguiente carpeta: " + carpeta;
                        }
                        else
                        {
                            actualizarXMLPeticiones(id, Mensaje, RutaXML);
                        }
                    }
                    else
                    {
                        actualizarXMLPeticiones(id, "Peticion aun no esta lista en los servidores del SAT", RutaXML);
                        MensajeDeDescarga = Rfc+" - Petición con Fecha: "+fechaInicial+" del Lote: "+claveLote+" con ID: "+id+" >> Aún no esta lista en los servidores del SAT";
                    }
                }
            }
            return MensajeDeDescarga;
        }

        public string DescargaMetadata(string id, string Rfc, string fechaInicial, CredencialSAT credencial, string RutaXML)
        {
            string prefijoFile = Rfc + "_" + fechaInicial + "_Metadata_";
            var data = SatWebService.validarSolicitud(credencial.Certificado, credencial.Autorizacion, id, Rfc);
            string Idpaq = data.Item1;
            int estado = data.Item2;
            int CodigoEstadoSolicitud = data.Item3;
            string Mensaje = data.Item4;
            string peticionInicial = "";
            string MensajeDeDescarga = "";

            if (estado == 5)
            {
                peticionInicial = actualizarXMLMetadata(id, "Rechazado", RutaXML);
            }
            else
            {
                peticionInicial = actualizarXMLMetadata(id, Mensaje, RutaXML);
            }

            if (peticionInicial != Mensaje || Mensaje != "Solicitud Aceptada")
            {
                if (CodigoEstadoSolicitud == 5004)
                {
                    MensajeDeDescarga = "No se encontro la informacion solicitada";
                }
                else
                {
                    if (Idpaq != "")
                    {
                        int descargado = SatWebService.descargarSolicitud(credencial.Certificado, credencial.Autorizacion, Idpaq, prefijoFile, Rfc);
                        if (descargado == 1)
                        {
                            actualizarXmlMetadataExitoso(id, RutaXML);
                            string carpeta = Application.StartupPath + "\\Recursos\\Peticiones Descargadas\\";
                            MensajeDeDescarga = "Metadata descargado, Se encuentra en la siguiente carpeta: " + carpeta;
                        }
                        else
                        {
                            actualizarXMLMetadata(id, Mensaje, RutaXML);
                        }
                    }
                    else
                    {
                        actualizarXMLMetadata(id, "Peticion aun no esta lista en los servidores del SAT", RutaXML);
                        MensajeDeDescarga = "Petición con ID: " + id + " >> Aún no esta lista en los servidores del SAT, Espere más tiempo";
                    }
                }
            }
            return MensajeDeDescarga;
        }

        public static string actualizarXMLPeticiones(string peticion, string estadoPeticion, string RutaXML)
        {
            string peticionInicial = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(RutaXML);

            XmlNode peticiones = doc.DocumentElement;

            foreach (XmlNode node in peticiones)
            {
                if (node.Attributes[0].Value.ToString() != peticion)
                    continue;
                else
                {
                    if (node.Attributes[node.Attributes.Count - 1].Value != estadoPeticion)
                    {
                        peticionInicial = node.Attributes[node.Attributes.Count - 1].Value;
                        node.Attributes[node.Attributes.Count - 1].Value = estadoPeticion;
                        doc.Save(RutaXML);
                        //llenarGrid(chkTodo.Checked);
                        break;
                    }
                }
            }
            return peticionInicial;
        }

        public static string actualizarXMLMetadata(string peticion, string estadoPeticion, string RutaXML)
        {
            string peticionInicial = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(RutaXML);

            XmlNode peticiones = doc.DocumentElement;

            foreach (XmlNode node in peticiones)
            {
                if (node.Attributes[0].Value.ToString() != peticion)
                    continue;
                else
                {
                    if (node.Attributes[node.Attributes.Count - 1].Value != estadoPeticion)
                    {
                        peticionInicial = node.Attributes[node.Attributes.Count - 1].Value;
                        node.Attributes[node.Attributes.Count - 1].Value = estadoPeticion;
                        doc.Save(RutaXML);
                        break;
                    }
                }
            }
            return peticionInicial;
        }

        private string actualizarXMLExitoso(string peticion, string RutaXML)
        {
            string peticionInicial = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(RutaXML);

            XmlNode peticiones = doc.DocumentElement;

            foreach (XmlNode node in peticiones)
            {
                if (node.Attributes[0].Value.ToString() != peticion)
                    continue;
                else
                {
                    peticionInicial = node.Attributes[node.Attributes.Count - 1].Value;
                    node.Attributes[node.Attributes.Count - 1].Value = "Descarga exitosa";
                    node.Attributes[1].Value = "1";
                    doc.Save(RutaXML);
                    //llenarGrid(chkTodo.Checked);
                    break;
                }
            }
            return peticionInicial;
        }

        private string actualizarXmlMetadataExitoso(string peticion, string RutaXML)
        {
            string peticionInicial = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(RutaXML);

            XmlNode peticiones = doc.DocumentElement;

            foreach (XmlNode node in peticiones)
            {
                if (node.Attributes[0].Value.ToString() != peticion)
                    continue;
                else
                {
                    peticionInicial = node.Attributes[node.Attributes.Count - 1].Value;
                    node.Attributes[node.Attributes.Count - 1].Value = "Descarga exitosa";
                    node.Attributes[1].Value = "1";
                    doc.Save(RutaXML);
                    break;
                }
            }
            return peticionInicial;
        }

        public void GuardaLogErrores(string TextoLogErrores)
        {
            string Fecha = DateTime.Now.ToString("dd-MM-yyyy");
            string directorioLogErrores = Application.StartupPath + "\\Recursos\\LogErrores\\";
            string pathLogErrrores = directorioLogErrores + "Log Errores-" + Fecha + ".txt";
            
            //Validamos si existe el directorio, si no la creamos 
            if (!Directory.Exists( directorioLogErrores))
            {
                Directory.CreateDirectory(directorioLogErrores);
            }
            
            //Validamos si existe el archivo txt de errores, si no la creamos
            if (!File.Exists(pathLogErrrores))
            {
                using (StreamWriter outputFile = new StreamWriter(@pathLogErrrores))
                {
                    outputFile.WriteLine(TextoLogErrores);
                }
            }
            else
            {
                StreamWriter Agrega = File.AppendText(@pathLogErrrores);
                Agrega.WriteLine(TextoLogErrores);
                Agrega.Close();
            }
        }

        public string enviarCorreo (string correoDestino, string asunto, string mensaje)
        {
            string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
            string from = "noresponder@itechs.mx";
            string displayName = "ITECHS";

            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(from, displayName);
                correo.To.Add(correoDestino);

                correo.Subject = asunto;
                correo.Body = mensaje;
                correo.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("mail.itechs.mx", 25);
                client.Credentials = new NetworkCredential(from, "Tangamanga1#");
                client.EnableSsl = false;

                client.Send(correo);
                msge = "¡Correo enviado exitosamente!";

            }
            catch (Exception ex)
            {
                msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
            }
            return msge;
        }
    }

    public class CredencialSAT
    {
        public string Token { get; set; }
        public X509Certificate2 Certificado { get; set; }
        public string Autorizacion { get; set; }
        public string Mensaje { get; set; }
    }

    public class FechasPeticiones
    {
        public int NumeroPeticionesRealizadas { get; set; }
        public IEnumerable<string> FechaFaltantes { get; set; }
        public bool RealizarPeticion { get; set; }
    }
}