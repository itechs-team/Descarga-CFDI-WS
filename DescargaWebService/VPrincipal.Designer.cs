namespace DescargaWebService
{
    partial class VPrincipal
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
            this.label1 = new System.Windows.Forms.Label();
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
            this.tmrFechHor = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFecha4 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHora3 = new System.Windows.Forms.TextBox();
            this.txtFecha3 = new System.Windows.Forms.TextBox();
            this.txtFecha2 = new System.Windows.Forms.TextBox();
            this.txtHora1 = new System.Windows.Forms.TextBox();
            this.txtFecha1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHoraAc = new System.Windows.Forms.TextBox();
            this.txtFechaAc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblTemp = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtLogEr = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridPet = new System.Windows.Forms.DataGridView();
            this.Posición = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroParte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(828, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "DESCARGA DE XML\'S";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLogEr);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 715);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1366, 244);
            this.groupBox1.TabIndex = 2;
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
            // tmrFechHor
            // 
            this.tmrFechHor.Enabled = true;
            this.tmrFechHor.Tick += new System.EventHandler(this.tmrFechHor_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtFecha4);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtHora3);
            this.groupBox2.Controls.Add(this.txtFecha3);
            this.groupBox2.Controls.Add(this.txtFecha2);
            this.groupBox2.Controls.Add(this.txtHora1);
            this.groupBox2.Controls.Add(this.txtFecha1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtHoraAc);
            this.groupBox2.Controls.Add(this.txtFechaAc);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(898, 120);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Peticiones";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(778, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 16);
            this.label16.TabIndex = 31;
            this.label16.Text = "Petición 4";
            // 
            // txtFecha4
            // 
            this.txtFecha4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha4.Location = new System.Drawing.Point(772, 48);
            this.txtFecha4.Name = "txtFecha4";
            this.txtFecha4.ReadOnly = true;
            this.txtFecha4.Size = new System.Drawing.Size(112, 22);
            this.txtFecha4.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(547, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 16);
            this.label15.TabIndex = 29;
            this.label15.Text = "Petición 2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(660, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 16);
            this.label14.TabIndex = 28;
            this.label14.Text = "Petición 3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(426, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "Petición 1";
            // 
            // txtHora3
            // 
            this.txtHora3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora3.Location = new System.Drawing.Point(536, 76);
            this.txtHora3.Name = "txtHora3";
            this.txtHora3.ReadOnly = true;
            this.txtHora3.Size = new System.Drawing.Size(112, 22);
            this.txtHora3.TabIndex = 26;
            this.txtHora3.Text = "23:59:59";
            // 
            // txtFecha3
            // 
            this.txtFecha3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha3.Location = new System.Drawing.Point(654, 48);
            this.txtFecha3.Name = "txtFecha3";
            this.txtFecha3.ReadOnly = true;
            this.txtFecha3.Size = new System.Drawing.Size(112, 22);
            this.txtFecha3.TabIndex = 25;
            // 
            // txtFecha2
            // 
            this.txtFecha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha2.Location = new System.Drawing.Point(536, 48);
            this.txtFecha2.Name = "txtFecha2";
            this.txtFecha2.ReadOnly = true;
            this.txtFecha2.Size = new System.Drawing.Size(112, 22);
            this.txtFecha2.TabIndex = 23;
            // 
            // txtHora1
            // 
            this.txtHora1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora1.Location = new System.Drawing.Point(418, 76);
            this.txtHora1.Name = "txtHora1";
            this.txtHora1.ReadOnly = true;
            this.txtHora1.Size = new System.Drawing.Size(112, 22);
            this.txtHora1.TabIndex = 22;
            this.txtHora1.Text = "00:00:00";
            // 
            // txtFecha1
            // 
            this.txtFecha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha1.Location = new System.Drawing.Point(418, 48);
            this.txtFecha1.Name = "txtFecha1";
            this.txtFecha1.ReadOnly = true;
            this.txtFecha1.Size = new System.Drawing.Size(112, 22);
            this.txtFecha1.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(265, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Horas A Consultar:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(254, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Fechas A Consultar:";
            // 
            // txtHoraAc
            // 
            this.txtHoraAc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraAc.Location = new System.Drawing.Point(136, 76);
            this.txtHoraAc.Name = "txtHoraAc";
            this.txtHoraAc.ReadOnly = true;
            this.txtHoraAc.Size = new System.Drawing.Size(112, 22);
            this.txtHoraAc.TabIndex = 18;
            // 
            // txtFechaAc
            // 
            this.txtFechaAc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaAc.Location = new System.Drawing.Point(136, 48);
            this.txtFechaAc.Name = "txtFechaAc";
            this.txtFechaAc.ReadOnly = true;
            this.txtFechaAc.Size = new System.Drawing.Size(112, 22);
            this.txtFechaAc.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Hora Actual:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Fecha Actual:";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(1026, 81);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(102, 28);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemp.Location = new System.Drawing.Point(917, 81);
            this.lblTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(102, 39);
            this.lblTemp.TabIndex = 5;
            this.lblTemp.Text = "00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtLogEr
            // 
            this.txtLogEr.Location = new System.Drawing.Point(682, 21);
            this.txtLogEr.Multiline = true;
            this.txtLogEr.Name = "txtLogEr";
            this.txtLogEr.ReadOnly = true;
            this.txtLogEr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogEr.Size = new System.Drawing.Size(678, 217);
            this.txtLogEr.TabIndex = 12;
            this.txtLogEr.Text = "Ejecutando...";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridPet);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(692, 236);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Peticiones";
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
            this.gridPet.Location = new System.Drawing.Point(7, 27);
            this.gridPet.Margin = new System.Windows.Forms.Padding(4);
            this.gridPet.Name = "gridPet";
            this.gridPet.RowHeadersWidth = 51;
            this.gridPet.Size = new System.Drawing.Size(671, 198);
            this.gridPet.TabIndex = 27;
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
            // VPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 980);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "VPrincipal";
            this.Text = "VPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSeg;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtPFX;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer tmrFechHor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtHora3;
        private System.Windows.Forms.TextBox txtFecha3;
        private System.Windows.Forms.TextBox txtFecha2;
        private System.Windows.Forms.TextBox txtHora1;
        private System.Windows.Forms.TextBox txtFecha1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHoraAc;
        private System.Windows.Forms.TextBox txtFechaAc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtFecha4;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtLogEr;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridPet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posición;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroParte;
    }
}