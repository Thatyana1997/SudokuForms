using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SudokuForms
{
    public partial class Form1 : Form
    {

        TextBox[,] matriz;
        public Form1()
        {
            InitializeComponent();
            iniciarMatriz();
            rellenarMatriz();
        }

        public void iniciarMatriz()
        {
            matriz = new TextBox[9, 9];

            matriz[0, 0] = txt00;
            matriz[0, 1] = txt01;
            matriz[0, 2] = txt02;
            matriz[0, 3] = txt03;
            matriz[0, 4] = txt04;
            matriz[0, 5] = txt05;
            matriz[0, 6] = txt06;
            matriz[0, 7] = txt07;
            matriz[0, 8] = txt08;

            matriz[1, 0] = txt10;
            matriz[1, 1] = txt11;
            matriz[1, 2] = txt12;
            matriz[1, 3] = txt13;
            matriz[1, 4] = txt14;
            matriz[1, 5] = txt15;
            matriz[1, 6] = txt16;
            matriz[1, 7] = txt17;
            matriz[1, 8] = txt18;

            matriz[2, 0] = txt20;
            matriz[2, 1] = txt21;
            matriz[2, 2] = txt22;
            matriz[2, 3] = txt23;
            matriz[2, 4] = txt24;
            matriz[2, 5] = txt25;
            matriz[2, 6] = txt26;
            matriz[2, 7] = txt27;
            matriz[2, 8] = txt28;

            matriz[3, 0] = txt30;
            matriz[3, 1] = txt31;
            matriz[3, 2] = txt32;
            matriz[3, 3] = txt33;
            matriz[3, 4] = txt34;
            matriz[3, 5] = txt35;
            matriz[3, 6] = txt36;
            matriz[3, 7] = txt37;
            matriz[3, 8] = txt38;

            matriz[4, 0] = txt40;
            matriz[4, 1] = txt41;
            matriz[4, 2] = txt42;
            matriz[4, 3] = txt43;
            matriz[4, 4] = txt44;
            matriz[4, 5] = txt45;
            matriz[4, 6] = txt46;
            matriz[4, 7] = txt47;
            matriz[4, 8] = txt48;

            matriz[5, 0] = txt50;
            matriz[5, 1] = txt51;
            matriz[5, 2] = txt52;
            matriz[5, 3] = txt53;
            matriz[5, 4] = txt54;
            matriz[5, 5] = txt55;
            matriz[5, 6] = txt56;
            matriz[5, 7] = txt57;
            matriz[5, 8] = txt58;

            matriz[6, 0] = txt60;
            matriz[6, 1] = txt61;
            matriz[6, 2] = txt62;
            matriz[6, 3] = txt63;
            matriz[6, 4] = txt64;
            matriz[6, 5] = txt65;
            matriz[6, 6] = txt66;
            matriz[6, 7] = txt67;
            matriz[6, 8] = txt68;

            matriz[7, 0] = txt70;
            matriz[7, 1] = txt71;
            matriz[7, 2] = txt72;
            matriz[7, 3] = txt73;
            matriz[7, 4] = txt74;
            matriz[7, 5] = txt75;
            matriz[7, 6] = txt76;
            matriz[7, 7] = txt77;
            matriz[7, 8] = txt78;

            matriz[8, 0] = txt80;
            matriz[8, 1] = txt81;
            matriz[8, 2] = txt82;
            matriz[8, 3] = txt83;
            matriz[8, 4] = txt84;
            matriz[8, 5] = txt85;
            matriz[8, 6] = txt86;
            matriz[8, 7] = txt87;
            matriz[8, 8] = txt88;

            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    matriz[fila, columna].Text = "";
                    matriz[fila, columna].Enabled = true;
                    matriz[fila, columna].BackColor = Color.White;
                }
            }
        }

        public void limpiarMatriz(TextBox[,] mat)
        {
            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    mat[fila, columna].Text = "";
                    mat[fila, columna].Enabled = true;
                    mat[fila, columna].BackColor = Color.White;
                    mat[fila, columna].Font = new Font(mat[fila, columna].Font, FontStyle.Bold);
                }
            }
        }

        public void rellenarMatriz()
        {
            int intento = 0;
            int contador = 0;

            Random coorY = new Random();

            for (int fila = 0; fila < 9; fila++)
            {

                intento = 0;
                while (intento < 3)
                {
                    contador = contador + 1;
                    int y = 0;

                    int minY = 0;
                    int maxY = 8;

                    y = coorY.Next(minY, maxY);

                    int numeroAleatorio = 0;
                    Random aleatorioDato = new Random();
                    int minDato = 1;
                    int maxDato = 9;

                    numeroAleatorio = aleatorioDato.Next(minDato, maxDato);

                    if (!revisarRepite(matriz, numeroAleatorio, fila, y))
                    {
                        if (matriz[fila, y].Text.Length == 0)
                        {
                            matriz[fila, y].Text = numeroAleatorio.ToString();
                            matriz[fila, y].Enabled = false;
                            matriz[fila, y].BackColor = Color.LightGray; // Fondo gris 
                            matriz[fila, y].Font = new Font(matriz[fila, y].Font, FontStyle.Bold); // Letras en negrita

                            intento = intento + 1;
                        }
                    }
                }
            }
        }

        public Boolean revisarRepite(TextBox[,] matriz, int numeroRevisar, int fil, int col)
        {
            Boolean repite = false;
            //revisamos si se repite en la fila 
            for (int fila = 0; fila < 9; fila++)
            {
                if (fila == fil)
                {
                    continue;
                }
                if (matriz[fila, col].Text.Length > 0)
                {
                    if (matriz[fila, col].Text.Equals(numeroRevisar.ToString()))
                    {
                        repite = true;
                    }
                }
            }
            //revisamos si se repite en la columna
            for (int columna = 0; columna < 9; columna++)
            {
                if (columna == col)
                {
                    continue;
                }
                if (matriz[fil, columna].Text.Equals(numeroRevisar.ToString()))
                {
                    repite = true;
                }
            }

            //revisar si se repite en la cuadracula
            if (fil >= 0 && fil <= 2)
            {
                if (col >= 0 && col <= 2)
                {
                    for (int x = 0; x <= 2; x++)
                    {
                        for (int y = 0; y <= 2; y++)
                        {
                            if (x == fil && y == col)
                            {
                                continue;
                            }
                            if (matriz[x, y].Text.Length > 0)
                            {
                                if (matriz[x, y].Text.Equals(numeroRevisar.ToString()))
                                {
                                    repite = true;
                                }
                            }
                        }
                    }
                }
                else if (col >= 3 && col <= 5)
                {
                    for (int x = 0; x <= 2; x++)
                    {
                        for (int y = 3; y <= 5; y++)
                        {
                            if (x == fil && y == col)
                            {
                                continue;
                            }
                            if (matriz[x, y].Text.Length > 0)
                            {
                                if (matriz[x, y].Text.Equals(numeroRevisar.ToString()))
                                {
                                    repite = true;
                                }
                            }
                        }
                    }
                }
                else if (col >= 6 && col <= 8)
                {
                    for (int x = 0; x <= 2; x++)
                    {
                        for (int y = 6; y <= 8; y++)
                        {
                            if (x == fil && y == col)
                            {
                                continue;
                            }
                            if (matriz[x, y].Text.Length > 0)
                            {
                                if (matriz[x, y].Text.Equals(numeroRevisar.ToString()))
                                {
                                    repite = true;
                                }
                            }
                        }
                    }
                }
            }
            else if (fil >= 3 && fil <= 5)
            {
                if (col >= 0 && col <= 2)
                {
                    for (int x = 3; x <= 5; x++)
                    {
                        for (int y = 0; y <= 2; y++)
                        {
                            if (x == fil && y == col)
                            {
                                continue;
                            }
                            if (matriz[x, y].Text.Length > 0)
                            {
                                if (matriz[x, y].Text.Equals(numeroRevisar.ToString()))
                                {
                                    repite = true;
                                }
                            }
                        }
                    }
                }
                else if (col >= 3 && col <= 5)
                {
                    for (int x = 3; x <= 5; x++)
                    {
                        for (int y = 3; y <= 5; y++)
                        {
                            if (x == fil && y == col)
                            {
                                continue;
                            }
                            if (matriz[x, y].Text.Length > 0)
                            {
                                if (matriz[x, y].Text.Equals(numeroRevisar.ToString()))
                                {
                                    repite = true;
                                }
                            }
                        }
                    }
                }
                else if (col >= 6 && col <= 8)
                {
                    for (int x = 3; x <= 5; x++)
                    {
                        for (int y = 6; y <= 8; y++)
                        {
                            if (x == fil && y == col)
                            {
                                continue;
                            }
                            if (matriz[x, y].Text.Length > 0)
                            {
                                if (matriz[x, y].Text.Equals(numeroRevisar.ToString()))
                                {
                                    repite = true;
                                }
                            }
                        }
                    }
                }
            }
            else if (fil >= 6 && fil <= 8)
            {
                if (col >= 0 && col <= 2)
                {
                    for (int x = 6; x <= 8; x++)
                    {
                        for (int y = 0; y <= 2; y++)
                        {
                            if (x == fil && y == col)
                            {
                                continue;
                            }
                            if (matriz[x, y].Text.Length > 0)
                            {
                                if (matriz[x, y].Text.Equals(numeroRevisar.ToString()))
                                {
                                    repite = true;
                                }
                            }
                        }
                    }
                }
                else if (col >= 3 && col <= 5)
                {
                    for (int x = 6; x <= 8; x++)
                    {
                        for (int y = 3; y <= 5; y++)
                        {
                            if (x == fil && y == col)
                            {
                                continue;
                            }
                            if (matriz[x, y].Text.Length > 0)
                            {
                                if (matriz[x, y].Text.Equals(numeroRevisar.ToString()))
                                {
                                    repite = true;
                                }
                            }
                        }
                    }
                }
                else if (col >= 6 && col <= 8)
                {
                    for (int x = 6; x <= 8; x++)
                    {
                        for (int y = 6; y <= 8; y++)
                        {
                            if (x == fil && y == col)
                            {
                                continue;
                            }
                            if (matriz[x, y].Text.Length > 0)
                            {
                                if (matriz[x, y].Text.Equals(numeroRevisar.ToString()))
                                {
                                    repite = true;
                                }
                            }
                        }
                    }
                }
            }
            return repite;
        }
         
        #region #ValidarEntradaDatosRepetidos
        public void cambioDato(int fila, int columna)
        {
            int dato = Int16.Parse(matriz[fila, columna].Text);
            if (revisarRepite(matriz, dato, fila, columna))
            {
                matriz[fila, columna].ForeColor = Color.Red;
            }
            else
            {
                matriz[fila, columna].ForeColor = Color.Black;
            }
        }

        private void txt00_TextChanged(object sender, EventArgs e)
        {
            if (txt00.Text.Length > 0)
            {
                cambioDato(0, 0);
            }
        }

        private void txt01_TextChanged(object sender, EventArgs e)
        {
            if (txt01.Text.Length > 0)
            {
                cambioDato(0, 1);
            }
        }

        private void txt02_TextChanged(object sender, EventArgs e)
        {
            if (txt02.Text.Length > 0)
            {
                cambioDato(0, 2);
            }
        }

        private void txt03_TextChanged(object sender, EventArgs e)
        {
            if (txt03.Text.Length > 0)
            {
                cambioDato(0, 3);
            }
        }

        private void txt04_TextChanged(object sender, EventArgs e)
        {
            if (txt04.Text.Length > 0)
            {
                cambioDato(0, 4);
            }
        }

        private void txt05_TextChanged(object sender, EventArgs e)
        {
            if (txt05.Text.Length > 0)
            {
                cambioDato(0, 5);
            }
        }

        private void txt06_TextChanged(object sender, EventArgs e)
        {
            if (txt06.Text.Length > 0)
            {
                cambioDato(0, 6);
            }
        }

        private void txt07_TextChanged(object sender, EventArgs e)
        {
            if (txt07.Text.Length > 0)
            {
                cambioDato(0, 7);
            }
        }

        private void txt08_TextChanged(object sender, EventArgs e)
        {
            if (txt08.Text.Length > 0)
            {
                cambioDato(0, 8);
            }
        }

        private void txt10_TextChanged(object sender, EventArgs e)
        {
            if (txt10.Text.Length > 0)
            {
                cambioDato(1, 0);
            }
        }

        private void txt11_TextChanged(object sender, EventArgs e)
        {
            if (txt11.Text.Length > 0)
            {
                cambioDato(1, 1);
            }
        }

        private void txt12_TextChanged(object sender, EventArgs e)
        {
            if (txt12.Text.Length > 0)
            {
                cambioDato(1, 2);
            }
        }

        private void txt13_TextChanged(object sender, EventArgs e)
        {
            if (txt13.Text.Length > 0)
            {
                cambioDato(1, 3);
            }
        }

        private void txt14_TextChanged(object sender, EventArgs e)
        {
            if (txt14.Text.Length > 0)
            {
                cambioDato(1, 4);
            }
        }

        private void txt15_TextChanged(object sender, EventArgs e)
        {
            if (txt15.Text.Length > 0)
            {
                cambioDato(1, 5);
            }
        }

        private void txt16_TextChanged(object sender, EventArgs e)
        {
            if (txt16.Text.Length > 0)
            {
                cambioDato(1, 6);
            }
        }

        private void txt17_TextChanged(object sender, EventArgs e)
        {
            if (txt17.Text.Length > 0)
            {
                cambioDato(1, 7);
            }
        }

        private void txt18_TextChanged(object sender, EventArgs e)
        {
            if (txt18.Text.Length > 0)
            {
                cambioDato(1, 8);
            }
        }

        private void txt20_TextChanged(object sender, EventArgs e)
        {
            if (txt20.Text.Length > 0)
            {
                cambioDato(2, 0);
            }
        }

        private void txt21_TextChanged(object sender, EventArgs e)
        {
            if (txt21.Text.Length > 0)
            {
                cambioDato(2, 1);
            }
        }

        private void txt22_TextChanged(object sender, EventArgs e)
        {
            if (txt22.Text.Length > 0)
            {
                cambioDato(2, 2);
            }
        }

        private void txt23_TextChanged(object sender, EventArgs e)
        {
            if (txt23.Text.Length > 0)
            {
                cambioDato(2, 3);
            }
        }

        private void txt24_TextChanged(object sender, EventArgs e)
        {
            if (txt24.Text.Length > 0)
            {
                cambioDato(2, 4);
            }
        }

        private void txt25_TextChanged(object sender, EventArgs e)
        {
            if (txt25.Text.Length > 0)
            {
                cambioDato(2, 5);
            }
        }

        private void txt26_TextChanged(object sender, EventArgs e)
        {
            if (txt26.Text.Length > 0)
            {
                cambioDato(2, 6);
            }
        }

        private void txt27_TextChanged(object sender, EventArgs e)
        {
            if (txt27.Text.Length > 0)
            {
                cambioDato(2, 7);
            }
        }

        private void txt28_TextChanged(object sender, EventArgs e)
        {
            if (txt28.Text.Length > 0)
            {
                cambioDato(2, 8);
            }
        }

        private void txt30_TextChanged(object sender, EventArgs e)
        {
            if (txt30.Text.Length > 0)
            {
                cambioDato(3, 0);
            }
        }

        private void txt31_TextChanged(object sender, EventArgs e)
        {
            if (txt31.Text.Length > 0)
            {
                cambioDato(3, 1);
            }
        }

        private void txt32_TextChanged(object sender, EventArgs e)
        {
            if (txt32.Text.Length > 0)
            {
                cambioDato(3, 2);
            }
        }

        private void txt33_TextChanged(object sender, EventArgs e)
        {
            if (txt33.Text.Length > 0)
            {
                cambioDato(3, 3);
            }
        }

        private void txt34_TextChanged(object sender, EventArgs e)
        {
            if (txt34.Text.Length > 0)
            {
                cambioDato(3, 4);
            }
        }

        private void txt35_TextChanged(object sender, EventArgs e)
        {
            if (txt35.Text.Length > 0)
            {
                cambioDato(3, 5);
            }
        }

        private void txt36_TextChanged(object sender, EventArgs e)
        {
            if (txt36.Text.Length > 0)
            {
                cambioDato(3, 6);
            }
        }

        private void txt37_TextChanged(object sender, EventArgs e)
        {
            if (txt37.Text.Length > 0)
            {
                cambioDato(3, 7);
            }
        }

        private void txt38_TextChanged(object sender, EventArgs e)
        {
            if (txt38.Text.Length > 0)
            {
                cambioDato(3, 8);
            }
        }

        private void txt40_TextChanged(object sender, EventArgs e)
        {
            if (txt40.Text.Length > 0)
            {
                cambioDato(4, 0);
            }
        }

        private void txt41_TextChanged(object sender, EventArgs e)
        {
            if (txt41.Text.Length > 0)
            {
                cambioDato(4, 1);
            }
        }

        private void txt42_TextChanged(object sender, EventArgs e)
        {
            if (txt42.Text.Length > 0)
            {
                cambioDato(4, 2);
            }
        }

        private void txt43_TextChanged(object sender, EventArgs e)
        {
            if (txt43.Text.Length > 0)
            {
                cambioDato(4, 3);
            }
        }

        private void txt44_TextChanged(object sender, EventArgs e)
        {
            if (txt44.Text.Length > 0)
            {
                cambioDato(4, 4);
            }
        }

        private void txt45_TextChanged(object sender, EventArgs e)
        {
            if (txt45.Text.Length > 0)
            {
                cambioDato(4, 5);
            }
        }

        private void txt46_TextChanged(object sender, EventArgs e)
        {
            if (txt46.Text.Length > 0)
            {
                cambioDato(4, 6);
            }
        }

        private void txt47_TextChanged(object sender, EventArgs e)
        {
            if (txt47.Text.Length > 0)
            {
                cambioDato(4, 7);
            }
        }

        private void txt48_TextChanged(object sender, EventArgs e)
        {
            if (txt48.Text.Length > 0)
            {
                cambioDato(4, 8);
            }
        }

        private void txt50_TextChanged(object sender, EventArgs e)
        {
            if (txt50.Text.Length > 0)
            {
                cambioDato(5, 0);
            }
        }

        private void txt51_TextChanged(object sender, EventArgs e)
        {
            if (txt51.Text.Length > 0)
            {
                cambioDato(5, 1);
            }
        }

        private void txt52_TextChanged(object sender, EventArgs e)
        {
            if (txt52.Text.Length > 0)
            {
                cambioDato(5, 2);
            }
        }

        private void txt53_TextChanged(object sender, EventArgs e)
        {
            if (txt53.Text.Length > 0)
            {
                cambioDato(5, 3);
            }
        }

        private void txt54_TextChanged(object sender, EventArgs e)
        {
            if (txt54.Text.Length > 0)
            {
                cambioDato(5, 4);
            }
        }

        private void txt55_TextChanged(object sender, EventArgs e)
        {
            if (txt55.Text.Length > 0)
            {
                cambioDato(5, 5);
            }
        }

        private void txt56_TextChanged(object sender, EventArgs e)
        {
            if (txt56.Text.Length > 0)
            {
                cambioDato(5, 6);
            }
        }

        private void txt57_TextChanged(object sender, EventArgs e)
        {
            if (txt57.Text.Length > 0)
            {
                cambioDato(5, 7);
            }
        }

        private void txt58_TextChanged(object sender, EventArgs e)
        {
            if (txt58.Text.Length > 0)
            {
                cambioDato(5, 8);
            }
        }

        private void txt60_TextChanged(object sender, EventArgs e)
        {
            if (txt60.Text.Length > 0)
            {
                cambioDato(6, 0);
            }
        }

        private void txt61_TextChanged(object sender, EventArgs e)
        {
            if (txt61.Text.Length > 0)
            {
                cambioDato(6, 1);
            }
        }

        private void txt62_TextChanged(object sender, EventArgs e)
        {
            if (txt62.Text.Length > 0)
            {
                cambioDato(6, 2);
            }
        }

        private void txt63_TextChanged(object sender, EventArgs e)
        {
            if (txt63.Text.Length > 0)
            {
                cambioDato(6, 3);
            }
        }

        private void txt64_TextChanged(object sender, EventArgs e)
        {
            if (txt64.Text.Length > 0)
            {
                cambioDato(6, 4);
            }
        }

        private void txt65_TextChanged(object sender, EventArgs e)
        {
            if (txt65.Text.Length > 0)
            {
                cambioDato(6, 5);
            }
        }

        private void txt66_TextChanged(object sender, EventArgs e)
        {
            if (txt66.Text.Length > 0)
            {
                cambioDato(6, 6);
            }
        }

        private void txt67_TextChanged(object sender, EventArgs e)
        {
            if (txt67.Text.Length > 0)
            {
                cambioDato(6, 7);
            }
        }

        private void txt68_TextChanged(object sender, EventArgs e)
        {
            if (txt68.Text.Length > 0)
            {
                cambioDato(6, 8);
            }
        }

        private void txt70_TextChanged(object sender, EventArgs e)
        {
            if (txt70.Text.Length > 0)
            {
                cambioDato(7, 0);
            }
        }

        private void txt71_TextChanged(object sender, EventArgs e)
        {
            if (txt71.Text.Length > 0)
            {
                cambioDato(7, 1);
            }
        }

        private void txt72_TextChanged(object sender, EventArgs e)
        {
            if (txt72.Text.Length > 0)
            {
                cambioDato(7, 2);
            }
        }

        private void txt73_TextChanged(object sender, EventArgs e)
        {
            if (txt73.Text.Length > 0)
            {
                cambioDato(7, 3);
            }
        }

        private void txt74_TextChanged(object sender, EventArgs e)
        {
            if (txt74.Text.Length > 0)
            {
                cambioDato(7, 4);
            }
        }

        private void txt75_TextChanged(object sender, EventArgs e)
        {
            if (txt75.Text.Length > 0)
            {
                cambioDato(7, 5);
            }
        }

        private void txt76_TextChanged(object sender, EventArgs e)
        {
            if (txt76.Text.Length > 0)
            {
                cambioDato(7, 6);
            }
        }

        private void txt77_TextChanged(object sender, EventArgs e)
        {
            if (txt77.Text.Length > 0)
            {
                cambioDato(7, 7);
            }
        }

        private void txt78_TextChanged(object sender, EventArgs e)
        {
            if (txt78.Text.Length > 0)
            {
                cambioDato(7, 8);
            }
        }

        private void txt80_TextChanged(object sender, EventArgs e)
        {
            if (txt80.Text.Length > 0)
            {
                cambioDato(8, 0);
            }
        }

        private void txt81_TextChanged(object sender, EventArgs e)
        {
            if (txt81.Text.Length > 0)
            {
                cambioDato(8, 1);
            }
        }

        private void txt82_TextChanged(object sender, EventArgs e)
        {
            if (txt82.Text.Length > 0)
            {
                cambioDato(8, 2);
            }
        }

        private void txt83_TextChanged(object sender, EventArgs e)
        {
            if (txt83.Text.Length > 0)
            {
                cambioDato(8, 3);
            }
        }

        private void txt84_TextChanged(object sender, EventArgs e)
        {
            if (txt84.Text.Length > 0)
            {
                cambioDato(8, 4);
            }
        }

        private void txt85_TextChanged(object sender, EventArgs e)
        {
            if (txt85.Text.Length > 0)
            {
                cambioDato(8, 5);
            }
        }

        private void txt86_TextChanged(object sender, EventArgs e)
        {
            if (txt86.Text.Length > 0)
            {
                cambioDato(8, 6);
            }
        }

        private void txt87_TextChanged(object sender, EventArgs e)
        {
            if (txt87.Text.Length > 0)
            {
                cambioDato(8, 7);
            }
        }

        private void txt88_TextChanged(object sender, EventArgs e)
        {
            if (txt88.Text.Length > 0)
            {
                cambioDato(8, 8);
            }
        }
        #endregion

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            limpiarMatriz(matriz);
            rellenarMatriz();
        }

        private void btnRevisar_Click(object sender, EventArgs e)
        {

        }
    
    
    }
}
