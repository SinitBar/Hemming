using System.Reflection;

namespace Hemming
{
    public partial class FormHemming : Form
    {
        Painter painterSample1;
        Painter painterSample2;
        Painter painterSample3;
        Painter painterSample4;
        Painter painterSample5;
        Painter painterSample6;
        Painter painterInput;
        Painter painterOutput;

        const int pictureBoxHeightInNeurons = 5;
        const int pictureBoxWidthInNeurons = 5;

        const int samplesAmount = 6;

        double epsilon = 0.16;

        public FormHemming()
        {
            InitializeComponent();
            labelMessage.Text = "";
            painterSample1 = new Painter(pictureBox1, pictureBoxHeightInNeurons, pictureBoxWidthInNeurons);
            painterSample2 = new Painter(pictureBox2, pictureBoxHeightInNeurons, pictureBoxWidthInNeurons);
            painterSample3 = new Painter(pictureBox3, pictureBoxHeightInNeurons, pictureBoxWidthInNeurons);
            painterSample4 = new Painter(pictureBox4, pictureBoxHeightInNeurons, pictureBoxWidthInNeurons);
            painterSample5 = new Painter(pictureBox5, pictureBoxHeightInNeurons, pictureBoxWidthInNeurons);
            painterSample6 = new Painter(pictureBox6, pictureBoxHeightInNeurons, pictureBoxWidthInNeurons);
            painterInput = new Painter(pictureBoxInput, pictureBoxHeightInNeurons, pictureBoxWidthInNeurons);
            painterOutput = new Painter(pictureBoxOutput, pictureBoxHeightInNeurons, pictureBoxWidthInNeurons);
        }

        private void buttonRecognize_Click(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            painterOutput.clear();

            List<int[,]> samples = formSamplesList();

            HemmingNet hemmingNet = new HemmingNet(samplesAmount,
                pictureBoxHeightInNeurons * pictureBoxWidthInNeurons, samples, epsilon);

            List<int> results = hemmingNet.HemmingAlgorithm(painterInput.CellMatrix);

            if (results.Count == 0)
                throw new Exception("Algorithm didn't find any decision");

            if (results.Count > 1)
            {
                labelMessage.Text = "there are several \n samples that match: \n" + (results[0] + 1);
                for (int i = 1; i < results.Count; i++)
                    labelMessage.Text += ", " + (results[i] + 1);
            }

            // demostrate first (and maybe the only one) of the found samples
            painterOutput.copy(samples[results[0]]);
        }

        private List<int[,]> formSamplesList()
        {
            List<int[,]> samples = new List<int[,]>() { painterSample1.CellMatrix,
            painterSample2.CellMatrix, painterSample3.CellMatrix, 
                painterSample4.CellMatrix, painterSample5.CellMatrix, painterSample6.CellMatrix };

            return samples;
        }

        private void mouseChange(MouseEventArgs e, Painter painter)
        {
            int cellHeight = painter._PictureBox.Height / painter.CellMatrix.GetLength(0);
            int cellWidth = painter._PictureBox.Width / painter.CellMatrix.GetLength(1);

            var x = e.Location.X / cellWidth;
            var y = e.Location.Y / cellHeight;

            if (e.Button == MouseButtons.Left)
            {
                if (painter.isPointInside(e.Location))
                    painter.changeCell(y, x, 1);
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (painter.isPointInside(e.Location))
                    painter.changeCell(y, x, -1);
            }
        }

        private void buttonClear1Sample_Click(object sender, EventArgs e)
        {
            painterSample1.clear();
        }

        private void buttonClear2Sample_Click(object sender, EventArgs e)
        {
            painterSample2.clear();
        }

        private void buttonClear3Sample_Click(object sender, EventArgs e)
        {
            painterSample3.clear();
        }

        private void buttonClear4Sample_Click(object sender, EventArgs e)
        {
            painterSample4.clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            painterInput.copy(painterSample1.CellMatrix);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            painterInput.copy(painterSample2.CellMatrix);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            painterInput.copy(painterSample3.CellMatrix);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            painterInput.copy(painterSample4.CellMatrix);
        }

        private void buttonClearInput_Click(object sender, EventArgs e)
        {
            painterInput.clear();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterSample1);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterSample1);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterSample2);
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterSample2);
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterSample3);
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterSample3);
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterSample4);
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterSample4);
        }

        private void pictureBoxInput_MouseMove(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterInput);
        }

        private void pictureBoxInput_MouseClick(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterInput);
        }

        private void buttonClear5Sample_Click(object sender, EventArgs e)
        {
            painterSample5.clear();
        }

        private void buttonClear6Sample_Click(object sender, EventArgs e)
        {
            painterSample6.clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            painterInput.copy(painterSample5.CellMatrix);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            painterInput.copy(painterSample6.CellMatrix);
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterSample6);
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterSample6);
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterSample5);
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            mouseChange(e, painterSample5);
        }
    }
}