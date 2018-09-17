using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace solucionTrabajoPracticoUno
{
    public partial class frmCalculadora : Form
    {
        public Numero numeroUno;
        public Numero numeroDos;
        public double resultado;
        public string operando;
        public Calculadora operacion;

        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void txtNumeroUno_TextChanged(object sender, EventArgs e)
        {
            numeroUno = new Numero(txtNumeroUno.Text);
        }

        private void cmbOperando_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.operando = cmbOperando.Text;
        }

        private void txtNumeroDos_TextChanged(object sender, EventArgs e)
        {
            numeroDos = new Numero(txtNumeroDos.Text);
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumeroUno.Text = string.Empty;
            this.txtNumeroDos.Text = string.Empty;
            this.lblResultado.Text = string.Empty;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            operacion = new Calculadora();
            resultado = operacion.operar(numeroUno, numeroDos, operando);
            lblResultado.Text = resultado.ToString();
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        { 
            
        }
    }
}
