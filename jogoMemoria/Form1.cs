using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jogoMemoria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquare();
        }
        Label primeiroClique = null;
        Label segundoClique = null;

        Random aleatorio = new Random();
        List<string> icones = new List<string>()
        {
            "!", "!", "N","N",",",",","k","k","b","b","v","v","w","w","z","z"
        };

        private void AssignIconsToSquare()
        {
            foreach(Control controle in tableLayoutPanel1.Controls)
            {
                Label iconeLabel = controle as Label;
                if(iconeLabel != null)
                {
                    int numeroAleatorio = aleatorio.Next(icones.Count);
                    iconeLabel.Text = icones[numeroAleatorio];
                    iconeLabel.ForeColor = iconeLabel.BackColor;
                    icones.RemoveAt(numeroAleatorio);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                return;
            }
            Label labelClicada = sender as Label;
            if(labelClicada != null)
            {
                 if(labelClicada.ForeColor == Color.Teal)
                {
                    return;
                }
                if(primeiroClique == null)
                {
                    primeiroClique = labelClicada;
                    primeiroClique.ForeColor = Color.Teal;
                    return;
                }
                segundoClique = labelClicada;
                segundoClique.ForeColor = Color.Teal;

                if (primeiroClique.Text == segundoClique.Text)
                {
                    primeiroClique = null;
                    segundoClique = null;
                    return;
                }

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            primeiroClique.ForeColor = primeiroClique.BackColor;
            segundoClique.ForeColor = segundoClique.BackColor;

            primeiroClique = null;
            segundoClique = null;
        }
    }    
}
