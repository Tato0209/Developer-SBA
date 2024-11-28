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
            this.btnDelete = new System.Windows.Forms.Button();
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
            this.SocioNegocio = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.txtBP = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Asiento = new System.Windows.Forms.TabPage();
            this.txtJECC = new System.Windows.Forms.TextBox();
            this.txtJEC = new System.Windows.Forms.TextBox();
            this.txtJE = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.DocMkt = new System.Windows.Forms.TabPage();
            this.txtNC = new System.Windows.Forms.TextBox();
            this.txtFC = new System.Windows.Forms.TextBox();
            this.txtDC = new System.Windows.Forms.TextBox();
            this.txtEM = new System.Windows.Forms.TextBox();
            this.txtOC = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.btnEM = new System.Windows.Forms.Button();
            this.btnOC = new System.Windows.Forms.Button();
            this.Inventario = new System.Windows.Forms.TabPage();
            this.txtTI = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.txtSI = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.txtEI = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Articulo.SuspendLayout();
            this.SocioNegocio.SuspendLayout();
            this.Asiento.SuspendLayout();
            this.DocMkt.SuspendLayout();
            this.Inventario.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Articulo);
            this.tabControl1.Controls.Add(this.SocioNegocio);
            this.tabControl1.Controls.Add(this.Asiento);
            this.tabControl1.Controls.Add(this.DocMkt);
            this.tabControl1.Controls.Add(this.Inventario);
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
            // SocioNegocio
            // 
            this.SocioNegocio.Controls.Add(this.button6);
            this.SocioNegocio.Controls.Add(this.button5);
            this.SocioNegocio.Controls.Add(this.txtBP);
            this.SocioNegocio.Controls.Add(this.button4);
            this.SocioNegocio.Controls.Add(this.button3);
            this.SocioNegocio.Location = new System.Drawing.Point(4, 22);
            this.SocioNegocio.Name = "SocioNegocio";
            this.SocioNegocio.Padding = new System.Windows.Forms.Padding(3);
            this.SocioNegocio.Size = new System.Drawing.Size(752, 350);
            this.SocioNegocio.TabIndex = 1;
            this.SocioNegocio.Text = "Socios de Negocio";
            this.SocioNegocio.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(43, 198);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Update";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(43, 147);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Delete";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtBP
            // 
            this.txtBP.Location = new System.Drawing.Point(137, 95);
            this.txtBP.Name = "txtBP";
            this.txtBP.Size = new System.Drawing.Size(200, 20);
            this.txtBP.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(43, 92);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Cargar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(43, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Crear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Asiento
            // 
            this.Asiento.Controls.Add(this.txtJECC);
            this.Asiento.Controls.Add(this.txtJEC);
            this.Asiento.Controls.Add(this.txtJE);
            this.Asiento.Controls.Add(this.button8);
            this.Asiento.Controls.Add(this.button7);
            this.Asiento.Location = new System.Drawing.Point(4, 22);
            this.Asiento.Name = "Asiento";
            this.Asiento.Padding = new System.Windows.Forms.Padding(3);
            this.Asiento.Size = new System.Drawing.Size(752, 350);
            this.Asiento.TabIndex = 2;
            this.Asiento.Text = "Asiento";
            this.Asiento.UseVisualStyleBackColor = true;
            // 
            // txtJECC
            // 
            this.txtJECC.Location = new System.Drawing.Point(133, 151);
            this.txtJECC.Name = "txtJECC";
            this.txtJECC.Size = new System.Drawing.Size(170, 20);
            this.txtJECC.TabIndex = 4;
            // 
            // txtJEC
            // 
            this.txtJEC.Location = new System.Drawing.Point(133, 111);
            this.txtJEC.Name = "txtJEC";
            this.txtJEC.Size = new System.Drawing.Size(170, 20);
            this.txtJEC.TabIndex = 3;
            // 
            // txtJE
            // 
            this.txtJE.Location = new System.Drawing.Point(133, 36);
            this.txtJE.Name = "txtJE";
            this.txtJE.Size = new System.Drawing.Size(170, 20);
            this.txtJE.TabIndex = 2;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(36, 111);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 1;
            this.button8.Text = "Anular";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(36, 36);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 0;
            this.button7.Text = "Crear";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // DocMkt
            // 
            this.DocMkt.Controls.Add(this.txtNC);
            this.DocMkt.Controls.Add(this.txtFC);
            this.DocMkt.Controls.Add(this.txtDC);
            this.DocMkt.Controls.Add(this.txtEM);
            this.DocMkt.Controls.Add(this.txtOC);
            this.DocMkt.Controls.Add(this.button13);
            this.DocMkt.Controls.Add(this.button12);
            this.DocMkt.Controls.Add(this.button11);
            this.DocMkt.Controls.Add(this.btnEM);
            this.DocMkt.Controls.Add(this.btnOC);
            this.DocMkt.Location = new System.Drawing.Point(4, 22);
            this.DocMkt.Name = "DocMkt";
            this.DocMkt.Size = new System.Drawing.Size(752, 350);
            this.DocMkt.TabIndex = 3;
            this.DocMkt.Text = "Documentos MKT";
            this.DocMkt.UseVisualStyleBackColor = true;
            // 
            // txtNC
            // 
            this.txtNC.Location = new System.Drawing.Point(176, 195);
            this.txtNC.Name = "txtNC";
            this.txtNC.Size = new System.Drawing.Size(130, 20);
            this.txtNC.TabIndex = 9;
            // 
            // txtFC
            // 
            this.txtFC.Location = new System.Drawing.Point(176, 152);
            this.txtFC.Name = "txtFC";
            this.txtFC.Size = new System.Drawing.Size(130, 20);
            this.txtFC.TabIndex = 8;
            // 
            // txtDC
            // 
            this.txtDC.Location = new System.Drawing.Point(176, 112);
            this.txtDC.Name = "txtDC";
            this.txtDC.Size = new System.Drawing.Size(130, 20);
            this.txtDC.TabIndex = 7;
            // 
            // txtEM
            // 
            this.txtEM.Location = new System.Drawing.Point(176, 73);
            this.txtEM.Name = "txtEM";
            this.txtEM.Size = new System.Drawing.Size(130, 20);
            this.txtEM.TabIndex = 6;
            // 
            // txtOC
            // 
            this.txtOC.Location = new System.Drawing.Point(176, 32);
            this.txtOC.Name = "txtOC";
            this.txtOC.Size = new System.Drawing.Size(130, 20);
            this.txtOC.TabIndex = 5;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(20, 193);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(150, 23);
            this.button13.TabIndex = 4;
            this.button13.Text = "Nota de Credito";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(20, 150);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(150, 23);
            this.button12.TabIndex = 3;
            this.button12.Text = "Factura Compra";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(20, 110);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(150, 23);
            this.button11.TabIndex = 2;
            this.button11.Text = "Devolucion";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // btnEM
            // 
            this.btnEM.Location = new System.Drawing.Point(20, 71);
            this.btnEM.Name = "btnEM";
            this.btnEM.Size = new System.Drawing.Size(150, 23);
            this.btnEM.TabIndex = 1;
            this.btnEM.Text = "Crear Entrada de Mercancia";
            this.btnEM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEM.UseVisualStyleBackColor = true;
            this.btnEM.Click += new System.EventHandler(this.btnEM_Click);
            // 
            // btnOC
            // 
            this.btnOC.Location = new System.Drawing.Point(20, 32);
            this.btnOC.Name = "btnOC";
            this.btnOC.Size = new System.Drawing.Size(150, 23);
            this.btnOC.TabIndex = 0;
            this.btnOC.Text = "Crear Orden de Compra";
            this.btnOC.UseVisualStyleBackColor = true;
            this.btnOC.Click += new System.EventHandler(this.btnOC_Click);
            // 
            // Inventario
            // 
            this.Inventario.Controls.Add(this.txtTI);
            this.Inventario.Controls.Add(this.button14);
            this.Inventario.Controls.Add(this.txtSI);
            this.Inventario.Controls.Add(this.button10);
            this.Inventario.Controls.Add(this.txtEI);
            this.Inventario.Controls.Add(this.button9);
            this.Inventario.Location = new System.Drawing.Point(4, 22);
            this.Inventario.Name = "Inventario";
            this.Inventario.Size = new System.Drawing.Size(752, 350);
            this.Inventario.TabIndex = 4;
            this.Inventario.Text = "Inventario";
            this.Inventario.UseVisualStyleBackColor = true;
            this.Inventario.Click += new System.EventHandler(this.Inventario_Click);
            // 
            // txtTI
            // 
            this.txtTI.Location = new System.Drawing.Point(208, 127);
            this.txtTI.Name = "txtTI";
            this.txtTI.Size = new System.Drawing.Size(130, 20);
            this.txtTI.TabIndex = 11;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(52, 127);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(150, 23);
            this.button14.TabIndex = 10;
            this.button14.Text = "Crear Transferencia";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // txtSI
            // 
            this.txtSI.Location = new System.Drawing.Point(208, 76);
            this.txtSI.Name = "txtSI";
            this.txtSI.Size = new System.Drawing.Size(130, 20);
            this.txtSI.TabIndex = 9;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(52, 76);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(150, 23);
            this.button10.TabIndex = 8;
            this.button10.Text = "Crear Salida de Inventario";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // txtEI
            // 
            this.txtEI.Location = new System.Drawing.Point(208, 29);
            this.txtEI.Name = "txtEI";
            this.txtEI.Size = new System.Drawing.Size(130, 20);
            this.txtEI.TabIndex = 7;
            this.txtEI.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(52, 29);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(150, 23);
            this.button9.TabIndex = 6;
            this.button9.Text = "Crear Entrada de Inventario";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
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
            this.SocioNegocio.ResumeLayout(false);
            this.SocioNegocio.PerformLayout();
            this.Asiento.ResumeLayout(false);
            this.Asiento.PerformLayout();
            this.DocMkt.ResumeLayout(false);
            this.DocMkt.PerformLayout();
            this.Inventario.ResumeLayout(false);
            this.Inventario.PerformLayout();
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
        private System.Windows.Forms.TabPage SocioNegocio;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtBP;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabPage Asiento;
        private System.Windows.Forms.TextBox txtJECC;
        private System.Windows.Forms.TextBox txtJEC;
        private System.Windows.Forms.TextBox txtJE;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TabPage DocMkt;
        private System.Windows.Forms.TextBox txtNC;
        private System.Windows.Forms.TextBox txtFC;
        private System.Windows.Forms.TextBox txtDC;
        private System.Windows.Forms.TextBox txtEM;
        private System.Windows.Forms.TextBox txtOC;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button btnEM;
        private System.Windows.Forms.Button btnOC;
        private System.Windows.Forms.TabPage Inventario;
        private System.Windows.Forms.TextBox txtEI;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox txtTI;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.TextBox txtSI;
        private System.Windows.Forms.Button button10;
    }
}