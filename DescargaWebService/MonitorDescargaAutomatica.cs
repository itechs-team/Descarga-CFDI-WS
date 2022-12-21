using sw.descargamasiva;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace DescargaWebService
{
    public partial class btnVerPeticiones : Form
    {
        string archivoPeticiones = Application.StartupPath + "\\Recursos\\Archivo_Peticiones\\peticiones_";
        string Rfc;
        public CredencialSAT credencial;
        SatWebService WebServiceSAT = new SatWebService();
        DescargaAutomatica Descargador = new DescargaAutomatica();
        StringBuilder MensajeBuilder = new StringBuilder();
        bool PeticionesTerminadas;

        //SET de Hora Inicial de Ejecucion
        string HoraInicial = "18:00:00";
        string horaEjecucion = "18:00:00";
        bool horaProgramada = false;

        //Tiempo para Timer de Peticiones
        int min = 59;
        int seg = 59;

        //Tiempo para Timer de Descargas
        int minuto = 30;
        int segundo = 0;
        bool VerificarEjecucion = false;
        bool VerificadorDescargasTerminadas = false;

        public btnVerPeticiones()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            txtLogEr.Clear();
            txtLogEr.AppendText("\r\nEjecutando Peticiones XMLs "+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "..........................................................................................................");
            foreach (var item in cboEmpresas.Items)
            {
                Rfc = item.ToString();
                try
                {
                    credencial = Descargador.ObtieneToken(Rfc);
                    if (credencial.Mensaje == null)
                    {
                        txtLogEr.AppendText("\r\n"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") +Rfc + ": Iniciando Peticiones ");

                        var DatosPeticiones = Descargador.CrearPeticionesDiarias(Rfc, credencial.Certificado, credencial.Autorizacion);
                        string MensajeProcesoPeticiones = DatosPeticiones.Item1;
                        PeticionesTerminadas = DatosPeticiones.Item2;

                        if (MensajeProcesoPeticiones != "")
                        {
                            txtLogEr.AppendText("\r\n"+MensajeProcesoPeticiones);
                        }
                    }
                    else { txtLogEr.AppendText("\r\n"+credencial.Mensaje); }
                }
                catch (Exception Error)
                {
                    txtLogEr.AppendText("\r\n"+Error.Message);
                }
            }

            if (PeticionesTerminadas == true)
            {
                tmrTemporizador.Enabled = false;
                txtLogEr.AppendText("\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") +"Iniciando Timer para verificar los paquetes a descargar ");
                tmrDescargaPaquetes.Enabled = true;
            }
            else
            {
                txtLogEr.AppendText("\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Iniciando Timer, para reintentar las Peticiones del dia ");
                tmrTemporizador.Enabled = true;
            }
            Descargador.GuardaLogErrores(txtLogEr.Text);
        }

        private void btnDescarga_Click(object sender, EventArgs e)
        {
            txtLogEr.Clear();
            txtLogEr.AppendText("\r\nEjecutando Descarga de XMLs "+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+ "..........................................................................................................");
            int NumeroPeticiones = 0;
            int numeroRegistrosPeticiones = 0;

            foreach (var item in cboEmpresas.Items)
            {
                Rfc = item.ToString();
                string RutaXML = archivoPeticiones + Rfc + ".xml";
                if (File.Exists(RutaXML))
                {
                    txtLogEr.AppendText("\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") +Rfc+" :Intentando Descargar Paquetes");
                    credencial = Descargador.ObtieneToken(Rfc);
                    var DatosXML = Descargador.ObtieneXMLPeticiones(RutaXML);
                    numeroRegistrosPeticiones = DatosXML.Count();
                    foreach (var datos in DatosXML)
                    {
                        string id = datos.Attribute("id").Value;
                        string estadoSolicitud = datos.Attribute("estadoSolicitud").Value;
                        string fechaInicial = datos.Attribute("fechaInicial").Value;
                        string claveLote = datos.Attribute("ClaveLote").Value;
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            if (estadoSolicitud != "Rechazado" && estadoSolicitud != "Descarga exitosa")
                            {
                                string MensajeDeDescarga = Descargador.DescargaItem(id, Rfc, fechaInicial, credencial, RutaXML, claveLote);
                                txtLogEr.AppendText("\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + MensajeDeDescarga);
                            }
                            else { NumeroPeticiones++; }
                        }
                        catch (Exception ex)
                        {
                            txtLogEr.AppendText("\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") +ex.Message);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }
                    }
                    if (NumeroPeticiones == numeroRegistrosPeticiones)
                    {
                        txtLogEr.AppendText("\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") +Rfc + " : No hay Paquetes pendientes de Descargar ");
                        VerificadorDescargasTerminadas = true;
                    }
                    txtLogEr.AppendText("\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") +Rfc + " - Intento de Descarga >> FINALIZADO");
                }
                else
                {
                    txtLogEr.AppendText("\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + Rfc +" :Archivo XML de Peticiones NO ENCONTRADO");
                }
            }
            Descargador.GuardaLogErrores(txtLogEr.Text);
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            tmrDescargaPaquetes.Enabled = true;

        }
        private void llenarGrid(bool mostrarTodo)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(archivoPeticiones);

            XmlNode peticiones = doc.DocumentElement;

            DataTable dt = new DataTable();
            dt.Columns.Add("Peticion", typeof(string));
            dt.Columns.Add("Descargada", typeof(bool)); 
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Fecha Inicial", typeof(string));
            dt.Columns.Add("Hora Inicial",typeof(string));
            dt.Columns.Add("Fecha Final", typeof(string));
            dt.Columns.Add("Hora Final", typeof(string));
            dt.Columns.Add("Estado Solicitud", typeof(string));
            foreach (XmlNode peticion in peticiones)
            {
                if (mostrarTodo)
                {
                    dt.Rows.Add(peticion.Attributes[0].Value,
                        peticion.Attributes[1].Value == "0" ? false : true,
                        peticion.Attributes[2].Value,
                        peticion.Attributes[3].Value,
                        peticion.Attributes[4].Value,
                        peticion.Attributes[5].Value,
                        peticion.Attributes[6].Value,
                        peticion.Attributes[7].Value);
                }
                else
                {
                    if (peticion.Attributes[1].Value == "1" ? false : true)
                    {
                        dt.Rows.Add(peticion.Attributes[0].Value,
                            peticion.Attributes[1].Value == "0" ? false : true,
                            peticion.Attributes[2].Value,
                            peticion.Attributes[3].Value,
                            peticion.Attributes[4].Value,
                            peticion.Attributes[5].Value,
                            peticion.Attributes[6].Value,
                            peticion.Attributes[7].Value);
                    }
                }
            }
            gridPeticiones.DataSource = dt;
            gridPeticiones.Refresh();
            numRegistros.Text = gridPeticiones.Rows.Count.ToString();

        }

        private void cboEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    credencial = Descargador.ObtieneToken(cboEmpresas.SelectedItem.ToString());
            //    txtLogEr.AppendText("\r\n RFC: " + cboEmpresas.SelectedItem.ToString());
            //    txtLogEr.AppendText("\r\n TOKEN: " + credencial.Token);
            //}
            //catch (Exception Error)
            //{
            //    MessageBox.Show(Error.Message);
            //}
        }

        private void tmrHora_Tick(object sender, EventArgs e)
        {
            lblFechAct.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblHoraAc.Text = DateTime.Now.ToString("HH:mm:ss");
            
            string HoraActual = DateTime.Now.ToString("HH:mm:ss");

            var HoraInicialDT = DateTime.Parse(HoraInicial);
            var HoraActualDT = DateTime.Parse(HoraActual);

            if (VerificarEjecucion == false && HoraActualDT > HoraInicialDT && horaProgramada == false)
            {
                VerificarEjecucion = true;
                horaEjecucion = DateTime.Now.AddMinutes(1).ToString("HH:mm:ss");
                horaProgramada= true;
            }

            if (lblHoraAc.Text == horaEjecucion)
            {
                txtLogEr.AppendText("\r\nIniciando Ejecucion -- "+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                btnIniciar.PerformClick();
                VerificarEjecucion = true;
            }
        }

        private void tmrTemporizador_Tick(object sender, EventArgs e)
        {
            string minutos = min.ToString();
            string segundos = seg.ToString();

            if (min < 10)
            {
                minutos = "0" + min.ToString();
            }
            if (seg < 10) { segundos = "0" + seg.ToString(); }

            if (seg == 0 && min > 0) { min -= 1; seg = 60; }

            if (min == 0 && seg == 0)
            {
                btnIniciar.PerformClick();
                min = 59;
                seg = 59;
            }
            lblTemp.Text = minutos+ ":" + segundos;
            if (seg != 0) { seg -= 1; }
        }

        private void btnIniciaTimer_Click(object sender, EventArgs e)
        {
            tmrTemporizador.Enabled = true;
        }

        private void tmrDescargaPaquetes_Tick(object sender, EventArgs e)
        {
            string Minutos = minuto.ToString();
            string Segundos = segundo.ToString();

            if (minuto < 10)
            {
                Minutos = "0" + minuto.ToString();
            }
            if (segundo < 10) { Segundos = "0" + segundo.ToString(); }

            if (segundo == 0 && minuto > 0) { minuto -= 1; segundo = 60; }

            if (minuto == 0 && segundo == 0)
            {
                btnDescarga.PerformClick();
                if (VerificadorDescargasTerminadas == true)
                {
                    tmrDescargaPaquetes.Enabled = false;
                }
                minuto = 30;
                segundo = 0;
            }
            lblTimerDescargaPaq.Text = Minutos + ":" + Segundos;

            if (segundo != 0) { segundo -= 1; }
        }

        private void btnMetadata_Click(object sender, EventArgs e)
        {
            string fechaInicial = datePickerInicial.Value.ToString("yyyy-MM-dd");
            string fechaFinal = datePickerFinal.Value.ToString("yyyy-MM-dd"); 
            string horaInicio = "00:00:00";
            string horaFinal = "23:59:59";

            if (cboEmpresas.SelectedIndex == -1)
            {
                MessageBox.Show("Elija un RFC del menu desplegable");
                cboEmpresas.Focus();
            }
            else
            {
                string RFC = cboEmpresas.SelectedItem.ToString();
                txtLogEr.Clear();
                txtLogEr.AppendText("\r\nEjecutando Peticion Metadata " + DateTime.Now.ToString("HH:mm:ss") + "..........................................................................................................");
               
                credencial = Descargador.ObtieneToken(RFC);

                if (credencial.Mensaje == null)
                {
                    txtLogEr.AppendText("\r\n" + RFC + ": Iniciando Peticion MetaData");
                    var mensaje = Descargador.peticionesMetadata(RFC, credencial.Certificado, credencial.Autorizacion, fechaInicial, horaInicio, fechaFinal, horaFinal);
                    
                    if (mensaje != "")
                    {
                        txtLogEr.AppendText("\r\n" + mensaje);
                    }
                }
                else { txtLogEr.AppendText("\r\n" + credencial.Mensaje); }
            }
            Descargador.GuardaLogErrores(txtLogEr.Text);
        }

        private void btnDescargaMetadata_Click(object sender, EventArgs e)
        {
            int numeroRegistrosPeticiones = 0;
            int NumeroPeticiones = 0;
            string RutaXml = Application.StartupPath + "\\Recursos\\Archivo_Peticiones\\Metadata_";
            if (cboEmpresas.SelectedIndex == -1)
            {
                MessageBox.Show("Elija un RFC del menu desplegable");
                cboEmpresas.Focus();
            }
            else
            {
                string RFC = cboEmpresas.SelectedItem.ToString();
                txtLogEr.Clear();
                txtLogEr.AppendText("\r\nEjecutando Descarga de Metadata " + DateTime.Now.ToString("HH:mm:ss") + "..........................................................................................................");
                string XmlMetadata = RutaXml + RFC+ ".xml";
                if (File.Exists(XmlMetadata))
                {
                    txtLogEr.AppendText("\r\n" + RFC + " :Intentando Descargar Metadata");
                    credencial = Descargador.ObtieneToken(RFC);
                    var DatosXML = Descargador.obtienePeticionesMetadata(XmlMetadata);
                    numeroRegistrosPeticiones = DatosXML.Count();

                    foreach (var datos in DatosXML)
                    {
                        string id = datos.Attribute("id").Value;
                        string estadoSolicitud = datos.Attribute("estadoSolicitud").Value;
                        string fechaInicial = datos.Attribute("fechaInicial").Value;
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            if (estadoSolicitud != "Rechazado" && estadoSolicitud != "Descarga exitosa")
                            {
                                string MensajeDeDescarga = Descargador.DescargaMetadata(id, RFC, fechaInicial, credencial, XmlMetadata);
                                txtLogEr.AppendText("\r\n" + MensajeDeDescarga);
                            }
                            else { NumeroPeticiones++; }
                        }
                        catch (Exception ex)
                        {
                            txtLogEr.AppendText("\r\n" + ex.Message);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }
                    }
                    if (NumeroPeticiones == numeroRegistrosPeticiones)
                    {
                        txtLogEr.AppendText("\r\n" + "No hay Metadata pendiente de Descargar, RFC: " + RFC);
                        VerificadorDescargasTerminadas = true;
                    }
                    txtLogEr.AppendText("\r\n" + "Intento de Descarga del RFC: " + RFC + " >> FINALIZADO");
                }
                else
                {
                    txtLogEr.AppendText("\r\n" + RFC + " :Archivo XML de Peticiones Metadata NO ENCONTRADO");
                }
            }
            Descargador.GuardaLogErrores(txtLogEr.Text);
        }
    }
}