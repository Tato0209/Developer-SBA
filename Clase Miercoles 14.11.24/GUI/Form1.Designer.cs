namespace GUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ServerType = new System.Windows.Forms.Label();
            this.txtPassSAP = new System.Windows.Forms.TextBox();
            this.txtUsuarioSAP = new System.Windows.Forms.TextBox();
            this.txtNombreBD = new System.Windows.Forms.TextBox();
            this.txtServerLC = new System.Windows.Forms.TextBox();
            this.txtPassBD = new System.Windows.Forms.TextBox();
            this.txtUsuarioBD = new System.Windows.Forms.TextBox();
            this.txtServerBD = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.cmbServerType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server BD";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario BD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pass BD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Server Licence";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nombre BD";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Usuario SAP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Pass BD";
            // 
            // ServerType
            // 
            this.ServerType.AutoSize = true;
            this.ServerType.Location = new System.Drawing.Point(54, 270);
            this.ServerType.Name = "ServerType";
            this.ServerType.Size = new System.Drawing.Size(62, 13);
            this.ServerType.TabIndex = 7;
            this.ServerType.Text = "Tipo Server";
            // 
            // txtPassSAP
            // 
            this.txtPassSAP.Location = new System.Drawing.Point(146, 236);
            this.txtPassSAP.Name = "txtPassSAP";
            this.txtPassSAP.Size = new System.Drawing.Size(160, 20);
            this.txtPassSAP.TabIndex = 9;
            this.txtPassSAP.Text = "B1Admin";
            // 
            // txtUsuarioSAP
            // 
            this.txtUsuarioSAP.Location = new System.Drawing.Point(146, 196);
            this.txtUsuarioSAP.Name = "txtUsuarioSAP";
            this.txtUsuarioSAP.Size = new System.Drawing.Size(160, 20);
            this.txtUsuarioSAP.TabIndex = 10;
            this.txtUsuarioSAP.Text = "manager";
            // 
            // txtNombreBD
            // 
            this.txtNombreBD.Location = new System.Drawing.Point(146, 164);
            this.txtNombreBD.Name = "txtNombreBD";
            this.txtNombreBD.Size = new System.Drawing.Size(160, 20);
            this.txtNombreBD.TabIndex = 11;
            this.txtNombreBD.Text = "SBO_QUICKSA_27102024";
            // 
            // txtServerLC
            // 
            this.txtServerLC.Location = new System.Drawing.Point(146, 133);
            this.txtServerLC.Name = "txtServerLC";
            this.txtServerLC.Size = new System.Drawing.Size(160, 20);
            this.txtServerLC.TabIndex = 12;
            // 
            // txtPassBD
            // 
            this.txtPassBD.Location = new System.Drawing.Point(146, 99);
            this.txtPassBD.Name = "txtPassBD";
            this.txtPassBD.Size = new System.Drawing.Size(160, 20);
            this.txtPassBD.TabIndex = 13;
            this.txtPassBD.Text = "B1Admin#$21@SvrH";
            // 
            // txtUsuarioBD
            // 
            this.txtUsuarioBD.Location = new System.Drawing.Point(146, 60);
            this.txtUsuarioBD.Name = "txtUsuarioBD";
            this.txtUsuarioBD.Size = new System.Drawing.Size(160, 20);
            this.txtUsuarioBD.TabIndex = 14;
            this.txtUsuarioBD.Text = "SYSTEM";
            // 
            // txtServerBD
            // 
            this.txtServerBD.Location = new System.Drawing.Point(146, 26);
            this.txtServerBD.Name = "txtServerBD";
            this.txtServerBD.Size = new System.Drawing.Size(160, 20);
            this.txtServerBD.TabIndex = 15;
            this.txtServerBD.Text = "NDB@192.168.1.10:30013";
            this.txtServerBD.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(57, 328);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 16;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(175, 327);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 17;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // cmbServerType
            // 
            this.cmbServerType.FormattingEnabled = true;
            this.cmbServerType.Items.AddRange(new object[] {
            "MYSQL",
            "SQLSERVER",
            "HANA"});
            this.cmbServerType.Location = new System.Drawing.Point(146, 267);
            this.cmbServerType.Name = "cmbServerType";
            this.cmbServerType.Size = new System.Drawing.Size(160, 21);
            this.cmbServerType.TabIndex = 18;
            this.cmbServerType.SelectedIndexChanged += new System.EventHandler(this.cmbServerType_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 374);
            this.Controls.Add(this.cmbServerType);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtServerBD);
            this.Controls.Add(this.txtUsuarioBD);
            this.Controls.Add(this.txtPassBD);
            this.Controls.Add(this.txtServerLC);
            this.Controls.Add(this.txtNombreBD);
            this.Controls.Add(this.txtUsuarioSAP);
            this.Controls.Add(this.txtPassSAP);
            this.Controls.Add(this.ServerType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ServerType;
        private System.Windows.Forms.TextBox txtPassSAP;
        private System.Windows.Forms.TextBox txtUsuarioSAP;
        private System.Windows.Forms.TextBox txtNombreBD;
        private System.Windows.Forms.TextBox txtServerLC;
        private System.Windows.Forms.TextBox txtPassBD;
        private System.Windows.Forms.TextBox txtUsuarioBD;
        private System.Windows.Forms.TextBox txtServerBD;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox cmbServerType;
    }
}

