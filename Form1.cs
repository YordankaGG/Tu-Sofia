using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

    namespace Homework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = pnl_Draw.CreateGraphics();
        }

        bool startPaint = false;
        Graphics g;
        int? initX = null;
        int? initY = null;
        bool drawSquare = false;
        bool drawRectangle = false;
        bool drawCircle = false;
        //Subitieto startira kogato mishkata e vurhy panela(pnl_Draw).
        private void pnl_Draw_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPaint)
            {
                //Nastroivane na moliva (BackColor) i shirina na liniqta.
                Pen p = new Pen(btn_PenColor.BackColor, float.Parse(cmb_PenSize.Text));
                g.DrawLine(p, new Point(initX ?? e.X, initY ?? e.Y), new Point(e.X, e.Y));
                initX = e.X;
                initY = e.Y;
            }
        }
        //Subitieto startira kogato mishkata e vurhy panela i natisnem kopcheto na mishkata.
        private void pnl_Draw_MouseDown(object sender, MouseEventArgs e)
        {
            startPaint = true;
            if (drawSquare)
            {
                //Izpolzvame moliva za chertane na figyra
                Pen p = new Pen(btn_PenColor.BackColor);
                g.DrawRectangle(p, e.X, e.Y, int.Parse(txt_ShapeSize.Text), int.Parse(txt_ShapeSize.Text));
                startPaint = false;
                drawSquare = false;
            }
            if (drawRectangle)
            {
                Pen p = new Pen(btn_PenColor.BackColor);
                //Nastroivame shirinata da e 2 puti po-golqma ot duljinata
                g.DrawRectangle(p, e.X, e.Y, 2 * int.Parse(txt_ShapeSize.Text), int.Parse(txt_ShapeSize.Text));
                startPaint = false;
                drawRectangle = false;
            }
            if (drawCircle)
            {
                Pen p = new Pen(btn_PenColor.BackColor);
                g.DrawEllipse(p, e.X, e.Y, int.Parse(txt_ShapeSize.Text), int.Parse(txt_ShapeSize.Text));
                startPaint = false;
                drawCircle = false;
            }
        }
        private void pnl_Draw_MouseUp(object sender, MouseEventArgs e)
        {
            startPaint = false;
            initX = null;
            initY = null;
        }
        //Byton za nastroika cveta na moliva
        private void button1_Click(object sender, EventArgs e)
        {
            //Otvarqne na cvetovete i zadavane na fon, ako potrebitelq natisne OK
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                btn_PenColor.BackColor = c.Color;
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Izchistvane na grafikite ot panela 
            g.Clear(pnl_Draw.BackColor);
            pnl_Draw.BackColor = Color.White;
            btn_CanvasColor.BackColor = Color.White;
        }
        private void btn_CanvasColor_Click_1(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                pnl_Draw.BackColor = c.Color;
                btn_CanvasColor.BackColor = c.Color;
            }
        }

        private void btn_Square_Click(object sender, EventArgs e)
        {
            drawSquare = true;
        }

        private void btn_Rectangle_Click(object sender, EventArgs e)
        {
            drawRectangle = true;
        }

        private void btn_Circle_Click(object sender, EventArgs e)
        {
            drawCircle = true;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cmb_PenSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_Draw_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_ShapeSize_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
