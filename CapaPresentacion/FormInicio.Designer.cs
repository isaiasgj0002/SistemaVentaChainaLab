namespace CapaPresentacion
{
    partial class FormInicio
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuusuario = new FontAwesome.Sharp.IconMenuItem();
            this.menumantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.icmcategoria = new FontAwesome.Sharp.IconMenuItem();
            this.icmproducto = new FontAwesome.Sharp.IconMenuItem();
            this.imcplatos = new FontAwesome.Sharp.IconMenuItem();
            this.submenunegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuventas = new FontAwesome.Sharp.IconMenuItem();
            this.icmregistrar = new FontAwesome.Sharp.IconMenuItem();
            this.icmdetalle = new FontAwesome.Sharp.IconMenuItem();
            this.menucompras = new FontAwesome.Sharp.IconMenuItem();
            this.icmregistrarcompra = new FontAwesome.Sharp.IconMenuItem();
            this.icmdetallecompra = new FontAwesome.Sharp.IconMenuItem();
            this.menuproveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menuacercade = new FontAwesome.Sharp.IconMenuItem();
            this.menuclientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbluser = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuusuario,
            this.menumantenedor,
            this.menuventas,
            this.menucompras,
            this.menuproveedores,
            this.menuacercade,
            this.menuclientes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 88);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1677, 73);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menu";
            // 
            // menuusuario
            // 
            this.menuusuario.AutoSize = false;
            this.menuusuario.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.menuusuario.IconChar = FontAwesome.Sharp.IconChar.UserCog;
            this.menuusuario.IconColor = System.Drawing.Color.Black;
            this.menuusuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuusuario.IconSize = 30;
            this.menuusuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuusuario.Name = "menuusuario";
            this.menuusuario.Size = new System.Drawing.Size(182, 69);
            this.menuusuario.Text = "Usuarios";
            this.menuusuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuusuario.Click += new System.EventHandler(this.menuusuario_Click);
            // 
            // menumantenedor
            // 
            this.menumantenedor.AutoSize = false;
            this.menumantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.icmcategoria,
            this.icmproducto,
            this.imcplatos,
            this.submenunegocio});
            this.menumantenedor.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.menumantenedor.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.menumantenedor.IconColor = System.Drawing.Color.Black;
            this.menumantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menumantenedor.IconSize = 30;
            this.menumantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menumantenedor.Name = "menumantenedor";
            this.menumantenedor.Size = new System.Drawing.Size(182, 69);
            this.menumantenedor.Text = "Mantenedor";
            this.menumantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // icmcategoria
            // 
            this.icmcategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icmcategoria.IconColor = System.Drawing.Color.Black;
            this.icmcategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icmcategoria.Name = "icmcategoria";
            this.icmcategoria.Size = new System.Drawing.Size(177, 34);
            this.icmcategoria.Text = "Categoria";
            this.icmcategoria.Click += new System.EventHandler(this.icmcategoria_Click);
            // 
            // icmproducto
            // 
            this.icmproducto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icmproducto.IconColor = System.Drawing.Color.Black;
            this.icmproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icmproducto.Name = "icmproducto";
            this.icmproducto.Size = new System.Drawing.Size(177, 34);
            this.icmproducto.Text = "Producto";
            this.icmproducto.Click += new System.EventHandler(this.icmproducto_Click);
            // 
            // imcplatos
            // 
            this.imcplatos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.imcplatos.IconColor = System.Drawing.Color.Black;
            this.imcplatos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imcplatos.Name = "imcplatos";
            this.imcplatos.Size = new System.Drawing.Size(177, 34);
            this.imcplatos.Text = "Platos";
            this.imcplatos.Click += new System.EventHandler(this.imcplatos_Click);
            // 
            // submenunegocio
            // 
            this.submenunegocio.Name = "submenunegocio";
            this.submenunegocio.Size = new System.Drawing.Size(177, 34);
            this.submenunegocio.Text = "Negocio";
            this.submenunegocio.Click += new System.EventHandler(this.submenunegocio_Click);
            // 
            // menuventas
            // 
            this.menuventas.AutoSize = false;
            this.menuventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.icmregistrar,
            this.icmdetalle});
            this.menuventas.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.menuventas.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.menuventas.IconColor = System.Drawing.Color.Black;
            this.menuventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuventas.IconSize = 30;
            this.menuventas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuventas.Name = "menuventas";
            this.menuventas.Size = new System.Drawing.Size(182, 69);
            this.menuventas.Text = "Ventas";
            this.menuventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // icmregistrar
            // 
            this.icmregistrar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icmregistrar.IconColor = System.Drawing.Color.Black;
            this.icmregistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icmregistrar.Name = "icmregistrar";
            this.icmregistrar.Size = new System.Drawing.Size(185, 34);
            this.icmregistrar.Text = "Registrar";
            this.icmregistrar.Click += new System.EventHandler(this.icmregistrar_Click);
            // 
            // icmdetalle
            // 
            this.icmdetalle.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icmdetalle.IconColor = System.Drawing.Color.Black;
            this.icmdetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icmdetalle.Name = "icmdetalle";
            this.icmdetalle.Size = new System.Drawing.Size(185, 34);
            this.icmdetalle.Text = "Ver Detalle";
            this.icmdetalle.Click += new System.EventHandler(this.icmdetalle_Click);
            // 
            // menucompras
            // 
            this.menucompras.AutoSize = false;
            this.menucompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.icmregistrarcompra,
            this.icmdetallecompra});
            this.menucompras.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.menucompras.IconChar = FontAwesome.Sharp.IconChar.CartFlatbed;
            this.menucompras.IconColor = System.Drawing.Color.Black;
            this.menucompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucompras.IconSize = 30;
            this.menucompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucompras.Name = "menucompras";
            this.menucompras.Size = new System.Drawing.Size(182, 69);
            this.menucompras.Text = "Compras";
            this.menucompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // icmregistrarcompra
            // 
            this.icmregistrarcompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icmregistrarcompra.IconColor = System.Drawing.Color.Black;
            this.icmregistrarcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icmregistrarcompra.Name = "icmregistrarcompra";
            this.icmregistrarcompra.Size = new System.Drawing.Size(183, 34);
            this.icmregistrarcompra.Text = "Registrar";
            this.icmregistrarcompra.Click += new System.EventHandler(this.icmregistrarcompra_Click);
            // 
            // icmdetallecompra
            // 
            this.icmdetallecompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icmdetallecompra.IconColor = System.Drawing.Color.Black;
            this.icmdetallecompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icmdetallecompra.Name = "icmdetallecompra";
            this.icmdetallecompra.Size = new System.Drawing.Size(183, 34);
            this.icmdetallecompra.Text = "Ver detalle";
            this.icmdetallecompra.Click += new System.EventHandler(this.icmdetallecompra_Click);
            // 
            // menuproveedores
            // 
            this.menuproveedores.AutoSize = false;
            this.menuproveedores.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.menuproveedores.IconChar = FontAwesome.Sharp.IconChar.Vcard;
            this.menuproveedores.IconColor = System.Drawing.Color.Black;
            this.menuproveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproveedores.IconSize = 30;
            this.menuproveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproveedores.Name = "menuproveedores";
            this.menuproveedores.Size = new System.Drawing.Size(182, 69);
            this.menuproveedores.Text = "Proveedores";
            this.menuproveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuproveedores.Click += new System.EventHandler(this.menuproveedores_Click);
            // 
            // menuacercade
            // 
            this.menuacercade.AutoSize = false;
            this.menuacercade.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.menuacercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuacercade.IconColor = System.Drawing.Color.Black;
            this.menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuacercade.IconSize = 30;
            this.menuacercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuacercade.Name = "menuacercade";
            this.menuacercade.Size = new System.Drawing.Size(182, 69);
            this.menuacercade.Text = "Acerca de";
            this.menuacercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuacercade.Click += new System.EventHandler(this.menuacercade_Click);
            // 
            // menuclientes
            // 
            this.menuclientes.AutoSize = false;
            this.menuclientes.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.menuclientes.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            this.menuclientes.IconColor = System.Drawing.Color.Black;
            this.menuclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuclientes.IconSize = 30;
            this.menuclientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuclientes.Name = "menuclientes";
            this.menuclientes.Size = new System.Drawing.Size(182, 69);
            this.menuclientes.Text = "Clientes";
            this.menuclientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuclientes.Click += new System.EventHandler(this.menuclientes_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.IndianRed;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(1677, 88);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menutitulo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.IndianRed;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(60, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema de ventas";
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 161);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1677, 783);
            this.contenedor.TabIndex = 3;
            this.contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.contenedor_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.IndianRed;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1395, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario: ";
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.BackColor = System.Drawing.Color.IndianRed;
            this.lbluser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluser.Location = new System.Drawing.Point(1491, 39);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(95, 25);
            this.lbluser.TabIndex = 5;
            this.lbluser.Text = "lblusuario";
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1677, 944);
            this.Controls.Add(this.lbluser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de ventas";
            this.Load += new System.EventHandler(this.FormInicio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private FontAwesome.Sharp.IconMenuItem menuusuario;
        private FontAwesome.Sharp.IconMenuItem menumantenedor;
        private FontAwesome.Sharp.IconMenuItem menuventas;
        private FontAwesome.Sharp.IconMenuItem menucompras;
        private FontAwesome.Sharp.IconMenuItem menuproveedores;
        private FontAwesome.Sharp.IconMenuItem menuacercade;
        private FontAwesome.Sharp.IconMenuItem menuclientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbluser;
        private FontAwesome.Sharp.IconMenuItem icmcategoria;
        private FontAwesome.Sharp.IconMenuItem icmproducto;
        private FontAwesome.Sharp.IconMenuItem icmregistrar;
        private FontAwesome.Sharp.IconMenuItem icmdetalle;
        private FontAwesome.Sharp.IconMenuItem icmregistrarcompra;
        private FontAwesome.Sharp.IconMenuItem icmdetallecompra;
        private FontAwesome.Sharp.IconMenuItem imcplatos;
        private System.Windows.Forms.ToolStripMenuItem submenunegocio;
    }
}

