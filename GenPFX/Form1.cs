using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using GenPFX.clases;

namespace GenPFX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreaPFX_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var oPFX = new PFX(RutaCer_txt.Text, RutaKey_txt.Text, PswFiel.Text, Path.GetDirectoryName(RutaCer_txt.Text) + "\\" + Path.GetFileNameWithoutExtension(RutaCer_txt.Text) + ".pfx", Path.GetDirectoryName(RutaCer_txt.Text), PswPFX.Text);

                if (oPFX.creaPFX())
                    MessageBox.Show("Archivo creado correctamente", "Archivo PFX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(oPFX.error, "Archivo PFX", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eror al generar el archivo llave.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void examinar_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files|*.cer";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string Filename = openFileDialog1.FileName;
                RutaCer_txt.Text = Filename;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files|*.key";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string Filename = openFileDialog1.FileName;
                RutaKey_txt.Text = Filename;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(ConfigurationManager.AppSettings["WorkingDirectory"] + "\\openssl.exe"))
            {
                MessageBox.Show("No existe el archivo: " + ConfigurationManager.AppSettings["WorkingDirectory"] + "\\openssl.exe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
