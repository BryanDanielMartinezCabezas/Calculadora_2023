using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Calculadora_2023;

namespace Calculadora_2023
{
    public partial class Form1 : Form
    {
        public decimal primernumero, segundonumero;
        public string operador;
        private Calculadora calculadora;

        public Form1()
        {
            InitializeComponent();
            CultureInfo customCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ",";
            customCulture.NumberFormat.NumberGroupSeparator = ".";
            customCulture.NumberFormat.CurrencyDecimalSeparator = ",";
            customCulture.NumberFormat.CurrencyGroupSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;
            Thread.CurrentThread.CurrentUICulture = customCulture;
            calculadora = new Calculadora();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AgregarNumero(string numero)
        {
            if (txtOperaciones.Text == "0" || txtOperaciones.Text == "No se divide entre 0")
                txtOperaciones.Text = numero;
            else
                txtOperaciones.Text += numero;
        }
        private void AgregarComa()
        {
            if (!txtOperaciones.Text.Contains(","))
                txtOperaciones.Text += ",";
        }

        public string sin_cero(decimal numero)
        {
            string valor_a_devolver = numero.ToString(); // Convierte el número a cadena

            // Verificar si el número tiene decimales y quitar ceros innecesarios
            if (numero % 1 == 0)
            {
                valor_a_devolver = valor_a_devolver.TrimEnd('0'); // Eliminar ceros a la derecha
                valor_a_devolver = valor_a_devolver.TrimEnd('.'); // Eliminar el punto decimal si no hay decimales
            }

            return valor_a_devolver;
        }

        public string sin_ceros(decimal numero)
        {
            return Convert.ToString(numero);
        }


        private void button10_Click(object sender, EventArgs e)
        {
            AgregarNumero("0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarNumero("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarNumero("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AgregarNumero("3");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            AgregarNumero("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AgregarNumero("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AgregarNumero("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AgregarNumero("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AgregarNumero("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AgregarNumero("9");
        }


        //limpia la caja de texto
        private void button12_Click(object sender, EventArgs e)
        {
            txtOperaciones.Text = "0";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            decimal numero = Convert.ToDecimal(txtOperaciones.Text);
            calculadora.Push(numero); // Agregar el número actual a la pila
            txtOperaciones.Text = "";
            calculadora.SetOperador("+");

        }

        private void button16_Click(object sender, EventArgs e)
        {
            decimal resultado = calculadora.RealizarOperacion(Convert.ToDecimal(txtOperaciones.Text));
            txtOperaciones.Text = calculadora.sin_cero(resultado);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            decimal numero = Convert.ToDecimal(txtOperaciones.Text);
            calculadora.Push(numero); // Agregar el número actual a la pila
            txtOperaciones.Text = "";
            calculadora.SetOperador("-");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            decimal numero = Convert.ToDecimal(txtOperaciones.Text);
            calculadora.Push(numero); // Agregar el número actual a la pila
            txtOperaciones.Text = "";
            calculadora.SetOperador("*");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            decimal numero = Convert.ToDecimal(txtOperaciones.Text);
            calculadora.Push(numero); // Agregar el número actual a la pila
            txtOperaciones.Text = "";
            calculadora.SetOperador("/");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AgregarComa();
        }
    }
    public class Calculadora
    {
        private Stack<decimal> pila = new Stack<decimal>();
        private string operador = "";

        public void Push(decimal numero)
        {
            pila.Push(numero);
        }

        public void SetOperador(string op)
        {
            operador = op;
        }

        public decimal RealizarOperacion(decimal segundoNumero)
        {
            if (pila.Count == 0)
            {
                return segundoNumero;
            }

            decimal primerNumero = pila.Pop();
            switch (operador)
            {
                case "+":
                    return primerNumero + segundoNumero;
                case "-":
                    return primerNumero - segundoNumero;
                case "*":
                    return primerNumero * segundoNumero;
                case "/":
                    if (segundoNumero == 0)
                    {
                        MessageBox.Show("No se puede dividir por cero.");
                        return 0;
                    }
                    return primerNumero / segundoNumero;
                default:
                    return segundoNumero;
            }
        }

        public string sin_cero(decimal numero)
        {
            string valor_a_devolver = numero.ToString();
            if (numero % 1 == 0)
            {
                valor_a_devolver = valor_a_devolver.TrimEnd('0');
                valor_a_devolver = valor_a_devolver.TrimEnd('.');
            }
            return valor_a_devolver;
        }

    }
}
