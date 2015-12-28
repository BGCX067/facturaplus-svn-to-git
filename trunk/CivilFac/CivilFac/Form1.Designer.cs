namespace CivilFac
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monedasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formasDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metodosDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foliosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conceptosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utileriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnCrearFactura = new System.Windows.Forms.Button();
            this.BtnConsultarFacturas = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnImprimirFactura = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.catalogosToolStripMenuItem,
            this.utileriasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItem1.Text = "Facturas";
            // 
            // catalogosToolStripMenuItem
            // 
            this.catalogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.impuestosToolStripMenuItem,
            this.monedasToolStripMenuItem,
            this.formasDePagoToolStripMenuItem,
            this.metodosDePagoToolStripMenuItem,
            this.seriesToolStripMenuItem,
            this.foliosToolStripMenuItem,
            this.conceptosToolStripMenuItem});
            this.catalogosToolStripMenuItem.Name = "catalogosToolStripMenuItem";
            this.catalogosToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.catalogosToolStripMenuItem.Text = "&Catálogos";
            // 
            // impuestosToolStripMenuItem
            // 
            this.impuestosToolStripMenuItem.Name = "impuestosToolStripMenuItem";
            this.impuestosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.impuestosToolStripMenuItem.Text = "&Impuestos";
            this.impuestosToolStripMenuItem.Click += new System.EventHandler(this.impuestosToolStripMenuItem_Click);
            // 
            // monedasToolStripMenuItem
            // 
            this.monedasToolStripMenuItem.Name = "monedasToolStripMenuItem";
            this.monedasToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.monedasToolStripMenuItem.Text = "&Monedas";
            // 
            // formasDePagoToolStripMenuItem
            // 
            this.formasDePagoToolStripMenuItem.Name = "formasDePagoToolStripMenuItem";
            this.formasDePagoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.formasDePagoToolStripMenuItem.Text = "&Formas de Pago";
            // 
            // metodosDePagoToolStripMenuItem
            // 
            this.metodosDePagoToolStripMenuItem.Name = "metodosDePagoToolStripMenuItem";
            this.metodosDePagoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.metodosDePagoToolStripMenuItem.Text = "&Metodos de Pago";
            // 
            // seriesToolStripMenuItem
            // 
            this.seriesToolStripMenuItem.Name = "seriesToolStripMenuItem";
            this.seriesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.seriesToolStripMenuItem.Text = "&Series";
            // 
            // foliosToolStripMenuItem
            // 
            this.foliosToolStripMenuItem.Name = "foliosToolStripMenuItem";
            this.foliosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.foliosToolStripMenuItem.Text = "&Folios";
            // 
            // conceptosToolStripMenuItem
            // 
            this.conceptosToolStripMenuItem.Name = "conceptosToolStripMenuItem";
            this.conceptosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.conceptosToolStripMenuItem.Text = "&Conceptos";
            // 
            // utileriasToolStripMenuItem
            // 
            this.utileriasToolStripMenuItem.Name = "utileriasToolStripMenuItem";
            this.utileriasToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.utileriasToolStripMenuItem.Text = "&Utilerias";
            this.utileriasToolStripMenuItem.Click += new System.EventHandler(this.utileriasToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "&Ayuda";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.BtnImprimirFactura, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnSalir, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnConsultarFacturas, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnCrearFactura, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(772, 124);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // BtnCrearFactura
            // 
            this.BtnCrearFactura.Location = new System.Drawing.Point(3, 3);
            this.BtnCrearFactura.Name = "BtnCrearFactura";
            this.BtnCrearFactura.Size = new System.Drawing.Size(187, 118);
            this.BtnCrearFactura.TabIndex = 0;
            this.BtnCrearFactura.Text = "C&rear Factura";
            this.BtnCrearFactura.UseVisualStyleBackColor = true;
            // 
            // BtnConsultarFacturas
            // 
            this.BtnConsultarFacturas.Location = new System.Drawing.Point(389, 3);
            this.BtnConsultarFacturas.Name = "BtnConsultarFacturas";
            this.BtnConsultarFacturas.Size = new System.Drawing.Size(187, 117);
            this.BtnConsultarFacturas.TabIndex = 1;
            this.BtnConsultarFacturas.Text = "Consultar &Facturas";
            this.BtnConsultarFacturas.UseVisualStyleBackColor = true;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(582, 3);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(187, 117);
            this.BtnSalir.TabIndex = 2;
            this.BtnSalir.Text = "&Salir del sistema";
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // BtnImprimirFactura
            // 
            this.BtnImprimirFactura.Location = new System.Drawing.Point(196, 3);
            this.BtnImprimirFactura.Name = "BtnImprimirFactura";
            this.BtnImprimirFactura.Size = new System.Drawing.Size(187, 117);
            this.BtnImprimirFactura.TabIndex = 3;
            this.BtnImprimirFactura.Text = "&Imprimir Factura";
            this.BtnImprimirFactura.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 212);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MaximumSize = new System.Drawing.Size(800, 250);
            this.MinimumSize = new System.Drawing.Size(800, 250);
            this.Name = "Form1";
            this.Text = "Factura Electrónica CFDI";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem catalogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utileriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monedasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formasDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metodosDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foliosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conceptosToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnImprimirFactura;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnConsultarFacturas;
        private System.Windows.Forms.Button BtnCrearFactura;
    }
}

