namespace GUI
{
    partial class Entidades
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Articulo = new System.Windows.Forms.TabPage();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.chkAV = new System.Windows.Forms.CheckBox();
            this.chkAC = new System.Windows.Forms.CheckBox();
            this.chkAI = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Articulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Articulo);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 376);
            this.tabControl1.TabIndex = 0;
            // 
            // Articulo
            // 
            this.Articulo.Controls.Add(this.btnDelete);
            this.Articulo.Controls.Add(this.txtCP);
            this.Articulo.Controls.Add(this.label4);
            this.Articulo.Controls.Add(this.button2);
            this.Articulo.Controls.Add(this.button1);
            this.Articulo.Controls.Add(this.txtGroup);
            this.Articulo.Controls.Add(this.txtDescrip);
            this.Articulo.Controls.Add(this.txtCode);
            this.Articulo.Controls.Add(this.chkAV);
            this.Articulo.Controls.Add(this.chkAC);
            this.Articulo.Controls.Add(this.chkAI);
            this.Articulo.Controls.Add(this.label3);
            this.Articulo.Controls.Add(this.label2);
            this.Articulo.Controls.Add(this.label1);
            this.Articulo.Location = new System.Drawing.Point(4, 22);
            this.Articulo.Name = "Articulo";
            this.Articulo.Padding = new System.Windows.Forms.Padding(3);
            this.Articulo.Size = new System.Drawing.Size(752, 350);
            this.Articulo.TabIndex = 0;
            this.Articulo.Text = "Articulo";
            this.Articulo.UseVisualStyleBackColor = true;
            // 
            // txtCP
            // 
            this.txtCP.Location = new System.Drawing.Point(112, 131);
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(163, 20);
            this.txtCP.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Campo Prueba";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Cargar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Crear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(98, 91);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(177, 20);
            this.txtGroup.TabIndex = 8;
            // 
            // txtDescrip
            // 
            this.txtDescrip.Location = new System.Drawing.Point(98, 56);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(177, 20);
            this.txtDescrip.TabIndex = 7;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(98, 24);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(177, 20);
            this.txtCode.TabIndex = 6;
            // 
            // chkAV
            // 
            this.chkAV.AutoSize = true;
            this.chkAV.Location = new System.Drawing.Point(387, 91);
            this.chkAV.Name = "chkAV";
            this.chkAV.Size = new System.Drawing.Size(92, 17);
            this.chkAV.TabIndex = 5;
            this.chkAV.Text = "Articulo Venta";
            this.chkAV.UseVisualStyleBackColor = true;
            // 
            // chkAC
            // 
            this.chkAC.AutoSize = true;
            this.chkAC.Location = new System.Drawing.Point(387, 56);
            this.chkAC.Name = "chkAC";
            this.chkAC.Size = new System.Drawing.Size(100, 17);
            this.chkAC.TabIndex = 4;
            this.chkAC.Text = "Articulo Compra";
            this.chkAC.UseVisualStyleBackColor = true;
            // 
            // chkAI
            // 
            this.chkAI.AutoSize = true;
            this.chkAI.Location = new System.Drawing.Point(387, 24);
            this.chkAI.Name = "chkAI";
            this.chkAI.Size = new System.Drawing.Size(111, 17);
            this.chkAI.TabIndex = 3;
            this.chkAI.Text = "Articulo Inventario";
            this.chkAI.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Grupo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Socios de Negocio";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(220, 173);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Entidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Entidades";
            this.Text = "Entidades";
            this.tabControl1.ResumeLayout(false);
            this.Articulo.ResumeLayout(false);
            this.Articulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Articulo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.CheckBox chkAV;
        private System.Windows.Forms.CheckBox chkAC;
        private System.Windows.Forms.CheckBox chkAI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
    }
}