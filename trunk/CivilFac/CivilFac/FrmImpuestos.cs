using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
namespace CivilFac
{
    public partial class FrmImpuestos : Form
    {
        public FrmImpuestos()
        {
            InitializeComponent();
        }

        private void FrmImpuestos_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Insertar();  
        }
        private void GridImpuestos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Eliminar();
        }
        private void GridImpuestos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelecionarRegistro(); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Eliminar();
        }


        #region Metodos Privados ABC
        private void Eliminar()
        {
            try
            {
                Impuesto ObjImpuestos = new Impuesto();
                ObjImpuestos.Delete(Convert.ToInt32(GridImpuestos.SelectedRows[0].Cells[0].Value));
                LlenarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido un error Al Tratar de eliminar:" + ex.Message);
            }
        }

        private void LlenarGrid()
        {
            try
            {
                GridImpuestos.MultiSelect = false;
                Impuesto ObjImpuestos = new Impuesto();
                GridImpuestos.DataSource = ObjImpuestos.Get("");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido un error Al Tratar de Traer los Datos." + ex.Message);
            }

        }

        private void Insertar()
        {
            try
            {
                Impuesto ObjImpuesto = new Impuesto();
                if (!string.IsNullOrEmpty(this.TxtPKImpuestoId.Text))
                {
                    ObjImpuesto.PKImpuestoId = Convert.ToInt32(this.TxtPKImpuestoId.Text);
                }
                ObjImpuesto.Tasa = Convert.ToInt32(this.TxtTasa.Text);
                ObjImpuesto.DescImpuesto = this.txtImpuesto.Text;
                ObjImpuesto.Insert(ObjImpuesto);
                LlenarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido un error Al Tratar de Insertar el registro." + ex.Message);
            }
        }

        private void SelecionarRegistro()
        { 
         try
            {
                if (GridImpuestos.SelectedRows.Count > 0)
                {
                    this.TxtPKImpuestoId.Text = Convert.ToString(GridImpuestos.SelectedRows[0].Cells[0].Value);
                    this.txtImpuesto.Text = Convert.ToString(GridImpuestos.SelectedRows[0].Cells[1].Value);
                    this.TxtTasa.Text = Convert.ToString(GridImpuestos.SelectedRows[0].Cells[2].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido un error Al Tratar de Seleccionar El Elemento:" + ex.Message);
            }
        }

        #endregion
    }
}
