using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace Proyecto
{
   
    public partial class Form1 : Form
    {
        private List<PictureBox> Fichas;
        private int[][] Tablero;
        private List<int> Auxiliar;
        private const int Profundidad = 1;
        private List<Servidor> servidores;
        private bool conectado;
        private Thread Habla;
        private Thread Escucha;
        private string dirGrupo;
        private Socket Server;
        private Socket Client;
        private IPEndPoint EPCliente;
        private IPEndPoint EPServidor;
        private Thread EscuchaTCP;
        private Socket EnviarServidor;
        public Form1()
        {
            InitializeComponent();

            dirGrupo = "230.0.0.0";

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            servidores = new List<Servidor>();

            Escucha = new Thread(SoyCliente);

            Habla = new Thread(SoyServidor);

            conectado = false;

            CheckForIllegalCrossThreadCalls = false;

            Auxiliar = new List<int>();

            Tablero = new int[17][];
            for (int i = 0; i < 17; i++)
                Tablero[i] = new int[9];
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Tablero[i][j] = -1;
                }
            }
            int c = 3, c2 = 5, c3 = 0, cont=0;
            for (int j = 0; j < 9; j++)
            {
                for (int i = c + 1; i < 17; i += 2)
                {
                    if (c3 < c2)
                    {
                        Tablero[i][j] = cont;
                        c3++;
                        cont++;
                        if (cont == 22 || cont == 28 || cont == 37)
                            i += 2;
                    }
                    else
                        break;
                }
                if (j >= 4)
                {
                    c++;
                    c2--;
                }
                else
                {
                    c--;
                    c2++;
                }
                c3 = 0;
            }

            Fichas = new List<PictureBox>();

            Fichas.Add(pictureBox2);
            Fichas.Add(pictureBox3);
            Fichas.Add(pictureBox4);
            Fichas.Add(pictureBox5);
            Fichas.Add(pictureBox6);
            Fichas.Add(pictureBox7);
            Fichas.Add(pictureBox8);
            Fichas.Add(pictureBox9);
            Fichas.Add(pictureBox10);
            Fichas.Add(pictureBox11);
            Fichas.Add(pictureBox12);
            Fichas.Add(pictureBox13);
            Fichas.Add(pictureBox14);
            Fichas.Add(pictureBox15);
            Fichas.Add(pictureBox16);
            Fichas.Add(pictureBox17);
            Fichas.Add(pictureBox18);
            Fichas.Add(pictureBox19);
            Fichas.Add(pictureBox20);
            Fichas.Add(pictureBox21);
            Fichas.Add(pictureBox22);
            Fichas.Add(pictureBox23);
            Fichas.Add(pictureBox24);
            Fichas.Add(pictureBox25);
            Fichas.Add(pictureBox26);
            Fichas.Add(pictureBox27);
            Fichas.Add(pictureBox28);
            Fichas.Add(pictureBox29);
            Fichas.Add(pictureBox30);
            Fichas.Add(pictureBox31);
            Fichas.Add(pictureBox32);
            Fichas.Add(pictureBox33);
            Fichas.Add(pictureBox34);
            Fichas.Add(pictureBox35);
            Fichas.Add(pictureBox36);
            Fichas.Add(pictureBox37);
            Fichas.Add(pictureBox38);
            Fichas.Add(pictureBox39);
            Fichas.Add(pictureBox40);
            Fichas.Add(pictureBox41);
            Fichas.Add(pictureBox42);
            Fichas.Add(pictureBox43);
            Fichas.Add(pictureBox44);
            Fichas.Add(pictureBox45);
            Fichas.Add(pictureBox46);
            Fichas.Add(pictureBox47);
            Fichas.Add(pictureBox48);
            Fichas.Add(pictureBox49);
            Fichas.Add(pictureBox50);
            Fichas.Add(pictureBox51);
            Fichas.Add(pictureBox52);
            Fichas.Add(pictureBox53);
            Fichas.Add(pictureBox54);
            Fichas.Add(pictureBox55);
            Fichas.Add(pictureBox56);
            Fichas.Add(pictureBox57);
            Fichas.Add(pictureBox58);
            Fichas.Add(pictureBox59);

            for(int i = 0; i < Fichas.Count; i++)
            {
                Fichas.ElementAt(i).Parent = pictureBox1;
                Fichas.ElementAt(i).Image = null;
                Fichas.ElementAt(i).Tag = 0;
            }

            Fichas.ElementAt(0).Location = new Point(43, 128);
            Fichas.ElementAt(1).Location = new Point(43, 178);
            Fichas.ElementAt(2).Location = new Point(43, 230);
            Fichas.ElementAt(3).Location = new Point(43, 283);
            Fichas.ElementAt(4).Location = new Point(43, 335);

            Fichas.ElementAt(5).Location = new Point(108, 102);
            Fichas.ElementAt(6).Location = new Point(108, 155);
            Fichas.ElementAt(7).Location = new Point(108, 208);
            Fichas.ElementAt(8).Location = new Point(108, 256);
            Fichas.ElementAt(9).Location = new Point(108, 308);
            Fichas.ElementAt(10).Location = new Point(108, 363);

            Fichas.ElementAt(11).Location = new Point(170, 73);
            Fichas.ElementAt(12).Location = new Point(170, 128);
            Fichas.ElementAt(13).Location = new Point(170, 178);
            Fichas.ElementAt(14).Location = new Point(170, 228);
            Fichas.ElementAt(15).Location = new Point(170, 280);
            Fichas.ElementAt(16).Location = new Point(170, 335);
            Fichas.ElementAt(17).Location = new Point(170, 390);

            Fichas.ElementAt(18).Location = new Point(235, 48);
            Fichas.ElementAt(19).Location = new Point(235, 98);
            Fichas.ElementAt(20).Location = new Point(235, 151);
            Fichas.ElementAt(21).Location = new Point(235, 203);
            Fichas.ElementAt(22).Location = new Point(235, 308);
            Fichas.ElementAt(23).Location = new Point(235, 361);
            Fichas.ElementAt(24).Location = new Point(235, 414);

            Fichas.ElementAt(25).Location = new Point(300, 20);
            Fichas.ElementAt(26).Location = new Point(300, 73);
            Fichas.ElementAt(27).Location = new Point(300, 125);
            Fichas.ElementAt(28).Location = new Point(300, 228);
            Fichas.ElementAt(29).Location = new Point(303, 281);
            Fichas.ElementAt(30).Location = new Point(303, 335);
            Fichas.ElementAt(31).Location = new Point(300, 390);
            Fichas.ElementAt(32).Location = new Point(300, 443);

            Fichas.ElementAt(33).Location = new Point(365, 48);
            Fichas.ElementAt(34).Location = new Point(365, 98);
            Fichas.ElementAt(35).Location = new Point(365, 151);
            Fichas.ElementAt(36).Location = new Point(365, 203);
            Fichas.ElementAt(37).Location = new Point(365, 308);
            Fichas.ElementAt(38).Location = new Point(365, 361);
            Fichas.ElementAt(39).Location = new Point(365, 414);

            Fichas.ElementAt(40).Location = new Point(432, 73);
            Fichas.ElementAt(41).Location = new Point(432, 128);
            Fichas.ElementAt(42).Location = new Point(432, 178);
            Fichas.ElementAt(43).Location = new Point(432, 228);
            Fichas.ElementAt(44).Location = new Point(432, 280);
            Fichas.ElementAt(45).Location = new Point(432, 335);
            Fichas.ElementAt(46).Location = new Point(432, 390);

            Fichas.ElementAt(47).Location = new Point(498, 102);
            Fichas.ElementAt(48).Location = new Point(498, 155);
            Fichas.ElementAt(49).Location = new Point(498, 208);
            Fichas.ElementAt(50).Location = new Point(498, 256);
            Fichas.ElementAt(51).Location = new Point(498, 308);
            Fichas.ElementAt(52).Location = new Point(498, 363);

            Fichas.ElementAt(53).Location = new Point(562, 128);
            Fichas.ElementAt(54).Location = new Point(562, 178);
            Fichas.ElementAt(55).Location = new Point(562, 230);
            Fichas.ElementAt(56).Location = new Point(562, 283);
            Fichas.ElementAt(57).Location = new Point(562, 335);

            Fichas.ElementAt(0).Tag = 1;
            Fichas.ElementAt(0).Image = Proyecto.Properties.Resources.Vespiquen;
            Fichas.ElementAt(32).Tag = 1;
            Fichas.ElementAt(32).Image = Proyecto.Properties.Resources.Vespiquen;
            Fichas.ElementAt(53).Tag = 1;
            Fichas.ElementAt(53).Image = Proyecto.Properties.Resources.Vespiquen;
            Fichas.ElementAt(4).Tag = 2;
            Fichas.ElementAt(4).Image = Proyecto.Properties.Resources.Beedrill;
            Fichas.ElementAt(25).Tag = 2;
            Fichas.ElementAt(25).Image = Proyecto.Properties.Resources.Beedrill;
            Fichas.ElementAt(57).Tag = 2;
            Fichas.ElementAt(57).Image = Proyecto.Properties.Resources.Beedrill;

        }

        private void ObtieneCoordenadas(ref int x, ref int y, int Nodo)
        {
            for(int i = 0; i < 17; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (Tablero[i][j] == Nodo)
                    {
                        x = j;
                        y = i;
                        return;
                    }
                }
            }
        }

        private bool MovPosible(int NodoI, int NodoF, string Accion)
        {
            int x = 0, y = 0;
            ObtieneCoordenadas(ref x, ref y, NodoI);
            if (Accion.CompareTo("clonar") == 0)
            {
                if ((x - 1 >= 0 && y - 1 >= 0) && Tablero[y - 1][x - 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 1][x - 1]).Tag) == 0)//Puedo clonar esquina sup izq
                    return true;
                if ((x + 1 < 9 && y - 1 >= 0) && Tablero[y - 1][x + 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 1][x + 1]).Tag) == 0)//Puedo clonar esquina sup der
                    return true;
                if ((x - 1 >= 0 && y + 1 < 17) && Tablero[y + 1][x - 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 1][x - 1]).Tag) == 0)//Puedo clonar esquina inf izq
                    return true;
                if ((x + 1 < 9 && y + 1 < 17) && Tablero[y + 1][x + 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 1][x + 1]).Tag) == 0)//Puedo clonar esquina inf izq
                    return true;
                if (y - 2 >= 0 && Tablero[y - 2][x] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x]).Tag) == 0)//Puedo clonar hacia arriba
                    return true;
                if (y + 2 < 17 && Tablero[y + 2][x] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x]).Tag) == 0)//Puedo clonar hacia arriba
                    return true;
            }
            if (Accion.CompareTo("saltar") == 0)
            {
                if ((x - 2 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 2] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x - 2]).Tag) == 0)//Puedo saltar esquina sup izq
                    return true;
                if ((x + 2 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 2] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x + 2]).Tag) == 0)//Puedo saltar esquina sup der
                    return true;
                if ((x - 2 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 2] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x - 2]).Tag) == 0)//Puedo saltar esquina inf izq
                    return true;
                if ((x + 2 < 9 && y + 2 < 17) && Tablero[y + 2][x + 2] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x + 2]).Tag) == 0)//Puedo saltar esquina inf izq
                    return true;
                if ((x - 1 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x - 1]).Tag) == 0)//Puedo saltar esquina sup izq rara
                    return true;
                if ((x + 1 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x + 1]).Tag) == 0)//Puedo saltar esquina sup der rara
                    return true;
                if ((x - 1 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x - 1]).Tag) == 0)//Puedo saltar esquina inf izq rara
                    return true;
                if ((x + 1 < 9 && y + 2 < 17) && Tablero[y + 2][x + 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x + 1]).Tag) == 0)//Puedo saltar esquina inf izq rara
                    return true;
                if (y - 4 >= 0 && Tablero[y - 4][x] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 4][x]).Tag) == 0)//Puedo saltar hacia arriba
                    return true;
                if (y + 4 < 17 && Tablero[y + 4][x] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 4][x]).Tag) == 0)//Puedo saltar hacia arriba
                    return true;
                if (x - 2 >= 0 && Tablero[y][x - 2] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y][x - 2]).Tag) == 0)//Puedo saltar hacia izq
                    return true;
                if (x + 2 < 9 && Tablero[y][x + 2] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y][x + 2]).Tag) == 0)//Puedo saltar hacia der
                    return true;
            }
            return false;
        }

        private bool MovPosibleAuxiliar(int NodoI, int NodoF, string Accion)
        {
            int x = 0, y = 0;
            ObtieneCoordenadas(ref x, ref y, NodoI);
            if (Accion.CompareTo("clonar") == 0)
            {
                if ((x - 1 >= 0 && y - 1 >= 0) && Tablero[y - 1][x - 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 1][x - 1])) == 0)//Puedo clonar esquina sup izq
                    return true;
                if ((x + 1 < 9 && y - 1 >= 0) && Tablero[y - 1][x + 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 1][x + 1])) == 0)//Puedo clonar esquina sup der
                    return true;
                if ((x - 1 >= 0 && y + 1 < 17) && Tablero[y + 1][x - 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 1][x - 1])) == 0)//Puedo clonar esquina inf izq
                    return true;
                if ((x + 1 < 9 && y + 1 < 17) && Tablero[y + 1][x + 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 1][x + 1])) == 0)//Puedo clonar esquina inf izq
                    return true;
                if (y - 2 >= 0 && Tablero[y - 2][x] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 2][x])) == 0)//Puedo clonar hacia arriba
                    return true;
                if (y + 2 < 17 && Tablero[y + 2][x] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 2][x])) == 0)//Puedo clonar hacia arriba
                    return true;
            }
            if (Accion.CompareTo("saltar") == 0)
            {
                if ((x - 2 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 2] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 2][x - 2])) == 0)//Puedo saltar esquina sup izq
                    return true;
                if ((x + 2 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 2] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 2][x + 2])) == 0)//Puedo saltar esquina sup der
                    return true;
                if ((x - 2 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 2] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 2][x - 2])) == 0)//Puedo saltar esquina inf izq
                    return true;
                if ((x + 2 < 9 && y + 2 < 17) && Tablero[y + 2][x + 2] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 2][x + 2])) == 0)//Puedo saltar esquina inf izq
                    return true;
                if ((x - 1 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 2][x - 1])) == 0)//Puedo saltar esquina sup izq rara
                    return true;
                if ((x + 1 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 2][x + 1])) == 0)//Puedo saltar esquina sup der rara
                    return true;
                if ((x - 1 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 2][x - 1])) == 0)//Puedo saltar esquina inf izq rara
                    return true;
                if ((x + 1 < 9 && y + 2 < 17) && Tablero[y + 2][x + 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 2][x + 1])) == 0)//Puedo saltar esquina inf izq rara
                    return true;
                if (y - 4 >= 0 && Tablero[y - 4][x] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 4][x])) == 0)//Puedo saltar hacia arriba
                    return true;
                if (y + 4 < 17 && Tablero[y + 4][x] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 4][x])) == 0)//Puedo saltar hacia arriba
                    return true;
                if (x - 2 >= 0 && Tablero[y][x - 2] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y][x - 2])) == 0)//Puedo saltar hacia izq
                    return true;
                if (x + 2 < 17 && Tablero[y][x + 2] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y][x + 2])) == 0)//Puedo saltar hacia der
                    return true;
            }
            return false;
        }

        private void Pintar()
        {
            for(int i = 0; i < Fichas.Count; i++)
            {
                if (((int)Fichas.ElementAt(i).Tag) == 1)
                {
                    Fichas.ElementAt(i).Image = Proyecto.Properties.Resources.Vespiquen;
                }
                if (((int)Fichas.ElementAt(i).Tag) == 2)
                {
                    Fichas.ElementAt(i).Image = Proyecto.Properties.Resources.Beedrill;
                }
                if (((int)Fichas.ElementAt(i).Tag) == 0)
                {
                    Fichas.ElementAt(i).Image = null;
                }
            }
            this.Refresh();
        }

        private void Multiplicar(int Nodo)
        {
            int x = 0, y = 0;
            ObtieneCoordenadas(ref x, ref y, Nodo);
            if ((x - 1 >= 0 && y - 1 >= 0) && Tablero[y - 1][x - 1] != -1
                    && ((int)Fichas.ElementAt(Tablero[y - 1][x - 1]).Tag) != 0)//Puedo clonar esquina sup izq
                Fichas.ElementAt(Tablero[y - 1][x - 1]).Tag = Fichas.ElementAt(Nodo).Tag;
            if ((x + 1 < 9 && y - 1 >= 0) && Tablero[y - 1][x + 1] != -1
                && ((int)Fichas.ElementAt(Tablero[y - 1][x + 1]).Tag) != 0)//Puedo clonar esquina sup der
                Fichas.ElementAt(Tablero[y - 1][x + 1]).Tag = Fichas.ElementAt(Nodo).Tag;
            if ((x - 1 >= 0 && y + 1 < 17) && Tablero[y + 1][x - 1] != -1
                && ((int)Fichas.ElementAt(Tablero[y + 1][x - 1]).Tag) != 0)//Puedo clonar esquina inf izq
                Fichas.ElementAt(Tablero[y + 1][x - 1]).Tag = Fichas.ElementAt(Nodo).Tag;
            if ((x + 1 < 9 && y + 1 < 17) && Tablero[y + 1][x + 1] != -1
                && ((int)Fichas.ElementAt(Tablero[y + 1][x + 1]).Tag) != 0)//Puedo clonar esquina inf izq
                Fichas.ElementAt(Tablero[y + 1][x + 1]).Tag = Fichas.ElementAt(Nodo).Tag;
            if (y - 2 >= 0 && Tablero[y - 2][x] != -1
                && ((int)Fichas.ElementAt(Tablero[y - 2][x]).Tag) != 0)//Puedo clonar hacia arriba
                Fichas.ElementAt(Tablero[y - 2][x]).Tag = Fichas.ElementAt(Nodo).Tag;
            if (y + 2 < 17 && Tablero[y + 2][x] != -1
                && ((int)Fichas.ElementAt(Tablero[y + 2][x]).Tag) != 0)//Puedo clonar hacia arriba
                Fichas.ElementAt(Tablero[y + 2][x]).Tag = Fichas.ElementAt(Nodo).Tag;
        }

        private void MultiplicarAuxiliar(int Nodo)
        {
            int x = 0, y = 0;
            ObtieneCoordenadas(ref x, ref y, Nodo);
            if ((x - 1 >= 0 && y - 1 >= 0) && Tablero[y - 1][x - 1] != -1
                    && (Auxiliar.ElementAt(Tablero[y - 1][x - 1])) != 0)//Puedo clonar esquina sup izq
                Auxiliar[Tablero[y - 1][x - 1]] = Auxiliar.ElementAt(Nodo);
            if ((x + 1 < 9 && y - 1 >= 0) && Tablero[y - 1][x + 1] != -1
                && (Auxiliar.ElementAt(Tablero[y - 1][x + 1])) != 0)//Puedo clonar esquina sup der
                Auxiliar[Tablero[y - 1][x + 1]] = Auxiliar.ElementAt(Nodo);
            if ((x - 1 >= 0 && y + 1 < 17) && Tablero[y + 1][x - 1] != -1
                && (Auxiliar.ElementAt(Tablero[y + 1][x - 1])) != 0)//Puedo clonar esquina inf izq
                Auxiliar[Tablero[y + 1][x - 1]] = Auxiliar.ElementAt(Nodo);
            if ((x + 1 < 9 && y + 1 < 17) && Tablero[y + 1][x + 1] != -1
                && (Auxiliar.ElementAt(Tablero[y + 1][x + 1])) != 0)//Puedo clonar esquina inf izq
                Auxiliar[Tablero[y + 1][x + 1]] = Auxiliar.ElementAt(Nodo);
            if (y - 2 >= 0 && Tablero[y - 2][x] != -1
                && (Auxiliar.ElementAt(Tablero[y - 2][x])) != 0)//Puedo clonar hacia arriba
                Auxiliar[Tablero[y - 2][x]] = Auxiliar.ElementAt(Nodo);
            if (y + 2 < 17 && Tablero[y + 2][x] != -1
                && (Auxiliar.ElementAt(Tablero[y + 2][x])) != 0)//Puedo clonar hacia arriba
                Auxiliar[Tablero[y + 2][x]] = Auxiliar.ElementAt(Nodo);
        }

        private void Mover(int NodoI,int NodoF,string Accion)
        {
            int x = 0, y = 0;
            ObtieneCoordenadas(ref x, ref y, NodoI);
            if (Accion.CompareTo("clonar") == 0)
            {
                if ((x - 1 >= 0 && y - 1 >= 0) && Tablero[y - 1][x - 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 1][x - 1]).Tag) == 0)//Puedo clonar esquina sup izq
                    Fichas.ElementAt(Tablero[y - 1][x - 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                if ((x + 1 < 9 && y - 1 >= 0) && Tablero[y - 1][x + 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 1][x + 1]).Tag) == 0)//Puedo clonar esquina sup der
                    Fichas.ElementAt(Tablero[y - 1][x + 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                if ((x - 1 >= 0 && y + 1 < 17) && Tablero[y + 1][x - 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 1][x - 1]).Tag) == 0)//Puedo clonar esquina inf izq
                    Fichas.ElementAt(Tablero[y + 1][x - 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                if ((x + 1 < 9 && y + 1 < 17) && Tablero[y + 1][x + 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 1][x + 1]).Tag) == 0)//Puedo clonar esquina inf izq
                    Fichas.ElementAt(Tablero[y + 1][x + 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                if (y - 2 >= 0 && Tablero[y - 2][x] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x]).Tag) == 0)//Puedo clonar hacia arriba
                    Fichas.ElementAt(Tablero[y - 2][x]).Tag = Fichas.ElementAt(NodoI).Tag;
                if (y + 2 < 17 && Tablero[y + 2][x] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x]).Tag) == 0)//Puedo clonar hacia arriba
                    Fichas.ElementAt(Tablero[y + 2][x]).Tag = Fichas.ElementAt(NodoI).Tag;
            }
            if (Accion.CompareTo("saltar") == 0)
            {
                if ((x - 2 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 2] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x - 2]).Tag) == 0)//Puedo saltar esquina sup izq
                    Fichas.ElementAt(Tablero[y - 2][x - 2]).Tag = Fichas.ElementAt(NodoI).Tag;
                if ((x + 2 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 2] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x + 2]).Tag) == 0)//Puedo saltar esquina sup der
                    Fichas.ElementAt(Tablero[y - 2][x + 2]).Tag = Fichas.ElementAt(NodoI).Tag;
                if ((x - 2 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 2] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x - 2]).Tag) == 0)//Puedo saltar esquina inf izq
                    Fichas.ElementAt(Tablero[y + 2][x - 2]).Tag = Fichas.ElementAt(NodoI).Tag;
                if ((x + 2 < 9 && y + 2 < 17) && Tablero[y + 2][x + 2] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x + 2]).Tag) == 0)//Puedo saltar esquina inf izq
                    Fichas.ElementAt(Tablero[y + 2][x + 2]).Tag = Fichas.ElementAt(NodoI).Tag;
                if ((x - 1 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x - 1]).Tag) == 0)//Puedo saltar esquina sup izq rara
                    Fichas.ElementAt(Tablero[y - 2][x - 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                if ((x + 1 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x + 1]).Tag) == 0)//Puedo saltar esquina sup der rara
                    Fichas.ElementAt(Tablero[y - 2][x + 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                if ((x - 1 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x - 1]).Tag) == 0)//Puedo saltar esquina inf izq rara
                    Fichas.ElementAt(Tablero[y + 2][x - 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                if ((x + 1 < 9 && y + 2 < 17) && Tablero[y + 2][x + 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x + 1]).Tag) == 0)//Puedo saltar esquina inf der rara
                    Fichas.ElementAt(Tablero[y + 2][x + 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                if (y - 4 >= 0 && Tablero[y - 4][x] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y - 4][x]).Tag) == 0)//Puedo saltar hacia arriba doble
                    Fichas.ElementAt(Tablero[y - 4][x]).Tag = Fichas.ElementAt(NodoI).Tag;
                if (y + 4 < 17 && Tablero[y + 4][x] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 4][x]).Tag) == 0)//Puedo saltar hacia abajo doble
                    Fichas.ElementAt(Tablero[y + 4][x]).Tag = Fichas.ElementAt(NodoI).Tag;
                if (x - 2 >= 0 && Tablero[y][x - 2] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y][x - 2]).Tag) == 0)//Puedo saltar hacia izq
                    Fichas.ElementAt(Tablero[y][x - 2]).Tag = Fichas.ElementAt(NodoI).Tag;
                if (x + 2 < 9 && Tablero[y][x + 2] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y][x + 2]).Tag) == 0)//Puedo saltar hacia der
                    Fichas.ElementAt(Tablero[y][x + 2]).Tag = Fichas.ElementAt(NodoI).Tag;
            }
            if (Accion.CompareTo("") == 0)
            {
                if ((x - 2 >= 0 && y - 2 >= 0) 
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x - 2]).Tag) == 0)//Puedo saltar esquina sup izq
                {
                    Fichas.ElementAt(Tablero[y - 2][x - 2]).Tag = Fichas.ElementAt(NodoI).Tag;
                    Fichas.ElementAt(NodoI).Tag = 0;
                    Multiplicar(Tablero[y - 2][x - 2]);
                }
                else if ((x + 2 < 9 && y - 2 >= 0) 
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x + 2]).Tag) == 0)//Puedo saltar esquina sup der
                {
                    Fichas.ElementAt(Tablero[y - 2][x + 2]).Tag = Fichas.ElementAt(NodoI).Tag;
                    Fichas.ElementAt(NodoI).Tag = 0;
                    Multiplicar(Tablero[y - 2][x + 2]);
                }
                else if ((x - 2 >= 0 && y + 2 < 17)
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x - 2]).Tag) == 0)//Puedo saltar esquina inf izq
                {
                    Fichas.ElementAt(Tablero[y + 2][x - 2]).Tag = Fichas.ElementAt(NodoI).Tag;
                    Fichas.ElementAt(NodoI).Tag = 0;
                    Multiplicar(Tablero[y + 2][x - 2]);
                }
                else if ((x + 2 < 9 && y + 2 < 17) 
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x + 2]).Tag) == 0)//Puedo saltar esquina inf izq
                {
                    Fichas.ElementAt(Tablero[y + 2][x + 2]).Tag = Fichas.ElementAt(NodoI).Tag;
                    Fichas.ElementAt(NodoI).Tag = 0;
                    Multiplicar(Tablero[y + 2][x + 2]);
                }      
                else if ((x - 1 >= 0 && y - 2 >= 0) 
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x - 1]).Tag) == 0)//Puedo saltar esquina sup izq rara
                {
                    Fichas.ElementAt(Tablero[y - 2][x - 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                    Fichas.ElementAt(NodoI).Tag = 0;
                    Multiplicar(Tablero[y - 2][x - 1]);
                }
                else if ((x + 1 < 9 && y - 2 >= 0) 
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x + 1]).Tag) == 0)//Puedo saltar esquina sup der rara
                {
                    Fichas.ElementAt(Tablero[y - 2][x + 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                    Fichas.ElementAt(NodoI).Tag = 0;
                    Multiplicar(Tablero[y - 2][x + 1]);
                }    
                else if ((x - 1 >= 0 && y + 2 < 17) 
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x - 1]).Tag) == 0)//Puedo saltar esquina inf izq rara
                {
                    Fichas.ElementAt(Tablero[y + 2][x - 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                    Fichas.ElementAt(NodoI).Tag = 0;
                    Multiplicar(Tablero[y + 2][x - 1]);
                }                    
                else if ((x + 1 < 9 && y + 2 < 17) 
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x + 1]).Tag) == 0)//Puedo saltar esquina inf der rara
                {
                    Fichas.ElementAt(Tablero[y + 2][x + 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                    Fichas.ElementAt(NodoI).Tag = 0;
                    Multiplicar(Tablero[y + 2][x + 1]);
                }                    
                else if (y - 4 >= 0 
                    && ((int)Fichas.ElementAt(Tablero[y - 4][x]).Tag) == 0)//Puedo saltar hacia arriba doble
                {
                    Fichas.ElementAt(Tablero[y - 4][x]).Tag = Fichas.ElementAt(NodoI).Tag;
                    Fichas.ElementAt(NodoI).Tag = 0;
                    Multiplicar(Tablero[y - 4][x]);
                }
                else if (y + 4 < 17 
                    && ((int)Fichas.ElementAt(Tablero[y + 4][x]).Tag) == 0)//Puedo saltar hacia abajo doble
                {
                    Fichas.ElementAt(Tablero[y + 4][x]).Tag = Fichas.ElementAt(NodoI).Tag;
                    Fichas.ElementAt(NodoI).Tag = 0;
                    Multiplicar(Tablero[y + 4][x]);
                }    
                else if (x - 2 >= 0 
                    && ((int)Fichas.ElementAt(Tablero[y][x - 2]).Tag) == 0)//Puedo saltar hacia izq
                {
                    Fichas.ElementAt(Tablero[y][x - 2]).Tag = Fichas.ElementAt(NodoI).Tag;
                    Fichas.ElementAt(NodoI).Tag = 0;
                    Multiplicar(Tablero[y][x - 2]);
                }
                else if (x + 2 < 9 
                    && ((int)Fichas.ElementAt(Tablero[y][x + 2]).Tag) == 0)//Puedo saltar hacia der
                {
                    Fichas.ElementAt(Tablero[y][x + 2]).Tag = Fichas.ElementAt(NodoI).Tag;
                    Fichas.ElementAt(NodoI).Tag = 0;
                    Multiplicar(Tablero[y][x + 2]);
                }    
                else if ((x - 1 >= 0 && y - 1 >= 0) 
                    && ((int)Fichas.ElementAt(Tablero[y - 1][x - 1]).Tag) == 0)//Puedo clonar esquina sup izq
                    Fichas.ElementAt(Tablero[y - 1][x - 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                else if ((x + 1 < 9 && y - 1 >= 0) 
                    && ((int)Fichas.ElementAt(Tablero[y - 1][x + 1]).Tag) == 0)//Puedo clonar esquina sup der
                    Fichas.ElementAt(Tablero[y - 1][x + 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                else if ((x - 1 >= 0 && y + 1 < 17) 
                    && ((int)Fichas.ElementAt(Tablero[y + 1][x - 1]).Tag) == 0)//Puedo clonar esquina inf izq
                    Fichas.ElementAt(Tablero[y + 1][x - 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                else if ((x + 1 < 9 && y + 1 < 17) && Tablero[y + 1][x + 1] == NodoF
                    && ((int)Fichas.ElementAt(Tablero[y + 1][x + 1]).Tag) == 0)//Puedo clonar esquina inf izq
                    Fichas.ElementAt(Tablero[y + 1][x + 1]).Tag = Fichas.ElementAt(NodoI).Tag;
                else if (y - 2 >= 0 
                    && ((int)Fichas.ElementAt(Tablero[y - 2][x]).Tag) == 0)//Puedo clonar hacia arriba
                    Fichas.ElementAt(Tablero[y - 2][x]).Tag = Fichas.ElementAt(NodoI).Tag;
                else if (y + 2 < 17 
                    && ((int)Fichas.ElementAt(Tablero[y + 2][x]).Tag) == 0)//Puedo clonar hacia arriba
                    Fichas.ElementAt(Tablero[y + 2][x]).Tag = Fichas.ElementAt(NodoI).Tag;
                Pintar();
                return;
            }
            Multiplicar(NodoF);
            Pintar();
        }

        private int FuncionObjetivo(int Player)
        {
            int c = 0;
            for(int i = 0; i < Auxiliar.Count; i++)
            {
                if (Auxiliar.ElementAt(i) == Player)
                    c++;
            }
            return c;
        }

        private void MoverAuxiliar(int NodoI,int NodoF, string Accion)
        {
            int x = 0, y = 0;
            ObtieneCoordenadas(ref x, ref y, NodoI);
            if (Accion.CompareTo("clonar") == 0)
            {
                if ((x - 1 >= 0 && y - 1 >= 0) && Tablero[y - 1][x - 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 1][x - 1])) == 0)//Puedo clonar esquina sup izq
                    Auxiliar[Tablero[y - 1][x - 1]] = Auxiliar.ElementAt(NodoI);
                if ((x + 1 < 9 && y - 1 >= 0) && Tablero[y - 1][x + 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 1][x + 1])) == 0)//Puedo clonar esquina sup der
                    Auxiliar[Tablero[y - 1][x + 1]] = Auxiliar.ElementAt(NodoI);
                if ((x - 1 >= 0 && y + 1 < 17) && Tablero[y + 1][x - 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 1][x - 1])) == 0)//Puedo clonar esquina inf izq
                    Auxiliar[Tablero[y + 1][x - 1]] = Auxiliar.ElementAt(NodoI);
                if ((x + 1 < 9 && y + 1 < 17) && Tablero[y + 1][x + 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 1][x + 1])) == 0)//Puedo clonar esquina inf izq
                    Auxiliar[Tablero[y + 1][x + 1]] = Auxiliar.ElementAt(NodoI);
                if (y - 2 >= 0 && Tablero[y - 2][x] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 2][x])) == 0)//Puedo clonar hacia arriba
                    Auxiliar[Tablero[y - 2][x]] = Auxiliar.ElementAt(NodoI);
                if (y + 2 < 17 && Tablero[y + 2][x] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 2][x])) == 0)//Puedo clonar hacia arriba
                    Auxiliar[Tablero[y + 2][x]] = Auxiliar.ElementAt(NodoI);
            }
            if (Accion.CompareTo("saltar") == 0)
            {
                if ((x - 2 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 2] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 2][x - 2])) == 0)//Puedo saltar esquina sup izq
                    Auxiliar[Tablero[y - 2][x - 2]] = Auxiliar.ElementAt(NodoI);
                if ((x + 2 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 2] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 2][x + 2])) == 0)//Puedo saltar esquina sup der
                    Auxiliar[Tablero[y - 2][x + 2]] = Auxiliar.ElementAt(NodoI);
                if ((x - 2 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 2] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 2][x - 2])) == 0)//Puedo saltar esquina inf izq
                    Auxiliar[Tablero[y + 2][x - 2]] = Auxiliar.ElementAt(NodoI);
                if ((x + 2 < 9 && y + 2 < 17) && Tablero[y + 2][x + 2] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 2][x + 2])) == 0)//Puedo saltar esquina inf izq
                    Auxiliar[Tablero[y + 2][x + 2]] = Auxiliar.ElementAt(NodoI);
                if ((x - 1 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 2][x - 1])) == 0)//Puedo saltar esquina sup izq rara
                    Auxiliar[Tablero[y - 2][x - 1]] = Auxiliar.ElementAt(NodoI);
                if ((x + 1 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 2][x + 1])) == 0)//Puedo saltar esquina sup der rara
                    Auxiliar[Tablero[y - 2][x + 1]] = Auxiliar.ElementAt(NodoI);
                if ((x - 1 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 2][x - 1])) == 0)//Puedo saltar esquina inf izq rara
                    Auxiliar[Tablero[y + 2][x - 1]] = Auxiliar.ElementAt(NodoI);
                if ((x + 1 < 9 && y + 2 < 17) && Tablero[y + 2][x + 1] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 2][x + 1])) == 0)//Puedo saltar esquina inf der rara
                    Auxiliar[Tablero[y + 2][x + 1]] = Auxiliar.ElementAt(NodoI);
                if (y - 4 >= 0 && Tablero[y - 4][x] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y - 4][x])) == 0)//Puedo saltar hacia arriba doble
                    Auxiliar[Tablero[y - 4][x]] = Auxiliar.ElementAt(NodoI);
                if (y + 4 < 17 && Tablero[y + 4][x] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y + 4][x])) == 0)//Puedo saltar hacia abajo doble
                    Auxiliar[Tablero[y + 4][x]] = Auxiliar.ElementAt(NodoI);
                if (x - 2 >= 0 && Tablero[y][x - 2] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y][x - 2])) == 0)//Puedo saltar hacia izq
                    Auxiliar[Tablero[y][x - 2]] = Auxiliar.ElementAt(NodoI);
                if (x + 2 < 9 && Tablero[y][x + 2] == NodoF
                    && (Auxiliar.ElementAt(Tablero[y][x + 2])) == 0)//Puedo saltar hacia der
                    Auxiliar[Tablero[y ][x + 2]] = Auxiliar.ElementAt(NodoI);
                Auxiliar[NodoI] = 0;
            }
            MultiplicarAuxiliar(NodoF);
        }

        private int MaximizaEnemigo(int Player,int Nivel = 0)
        {
            List<int> Copia;
            int x = 0, y = 0, Mayor = -999;
            int b = 0;
            if (Player == 1)
            {
                for(int i = 0; i < Auxiliar.Count; i++)
                {
                    if (Auxiliar.ElementAt(i) == 2)
                    {
                        ObtieneCoordenadas(ref x, ref y, i);
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x - 1 >= 0 && y - 1 >= 0) && Tablero[y - 1][x - 1] != -1
                            && Auxiliar.ElementAt(Tablero[y - 1][x - 1]) == 0)//El enemigo puede ir a la esquina sup izquierda
                        {
                            MoverAuxiliar(i, Tablero[y - 1][x - 1], "clonar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x + 1 < 9 && y - 1 >= 0) && Tablero[y - 1][x + 1] != -1
                            && Auxiliar.ElementAt(Tablero[y - 1][x + 1]) == 0)//El enemigo puede ir a la esquina sup der
                        {
                            MoverAuxiliar(i, Tablero[y - 1][x + 1], "clonar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x - 1 >= 0 && y + 1 < 17) && Tablero[y + 1][x - 1] != -1
                            && Auxiliar.ElementAt(Tablero[y + 1][x - 1]) == 0)//El enemigo puede ir a la esquina inf izquierda
                        {
                            MoverAuxiliar(i, Tablero[y + 1][x - 1], "clonar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x + 1 < 9 && y + 1 < 17) && Tablero[y + 1][x + 1] != -1
                            && Auxiliar.ElementAt(Tablero[y + 1][x + 1]) == 0)//El enemigo puede ir a la esquina inf der
                        {
                            MoverAuxiliar(i, Tablero[y + 1][x + 1], "clonar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if (y - 2 >= 0 && Tablero[y - 2][x] != -1
                            && Auxiliar.ElementAt(Tablero[y - 2][x]) == 0)//El enemigo puede ir arriba
                        {
                            MoverAuxiliar(i, Tablero[y - 2][x], "clonar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if (y + 2 < 17 && Tablero[y + 2][x] != -1
                            && Auxiliar.ElementAt(Tablero[y + 2][x]) == 0)//El enemigo puede ir abajo
                        {
                            MoverAuxiliar(i, Tablero[y + 2][x], "clonar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if (x + 2 < 9 && Tablero[y][x + 2] != -1
                            && Auxiliar.ElementAt(Tablero[y][x + 2]) == 0)//El enemigo puede ir derecha
                        {
                            MoverAuxiliar(i, Tablero[y][x + 2], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if (x - 2 >= 0 && Tablero[y][x - 2] != -1
                            && Auxiliar.ElementAt(Tablero[y][x - 2]) == 0)//El enemigo puede ir izq
                        {
                            MoverAuxiliar(i, Tablero[y][x - 2], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if (y + 4 < 17 && Tablero[y + 4][x] != -1
                            && Auxiliar.ElementAt(Tablero[y + 4][x]) == 0)//El enemigo puede ir abajo doble
                        {
                            MoverAuxiliar(i, Tablero[y + 4][x], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if (y - 4 >= 0 && Tablero[y - 4][x] != -1
                            && Auxiliar.ElementAt(Tablero[y - 4][x]) == 0)//El enemigo puede ir arriba doble
                        {
                            MoverAuxiliar(i, Tablero[y - 4][x], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x - 2 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 2] != -1
                            && Auxiliar.ElementAt(Tablero[y - 2][x - 2]) == 0)//El enemigo puede ir a la esquina sup izq doble
                        {
                            MoverAuxiliar(i, Tablero[y - 2][x - 2], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x + 2 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 2] != -1
                            && Auxiliar.ElementAt(Tablero[y - 2][x + 2]) == 0)//El enemigo puede ir a la esquina sup der doble
                        {
                            MoverAuxiliar(i, Tablero[y - 2][x + 2], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x - 2 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 2] != -1
                            && Auxiliar.ElementAt(Tablero[y + 2][x - 2]) == 0)//El enemigo puede ir a la esquina inf izq dob
                        {
                            MoverAuxiliar(i, Tablero[y + 2][x - 2], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x + 2 < 9 && y + 2 < 17) && Tablero[y + 2][x + 2] != -1
                            && Auxiliar.ElementAt(Tablero[y + 2][x + 2]) == 0)//El enemigo puede ir a la esquina inf der dob
                        {
                            MoverAuxiliar(i, Tablero[y + 2][x + 2], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x - 1 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 1] != -1
                            && Auxiliar.ElementAt(Tablero[y - 2][x - 1]) == 0)//El enemigo puede ir a la esquina sup izq rara
                        {
                            MoverAuxiliar(i, Tablero[y - 2][x - 1], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x + 1 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 1] != -1
                            && Auxiliar.ElementAt(Tablero[y - 2][x + 1]) == 0)//El enemigo puede ir a la esquina sup der rara
                        {
                            MoverAuxiliar(i, Tablero[y - 2][x + 1], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x - 1 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 1] != -1
                            && Auxiliar.ElementAt(Tablero[y + 2][x - 1]) == 0)//El enemigo puede ir a la esquina inf izq rara
                        {
                            MoverAuxiliar(i, Tablero[y + 2][x - 1], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x + 1 < 9 && y + 2 < 17) && Tablero[y + 2][x + 1] != -1
                            && Auxiliar.ElementAt(Tablero[y + 2][x + 1]) == 0)//El enemigo puede ir a la esquina inf der rara
                        {
                            MoverAuxiliar(i, Tablero[y + 2][x + 1], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(2, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(2);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Auxiliar.Count; i++)
                {
                    if (Auxiliar.ElementAt(i) == 1)
                    {
                        ObtieneCoordenadas(ref x, ref y, i);
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x - 1 >= 0 && y - 1 >= 0) && Tablero[y - 1][x - 1] != -1
                            && Auxiliar.ElementAt(Tablero[y - 1][x - 1]) == 0)//El enemigo puede ir a la esquina sup izquierda
                        {
                            MoverAuxiliar(i, Tablero[y - 1][x - 1], "clonar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x + 1 < 9 && y - 1 >= 0) && Tablero[y - 1][x + 1] != -1
                            && Auxiliar.ElementAt(Tablero[y - 1][x + 1]) == 0)//El enemigo puede ir a la esquina sup der
                        {
                            MoverAuxiliar(i, Tablero[y - 1][x + 1], "clonar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x - 1 >= 0 && y + 1 < 17) && Tablero[y + 1][x - 1] != -1
                            && Auxiliar.ElementAt(Tablero[y + 1][x - 1]) == 0)//El enemigo puede ir a la esquina inf izquierda
                        {
                            MoverAuxiliar(i, Tablero[y + 1][x - 1], "clonar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x + 1 < 9 && y + 1 < 17) && Tablero[y + 1][x + 1] != -1
                            && Auxiliar.ElementAt(Tablero[y + 1][x + 1]) == 0)//El enemigo puede ir a la esquina inf der
                        {
                            MoverAuxiliar(i, Tablero[y + 1][x + 1], "clonar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if (y - 2 >= 0 && Tablero[y - 2][x] != -1 
                            && Auxiliar.ElementAt(Tablero[y - 2][x]) == 0)//El enemigo puede ir arriba
                        {
                            MoverAuxiliar(i, Tablero[y - 2][x], "clonar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if (y + 2 < 17 && Tablero[y + 2][x] != -1
                            && Auxiliar.ElementAt(Tablero[y + 2][x]) == 0)//El enemigo puede ir abajo
                        {
                            MoverAuxiliar(i, Tablero[y + 2][x], "clonar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if (x + 2 < 9 && Tablero[y][x + 2] != -1
                            && Auxiliar.ElementAt(Tablero[y][x + 2]) == 0)//El enemigo puede ir derecha
                        {
                            MoverAuxiliar(i, Tablero[y][x + 2], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if (x - 2 >= 0 && Tablero[y][x - 2] != -1
                            && Auxiliar.ElementAt(Tablero[y][x - 2]) == 0)//El enemigo puede ir izq
                        {
                            MoverAuxiliar(i, Tablero[y][x - 2], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if (y + 4 < 17 && Tablero[y + 4][x] != -1
                            && Auxiliar.ElementAt(Tablero[y + 4][x]) == 0)//El enemigo puede ir abajo doble
                        {
                            MoverAuxiliar(i, Tablero[y + 4][x], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if (y - 4 >= 0 && Tablero[y - 4][x] != -1
                            && Auxiliar.ElementAt(Tablero[y - 4][x]) == 0)//El enemigo puede ir arriba doble
                        {
                            MoverAuxiliar(i, Tablero[y - 4][x], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x - 2 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 2] != -1
                            && Auxiliar.ElementAt(Tablero[y - 2][x - 2]) == 0)//El enemigo puede ir a la esquina sup izq doble
                        {
                            MoverAuxiliar(i, Tablero[y - 2][x - 2], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x + 2 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 2] != -1
                            && Auxiliar.ElementAt(Tablero[y - 2][x + 2]) == 0)//El enemigo puede ir a la esquina sup der doble
                        {
                            MoverAuxiliar(i, Tablero[y - 2][x + 2], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x - 2 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 2] != -1
                            && Auxiliar.ElementAt(Tablero[y + 2][x - 2]) == 0)//El enemigo puede ir a la esquina inf izq dob
                        {
                            MoverAuxiliar(i, Tablero[y + 2][x - 2], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x + 2 < 9 && y + 2 < 17) && Tablero[y + 2][x + 2] != -1
                            && Auxiliar.ElementAt(Tablero[y + 2][x + 2]) == 0)//El enemigo puede ir a la esquina inf der dob
                        {
                            MoverAuxiliar(i, Tablero[y + 2][x + 2], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x - 1 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 1] != -1
                            && Auxiliar.ElementAt(Tablero[y - 2][x - 1]) == 0)//El enemigo puede ir a la esquina sup izq rara
                        {
                            MoverAuxiliar(i, Tablero[y - 2][x - 1], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x + 1 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 1] != -1
                            && Auxiliar.ElementAt(Tablero[y - 2][x + 1]) == 0)//El enemigo puede ir a la esquina sup der rara
                        {
                            MoverAuxiliar(i, Tablero[y - 2][x + 1], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x - 1 >= 0 && y + 2 < 17) && Tablero[y+2][x - 1] != -1 
                            && Auxiliar.ElementAt(Tablero[y + 2][x - 1]) == 0)//El enemigo puede ir a la esquina inf izq rara
                        {
                            MoverAuxiliar(i, Tablero[y + 2][x - 1], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                        Copia = new List<int>();
                        for (int j = 0; j < Auxiliar.Count; j++)
                        {
                            Copia.Add(Auxiliar.ElementAt(j));
                        }
                        if ((x + 1 < 9 && y + 2 < 17) && Tablero[y+2][x+1]!=-1 
                            && Auxiliar.ElementAt(Tablero[y + 2][x + 1]) == 0)//El enemigo puede ir a la esquina inf der rara
                        {
                            MoverAuxiliar(i, Tablero[y + 2][x + 1], "saltar");
                            if (Nivel < Profundidad)
                            {
                                b = b - MaximizaEnemigo(1, Nivel + 1);
                            }
                            else
                                b = FuncionObjetivo(1);
                            if (b > Mayor)
                            {
                                Mayor = b;
                            }
                            Auxiliar = new List<int>();
                            for (int j = 0; j < Copia.Count; j++)
                            {
                                Auxiliar.Add(Copia.ElementAt(j));
                            }
                        }
                    }
                }
            }
            return Mayor;
        }

        private int Maximiza(int NodoI, ref int NodoF, int Player, ref string Accion)
        {
            int a = 0, x = 0, y = 0, Mayor = -999, b = 0;
            List<int> Copia = new List<int>();
            ObtieneCoordenadas(ref x, ref y, NodoI);
            Auxiliar = new List<int>();
            for (int i = 0; i < Fichas.Count; i++)
            {
                Auxiliar.Add(((int)Fichas.ElementAt(i).Tag));
            }

            

            Copia = new List<int>();
            for(int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if ((x - 1 >= 0 && y - 1 >= 0) && Tablero[y - 1][x - 1] != -1 && Auxiliar.ElementAt(Tablero[y - 1][x - 1]) == 0)//Me puedo clonar esq sup izq
            {
                MoverAuxiliar(NodoI, Tablero[y - 1][x - 1], "clonar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y - 1][x - 1];
                    Accion = "clonar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if ((x + 1 < 9 && y - 1 >= 0) && Tablero[y - 1][x + 1]!=-1 && Auxiliar.ElementAt(Tablero[y - 1][x + 1]) == 0)//Me puedo clonar esq sup der
            {
                MoverAuxiliar(NodoI, Tablero[y - 1][x + 1], "clonar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y - 1][x + 1];
                    Accion = "clonar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if ((x - 1 >= 0 && y + 1 < 17) && Tablero[y + 1][x - 1] != -1 && Auxiliar.ElementAt(Tablero[y + 1][x - 1]) == 0)//Me puedo clonar esq inf izq
            {
                MoverAuxiliar(NodoI, Tablero[y + 1][x - 1], "clonar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y + 1][x - 1];
                    Accion = "clonar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if ((x + 1 < 9 && y + 1 < 17) && Tablero[y + 1][x + 1] != -1 && Auxiliar.ElementAt(Tablero[y + 1][x + 1]) == 0)//Me puedo clonar esq inf der
            {
                MoverAuxiliar(NodoI, Tablero[y + 1][x + 1], "clonar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y + 1][x + 1];
                    Accion = "clonar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if ((x + 2 < 9 && y + 2 < 17) && Tablero[y + 2][x + 2] != -1 && Auxiliar.ElementAt(Tablero[y + 2][x + 2]) == 0)//Puedo Saltar esq inf der doble
            {
                MoverAuxiliar(NodoI, Tablero[y + 2][x + 2], "saltar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y + 2][x + 2];
                    Accion = "saltar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if ((x - 2 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 2] != -1 && Auxiliar.ElementAt(Tablero[y + 2][x - 2]) == 0)//Puedo Saltar esq inf izq doble
            {
                MoverAuxiliar(NodoI, Tablero[y + 2][x - 2], "saltar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y + 2][x - 2];
                    Accion = "saltar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if ((x - 2 >= 0 && y - 2 >= 0) && Tablero[y-2][x-2]!=-1 && Auxiliar.ElementAt(Tablero[y - 2][x - 2]) == 0)//Puedo Saltar esq sup izq doble
            {
                MoverAuxiliar(NodoI, Tablero[y - 2][x - 2], "saltar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y - 2][x - 2];
                    Accion = "saltar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if ((x + 2 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 2] != -1 && Auxiliar.ElementAt(Tablero[y - 2][x + 2]) == 0)//Puedo Saltar esq sup der doble
            {
                MoverAuxiliar(NodoI, Tablero[y - 2][x + 2], "saltar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y - 2][x + 2];
                    Accion = "saltar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if ((x + 1 < 9 && y + 2 < 17) && Tablero[y + 2][x + 1] != -1 && Auxiliar.ElementAt(Tablero[y + 2][x + 1]) == 0)//Puedo Saltar esq inf der rara
            {
                MoverAuxiliar(NodoI, Tablero[y + 2][x + 1], "saltar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y + 2][x + 1];
                    Accion = "saltar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if ((x - 1 >= 0 && y + 2 < 17) && Tablero[y + 2][x - 1] != -1 && Auxiliar.ElementAt(Tablero[y + 2][x - 1]) == 0)//Puedo Saltar esq inf izq rara
            {
                MoverAuxiliar(NodoI, Tablero[y + 2][x - 1], "saltar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y + 2][x - 1];
                    Accion = "saltar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if ((x - 1 >= 0 && y - 2 >= 0) && Tablero[y - 2][x - 1] != -1 && Auxiliar.ElementAt(Tablero[y - 2][x - 1]) == 0)//Puedo Saltar esq sup izq rara
            {
                MoverAuxiliar(NodoI, Tablero[y - 2][x - 1], "saltar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y - 2][x - 1];
                    Accion = "saltar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if ((x + 1 < 9 && y - 2 >= 0) && Tablero[y - 2][x + 1] != -1 && Auxiliar.ElementAt(Tablero[y - 2][x + 1]) == 0)//Puedo Saltar esq sup der rara
            {
                MoverAuxiliar(NodoI, Tablero[y - 2][x + 1], "saltar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y - 2][x + 1];
                    Accion = "saltar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if (y - 4 >= 0 && Tablero[y - 4][x] != -1 && Auxiliar.ElementAt(Tablero[y - 4][x]) == 0)//Puedo Saltar arriba doble
            {
                MoverAuxiliar(NodoI, Tablero[y - 4][x], "saltar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y - 4][x];
                    Accion = "saltar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if (y + 4 < 17 && Tablero[y + 4][x] != -1 && Auxiliar.ElementAt(Tablero[y + 4][x]) == 0)//Puedo Saltar abajo doble
            {
                MoverAuxiliar(NodoI, Tablero[y + 4][x], "saltar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y + 4][x];
                    Accion = "saltar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if (y - 2 >= 0 && Tablero[y - 2][x] != -1 && Auxiliar.ElementAt(Tablero[y - 2][x]) == 0)//Puedo clonar arriba
            {
                MoverAuxiliar(NodoI, Tablero[y - 2][x], "clonar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y - 2][x];
                    Accion = "clonar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if (y + 2 < 17 && Tablero[y + 2][x] != -1 && Auxiliar.ElementAt(Tablero[y + 2][x]) == 0)//Puedo Saltar abajo doble
            {
                MoverAuxiliar(NodoI, Tablero[y + 2][x], "clonar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y + 2][x];
                    Accion = "clonar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if (x + 2 < 9 && Tablero[y][x + 2] != -1 && Auxiliar.ElementAt(Tablero[y][x + 2]) == 0)//Puedo Saltar der
            {
                MoverAuxiliar(NodoI, Tablero[y][x + 2], "saltar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y][x + 2];
                    Accion = "saltar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            Copia = new List<int>();
            for (int i = 0; i < Auxiliar.Count; i++)
            {
                Copia.Add(Auxiliar.ElementAt(i));
            }
            if (x - 2 >= 0 && Tablero[y][x - 2] != -1 && Auxiliar.ElementAt(Tablero[y][x - 2]) == 0)//Puedo Saltar izq
            {
                MoverAuxiliar(NodoI, Tablero[y][x - 2], "saltar");
                a = FuncionObjetivo(Player);
                b = MaximizaEnemigo(Player);
                if ((a - b) > Mayor)
                {
                    Mayor = a - b;
                    NodoF = Tablero[y][x - 2];
                    Accion = "saltar";
                }
                Auxiliar = new List<int>();
                for (int i = 0; i < Copia.Count; i++)
                {
                    Auxiliar.Add(Copia.ElementAt(i));
                }
            }

            return Mayor;
        }

        private bool Fin(int Player)
        {
            for(int i = 0; i < Fichas.Count; i++)
            {
                if (((int)Fichas.ElementAt(i).Tag) != Player && ((int)Fichas.ElementAt(i).Tag) != 0)
                    return false;
            }
            return true;
        }

        private bool Lleno()
        {
            for (int i = 0; i < Fichas.Count; i++)
            {
                if (((int)Fichas.ElementAt(i).Tag) == 0)
                    return false;
            }
            return true;
        }

        private void SoyServidor()
        {
            UdpClient udpclient = new UdpClient();

            IPAddress multicastaddress = IPAddress.Parse(dirGrupo);
            udpclient.JoinMulticastGroup(multicastaddress);
            IPEndPoint remoteep = new IPEndPoint(IPAddress.Broadcast, 1234);

            string strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            IPAddress[] hostIPs = Dns.GetHostAddresses(strHostName);

            Servidor server = new Servidor();
            server.hostname = textBox1.Text;
            server.ip = hostIPs[2].ToString();
            server.puerto = 5000;

            byte[] buffer;
            buffer = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(server));
            
            while(!conectado)
            {
                udpclient.Send(buffer, buffer.Length, remoteep);
            }
            udpclient.Close();
        }

        /*do{
                int Mayor = -999, final = 0, f = 0, inicial = 0;
                string Accion = "", Ac = "";
                int a;
                for (int i = 0; i < Fichas.Count; i++)
                {
                    if (((int)Fichas.ElementAt(i).Tag) == turno)
                    {
                        a = Maximiza(i, ref f, turno, ref Ac);
                        if (a > Mayor)
                        {
                            final = f;
                            Accion = Ac;
                            Mayor = a;
                            inicial = i;
                        }
                    }
                }
                Mover(inicial, final, Accion);
                if (turno == 1)
                    turno = 2;
                else
                    turno = 1;
                Thread.Sleep(100);
            } while (!Fin(1) && !Fin(2) && !Lleno()) ;*/

        private void SoyCliente()
        {
            UdpClient client = new UdpClient();

            //client.ExclusiveAddressUse = false;
            IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 1234);

            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            //client.ExclusiveAddressUse = false;

            client.Client.Bind(localEp);
            IPAddress multicastaddress = IPAddress.Parse(dirGrupo);
            timer1.Start();
            client.JoinMulticastGroup(multicastaddress);
            

            while (!conectado)
            {
                Byte[] data = client.Receive(ref localEp);
                string v = Encoding.ASCII.GetString(data);
                Servidor s = JsonConvert.DeserializeObject<Servidor>(v);
                bool b = false;
                for(int i = 0; i < servidores.Count; i++)
                {
                    if (servidores.ElementAt(i).hostname.CompareTo(s.hostname) == 0)
                    {
                        b = true;
                        break;
                    }
                }
                if (!b)
                {
                    comboBox1.Items.Add(s.hostname);
                    servidores.Add(s);
                }
                
            }
        }

        private void ListenCliente()
        {

        }

        private void Listen()
        {
            string strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            IPAddress[] hostIPs = Dns.GetHostAddresses(strHostName);
            EPServidor = new IPEndPoint(hostIPs[2], 5000);
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server.Bind(EPServidor);
            Server.Listen(1);
            EnviarServidor = Server.Accept();
            MessageBox.Show("Cliente Conectado con Exito");
            conectado = true;
            if (Habla.IsAlive)
                Habla.Abort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Habla.IsAlive)
                return;
            Habla.Start();
            label2.Show();
            this.Refresh();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (Escucha.IsAlive)
                return;
            Escucha.Start();
            EscuchaTCP = new Thread(Listen);
            EscuchaTCP.Start();
            comboBox1.Show();
            button2.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Escucha.Abort();
            Habla.Abort();
            if(EscuchaTCP != null && EscuchaTCP.IsAlive)
                EscuchaTCP.Abort();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Show();
            textBox1.Show();
            label3.Show();
            comboBox1.Hide();
            if (Escucha.IsAlive)
                Escucha.Abort();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dirGrupo.CompareTo("230.0.0.0") == 0)
                dirGrupo = "230.0.4.20";
            else
                dirGrupo = "230.0.0.0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Debe elegir una partida para unirse");
                return;
            }
            string ip="";
            int puerto=0;
            for(int i = 0; i < servidores.Count; i++)
            {
                if (servidores.ElementAt(i).hostname.CompareTo(comboBox1.SelectedItem.ToString()) == 0)
                {
                    ip = servidores.ElementAt(i).ip;
                    puerto = servidores.ElementAt(i).puerto;
                    break;
                }
            }
            EPCliente = new IPEndPoint(IPAddress.Parse(ip), puerto);
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Client.Connect(EPCliente);
            conectado = true;
            if (Escucha.IsAlive)
                Escucha.Abort();
        }
    }
}