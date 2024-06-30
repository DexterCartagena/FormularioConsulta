using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocio;

namespace DenyTirinaCartagena
{
    public partial class FrmMotivoConsulta : Form
    {
        CN_Consulta oConsulta = new CN_Consulta();
        string accion = "";
        public FrmMotivoConsulta()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            accion = "N";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            accion = "N";
            LimpiarEntradas();
            txtCodigo.Enabled = false;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = true;
        }
        private void LimpiarEntradas()
        {
            txtCodigo.Clear();
            txtNombreCompleto.Clear();
            txtDetalle.Clear();
            txtFecha.Clear();
            txtNombreCompleto.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (accion == "N" || accion == "G")
            {
                accion = "G";
                oConsulta.NOMBRE_COMPLETO = txtNombreCompleto.Text;
                oConsulta.DETALLE = txtDetalle.Text;
                oConsulta.FECHA = txtFecha.Text;
                if (oConsulta.Guardar())
                {
                    MessageBox.Show("datos correctos");

                }
                else
                {
                    MessageBox.Show("error verifique los datos");
                }
                if (accion == "M")
                {
                    oConsulta.NOMBRE_COMPLETO = txtNombreCompleto.Text;
                    oConsulta.DETALLE = txtDetalle.Text;
                    oConsulta.FECHA = txtFecha.Text;
                    if (oConsulta.Modificar(txtCodigo.Text))
                    {
                        MessageBox.Show("datos modificados correctamente");

                    }
                    else
                    {
                        MessageBox.Show("error verifique los datos");
                    }
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            accion = "M";
            LimpiarEntradas();
            txtCodigo.Enabled = true;
            txtCodigo.Focus();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable TablaConsulta = new DataTable();

                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("se abre una ventana");
                }
                else
                {
                   if (oConsulta.VerificarCliente(txtCodigo.Text, ref TablaConsulta))
                    {
                        txtNombreCompleto.Text = TablaConsulta.Rows[0][0].ToString();
                        txtDetalle.Text = TablaConsulta.Rows[0][1].ToString();
                        txtFecha.Text = TablaConsulta.Rows[0][2].ToString();

                    }
                    else
                    {
                        MessageBox.Show("error de Dato y/o El codigo no existe");
                        txtCodigo.Clear();
                        LimpiarEntradas();
                        txtCodigo.Focus();
                    }
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            accion = "I";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (accion == "N")
            {
                accion = "E";
                txtCodigo.Enabled = true;
                txtCodigo.Focus();
                btnGuardar.Enabled = false;
                btnModificar.Enabled = false;
            }
            else
            {
                if (accion == "E")
                {
                    accion = "N";

                    if (oConsulta.Eliminar(txtCodigo.Text))
                    {
                        MessageBox.Show("Datos Eliminado Correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Error Verifique los Dato");
                    }
                    LimpiarEntradas();
                    btnCancelar_Click(sender, e);
                }
            }
        }
    }
}
