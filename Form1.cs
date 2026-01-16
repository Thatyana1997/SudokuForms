using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuForms
{
    public partial class Form1 : Form
    {

        TextBox[,] matriz;
        public Form1()
        {
            InitializeComponent();
            iniciarMatriz();
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

            int contador = 0;
            int intento = 0;

            for (int fila = 0; fila < 9; fila++)
            {
                contador = 0;
                intento = 0;

                for (int columna = 0; columna < 9; columna++)
                {
                    if (matriz[fila, columna].Text.Length > 0)
                    {
                        contador = contador + 1;
                    }
                }

                while (intento < 3)
                {
                    int y = 0;
                    Random coorY = new Random();
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
                            intento = intento + 1;
                        }
                    }
                }
            }
        }

        public Boolean revisarRepite(TextBox[,] matriz, int numeroRevisar, int fil, int col)
        {
            Boolean repite = false;
            for (int fila = 0; fila < 9; fila++)
            {
                if (matriz[fila, col].Text.Equals(numeroRevisar))
                {
                    repite = true;
                }
            }

            for (int columna = 0; columna < 9; columna++)
            {
                if (matriz[fil, columna].Text.Equals(numeroRevisar))
                {
                    repite = true;
                }
            }

            return repite;
        }
    }
}
