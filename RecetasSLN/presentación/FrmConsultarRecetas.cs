using RecetasSLN.dominio;
using RecetasSLN.servicios;
using RecetasSLN.servicios.interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultarRecetas : Form
    {
        private Receta nuevaR;
        private IServicio service;
        public FrmConsultarRecetas()
        {
            InitializeComponent();
            nuevaR = new Receta();
            service = new serviceFactoryImpl().crearServicio();
        }

        private void FrmConsultarRecetas_Load(object sender, EventArgs e)
        {
            proximoID();
            cargarCombo();
        }

        private void cargarCombo()
        {
            cboIngrediente.DataSource = service.obtenerNombre();
            cboIngrediente.ValueMember = "ingredienteID"; //Atributos de la clase q cargo en combo
            cboIngrediente.DisplayMember = "nombre"; //Atributo nombre de la clase
        }

        private void proximoID()
        {
            int next = service.proximoID();
            if (next > 0)
            {
                lblNro.Text = "Receta#: " + next.ToString();
            }
            else
            {
                MessageBox.Show("No se pudieron obtener datos de la ultima receta", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboIngrediente.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe elegir un ingrediente", "Error", MessageBoxButtons.OK);
                return;
            }
            if (nudCantidad.Value == 0)
            {
                MessageBox.Show("Debe seleccionar una cantidad!", "Error", MessageBoxButtons.OK);
                return;
            }
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                              //Nombre de la columna del nombre 
                if (row.Cells["ColIngrediente"].Value.ToString().Equals(cboIngrediente.Text))
                {
                    MessageBox.Show("No puede agregar un mismo ingrediente", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            Ingredientes nuevoIng = (Ingredientes)cboIngrediente.SelectedItem;
                                            //Numerador, puede ser un txt ojo
            int nuevaCant = Convert.ToInt32(nudCantidad.Value);

            DetalleRecetas detalleN = new DetalleRecetas(nuevoIng,nuevaCant);
            nuevaR.agregarDetalle(detalleN);
            dgvDetalles.Rows.Add(new object[] {nuevoIng.ingredienteID, nuevoIng.nombre, nudCantidad.Value });

            calcularTotal();
        }
        private void calcularTotal()
        {
            lblTotalIngredientes.Text = "Total ingredientes: " + dgvDetalles.Rows.Count.ToString();
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                                            //posicion del boton quitar
            if (dgvDetalles.CurrentCell.ColumnIndex == 3)
            {
                nuevaR.quitarDetalle(dgvDetalles.CurrentRow.Index);

                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);

                calcularTotal();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
                //VALIDAR QUE NO ESTEN VACIOS
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de la receta", "Error", MessageBoxButtons.OK);
                return;
            }
            if (txtCheff.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del chef", "Error", MessageBoxButtons.OK);
                return;
            }
            if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar el tipo de receta", "Error", MessageBoxButtons.OK);
                return;
            }
            nuevaR.nombreCheff = txtCheff.Text;
            nuevaR.nombreReceta = txtNombre.Text;
            nuevaR.tipoReceta = cboIngrediente.SelectedIndex + 1;

            if (service.guardarAlta(nuevaR))
            {
                MessageBox.Show("Datos insertados con éxito", "Alta", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            proximoID();
        }
        private void LimpiarCampos()
        {
            txtCheff.Text = String.Empty;
            txtNombre.Text = String.Empty;
            cboTipo.SelectedIndex = -1;
            cboIngrediente.SelectedIndex = -1;
            nudCantidad.Value = 1;
            dgvDetalles.Rows.Clear();
            lblNro.Text = "Receta #:" + service.proximoID().ToString();
            lblTotalIngredientes.Text = "Total de ingredientes:";
        }
    }
}
