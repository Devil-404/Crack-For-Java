using System;
using System.Drawing;
using System.Windows.Forms;

namespace Crack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        /// <summary>
        /// 退出前判断下载状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult TS;
            if (!Common.StopDownLoad)
            {
                
                TS = MessageBoxEx.Show(this,"正在下载，是否继续退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (TS == DialogResult.Yes)
                {
                    this.userControldownload1.downBreak();
                    
                    e.Cancel = false; 
                }
                else
                    e.Cancel = true;
            }
            else
            {
                TS = MessageBoxEx.Show(this,"退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (TS == DialogResult.Yes)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
            
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(groupBox1.BackColor);
            e.Graphics.DrawString(groupBox1.Text, groupBox1.Font, Brushes.Black, 10, 1);//字体颜色
            e.Graphics.DrawLine(new Pen(Color.FromArgb(188, 191, 164)), 1, 7, 8, 7);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(188, 191, 164)), e.Graphics.MeasureString(groupBox1.Text, groupBox1.Font).Width + 8, 7, groupBox1.Width - 2, 7);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(188, 191, 164)), 1, 7, 1, groupBox1.Height - 2);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(188, 191, 164)), 1, groupBox1.Height - 2, groupBox1.Width - 2, groupBox1.Height - 2);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(188, 191, 164)), groupBox1.Width - 2, 7, groupBox1.Width - 2, groupBox1.Height - 2);
            this.groupBox1.BackColor = Color.Transparent;
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(groupBox2.BackColor);
            //e.Graphics.DrawString(groupBox2.Text, groupBox2.Font, Brushes.Black, 10, 1);//字体颜色
            e.Graphics.DrawLine(new Pen(Color.FromArgb(188, 191, 164)), 1, 7, 8, 7);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(188, 191, 164)), e.Graphics.MeasureString(groupBox2.Text, groupBox2.Font).Width + 8, 7, groupBox2.Width - 2, 7);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(188, 191, 164)), 1, 7, 1, groupBox2.Height - 2);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(188, 191, 164)), 1, groupBox2.Height - 2, groupBox2.Width - 2, groupBox2.Height - 2);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(188, 191, 164)), groupBox2.Width - 2, 7, groupBox2.Width - 2, groupBox2.Height - 2);
            this.groupBox2.BackColor = Color.Transparent;
        }

        /// <summary>
        /// 点击文字复制内容到裁剪版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label5_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject("211396236@qq.com");
        }
    }
}