namespace CapaPresentacion
{
    partial class frmnegocio
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
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.icbguardarcambios = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdir = new System.Windows.Forms.TextBox();
            this.txtruc = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.icbsubirimagen = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.piclogo = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(34, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 25);
            this.label9.TabIndex = 48;
            this.label9.Text = "Datos del negocio";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(524, 450);
            this.label1.TabIndex = 47;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.icbguardarcambios);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtdir);
            this.groupBox1.Controls.Add(this.txtruc);
            this.groupBox1.Controls.Add(this.txtnombre);
            this.groupBox1.Controls.Add(this.icbsubirimagen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.piclogo);
            this.groupBox1.Location = new System.Drawing.Point(39, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 361);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // icbguardarcambios
            // 
            this.icbguardarcambios.BackColor = System.Drawing.SystemColors.Control;
            this.icbguardarcambios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icbguardarcambios.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.icbguardarcambios.FlatAppearance.BorderSize = 2;
            this.icbguardarcambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icbguardarcambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbguardarcambios.ForeColor = System.Drawing.Color.Black;
            this.icbguardarcambios.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.icbguardarcambios.IconColor = System.Drawing.Color.Black;
            this.icbguardarcambios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icbguardarcambios.IconSize = 16;
            this.icbguardarcambios.Location = new System.Drawing.Point(232, 249);
            this.icbguardarcambios.Name = "icbguardarcambios";
            this.icbguardarcambios.Size = new System.Drawing.Size(217, 54);
            this.icbguardarcambios.TabIndex = 87;
            this.icbguardarcambios.Text = "Guardar cambios";
            this.icbguardarcambios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.icbguardarcambios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icbguardarcambios.UseVisualStyleBackColor = false;
            this.icbguardarcambios.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 86;
            this.label5.Text = "Direccion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 85;
            this.label4.Text = "RUC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 84;
            this.label3.Text = "Nombre:";
            // 
            // txtdir
            // 
            this.txtdir.Location = new System.Drawing.Point(232, 217);
            this.txtdir.Name = "txtdir";
            this.txtdir.Size = new System.Drawing.Size(217, 26);
            this.txtdir.TabIndex = 83;
            // 
            // txtruc
            // 
            this.txtruc.Location = new System.Drawing.Point(232, 133);
            this.txtruc.Name = "txtruc";
            this.txtruc.Size = new System.Drawing.Size(217, 26);
            this.txtruc.TabIndex = 82;
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(232, 46);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(217, 26);
            this.txtnombre.TabIndex = 81;
            // 
            // icbsubirimagen
            // 
            this.icbsubirimagen.BackColor = System.Drawing.SystemColors.Control;
            this.icbsubirimagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icbsubirimagen.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.icbsubirimagen.FlatAppearance.BorderSize = 2;
            this.icbsubirimagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icbsubirimagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbsubirimagen.ForeColor = System.Drawing.Color.Black;
            this.icbsubirimagen.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.icbsubirimagen.IconColor = System.Drawing.Color.Black;
            this.icbsubirimagen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icbsubirimagen.IconSize = 16;
            this.icbsubirimagen.Location = new System.Drawing.Point(36, 174);
            this.icbsubirimagen.Name = "icbsubirimagen";
            this.icbsubirimagen.Size = new System.Drawing.Size(142, 54);
            this.icbsubirimagen.TabIndex = 80;
            this.icbsubirimagen.Text = "Subir";
            this.icbsubirimagen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.icbsubirimagen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icbsubirimagen.UseVisualStyleBackColor = false;
            this.icbsubirimagen.Click += new System.EventHandler(this.icbsubirimagen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Logo:";
            // 
            // piclogo
            // 
            this.piclogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.piclogo.Location = new System.Drawing.Point(36, 46);
            this.piclogo.Name = "piclogo";
            this.piclogo.Size = new System.Drawing.Size(142, 122);
            this.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.piclogo.TabIndex = 0;
            this.piclogo.TabStop = false;
            // 
            // frmnegocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Name = "frmnegocio";
            this.Text = "frmnegocio";
            this.Load += new System.EventHandler(this.frmnegocio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox piclogo;
        private FontAwesome.Sharp.IconButton icbsubirimagen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdir;
        private System.Windows.Forms.TextBox txtruc;
        private System.Windows.Forms.TextBox txtnombre;
        private FontAwesome.Sharp.IconButton icbguardarcambios;
    }
}