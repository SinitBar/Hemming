using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemming
{
    /**
     * class Painter represents a data that is needed to draw cells (neurons) in picture box
     */
    internal class Painter
    {
        Graphics _Graphics;
        public int[,] CellMatrix { get; private set; }
        public PictureBox _PictureBox { get; private set; }

        public Painter( PictureBox pictureBox,
            int pictureBoxHeightInNeurons, int pictureBoxWidthInNeurons)
        {
            CellMatrix = new int[pictureBoxHeightInNeurons, pictureBoxWidthInNeurons];
            _PictureBox = pictureBox;

            _PictureBox.Image = new Bitmap(_PictureBox.Width, _PictureBox.Height);
            _Graphics = Graphics.FromImage(_PictureBox.Image);
            CellMatrix = new int[pictureBoxHeightInNeurons, pictureBoxWidthInNeurons];

            clear();
        }

        /**
         * function changeCell changes a cell state of matrix of neurons
         */
        public void changeCell(int x, int y, int value)
        {
            CellMatrix[x, y] = value;
            paint();
        }

        /**
         * function clear clears picture box and matrix of neurons
         */
        public void clear()
        {
            _Graphics.FillRectangle(Brushes.White, 0, 0, _PictureBox.Width, _PictureBox.Height);

            for (int i = 0; i < CellMatrix.GetLength(0); i++)
                for (int j = 0; j < CellMatrix.GetLength(1); j++)
                    CellMatrix[i, j] = -1;

            _PictureBox.Refresh();
        }

        /**
         * function paint draws in picture box the matrix of neurons
         */
        public void paint()
        {
            int cellWidth = _PictureBox.Width / CellMatrix.GetLength(0);
            int cellHeight = _PictureBox.Height / CellMatrix.GetLength(1);

            for (int x = 0; x < CellMatrix.GetLength(0); x++)
            {
                for (int y = 0; y < CellMatrix.GetLength(1); y++)
                {
                    if (CellMatrix[y, x] == 1)
                        _Graphics.FillRectangle(Brushes.Black, x * cellWidth, y * cellHeight,
                            cellWidth, cellHeight);
                    else
                        _Graphics.FillRectangle(Brushes.White, x * cellWidth, y * cellHeight,
                            cellWidth, cellHeight);
                }
            }
            _PictureBox.Refresh();
        }

        /**
         * function isPointInside checks if point is inside the picture box
         */
        public bool isPointInside(Point point)
        {
            if (point.X < _PictureBox.Width && point.Y < _PictureBox.Height
                && point.X > 0 && point.Y > 0)
                return true;
            return false;
        }

        /**
         * function copy copies tha data cellMatrix to this object and draws it in it's picture box
         */
        public void copy(int[,] cellMatrix)
        {
            CellMatrix = cellMatrix.Clone() as int[,];
            paint();
        }
    }
}
