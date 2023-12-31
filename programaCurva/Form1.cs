﻿using System;
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
            PointF puntoInicio = new PointF(float.Parse(p1X.Text), float.Parse(p1Y.Text));
            PointF puntoControl1 = new PointF(float.Parse(p2X.Text), float.Parse(p2Y.Text));
            PointF puntoControl2 = new PointF(float.Parse(p3X.Text), float.Parse(p3Y.Text));
            PointF puntoFinal = new PointF(float.Parse(p4X.Text), float.Parse(p4Y.Text));

            PointF[] puntos =
            {
                puntoInicio, puntoControl1, puntoControl2, puntoFinal
            };

            Graphics g = zonaGraficar.CreateGraphics();
            g.Clear(Color.White);

            foreach (PointF punto in puntos)
            {
                g.DrawRectangle(Pens.Red, punto.X, punto.Y, 5, 5);
            }

            //g.DrawLines(Pens.Black,puntos);
            PointF[] puntosCurva = CalculaBezier(puntoInicio,puntoControl1,puntoControl2,puntoFinal);

            g.DrawLines(Pens.Black, puntosCurva);

        }

        private PointF[] CalculaBezier(PointF puntoInicio, PointF puntoControl1, PointF puntoControl2, PointF puntoFinal) 
        {
            int noPuntos = 1000000;
            PointF[] puntos = new PointF[noPuntos];

            for(int i = 0; i < noPuntos; i++)
            {
                double t = i / (double)(noPuntos - 1);

                double x = Math.Pow(1 - t, 3) * puntoInicio.X + 3 * Math.Pow(1 - t, 2) * t * puntoControl1.X + 3 * (1 - t) *
                    Math.Pow(t, 2) * puntoControl2.X + Math.Pow(t, 3) * puntoFinal.X;
                double y = Math.Pow(1 - t, 3) * puntoInicio.Y + 3 * Math.Pow(1 - t, 2) * t * puntoControl1.Y + 3 * (1 - t) *
                    Math.Pow(t, 2) * puntoControl2.Y + Math.Pow(t, 3) * puntoFinal.Y;

                puntos[i] = new PointF((float) x, (float)y);
            }

            return puntos;
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
