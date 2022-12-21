using sw.descargamasiva;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DescargaWebService
{
    public partial class VSolPet : Form
    {
        Stopwatch stp = new Stopwatch();
        public string token;
        public string rfc;
        public string pfx;
        public string contra;
        public X509Certificate2 certificate;
        public string autorization;
        string tiposol = "";

        public VSolPet(Form1.Datos info)
        {
            InitializeComponent();
            stp.Start();
            tmrTemp.Enabled = true;
            txtToken.Text = info.token;
            txtRFC.Text = info.rfc;
            txtContrasena.Text = info.contra;
            txtPFX.Text = info.pfx;
            certificate = info.certificate;
            autorization = info.autorization;

        }

        public struct Datos2
        {
            public string token;
            public string rfc;
            public string pfx;
            public X509Certificate2 certificate;
            public string autorization;
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                for (int fila = 0; fila < gridPet.Rows.Count - 1; fila++)
                {
                    string fechaInicial = gridPet.Rows[fila].Cells[0].Value.ToString();
                    string fechaFinal = gridPet.Rows[fila].Cells[1].Value.ToString();
                    System.Threading.Thread.Sleep(60);
                    if (CreaPeticion(fechaInicial, fechaFinal))
                    {
                        gridPet.Rows.RemoveAt(fila);
                        fila--;
                    }
                }
                //gridPet.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al solicitar petición " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Proceso terminado. Revise más tarde el estado de las Peticiones.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRevisa.Enabled = true;

                txtIDSolicitud.Enabled = true;
                txtEstadoSol.Enabled = true;
                btnDescargar.Enabled = false;
                btnAgregaPeticion.Enabled = false;
            }

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRevisa_Click(object sender, EventArgs e)
        {
            string rfc = txtRFC.Text;
            string idSolicitud = txtIDSolicitud.Text;
            var data = SatWebService.validarSolicitud(certificate, autorization, idSolicitud, rfc);
            string Idpaq = data.Item1;
            int estado = data.Item2;

            switch (estado)
            {
                case 0:
                    // Estado = 0 - Token Invalido 
                    txtEstadoSol.Text = "Token Invalido";
                    break;
                case 1:
                    // Estado = 1 - Aceptada 
                    txtEstadoSol.Text = "Aceptada";
                    break;
                case 2:
                    // Estado = 2 - En Proceso 
                    txtEstadoSol.Text = "Aceptada";
                    break;
                case 3:
                    // Estado = 3 - Terminada
                    txtEstadoSol.Text = "Terminada";
                    MessageBox.Show("Proceso Terminado, puede descargar el Paquete");
                    btnRevisa.Enabled = false;
                    txtIDPaq.Text = Idpaq;
                    btnDescargaPaq.Enabled = true;
                    break;
                case 4:
                    // Estado = 4 - Error 
                    txtEstadoSol.Text = "Error";
                    break;
                case 5:
                    // Estado = 5 - Rechazada
                    txtEstadoSol.Text = "Rechazada";
                    break;
                case 6:
                    // Estado = 6 - Vencida
                    txtEstadoSol.Text = "Vencida";
                    break;
            }
        }

        private void btnDescargaPaq_Click(object sender, EventArgs e)
        {
            string idPaquete = txtIDPaq.Text;
            int descargado = SatWebService.descargarSolicitud(certificate, autorization, idPaquete, "", rfc);
            if(descargado == 1)
            {
                MessageBox.Show("Descarga Exitosa");
                btnDescargaPaq.Enabled =false;
            }
            else
            {
                MessageBox.Show("No se procesó la descarga");
            }
        }

        private void btnBuscaID_Click(object sender, EventArgs e)
        {
            btnRevisa.Enabled = true;
            txtIDSolicitud.Enabled = true;
            txtEstadoSol.Enabled = true;
            txtIDSolicitud.ReadOnly = false;
            btnDescargar.Enabled = false;
        }

        private void tmrTemp_Tick(object sender, EventArgs e)
        {
            //TimeSpan ts = new TimeSpan(0,0,0,0,(int)stp.ElapsedMilliseconds);
            //txtMin.Text = ts.Minutes.ToString().Length<2 ? "0"+ ts.Minutes.ToString() : ts.Minutes.ToString();
            //txtSeg.Text = ts.Seconds.ToString().Length<2 ? "0"+ts.Seconds.ToString() : ts.Seconds.ToString();

            //if(txtMin.Text == "05")
            //{
            //    stp.Stop();
            //    tmrTemp.Enabled = false;
            //    MessageBox.Show("El Token ha expirado, le recomendamos volver a Iniciar Sesión");
            //    btnBuscaID.Enabled = false;
            //    btnDescargar.Enabled = false;
            //}
        }

        private void btnAgregaPeticion_Click(object sender, EventArgs e)
        {
            string fechaInicial = datePickerInicial.Value.ToString("yyyy-MM-dd");
            string fechaFinal = datePickerFinal.Value.ToString("yyyy-MM-dd");

            string horaInicial = Hinicial.Value.ToString("HH:mm:ss");
            string horaFinal = Hfinal.Value.ToString("HH:mm:ss");

            string FechaInicio = fechaInicial + "T" + horaInicial;
            string FechaFinal = fechaFinal+ "T" + horaFinal;
            gridPet.Rows.Insert(0, FechaInicio, FechaFinal);
        }

        private Boolean CreaPeticion(string fechaInicial, string fechaFinal)
        {
            //if (tipoComprobanteDD.SelectedIndex == 0)
            //{
            //    if(idSolicitud != null)
            //    {
            //        MessageBox.Show("Solicitud Enviada, ID de Solicitud: "+ idSolicitud);
            //        btnRevisa.Enabled = true;
            //        txtIDSolicitud.Enabled = true;
            //        txtEstadoSol.Enabled = true;
            //        txtIDSolicitud.Text = idSolicitud;
            //        btnDescargar.Enabled = false;
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se envio la solicitud");
            //    }
            //}
            //else
            //{
            //    if (idSolicitud != null)
            //    {
            //        MessageBox.Show("Solicitud Enviada, ID de Solicitud: " + idSolicitud);
            //        btnRevisa.Enabled = true;
            //        txtIDSolicitud.Enabled = true;
            //        txtEstadoSol.Enabled = true;
            //        txtIDSolicitud.Text = idSolicitud;
            //        btnDescargar.Enabled = false;
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se envio la solicitud");
            //    }
            //}
            string rfc = txtRFC.Text;

            if (tipoComprobanteDD.SelectedIndex == 0)
            {
                //Generar Solicitud Emitidas
                tiposol = "0";
                string idSolicitud = SatWebService.crearPeticion(certificate, autorization, tiposol, fechaInicial, "", fechaFinal, "", rfc, "CFDI");
                if (!string.IsNullOrEmpty(idSolicitud))
                {
                    guardarPeticiones(idSolicitud, "Emitidas", fechaInicial, fechaFinal, rfc);
                    //MessageBox.Show("Peticion " + idIssuerRequest + " guardada, por favor espere unas horas");
                    return true;
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la peticion");
                    return false;
                }
            }
            else
            {
                //Generar Solicitud Recibidas
                string tiposol = "1";
                string idSolicitud = SatWebService.crearPeticion(certificate, autorization, tiposol, fechaInicial, "", fechaFinal, "", rfc, "CFDI");
                //string idReceivedRequest = request.MakeRequest(1).IdSolicitud;
                if (!string.IsNullOrEmpty(idSolicitud))
                {
                    guardarPeticiones(idSolicitud, "Recibidas", fechaInicial, fechaFinal, rfc);
                    //MessageBox.Show("Peticion " + idReceivedRequest + " guardada, por favor espere unas horas");
                    return true;
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la peticion");
                    return false;
                }
            }
        }
        private void guardarPeticiones(string peticion, string tipo, string fechaInicial, string fechaFinal, string _RFC)
        {
            string archivoPeticiones = Application.StartupPath + "\\peticiones_" + _RFC + ".xml";
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

            XmlAttribute PeticionFechaFinal = doc.CreateAttribute("fechaFinal");
            PeticionFechaFinal.Value = fechaFinal;
            Peticion.Attributes.Append(PeticionFechaFinal);

            XmlAttribute PeticionEstadoSolicitud = doc.CreateAttribute("estadoSolicitud");
            PeticionEstadoSolicitud.Value = "Solicitud Aceptada";
            Peticion.Attributes.Append(PeticionEstadoSolicitud);

            Peticiones.AppendChild(Peticion);

            doc.Save(archivoPeticiones);

        }

        private void btnVerPet_Click(object sender, EventArgs e)
        {
            Datos2 info2;
            info2.rfc = txtRFC.Text;
            info2.pfx = txtPFX.Text;
            info2.token = txtToken.Text;
            info2.certificate = certificate;
            info2.autorization = autorization;

            VPet vPet = new VPet(info2);
            vPet.Show();
            this.Hide();
        }
    }
}
