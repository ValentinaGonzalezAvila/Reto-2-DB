using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Logica;
using Capa_Presentacion;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ClassLogica objent = new ClassLogica();
        ClassPresentacion objneg = new ClassPresentacion();

        public Form1()
        {
            InitializeComponent();
        }
        void mantenimiento(String accion)
        {
            objent.codigo = txtcodigo.Text;
            objent.titulo = txttitulo.Text;
            objent.autor = txtautor.Text;
            objent.editorial = txteditorial.Text;
            objent.precio = Convert.ToInt32(txtprecio.Text);
            objent.cantidad = Convert.ToInt32(txtcantidad.Text);
            objent.accion = accion;
            String men = objneg.N_mantenimiento_libros(objent);
            MessageBox.Show(men, "Mansaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void limpiar()
        {
            txtcodigo.Text = "";
            txttitulo.Text = "";
            txtautor.Text = "";
            txteditorial.Text = "";
            txtprecio.Text = "";
            txtcantidad.Text = "";
            txtbuscar.Text = "";
            dataGridView1.DataSource = objneg.N_listar_libros();
        }


        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.N_listar_libros();

        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text == "")
            {
                if (MessageBox.Show("¿Deseas registrar a " + txttitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + txttitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + txttitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar.Text != "")
            {
                objent.titulo = txtbuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_libros(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.N_listar_libros();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtcodigo.Text = dataGridView1[0, fila].Value.ToString();
            txttitulo.Text = dataGridView1[1, fila].Value.ToString();
            txtautor.Text = dataGridView1[2, fila].Value.ToString();
            txteditorial.Text = dataGridView1[3, fila].Value.ToString();
            txtprecio.Text = dataGridView1[4, fila].Value.ToString();
            txtcantidad.Text = dataGridView1[5, fila].Value.ToString();
        }
    }
}
