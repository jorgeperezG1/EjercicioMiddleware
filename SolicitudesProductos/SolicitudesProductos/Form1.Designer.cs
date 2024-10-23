namespace SolicitudesProductos
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
            this.dataGridViewProductos = new System.Windows.Forms.DataGridView();
            this.buttonSolicitar = new System.Windows.Forms.Button();
            this.comboBoxTiendas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProductos
            // 
            this.dataGridViewProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductos.Location = new System.Drawing.Point(63, 178);
            this.dataGridViewProductos.Name = "dataGridViewProductos";
            this.dataGridViewProductos.Size = new System.Drawing.Size(605, 214);
            this.dataGridViewProductos.TabIndex = 0;
            // 
            // buttonSolicitar
            // 
            this.buttonSolicitar.Location = new System.Drawing.Point(421, 94);
            this.buttonSolicitar.Name = "buttonSolicitar";
            this.buttonSolicitar.Size = new System.Drawing.Size(136, 43);
            this.buttonSolicitar.TabIndex = 1;
            this.buttonSolicitar.Text = "seleccionar";
            this.buttonSolicitar.UseVisualStyleBackColor = true;
            this.buttonSolicitar.Click += new System.EventHandler(this.buttonSolicitar_Click);
            // 
            // comboBoxTiendas
            // 
            this.comboBoxTiendas.FormattingEnabled = true;
            this.comboBoxTiendas.Location = new System.Drawing.Point(151, 96);
            this.comboBoxTiendas.Name = "comboBoxTiendas";
            this.comboBoxTiendas.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTiendas.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "VER INVENTARIO";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTiendas);
            this.Controls.Add(this.buttonSolicitar);
            this.Controls.Add(this.dataGridViewProductos);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProductos;
        private System.Windows.Forms.Button buttonSolicitar;
        private System.Windows.Forms.ComboBox comboBoxTiendas;
        private System.Windows.Forms.Label label1;
    }
}

