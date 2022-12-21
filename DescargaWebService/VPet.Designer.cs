namespace DescargaWebService
{
    partial class VPet
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkTodo = new System.Windows.Forms.CheckBox();
            this.numRegistros = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DescargarTodo_btn = new System.Windows.Forms.Button();
            this.gridPeticiones = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeticiones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.gridPeticiones);
            this.groupBox1.Controls.Add(this.btnVolver);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1055, 659);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticiones";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkTodo);
            this.groupBox2.Controls.Add(this.numRegistros);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.DescargarTodo_btn);
            this.groupBox2.Location = new System.Drawing.Point(7, 535);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1044, 117);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones";
            // 
            // chkTodo
            // 
            this.chkTodo.AutoSize = true;
            this.chkTodo.Location = new System.Drawing.Point(265, 30);
            this.chkTodo.Margin = new System.Windows.Forms.Padding(4);
            this.chkTodo.Name = "chkTodo";
            this.chkTodo.Size = new System.Drawing.Size(110, 20);
            this.chkTodo.TabIndex = 9;
            this.chkTodo.Text = "Mostrar Todo";
            this.chkTodo.UseVisualStyleBackColor = true;
            this.chkTodo.CheckedChanged += new System.EventHandler(this.chkTodo_CheckedChanged);
            // 
            // numRegistros
            // 
            this.numRegistros.AutoSize = true;
            this.numRegistros.Location = new System.Drawing.Point(1015, 22);
            this.numRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numRegistros.Name = "numRegistros";
            this.numRegistros.Size = new System.Drawing.Size(21, 16);
            this.numRegistros.TabIndex = 8;
            this.numRegistros.Text = "##";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(911, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Num Registros";
            // 
            // DescargarTodo_btn
            // 
            this.DescargarTodo_btn.Location = new System.Drawing.Point(115, 22);
            this.DescargarTodo_btn.Margin = new System.Windows.Forms.Padding(4);
            this.DescargarTodo_btn.Name = "DescargarTodo_btn";
            this.DescargarTodo_btn.Size = new System.Drawing.Size(142, 28);
            this.DescargarTodo_btn.TabIndex = 4;
            this.DescargarTodo_btn.Text = "Descargar Todo";
            this.DescargarTodo_btn.UseVisualStyleBackColor = true;
            this.DescargarTodo_btn.Click += new System.EventHandler(this.DescargarTodo_btn_Click);
            // 
            // gridPeticiones
            // 
            this.gridPeticiones.AllowUserToAddRows = false;
            this.gridPeticiones.AllowUserToDeleteRows = false;
            this.gridPeticiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPeticiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPeticiones.Location = new System.Drawing.Point(4, 65);
            this.gridPeticiones.Margin = new System.Windows.Forms.Padding(4);
            this.gridPeticiones.Name = "gridPeticiones";
            this.gridPeticiones.ReadOnly = true;
            this.gridPeticiones.RowHeadersWidth = 51;
            this.gridPeticiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPeticiones.Size = new System.Drawing.Size(1047, 463);
            this.gridPeticiones.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(972, 13);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(70, 28);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Salir";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // VPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 659);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "VPet";
            this.Text = "VPet";
            this.Load += new System.EventHandler(this.VPet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeticiones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridPeticiones;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DescargarTodo_btn;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label numRegistros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTodo;
    }
}