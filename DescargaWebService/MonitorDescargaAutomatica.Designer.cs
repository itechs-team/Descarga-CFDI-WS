namespace DescargaWebService
{
    partial class btnVerPeticiones
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
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtLogEr = new System.Windows.Forms.TextBox();
            this.btnDescarga = new System.Windows.Forms.Button();
            this.cboEmpresas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTimerDescargaPaq = new System.Windows.Forms.Label();
            this.chkTodo = new System.Windows.Forms.CheckBox();
            this.numRegistros = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.gridPeticiones = new System.Windows.Forms.DataGridView();
            this.btnIniciaTimer = new System.Windows.Forms.Button();
            this.tmrHora = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmrTemporizador = new System.Windows.Forms.Timer(this.components);
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblFechAct = new System.Windows.Forms.Label();
            this.lblHoraAc = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tmrDescargaPaquetes = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDescargaMetadata = new System.Windows.Forms.Button();
            this.btnMetadata = new System.Windows.Forms.Button();
            this.datePickerFinal = new System.Windows.Forms.DateTimePicker();
            this.datePickerInicial = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeticiones)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(9, 212);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(182, 38);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Iniciar Peticiones";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtLogEr
            // 
            this.txtLogEr.Location = new System.Drawing.Point(214, 21);
            this.txtLogEr.Multiline = true;
            this.txtLogEr.Name = "txtLogEr";
            this.txtLogEr.ReadOnly = true;
            this.txtLogEr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogEr.Size = new System.Drawing.Size(1003, 388);
            this.txtLogEr.TabIndex = 13;
            // 
            // btnDescarga
            // 
            this.btnDescarga.Location = new System.Drawing.Point(9, 256);
            this.btnDescarga.Name = "btnDescarga";
            this.btnDescarga.Size = new System.Drawing.Size(182, 38);
            this.btnDescarga.TabIndex = 14;
            this.btnDescarga.Text = "Descarga Paquetes";
            this.btnDescarga.UseVisualStyleBackColor = true;
            this.btnDescarga.Click += new System.EventHandler(this.btnDescarga_Click);
            // 
            // cboEmpresas
            // 
            this.cboEmpresas.FormattingEnabled = true;
            this.cboEmpresas.Items.AddRange(new object[] {
            "CAN830210LE8",
            "FDV030109CS3",
            "LDG0102073C5",
            "MGA080922FP0",
            "PUL860409I9A",
            "DCA040909263",
            "DPA060116FH3",
            "DIM140806MM9",
            "DIM150824B26",
            "RAR930331RF0"});
            this.cboEmpresas.Location = new System.Drawing.Point(9, 171);
            this.cboEmpresas.Name = "cboEmpresas";
            this.cboEmpresas.Size = new System.Drawing.Size(182, 24);
            this.cboEmpresas.TabIndex = 15;
            this.cboEmpresas.SelectedIndexChanged += new System.EventHandler(this.cboEmpresas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Seleccione RFC:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblTimerDescargaPaq);
            this.groupBox1.Controls.Add(this.chkTodo);
            this.groupBox1.Controls.Add(this.numRegistros);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnVer);
            this.groupBox1.Controls.Add(this.gridPeticiones);
            this.groupBox1.Location = new System.Drawing.Point(16, 433);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 131);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticiones";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Tiempo para Descargar";
            // 
            // lblTimerDescargaPaq
            // 
            this.lblTimerDescargaPaq.AutoSize = true;
            this.lblTimerDescargaPaq.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimerDescargaPaq.Location = new System.Drawing.Point(198, 72);
            this.lblTimerDescargaPaq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimerDescargaPaq.Name = "lblTimerDescargaPaq";
            this.lblTimerDescargaPaq.Size = new System.Drawing.Size(98, 38);
            this.lblTimerDescargaPaq.TabIndex = 26;
            this.lblTimerDescargaPaq.Text = "00:00";
            // 
            // chkTodo
            // 
            this.chkTodo.AutoSize = true;
            this.chkTodo.Location = new System.Drawing.Point(306, 22);
            this.chkTodo.Margin = new System.Windows.Forms.Padding(4);
            this.chkTodo.Name = "chkTodo";
            this.chkTodo.Size = new System.Drawing.Size(110, 20);
            this.chkTodo.TabIndex = 22;
            this.chkTodo.Text = "Mostrar Todo";
            this.chkTodo.UseVisualStyleBackColor = true;
            this.chkTodo.Visible = false;
            // 
            // numRegistros
            // 
            this.numRegistros.AutoSize = true;
            this.numRegistros.Location = new System.Drawing.Point(413, 46);
            this.numRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numRegistros.Name = "numRegistros";
            this.numRegistros.Size = new System.Drawing.Size(21, 16);
            this.numRegistros.TabIndex = 21;
            this.numRegistros.Text = "##";
            this.numRegistros.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Num Registros";
            this.label2.Visible = false;
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(9, 72);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(182, 38);
            this.btnVer.TabIndex = 19;
            this.btnVer.Text = "Iniciar Timer";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // gridPeticiones
            // 
            this.gridPeticiones.AllowUserToAddRows = false;
            this.gridPeticiones.AllowUserToDeleteRows = false;
            this.gridPeticiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPeticiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPeticiones.Location = new System.Drawing.Point(306, 72);
            this.gridPeticiones.Margin = new System.Windows.Forms.Padding(4);
            this.gridPeticiones.Name = "gridPeticiones";
            this.gridPeticiones.ReadOnly = true;
            this.gridPeticiones.RowHeadersWidth = 51;
            this.gridPeticiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPeticiones.Size = new System.Drawing.Size(128, 38);
            this.gridPeticiones.TabIndex = 18;
            this.gridPeticiones.Visible = false;
            // 
            // btnIniciaTimer
            // 
            this.btnIniciaTimer.Location = new System.Drawing.Point(9, 36);
            this.btnIniciaTimer.Name = "btnIniciaTimer";
            this.btnIniciaTimer.Size = new System.Drawing.Size(182, 38);
            this.btnIniciaTimer.TabIndex = 18;
            this.btnIniciaTimer.Text = "Iniciar Timer";
            this.btnIniciaTimer.UseVisualStyleBackColor = true;
            this.btnIniciaTimer.Click += new System.EventHandler(this.btnIniciaTimer_Click);
            // 
            // tmrHora
            // 
            this.tmrHora.Enabled = true;
            this.tmrHora.Tick += new System.EventHandler(this.tmrHora_Tick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 360);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Hora Actual:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Fecha Actual:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmrTemporizador
            // 
            this.tmrTemporizador.Interval = 1000;
            this.tmrTemporizador.Tick += new System.EventHandler(this.tmrTemporizador_Tick);
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemp.Location = new System.Drawing.Point(37, 93);
            this.lblTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(98, 38);
            this.lblTemp.TabIndex = 23;
            this.lblTemp.Text = "00:00";
            // 
            // lblFechAct
            // 
            this.lblFechAct.AutoSize = true;
            this.lblFechAct.Location = new System.Drawing.Point(15, 332);
            this.lblFechAct.Name = "lblFechAct";
            this.lblFechAct.Size = new System.Drawing.Size(93, 16);
            this.lblFechAct.TabIndex = 24;
            this.lblFechAct.Text = "YYYY-MM-DD";
            // 
            // lblHoraAc
            // 
            this.lblHoraAc.AutoSize = true;
            this.lblHoraAc.Location = new System.Drawing.Point(15, 388);
            this.lblHoraAc.Name = "lblHoraAc";
            this.lblHoraAc.Size = new System.Drawing.Size(69, 16);
            this.lblHoraAc.TabIndex = 25;
            this.lblHoraAc.Text = "HH:mm:ss";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtLogEr);
            this.groupBox2.Controls.Add(this.btnIniciaTimer);
            this.groupBox2.Controls.Add(this.lblTemp);
            this.groupBox2.Controls.Add(this.lblHoraAc);
            this.groupBox2.Controls.Add(this.btnDescarga);
            this.groupBox2.Controls.Add(this.lblFechAct);
            this.groupBox2.Controls.Add(this.btnIniciar);
            this.groupBox2.Controls.Add(this.cboEmpresas);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(16, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1223, 415);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Monitor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tiempo para crear Peticiones";
            // 
            // tmrDescargaPaquetes
            // 
            this.tmrDescargaPaquetes.Interval = 1000;
            this.tmrDescargaPaquetes.Tick += new System.EventHandler(this.tmrDescargaPaquetes_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDescargaMetadata);
            this.groupBox3.Controls.Add(this.btnMetadata);
            this.groupBox3.Controls.Add(this.datePickerFinal);
            this.groupBox3.Controls.Add(this.datePickerInicial);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(811, 433);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 131);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Descarga MetaData";
            // 
            // btnDescargaMetadata
            // 
            this.btnDescargaMetadata.Location = new System.Drawing.Point(232, 87);
            this.btnDescargaMetadata.Name = "btnDescargaMetadata";
            this.btnDescargaMetadata.Size = new System.Drawing.Size(190, 38);
            this.btnDescargaMetadata.TabIndex = 21;
            this.btnDescargaMetadata.Text = "Descarga MetaData";
            this.btnDescargaMetadata.UseVisualStyleBackColor = true;
            this.btnDescargaMetadata.Click += new System.EventHandler(this.btnDescargaMetadata_Click);
            // 
            // btnMetadata
            // 
            this.btnMetadata.Location = new System.Drawing.Point(6, 87);
            this.btnMetadata.Name = "btnMetadata";
            this.btnMetadata.Size = new System.Drawing.Size(190, 38);
            this.btnMetadata.TabIndex = 20;
            this.btnMetadata.Text = "Crear Peticion MetaData";
            this.btnMetadata.UseVisualStyleBackColor = true;
            this.btnMetadata.Click += new System.EventHandler(this.btnMetadata_Click);
            // 
            // datePickerFinal
            // 
            this.datePickerFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerFinal.Location = new System.Drawing.Point(250, 38);
            this.datePickerFinal.Margin = new System.Windows.Forms.Padding(4);
            this.datePickerFinal.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.datePickerFinal.Name = "datePickerFinal";
            this.datePickerFinal.Size = new System.Drawing.Size(116, 22);
            this.datePickerFinal.TabIndex = 15;
            // 
            // datePickerInicial
            // 
            this.datePickerInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerInicial.Location = new System.Drawing.Point(79, 38);
            this.datePickerInicial.Margin = new System.Windows.Forms.Padding(4);
            this.datePickerInicial.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.datePickerInicial.Name = "datePickerInicial";
            this.datePickerInicial.Size = new System.Drawing.Size(117, 22);
            this.datePickerInicial.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(203, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Fin:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Inicio:";
            // 
            // groupBox5
            // 
            this.groupBox5.BackgroundImage = global::DescargaWebService.Properties.Resources.Logo_565x100;
            this.groupBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox5.Location = new System.Drawing.Point(467, 433);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(338, 131);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            // 
            // btnVerPeticiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 576);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "btnVerPeticiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonitorDescargaAutomatica";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeticiones)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox txtLogEr;
        private System.Windows.Forms.Button btnDescarga;
        private System.Windows.Forms.ComboBox cboEmpresas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.DataGridView gridPeticiones;
        private System.Windows.Forms.Label numRegistros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTodo;
        private System.Windows.Forms.Timer tmrHora;
        private System.Windows.Forms.Button btnIniciaTimer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer tmrTemporizador;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblFechAct;
        private System.Windows.Forms.Label lblHoraAc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer tmrDescargaPaquetes;
        private System.Windows.Forms.Label lblTimerDescargaPaq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker datePickerFinal;
        private System.Windows.Forms.DateTimePicker datePickerInicial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnMetadata;
        private System.Windows.Forms.Button btnDescargaMetadata;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}