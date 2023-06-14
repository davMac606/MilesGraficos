using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testGraphics
{
    public partial class Form1 : Form
    {
        bool mult = false;

        public Form1()
        {
            InitializeComponent();
            Size = new Size(1216, 733);
            Text = "Desenho de retas";
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }
 

        public void btnMult_Click(object sender, EventArgs e)
        {
            mult = true;
            txtX2.Visible = true;
            txtY2.Visible = true;
            txtX3.Visible = true;
            txtY3.Visible = true;
            label6.Visible = true;
            label10.Visible = true;
            label8.Visible = true;
            label9.Visible = true;


        }
        private bool calcIntersecao(double m1, double n1, double m2, double n2, out int intersecaoX, out int intersecaoY)
        {
            if (m1 == m2)
            {
                intersecaoX = 0;
                intersecaoY = 0;
                
                return false;
                
            }

            intersecaoX = (int)((n2 - n1) / (m1 - m2));
            intersecaoY = (int)(m1 * intersecaoX + n1);
            return true;
        }
        private void btnDraw_Click(object sender, EventArgs e)
        {
            picDrawing.Refresh();
            string x = txtX.Text.Trim();
            string y = txtY.Text.Trim();
            string x1 = txtX1.Text.Trim();
            string y1 = txtY1.Text.Trim();
            string x2 = txtX2.Text.Trim();
            string y2 = txtY2.Text.Trim();
            string x3 = txtX3.Text.Trim();
            string y3 = txtY3.Text.Trim();

            try
            {
                int startX = Convert.ToInt32(x);
                int startY = Convert.ToInt32(y);
                int endX = Convert.ToInt32(x1);
                int endY = Convert.ToInt32(y1);
                int startX2 = Convert.ToInt32(x2);
                int startY2 = Convert.ToInt32(y2);
                int endX2 = Convert.ToInt32(x3);
                int endY2 = Convert.ToInt32(y3);

                picDrawing.Image = new Bitmap(picDrawing.Width, picDrawing.Height);
                Graphics g = Graphics.FromImage(picDrawing.Image);
                
                    Pen penReta = new Pen(Color.Black);
                    Pen penReta1 = new Pen(Color.Red);

                    double m1 = (endY - startY) / (endX - startX);
                    MessageBox.Show("Coeficiente angular da reta 1: " + m1 + ".", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    double n1 = startY - m1 * startX;
                
                    int xCoord1 = 0;
                    int yCoord1 = (int)(m1 * xCoord1 + n1);
                    int xCoord2 = picDrawing.Width - 1;
                    int yCoord2 = (int)(m1 * xCoord2 + n1);

                    g.DrawLine(penReta1, xCoord1, yCoord1, xCoord2, yCoord2);

                    double m2 = (endY2 - startY2) / (endX2 - startX2);
                    MessageBox.Show("Coeficiente angular da reta 2: " + m2 + ".", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    double n2 = startY2 - m2 * startX2;
                    
                    xCoord1 = 0;
                    yCoord1 = (int)(m2 * xCoord1 + n2);

                    xCoord2 = picDrawing.Width - 1;
                    yCoord2 = (int)(m2 * xCoord2 + n2);

                    g.DrawLine(penReta1, xCoord1, yCoord1, xCoord2, yCoord2);

                    int centerX = picDrawing.Width / 2;
                    g.DrawLine(penReta, centerX, 0, centerX, picDrawing.Height);

                    int centerY = picDrawing.Height / 2;
                    g.DrawLine(penReta, 0, centerY, picDrawing.Width, centerY);

                    penReta.Dispose();
                    if (m1 == m2 && n1 == n2)
                    {
                    picDrawing.Refresh();
                    MessageBox.Show("As retas são sobrepostas!", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    labelTipo.Text = "As retas são: " + "Sobrepostas";
                        return;

                    }

                    if (m1 * m2 == -1)
                    {
                    picDrawing.Refresh();
                    MessageBox.Show("As retas são perpendiculares!", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    labelTipo.Text = "As retas são: " + "Perpendiculares";
                        return;
      
                }

                    if (m1 == m2)
                    {
                    picDrawing.Refresh();
                    MessageBox.Show("As retas são paralelas!", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    labelTipo.Text = "As retas são: " + "Paralelas";
                        return;
                }

                    int intersecaoX;
                    int intersecaoY;
                    bool intercede = calcIntersecao(m1, n1, m2, n2, out intersecaoX, out intersecaoY);
                    if (intercede)
                    {
                        MessageBox.Show("Ponto de interseção: (" + intersecaoX + "," + intersecaoY + ").", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    picDrawing.Refresh();
                }
                    else
                    {
                        MessageBox.Show("As retas não se interceptam!", "Alerta do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    picDrawing.Refresh();
                }
                

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



    }

}

    




