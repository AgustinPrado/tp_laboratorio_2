using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            // Creo dos numeros auxiliares.
            Numero numero1 = new Numero(this.txtNumero1.Text);
            Numero numero2 = new Numero(this.txtNumero2.Text);
            // Hago la operacion y se la paso al label habiendolo convertido a string.
            this.lblResultado.Text = Calculadora.operar(numero1, numero2, cmbOperacion.Text).ToString();
            // Hago visible el resultado.
            this.lblResultado.Visible = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Llamo al método limpiar.
            this.limpiar();
            // Oculto el resultado.
            this.lblResultado.Visible = false;
        }

        private void limpiar()
        {
            // Limpio los numeros del textBox.
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
        }
    }
}
