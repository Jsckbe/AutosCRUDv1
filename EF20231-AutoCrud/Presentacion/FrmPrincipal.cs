using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Negocios;


namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        NegAuto objNegAuto = new NegAuto();
        private bool sortAscending = false;
        public FrmPrincipal()
        {
            InitializeComponent();
        }


        void ActualizarDatagridView()
        {
            dgAutos.DataSource = objNegAuto.ListarAuto();
            //dgAutos.Columns["placa"].Visible= false;  //Para no mostrar la columna placa
            btnModificar.Enabled=false;
            btnEliminar.Enabled=false;
            txtPlaca.Text = "";
            txtPlaca.Focus();
        }

        void ActualizarBoton()
        {
            dgAutos.DataSource = objNegAuto.ListarAuto();
            //dgAutos.Columns["placa"].Visible = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            txtPlaca.Text = "";
            //txtPlaca.Focus();
            cboMarca.Text = "";
            txtModelo.Text = "";
            txtColor.Text = "";
            cboAnio.Text = "";
            cboCombustible.Text = "";
            txtPlaca.Focus();
        }


        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarDatagridView();
        }

        private void dgAutos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IEnumerable<Auto> listado = objNegAuto.ListarAuto();
            String NombreColSelec = dgAutos.Columns[e.ColumnIndex].Name;
            if (sortAscending)
                dgAutos.DataSource = listado.OrderBy(_ => _.GetType().GetProperty(NombreColSelec).GetValue(_)).ToList();
            else
                dgAutos.DataSource = listado.OrderByDescending(_ => _.GetType().GetProperty(NombreColSelec).GetValue(_)).ToList();
            sortAscending = !sortAscending;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text != "" &  cboMarca.Text != "" & txtModelo.Text != "" & txtColor.Text != "" & cboAnio.Text != "" & cboCombustible.Text != "")
            {
                Auto objAuto = new Auto();
                objAuto.placa = txtPlaca.Text;
                objAuto.marca = cboMarca.Text;
                objAuto.modelo = txtModelo.Text;
                objAuto.color = txtColor.Text;
                objAuto.año = Convert.ToInt32(cboAnio.Text);
                objAuto.combustible = cboCombustible.Text;

                MessageBox.Show(objNegAuto.RegistrarAuto(objAuto));
                ActualizarDatagridView();
            }
            else
            {
                MessageBox.Show("Debe ingresar todos los datos del Auto");
            }
        }

        private void dgAutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgAutos.SelectedCells.Count > 0)
            if(e.RowIndex > -1)
            {   //DataGridViewRow filaSeleccionada = dgPaises.SelectedRows[0];
                DataGridViewRow filaSeleccionada = dgAutos.Rows[e.RowIndex];
                txtPlaca.Text= filaSeleccionada.Cells["placa"].Value.ToString();
                btnModificar.Enabled= true;
                btnEliminar.Enabled= true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text != "" & cboMarca.Text != "" & txtModelo.Text != "" & txtColor.Text != "" & cboAnio.Text != "" & cboCombustible.Text != "")
            {

                string placa = Convert.ToString(dgAutos.SelectedRows[0].Cells[0].Value);
            Auto objAuto = new Auto();
            //objAuto.placa - string;
            objAuto.placa = placa;
            objAuto.marca = cboMarca.Text;
            
            objAuto.modelo = txtModelo.Text;
            objAuto.color = txtColor.Text;
            objAuto.año = Convert.ToInt32(cboAnio.Text);
            objAuto.combustible = cboCombustible.Text;

            MessageBox.Show(objNegAuto.ModificarAuto(objAuto));
            ActualizarDatagridView();
            }
            else
            {
                MessageBox.Show("Debe ingresar todos los datos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string placa = Convert.ToString(dgAutos.SelectedRows[0].Cells[0].Value);
            MessageBox.Show(objNegAuto.EliminarAuto(placa));
            ActualizarDatagridView();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //ActualizarDatagridView();
            ActualizarBoton();
        }
    }


}
