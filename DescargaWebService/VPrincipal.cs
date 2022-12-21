using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using sw.descargamasiva;

namespace DescargaWebService
{
    public partial class VPrincipal : Form
    {
        string psw = ConfigurationManager.AppSettings["psw"];
        string PfxDca = ConfigurationManager.AppSettings["rutaPfxDca"];
        string PfxCan = ConfigurationManager.AppSettings["rutaPfxCan"];
        string PfxDpa = ConfigurationManager.AppSettings["rutaPfxDpa"];
        string RfcDca = ConfigurationManager.AppSettings["RFCDca"];
        string RfcCan = ConfigurationManager.AppSettings["RFCCan"];
        string RfcDpa = ConfigurationManager.AppSettings["RFCDpa"];
        SatWebService IniPr = new SatWebService();

        public string token;
        public X509Certificate2 certificate;
        public string autorization;

        public VPrincipal()
        {
            InitializeComponent();
        }

        private static List<string> UsingXmlReader(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList xnList = xml.SelectNodes("/Empresas/Empresa");
            int numReg = xnList.Count;
            //Declaracion de la lista..
            List<string> datos = new List<string>();
            foreach (XmlNode xn in xnList)
            {
                string RFC = xn["rfc"].InnerText;
                //Agregamos Datos a la lista..
                datos.Add(RFC);
            }
            return datos;
        }

        private void tmrFechHor_Tick(object sender, EventArgs e)
        {
            txtFechaAc.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtHoraAc.Text = DateTime.Now.ToString("HH:mm:ss");
            string fechaAc = txtFechaAc.Text;
            DateTime FechaActual = Convert.ToDateTime(fechaAc);
            txtFecha1.Text = FechaActual.AddDays(0).ToString("yyyy-MM-dd");
            txtFecha2.Text = FechaActual.AddDays(-1).ToString("yyyy-MM-dd");
            txtFecha3.Text = FechaActual.AddDays(-2).ToString("yyyy-MM-dd");
            txtFecha4.Text = FechaActual.AddDays(-3).ToString("yyyy-MM-dd");

            if (txtHoraAc.Text == "14:36:00")
            {
                txtToken.Text = "esto es una prueba";
                Ejecuta();
            }

            if (gridPet.Rows.Count == 1)
            {
                //Llena GridView con Fechas
                LlenaGrid();
            }


        }

        private void IniciaTemp()
        {
            if (lblTemp.Text != "00:00:00")
            {
                timer1.Start();
                
            }
        }


        int min;
        int seg;
        private void VPrincipal_Load(object sender, EventArgs e)
        {
            min = 25;
            seg = 0;
            string minutos = min.ToString();
            string segundos = seg.ToString();
            this.lblTemp.Text = minutos + ":0" + segundos;
            this.timer1.Enabled = true;
;        }

        public void LlenaGrid()
        {
            gridPet.Rows.Add(txtFecha1.Text,txtFecha1.Text);
            gridPet.Rows.Add(txtFecha2.Text, txtFecha2.Text);
            gridPet.Rows.Add(txtFecha3.Text, txtFecha3.Text);
            gridPet.Rows.Add(txtFecha4.Text, txtFecha4.Text);
        }

        public void Ejecuta()
        {
            string RutaXML = "C:\\Users\\LEO\\Downloads\\sw-descargamasiva-dotnet-master\\DescargaWebService\\Resources\\Empresas.xml";
            var DatosEmpresa = UsingXmlReader(RutaXML);
             foreach (var item in DatosEmpresa)
            {
                if (item.ToString() == "DPA060116FH3")
                {
                    txtPFX.Text = PfxDpa;
                    txtRFC.Text = RfcDpa;
                    txtLogEr.AppendText("\r\n" + "Consultando RFC: " + item.ToString());
                    var data = IniPr.obtenerCredenciales(psw, PfxDpa);
                    token = data.Item1;
                    autorization = data.Item2;
                    certificate = data.Item3;
                    txtLogEr.AppendText("\r\n" + "TOKEN: " + token);

                }
                if (item.ToString() == "DCA040909263")
                {
                    txtPFX.Text = PfxDca;
                    txtRFC.Text = RfcDca;
                }
            }
        }

        private void LeePfx()
        {
            //Ruta Archivos PFX
            string RutaArchPFX = "C:\\CFDIs\\pfx";
            string[] files = Directory.GetFiles(@RutaArchPFX); // Obtener archivo

        }

        private void CreaPeticiones(int PetFin1, int PetFin2, int PetFin3)
        {
            string Fecha1 = txtFecha1.Text;
            string Fecha2 = txtFecha2.Text;
            string Fecha3 = txtFecha3.Text;
            try
            {
                if (PetFin1 == 0)
                {
                    string IdPeticion;
                    PetFin1 = 1;
                }
                if (PetFin2 == 0)
                {
                    string IdPeticion;
                    PetFin2 = 1;
                }
                if (PetFin3 == 0)
                {
                    string IdPeticion;
                    PetFin3 = 1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                string token;
                CreaPeticiones(PetFin1, PetFin2, PetFin3);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            DescargaAutomatica da = new DescargaAutomatica();
            //da.CrearPeticiones(RfcDpa);
            Ejecuta();
            //timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string minutos = min.ToString();
            string segundos = seg.ToString();
            if (min < 10)
            {
                minutos = "0" + min.ToString();
            }
            if (seg < 10)
            {
                segundos = "0" + seg.ToString();

            }

            if (seg == 0 && min > 0)
            {
                min -= 1;
                seg = 60;
            }

            if (min == 0 && seg == 0)
            {
                timer1.Stop();
                MessageBox.Show("Se acabo el tiempo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            lblTemp.Text = minutos + ":" + segundos;
            seg -= 1;
        }

        //Metodo para hacer Peticiones
        private void Peticiones()
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
            }
        }

        private Boolean CreaPeticion(string fechaInicial, string fechaFinal)
        {
            string rfc = txtRFC.Text;

                //Generar Solicitud Recibidas
                string tiposol = "1";
                string idSolicitud = SatWebService.crearPeticion(certificate, autorization, tiposol, fechaInicial, "", fechaFinal, "", rfc, "CFDI");
                //string idReceivedRequest = request.MakeRequest(1).IdSolicitud;
                if (!string.IsNullOrEmpty(idSolicitud))
                {
                    //guardarPeticiones(idSolicitud, "Recibidas", fechaInicial, fechaFinal, rfc);
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
}
