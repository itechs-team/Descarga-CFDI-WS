using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sw.descargamasiva;

namespace DescargaWebService
{
    public partial class Form1 : Form
    {
        string Arpfx = "";
        string Arrfc = "";
        string Arcontra = "";
        string filename = null;
        SatWebService IniPr = new SatWebService();
        public Form1()
        {
            InitializeComponent();
        }

        public struct Datos
        {
            public string token;
            public string rfc;
            public string pfx;
            public string contra;
            public X509Certificate2 certificate;
            public string autorization;
        }
        
        private void btnBuscarPFX_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivopfx = new OpenFileDialog();
            archivopfx.Filter = "Archivo PFX|*.pfx";

            if (archivopfx.ShowDialog() == DialogResult.OK)
            {
                txtRutaPFX.Text = archivopfx.FileName;
                filename = Path.GetFileName(txtRutaPFX.ToString());
                if (filename == "dpa060116fh3.pfx")
                {
                    txtRFC.Text = "DPA060116FH3";
                    txtContrasena.Text = "Tangamanga1#";
                }
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Datos info;
            Arpfx = txtRutaPFX.Text.Trim();
            Arrfc = txtRFC.Text.Trim();
            Arcontra = txtContrasena.Text.Trim();

            if (!string.IsNullOrEmpty(Arpfx) && !string.IsNullOrEmpty(Arrfc) && !string.IsNullOrEmpty(Arcontra))
            {
                var data = IniPr.obtenerCredenciales(Arcontra, Arpfx);
                info.rfc = Arrfc;
                info.pfx = Arpfx;
                info.contra = Arcontra;
                info.token = data.Item1;
                info.autorization = data.Item2;
                info.certificate = data.Item3;

                VSolPet pet = new VSolPet(info);
                
                pet.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Por favor, llene todos los campos");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //var creaPFX = new CrearPFX_frm();
            //creaPFX.ShowDialog();
        }
    }
}
