namespace DescargaWebService
{
    partial class VSolPet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSeg = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtPFX = new System.Windows.Forms.TextBox();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVerPet = new System.Windows.Forms.Button();
            this.btnAgregaPeticion = new System.Windows.Forms.Button();
            this.gridPet = new System.Windows.Forms.DataGridView();
            this.Posición = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroParte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscaID = new System.Windows.Forms.Button();
            this.btnDescargar = new System.Windows.Forms.Button();
            this.tipoComprobanteDD = new System.Windows.Forms.ComboBox();
            this.Hfinal = new System.Windows.Forms.DateTimePicker();
            this.Hinicial = new System.Windows.Forms.DateTimePicker();
            this.datePickerFinal = new System.Windows.Forms.DateTimePicker();
            this.datePickerInicial = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRevisa = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtIDPaq = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDescargaPaq = new System.Windows.Forms.Button();
            this.txtEstadoSol = new System.Windows.Forms.TextBox();
            this.txtIDSolicitud = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tmrTemp = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPet)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtSeg);
            this.groupBox1.Controls.Add(this.txtMin);
            this.groupBox1.Controls.Add(this.txtToken);
            this.groupBox1.Controls.Add(this.txtContrasena);
            this.groupBox1.Controls.Add(this.txtPFX);
            this.groupBox1.Controls.Add(this.txtRFC);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(12, 432);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Sesión";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(545, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 16);
            this.label12.TabIndex = 10;
            this.label12.Text = "Tiempo de Sesión";
            // 
            // txtSeg
            // 
            this.txtSeg.Location = new System.Drawing.Point(604, 52);
            this.txtSeg.Name = "txtSeg";
            this.txtSeg.ReadOnly = true;
            this.txtSeg.Size = new System.Drawing.Size(24, 22);
            this.txtSeg.TabIndex = 9;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(572, 52);
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(22, 22);
            this.txtMin.TabIndex = 8;
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(98, 109);
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.ReadOnly = true;
            this.txtToken.Size = new System.Drawing.Size(565, 130);
            this.txtToken.TabIndex = 7;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(98, 81);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.ReadOnly = true;
            this.txtContrasena.Size = new System.Drawing.Size(423, 22);
            this.txtContrasena.TabIndex = 6;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // txtPFX
            // 
            this.txtPFX.Location = new System.Drawing.Point(98, 52);
            this.txtPFX.Name = "txtPFX";
            this.txtPFX.ReadOnly = true;
            this.txtPFX.Size = new System.Drawing.Size(423, 22);
            this.txtPFX.TabIndex = 5;
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(98, 23);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.ReadOnly = true;
            this.txtRFC.Size = new System.Drawing.Size(423, 22);
            this.txtRFC.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "TOKEN:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Contraseña:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "PFX:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "RFC:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(595, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 16);
            this.label13.TabIndex = 11;
            this.label13.Text = ":";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnVerPet);
            this.groupBox2.Controls.Add(this.btnAgregaPeticion);
            this.groupBox2.Controls.Add(this.gridPet);
            this.groupBox2.Controls.Add(this.btnBuscaID);
            this.groupBox2.Controls.Add(this.btnDescargar);
            this.groupBox2.Controls.Add(this.tipoComprobanteDD);
            this.groupBox2.Controls.Add(this.Hfinal);
            this.groupBox2.Controls.Add(this.Hinicial);
            this.groupBox2.Controls.Add(this.datePickerFinal);
            this.groupBox2.Controls.Add(this.datePickerInicial);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnSalir);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1257, 409);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Crear Nueva Solicitud";
            // 
            // btnVerPet
            // 
            this.btnVerPet.Location = new System.Drawing.Point(217, 295);
            this.btnVerPet.Name = "btnVerPet";
            this.btnVerPet.Size = new System.Drawing.Size(167, 35);
            this.btnVerPet.TabIndex = 28;
            this.btnVerPet.Text = "Verificar Peticiones";
            this.btnVerPet.UseVisualStyleBackColor = true;
            this.btnVerPet.Click += new System.EventHandler(this.btnVerPet_Click);
            // 
            // btnAgregaPeticion
            // 
            this.btnAgregaPeticion.Location = new System.Drawing.Point(217, 169);
            this.btnAgregaPeticion.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregaPeticion.Name = "btnAgregaPeticion";
            this.btnAgregaPeticion.Size = new System.Drawing.Size(167, 35);
            this.btnAgregaPeticion.TabIndex = 27;
            this.btnAgregaPeticion.Text = "Agregar Petición";
            this.btnAgregaPeticion.UseVisualStyleBackColor = true;
            this.btnAgregaPeticion.Click += new System.EventHandler(this.btnAgregaPeticion_Click);
            // 
            // gridPet
            // 
            this.gridPet.AllowDrop = true;
            this.gridPet.AllowUserToOrderColumns = true;
            this.gridPet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPet.ColumnHeadersHeight = 29;
            this.gridPet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Posición,
            this.numeroParte});
            this.gridPet.Location = new System.Drawing.Point(392, 35);
            this.gridPet.Margin = new System.Windows.Forms.Padding(4);
            this.gridPet.Name = "gridPet";
            this.gridPet.RowHeadersWidth = 51;
            this.gridPet.Size = new System.Drawing.Size(800, 345);
            this.gridPet.TabIndex = 26;
            // 
            // Posición
            // 
            this.Posición.HeaderText = "Fecha Inicio";
            this.Posición.MinimumWidth = 6;
            this.Posición.Name = "Posición";
            this.Posición.ReadOnly = true;
            // 
            // numeroParte
            // 
            this.numeroParte.HeaderText = "Fecha Fin";
            this.numeroParte.MinimumWidth = 6;
            this.numeroParte.Name = "numeroParte";
            this.numeroParte.ReadOnly = true;
            // 
            // btnBuscaID
            // 
            this.btnBuscaID.Location = new System.Drawing.Point(217, 211);
            this.btnBuscaID.Name = "btnBuscaID";
            this.btnBuscaID.Size = new System.Drawing.Size(167, 35);
            this.btnBuscaID.TabIndex = 16;
            this.btnBuscaID.Text = "Buscar por ID Solicitud";
            this.btnBuscaID.UseVisualStyleBackColor = true;
            this.btnBuscaID.Click += new System.EventHandler(this.btnBuscaID_Click);
            // 
            // btnDescargar
            // 
            this.btnDescargar.Location = new System.Drawing.Point(217, 253);
            this.btnDescargar.Margin = new System.Windows.Forms.Padding(4);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(167, 35);
            this.btnDescargar.TabIndex = 15;
            this.btnDescargar.Text = "Crear Solicitud(es)";
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // tipoComprobanteDD
            // 
            this.tipoComprobanteDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoComprobanteDD.FormattingEnabled = true;
            this.tipoComprobanteDD.Items.AddRange(new object[] {
            "Emitidas",
            "Recibidas"});
            this.tipoComprobanteDD.Location = new System.Drawing.Point(135, 122);
            this.tipoComprobanteDD.Margin = new System.Windows.Forms.Padding(4);
            this.tipoComprobanteDD.Name = "tipoComprobanteDD";
            this.tipoComprobanteDD.Size = new System.Drawing.Size(117, 24);
            this.tipoComprobanteDD.TabIndex = 14;
            // 
            // Hfinal
            // 
            this.Hfinal.CustomFormat = "HH:mm:ss";
            this.Hfinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Hfinal.Location = new System.Drawing.Point(259, 72);
            this.Hfinal.Name = "Hfinal";
            this.Hfinal.ShowUpDown = true;
            this.Hfinal.Size = new System.Drawing.Size(97, 22);
            this.Hfinal.TabIndex = 13;
            this.Hfinal.Value = new System.DateTime(2022, 10, 20, 23, 59, 59, 0);
            // 
            // Hinicial
            // 
            this.Hinicial.CustomFormat = "HH:mm:ss";
            this.Hinicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Hinicial.Location = new System.Drawing.Point(259, 35);
            this.Hinicial.Name = "Hinicial";
            this.Hinicial.ShowUpDown = true;
            this.Hinicial.Size = new System.Drawing.Size(97, 22);
            this.Hinicial.TabIndex = 12;
            this.Hinicial.Value = new System.DateTime(2022, 10, 19, 0, 0, 0, 0);
            // 
            // datePickerFinal
            // 
            this.datePickerFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerFinal.Location = new System.Drawing.Point(136, 72);
            this.datePickerFinal.Margin = new System.Windows.Forms.Padding(4);
            this.datePickerFinal.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.datePickerFinal.Name = "datePickerFinal";
            this.datePickerFinal.Size = new System.Drawing.Size(116, 22);
            this.datePickerFinal.TabIndex = 11;
            // 
            // datePickerInicial
            // 
            this.datePickerInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerInicial.Location = new System.Drawing.Point(135, 35);
            this.datePickerInicial.Margin = new System.Windows.Forms.Padding(4);
            this.datePickerInicial.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.datePickerInicial.Name = "datePickerInicial";
            this.datePickerInicial.Size = new System.Drawing.Size(117, 22);
            this.datePickerInicial.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de Factura:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Final:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1199, 21);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(52, 35);
            this.btnSalir.TabIndex = 16;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicial:";
            // 
            // btnRevisa
            // 
            this.btnRevisa.Enabled = false;
            this.btnRevisa.Location = new System.Drawing.Point(370, 106);
            this.btnRevisa.Name = "btnRevisa";
            this.btnRevisa.Size = new System.Drawing.Size(171, 35);
            this.btnRevisa.TabIndex = 17;
            this.btnRevisa.Text = "Revisar Estado Peticion";
            this.btnRevisa.UseVisualStyleBackColor = true;
            this.btnRevisa.Click += new System.EventHandler(this.btnRevisa_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.txtIDPaq);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnDescargaPaq);
            this.groupBox3.Controls.Add(this.txtEstadoSol);
            this.groupBox3.Controls.Add(this.txtIDSolicitud);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btnRevisa);
            this.groupBox3.Location = new System.Drawing.Point(699, 427);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(570, 249);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estado de la Solicitud";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(157, 179);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(384, 22);
            this.textBox2.TabIndex = 26;
            this.textBox2.Text = "C:\\PaquetesDescargados";
            // 
            // txtIDPaq
            // 
            this.txtIDPaq.Location = new System.Drawing.Point(157, 147);
            this.txtIDPaq.Name = "txtIDPaq";
            this.txtIDPaq.ReadOnly = true;
            this.txtIDPaq.Size = new System.Drawing.Size(384, 22);
            this.txtIDPaq.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 182);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "Ruta de Descarga";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "ID de Paquete";
            // 
            // btnDescargaPaq
            // 
            this.btnDescargaPaq.Enabled = false;
            this.btnDescargaPaq.Location = new System.Drawing.Point(456, 207);
            this.btnDescargaPaq.Name = "btnDescargaPaq";
            this.btnDescargaPaq.Size = new System.Drawing.Size(85, 35);
            this.btnDescargaPaq.TabIndex = 22;
            this.btnDescargaPaq.Text = "Descargar";
            this.btnDescargaPaq.UseVisualStyleBackColor = true;
            this.btnDescargaPaq.Click += new System.EventHandler(this.btnDescargaPaq_Click);
            // 
            // txtEstadoSol
            // 
            this.txtEstadoSol.Enabled = false;
            this.txtEstadoSol.Location = new System.Drawing.Point(157, 70);
            this.txtEstadoSol.Name = "txtEstadoSol";
            this.txtEstadoSol.ReadOnly = true;
            this.txtEstadoSol.Size = new System.Drawing.Size(384, 22);
            this.txtEstadoSol.TabIndex = 21;
            // 
            // txtIDSolicitud
            // 
            this.txtIDSolicitud.Enabled = false;
            this.txtIDSolicitud.Location = new System.Drawing.Point(157, 31);
            this.txtIDSolicitud.Name = "txtIDSolicitud";
            this.txtIDSolicitud.ReadOnly = true;
            this.txtIDSolicitud.Size = new System.Drawing.Size(384, 22);
            this.txtIDSolicitud.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Estado de la Solicitud";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "ID Solicitud";
            // 
            // tmrTemp
            // 
            this.tmrTemp.Interval = 1000;
            this.tmrTemp.Tick += new System.EventHandler(this.tmrTemp_Tick);
            // 
            // VSolPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 688);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "VSolPet";
            this.Text = "Descarga Web Service";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPet)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtPFX;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker Hfinal;
        private System.Windows.Forms.DateTimePicker Hinicial;
        private System.Windows.Forms.DateTimePicker datePickerFinal;
        private System.Windows.Forms.DateTimePicker datePickerInicial;
        private System.Windows.Forms.ComboBox tipoComprobanteDD;
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnRevisa;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEstadoSol;
        private System.Windows.Forms.TextBox txtIDSolicitud;
        private System.Windows.Forms.Button btnBuscaID;
        private System.Windows.Forms.Button btnDescargaPaq;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtIDPaq;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer tmrTemp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSeg;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView gridPet;
        private System.Windows.Forms.Button btnAgregaPeticion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posición;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroParte;
        private System.Windows.Forms.Button btnVerPet;
    }
}