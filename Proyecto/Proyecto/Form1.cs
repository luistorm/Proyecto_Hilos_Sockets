using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyecto
{
   
    public partial class Form1 : Form
    {
        private List<PictureBox> Fichas;
        private int[][] Tablero;
        public Form1()
        {
            InitializeComponent();

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
    }
}
