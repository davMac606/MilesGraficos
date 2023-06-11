using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using testGraphics;

public class LinearFunctionForm : Form
{
    public LinearFunctionForm()
    {
    
        Size = new Size(1216, 733);
        Text = "Linear Function";
        Paint += LinearFunctionForm_Paint;
    }

    private void LinearFunctionForm_Paint(object sender, PaintEventArgs e)
    {
        Form1 frm = new Form1();

    }

    private void LinearFunctionForm_Load(object sender, EventArgs e)
    {

    }
}