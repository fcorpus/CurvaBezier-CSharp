using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programaCurva
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void botonG_Click(object sender, EventArgs e)
        {
            Point puntoInicio = new Point(int.Parse(p1X.Text), int.Parse(p1Y.Text));
            Point puntoControl1 = new Point(int.Parse(p2X.Text), int.Parse(p2Y.Text));
            Point puntoControl2 = new Point(int.Parse(p3X.Text), int.Parse(p3Y.Text));
            Point puntoFinal = new Point(int.Parse(p4X.Text), int.Parse(p4Y.Text));

            Graphics g = zonaGraficar.CreateGraphics();
            g.Clear(Color.White);

            Point[] puntosCurva = CalculaBezier(puntoInicio,puntoControl1,puntoControl2,puntoFinal);

            g.DrawLines(Pens.Crimson, puntosCurva);

        }


        private void zonaGraficar_Paint(object sender, PaintEventArgs e)
        {
            /*Graphics g = e.Graphics;
            Point[] puntos = CalculaBezier();*/
        }
        private Point[] CalculaBezier(Point puntoInicio, Point puntoControl1, Point puntoControl2, Point puntoFinal) 
        {
            int noPuntos = 1000;
            Point[] puntos = new Point[noPuntos];

            for(int i = 0; i < noPuntos; i++)
            {
                double t = 1 / (double)(noPuntos - 1);

                double x = Math.Pow(1 - t, 3) * puntoInicio.X + 3 * Math.Pow(1 - t, 2) * t * puntoControl1.X + 3 * (1 - t) *
                    Math.Pow(t, 2) * puntoControl2.X + Math.Pow(t, 3) * puntoFinal.X;
                double y = Math.Pow(1 - t, 3) * puntoInicio.Y + 3 * Math.Pow(1 - t, 2) * t * puntoControl1.Y + 3 * (1 - t) *
                    Math.Pow(t, 2) * puntoControl2.Y + Math.Pow(t, 3) * puntoFinal.Y;

                puntos[i] = new Point((int) x, (int)y);
            }

            return puntos;
        }
    }
}
