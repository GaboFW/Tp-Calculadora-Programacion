using Entidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Calculadora___Integrador
{
    public partial class FrmCalculadora : Form
    {
        private Operacion calculadora;
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private Numeracion resultado;
        private ESistema sistema;

        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperacion.DataSource = new object[] { "", "+", "-", "/", "*" };
            this.rdbDecimal.Checked = true;
        }

        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ventanaCerrar = MessageBox.Show("Desea cerrar la calculadora?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ventanaCerrar == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtPrimerOperando.Clear();
            this.txtSegundoOperando.Clear();
            this.cmbOperacion.Text = "";
            this.labelResultado.Text = "";
        }
        
        private void btnOperar_Click(object sender, EventArgs e)
        {
            //Operacion opero = new Operacion(new Numeracion(txtPrimerOperando.Text, this.sistema), new Numeracion(txtSegundoOperando.Text, this.sistema));

            //char operador;

            //bool resultado = char.TryParse(cmbOperacion.Text, out operador);
            
            //Numeracion resultadoFinal = opero.Operar(operador);

            //this.labelResultado.Text = resultadoFinal.ValorNumerico;

            SetResultado();
        }
        
        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBinario.Checked)
            {
                this.sistema = ESistema.Binario;
            }
        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDecimal.Checked)
            {
                this.sistema = ESistema.Decimal;
            }
        }

        private void SetResultado()
        {
            Operacion opero = new Operacion(new Numeracion(txtPrimerOperando.Text, this.sistema), new Numeracion(txtSegundoOperando.Text, this.sistema));

            char operador;

            bool resultado = char.TryParse(cmbOperacion.Text, out operador);

            Numeracion resultadoFinal = opero.Operar(operador);

            if (this.sistema == ESistema.Binario)
            {
                labelResultado.Text = Convert.ToString(resultadoFinal.ConvertirA(ESistema.Binario));
            }
            else
            {
                labelResultado.Text = resultadoFinal.ValorNumerico;
            }
        }

        private void txtPrimerOperando_TextChanged(object sender, EventArgs e)
        {
            string numeroSegundoOperando = txtPrimerOperando.Text;
        }

        private void txtSegundoOperando_TextChanged(object sender, EventArgs e)
        {
            string numeroSegundoOperando = txtSegundoOperando.Text;
        }

        private void labelResultado_Click(object sender, EventArgs e)
        {
            string resultadoLabel = labelResultado.Text;
        }

        
    }
}