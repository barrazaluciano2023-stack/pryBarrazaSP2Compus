namespace pryBarrazaSP2Compus
{
    partial class frmPrincipal
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
            this.lblInformacion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMigracion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInformacion
            // 
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.Location = new System.Drawing.Point(20, 31);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(35, 13);
            this.lblInformacion.TabIndex = 0;
            this.lblInformacion.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInformacion);
            this.groupBox1.Location = new System.Drawing.Point(12, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 311);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion:";
            // 
            // btnMigracion
            // 
            this.btnMigracion.Location = new System.Drawing.Point(380, 73);
            this.btnMigracion.Name = "btnMigracion";
            this.btnMigracion.Size = new System.Drawing.Size(143, 33);
            this.btnMigracion.TabIndex = 2;
            this.btnMigracion.Text = "Iniciar Migración";
            this.btnMigracion.UseVisualStyleBackColor = true;
            this.btnMigracion.Click += new System.EventHandler(this.btnMigracion_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMigracion);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInformacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMigracion;
    }
}