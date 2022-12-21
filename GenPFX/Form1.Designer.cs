namespace GenPFX
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PswPFX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PswFiel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CreaPFX_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RutaKey_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.examinar_btn = new System.Windows.Forms.Button();
            this.RutaCer_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.PswPFX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PswFiel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CreaPFX_btn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.RutaKey_txt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.examinar_btn);
            this.groupBox1.Controls.Add(this.RutaCer_txt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 282);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ImageLocation = "http://www.adapli.com/logoitechs.png";
            this.pictureBox1.Location = new System.Drawing.Point(8, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(283, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // PswPFX
            // 
            this.PswPFX.Location = new System.Drawing.Point(155, 242);
            this.PswPFX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PswPFX.Name = "PswPFX";
            this.PswPFX.Size = new System.Drawing.Size(180, 22);
            this.PswPFX.TabIndex = 64;
            this.PswPFX.Text = "Tangamanga1#";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 246);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 63;
            this.label4.Text = "Contraseña PFX";
            // 
            // PswFiel
            // 
            this.PswFiel.Location = new System.Drawing.Point(155, 207);
            this.PswFiel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PswFiel.Name = "PswFiel";
            this.PswFiel.Size = new System.Drawing.Size(180, 22);
            this.PswFiel.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 210);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 61;
            this.label3.Text = "Contraseña FIEL";
            // 
            // CreaPFX_btn
            // 
            this.CreaPFX_btn.Location = new System.Drawing.Point(482, 213);
            this.CreaPFX_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreaPFX_btn.Name = "CreaPFX_btn";
            this.CreaPFX_btn.Size = new System.Drawing.Size(92, 49);
            this.CreaPFX_btn.TabIndex = 60;
            this.CreaPFX_btn.Text = "Crear";
            this.CreaPFX_btn.UseVisualStyleBackColor = true;
            this.CreaPFX_btn.Click += new System.EventHandler(this.CreaPFX_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 173);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 59;
            this.label2.Text = "Archivo .key";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(533, 170);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 28);
            this.button1.TabIndex = 58;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RutaKey_txt
            // 
            this.RutaKey_txt.AllowDrop = true;
            this.RutaKey_txt.Location = new System.Drawing.Point(155, 173);
            this.RutaKey_txt.Margin = new System.Windows.Forms.Padding(4);
            this.RutaKey_txt.Name = "RutaKey_txt";
            this.RutaKey_txt.Size = new System.Drawing.Size(369, 22);
            this.RutaKey_txt.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "Archivo .cer";
            // 
            // examinar_btn
            // 
            this.examinar_btn.Location = new System.Drawing.Point(533, 131);
            this.examinar_btn.Margin = new System.Windows.Forms.Padding(4);
            this.examinar_btn.Name = "examinar_btn";
            this.examinar_btn.Size = new System.Drawing.Size(41, 28);
            this.examinar_btn.TabIndex = 55;
            this.examinar_btn.Text = "...";
            this.examinar_btn.UseVisualStyleBackColor = true;
            this.examinar_btn.Click += new System.EventHandler(this.examinar_btn_Click);
            // 
            // RutaCer_txt
            // 
            this.RutaCer_txt.AllowDrop = true;
            this.RutaCer_txt.Location = new System.Drawing.Point(155, 134);
            this.RutaCer_txt.Margin = new System.Windows.Forms.Padding(4);
            this.RutaCer_txt.Name = "RutaCer_txt";
            this.RutaCer_txt.Size = new System.Drawing.Size(369, 22);
            this.RutaCer_txt.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(297, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(268, 39);
            this.label5.TabIndex = 66;
            this.label5.Text = "Generador PFX";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 306);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox PswPFX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PswFiel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CreaPFX_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox RutaKey_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button examinar_btn;
        private System.Windows.Forms.TextBox RutaCer_txt;
        private System.Windows.Forms.Label label5;
    }
}

