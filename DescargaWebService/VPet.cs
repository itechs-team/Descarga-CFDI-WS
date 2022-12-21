using sw.descargamasiva;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DescargaWebService
{
    public partial class VPet : Form
    {
        string archivoPeticiones = Application.StartupPath + "\\Recursos\\Archivo_Peticiones\\peticiones_";
        public string token;
        public string rfc;
        public string pfx;
        public string contra;
        public X509Certificate2 certificate;
        public string autorization;
        public VPet(VSolPet.Datos2 info2)
        {
            rfc = info2.rfc;
            certificate = info2.certificate;
            autorization = info2.autorization;
            InitializeComponent();
        }

        private void VPet_Load (object sender, EventArgs e)
        {
            archivoPeticiones = archivoPeticiones + rfc + ".xml";
            if (File.Exists(archivoPeticiones))
            {
                llenarGrid(chkTodo.Checked);
            }
            else
            {
                MessageBox.Show("No se han registrado peticiones todavía");
            }
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
            dt.Columns.Add("Fecha Final", typeof(string));
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
                        peticion.Attributes[5].Value);
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
                            peticion.Attributes[5].Value);
                    }
                }
            }

            //if (!mostrarTodo)
            //{
            //    dt = dt.AsEnumerable().Where(x => x.Field<String>("Estado Solicitud") != "No se encontro la informacion").CopyToDataTable();
            //    dt = dt.AsEnumerable().Where(x => x.Field<String>("Estado Solicitud") != "Descarga exitosa").CopyToDataTable();
            //}
            gridPeticiones.DataSource = dt;
            gridPeticiones.Refresh();
            numRegistros.Text = gridPeticiones.Rows.Count.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DescargarTodo_btn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                for (int fila = 0; fila < gridPeticiones.Rows.Count; fila++)
                {
                    if (gridPeticiones.Rows[fila].Cells[1].Value.ToString() == "False")
                    {
                        string id = gridPeticiones.Rows[fila].Cells[0].Value.ToString();
                        DescargaItem(id);
                    }
                }
                MessageBox.Show("Proceso terminado.", "Fin del prodeso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void DescargaItem(string id)
        {
            string prefijoFile = rfc + "_" + gridPeticiones.SelectedRows[0].Cells[3].Value.ToString().Substring(0, 10) + "-";
            //Verificzation verification = null;
            //sat_ws.Verifier.RespuestaVerificaSolicitudDescMasTercero response = null;
            //verification = new Verification(id, token, rfc);
            //response = verification.MakeRequest(pfx, contra);
            var data = SatWebService.validarSolicitud(certificate, autorization, id, rfc);
            string Idpaq = data.Item1;
            int estado = data.Item2;
            int CodigoEstadoSolicitud = data.Item3;
            string Mensaje = data.Item4;
            string peticionInicial = "";

            if (CodigoEstadoSolicitud == 5004)
                peticionInicial = actualizarXMLPeticiones(id, Mensaje);
            else
                peticionInicial = actualizarXMLPeticiones(id, Mensaje);

            if (peticionInicial != Mensaje || Mensaje != "Solicitud Aceptada")
            {
                if (CodigoEstadoSolicitud == 5004)
                {
                    //actualizarXMLPeticiones(gridPeticiones.SelectedRows[0].Cells[0].Value.ToString(), "No se encontro la informacion");
                    //MessageBox.Show("No se encontro la informacion solicitada"); //191220 1847
                }
                else
                {
                    if (Idpaq != "")
                    {

                        int descargado = SatWebService.descargarSolicitud(certificate, autorization, Idpaq, prefijoFile, rfc);
                        if (descargado == 1)
                        {
                            actualizarXMLExitoso(id);
                            string carpeta = Application.StartupPath + "\\Peticiones Descargadas\\";

                            //MessageBox.Show("Informacion descargada se encuentra la siguiente carpeta: " + carpeta);
                        }
                        else
                        {
                            actualizarXMLPeticiones(id, Mensaje);
                            // MessageBox.Show("No fue posible realizar la descarga, error:" + mensaje.Mensaje);
                        }
                    }
                    else
                    {
                        actualizarXMLPeticiones(id, "La peticion aun no esta lista en los servidores del SAT");
                        MessageBox.Show("La peticion aun no esta lista en los servidores del SAT, por favor espere mas tiempo");
                    }
                }
            }
        }
        private string actualizarXMLPeticiones(string peticion, string estadoPeticion)
        {
            string peticionInicial = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(archivoPeticiones);

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
                        doc.Save(archivoPeticiones);
                        llenarGrid(chkTodo.Checked);
                        break;
                    }
                }
            }
            return peticionInicial;
        }

        private string actualizarXMLExitoso(string peticion)
        {
            string peticionInicial = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(archivoPeticiones);

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
                    doc.Save(archivoPeticiones);
                    llenarGrid(chkTodo.Checked);
                    break;
                }
            }
            return peticionInicial;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodo.Checked)
                llenarGrid(true);
            else
                llenarGrid(false);
        }
    }
}
