using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjektNr1_Kuźnicki_61961.LaboratoriumNr1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;
using System.Security.AccessControl;

namespace ProjektNr1_Kuźnicki_61961
{
    public partial class ProjektNr1_Kuźnicki_61961 : Form
    {
        const float JKDGprzedzialuX = -3f;
        const float JKGGprzedzialuX = -1f;
        const int JKmargines = 10;
        const int JKpromienOA = 5;
        Graphics JKrysownica;
        float JKXd, JKXg, JKH;
        int JKLiczbaPrzedzialowH;
        private Color JKkolortła = Color.Tomato;
        Pen JKPioroXY = new Pen(Color.DarkOrange, 1);
        Pen JKPioroLiniiToru = new Pen(Color.Beige, 1.5F);
        int JKIndexPOA; //PopupEventArgs - polozenie obiektu animowanego
        int JKMaxIndexPOA;
        float[,] JKTWS;
        public int JKfigura = 0;
        SolidBrush JKpedzel = new SolidBrush(Color.Yellow);
        public float JKwielkoscObiektu = 2;
        static ProjektNr1_Kuźnicki_61961 JKUchwytFormularza;

        public ProjektNr1_Kuźnicki_61961()
        {
            InitializeComponent();
            JKUchwytFormularza = this;
            // utworzenie egzemplarza PióraLiniiToru
            JKPioroLiniiToru = new Pen(Color.Black, 1.5F);
            // ustawienie linii kropkowej
            JKPioroLiniiToru.DashStyle = DashStyle.Dot;
            // wstępne sformatowanie kontrolki PictureBox
            JKpb_rysownica.BackColor = Color.LightSeaGreen;
            JKpb_rysownica.BorderStyle = BorderStyle.Fixed3D;
            // utworzenie BitMapy i podpięcie jej do PictureBox
            JKpb_rysownica.Image = new Bitmap(JKpb_rysownica.Width, JKpb_rysownica.Height);
            JKPioroXY.Width = 1;
            JKPioroLiniiToru.Width = 1;
            // utworzenie egzemplarza powierzchni graficznej na BitMapie
            JKrysownica = Graphics.FromImage(JKpb_rysownica.Image);
            MessageBox.Show("Należy podać wartość Xd oraz Xg w przedziałach (-nieskończoność, -3) lub (-1, +nieskończoność)");
        }

        private void JKpb_rysownica_Paint(object sender, PaintEventArgs e)
        {
            // dodatkowe zabezpieczenie gdy TWS jest puste
            if (JKTWS is null)
                return;
            // "wymazanie" obrazu animacji
            JKrysownica.Clear(JKkolortła);
            // wykreślenie osi Y
            JKrysownica.DrawLine(JKPioroXY,
                PrzeliczanieWspółrzędnych.WspX(0),
                PrzeliczanieWspółrzędnych.WspY(PrzeliczanieWspółrzędnych.Ymin),
                PrzeliczanieWspółrzędnych.WspX(0),
                PrzeliczanieWspółrzędnych.WspY(PrzeliczanieWspółrzędnych.Ymax));
            // wykreślenie osi X
            JKrysownica.DrawLine(JKPioroXY,
                PrzeliczanieWspółrzędnych.WspX(PrzeliczanieWspółrzędnych.Xmin),
                PrzeliczanieWspółrzędnych.WspY(0),
                PrzeliczanieWspółrzędnych.WspX(PrzeliczanieWspółrzędnych.Xmax),
                PrzeliczanieWspółrzędnych.WspY(0));
            // wykreślenie linii toru
            for (int j = 0; j < JKTWS.GetLength(0) - 1; j++)
                JKrysownica.DrawLine(JKPioroLiniiToru,
                PrzeliczanieWspółrzędnych.WspX(JKTWS[j, 0]),
                PrzeliczanieWspółrzędnych.WspY(JKTWS[j, 1]),
                PrzeliczanieWspółrzędnych.WspX(JKTWS[j + 1, 0]),
                PrzeliczanieWspółrzędnych.WspY(JKTWS[j + 1, 1]));
            if (JKfigura == 1)
                JKrysownica.FillRectangle(JKpedzel,
                PrzeliczanieWspółrzędnych.WspX(JKTWS[JKIndexPOA, 0]) - JKpromienOA,
                PrzeliczanieWspółrzędnych.WspY(JKTWS[JKIndexPOA, 1]) - JKpromienOA,
                JKwielkoscObiektu * JKpromienOA, JKwielkoscObiektu * JKpromienOA);
            else if (JKfigura==2)
                JKrysownica.FillRectangle(JKpedzel,
                    PrzeliczanieWspółrzędnych.WspX(JKTWS[JKIndexPOA, 0]) - JKpromienOA,
                    PrzeliczanieWspółrzędnych.WspY(JKTWS[JKIndexPOA, 1]) - JKpromienOA,
                    JKwielkoscObiektu * JKpromienOA, JKwielkoscObiektu * JKpromienOA *2);
            else// wykreślenie OA w nowym położeniu określonym przez IndexPOA
                JKrysownica.FillEllipse(JKpedzel,
                    PrzeliczanieWspółrzędnych.WspX(JKTWS[JKIndexPOA, 0]) - JKpromienOA,
                    PrzeliczanieWspółrzędnych.WspY(JKTWS[JKIndexPOA, 1]) - JKpromienOA,
                    JKwielkoscObiektu * JKpromienOA, JKwielkoscObiektu * JKpromienOA);
        }


        private void ProjektNr1_Kuźnicki_61961_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Oknomessage = MessageBox.Show("Czy na pewno chcesz zamknąć ten formularz wrócić do kokpitu?"
                , this.Text, MessageBoxButtons.YesNo);
            //sprawdzenie podjetej decyzji przez uzytkownika programu
            if (Oknomessage == DialogResult.Yes)
            {//odszukanie formularza glownego Kokpit w OpenForms
                foreach (Form Formularz in Application.OpenForms)
                {//ukrycie biezacego formularza
                    this.Hide();
                    //odslniecie znalezionego formularza glownego
                    Formularz.Show();
                    //bezwarunkowe wyjscie z metody obslugi zdarzenia
                    return;
                }
                //gdy jestesmy tutaj, to jest to sytuacja awaryjna
                //wyswietlenie komunikatu o awarii
                MessageBox.Show("UWAGA: wystąpiła awaria w działaniu programu i program musi zostać zamknięty", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.ExitThread();
            }
            else
            {//skasowanie zdarzenia FormClosing
                e.Cancel = true;
            }
        }
        static class PrzeliczanieWspółrzędnych
        {
            // deklaracja zmiennych przechowujących wartości współczynników skali po osi X i osi Y oraz przesunięcia wzdłuż osi X i osi Y
            static float Sx, Sy;
            static float Dx, Dy;
            // deklaracja zmiennych opisujcych rozmiar powierzchni graficznej
            static int Xe_min, Xe_max, Ye_min, Ye_max;
            // deklaracja właściwości opisujących rozmiar powierzchni rzeczywistej
            static public float Xmin
            {
                get;
                private set;
            }
            static public float Xmax
            {
                get;
                private set;
            }
            static public float Ymin
            {
                get;
                private set;
            }
            static public float Ymax
            {
                get;
                private set;
            }
            // wyznaczenie rozmiarów i współczynników
            // deklaracja konstruktora klasy statycznej
            static PrzeliczanieWspółrzędnych()
            {// wyznaczenie rozmiaru powierzchni rzeczywistej
                Xmin = JKUchwytFormularza.JKXd;
                Xmax = JKUchwytFormularza.JKXg;
                Ymin = EkstremumSzeregu.MinSx(JKUchwytFormularza.JKTWS);
                Ymax = EkstremumSzeregu.MaxSx(JKUchwytFormularza.JKTWS);
                //wyznaczenie rozmiaru powierzchni graficznej na formularzu (kontrolce PictureBox)
                Xe_min = JKmargines;
                Xe_max = JKUchwytFormularza.JKpb_rysownica.Width - (JKmargines + JKmargines);
                Ye_min = JKmargines;
                Ye_max = JKUchwytFormularza.JKpb_rysownica.Height - (JKmargines + JKmargines);
                // wyznaczenie współczynników skali: Sx i Sy
                Sx = (Xe_max - Xe_min) / (Xmax - Xmin);
                Sy = (Ye_max - Ye_min) / (Ymax - Ymin);
                // obliczenie przesunięć: Dx i Dy
                Dx = Xe_min - Xmin * Sx;
                Dy = Ye_min - Ymin * Sy;
            } // koniec deklaracji konstruktora
            // deklaracja publicznych metod: WspX i WspY
            public static int WspX(float x)
            {
                return (int)(Sx * x + Dx);
            }
            static public int WspY(float y)
            {
                return (int)(Sy * y + Dy);
            }
        } // koniec deklaracji klasy statycznej PrzeliczanieWspółrzędnych
        bool JKPobierzDaneWejściowe(out float JKXd, out float JKXg, out float JKH)
        { // pomocnicze ustalenie tzw. wartości technicznych dla parametrów wyjściowych
            JKXd = JKXg = JKH = 0.0F;
            // pobranie Xd
            if (!float.TryParse(JKtxt_Xd.Text, out JKXd))
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(JKtxt_Xd, "ERROR: w podanym zapisie wartości dla Xd wystąpił niedozwolony znak");
                // przerwanie pobierania danych
                return false;
            }
            /*
            // sprawdzenie, czy Xd należy do przedziału zbieżności szeregu
            if ((JKXd <= JKDGprzedzialuX) || (JKXd >= JKGGprzedzialuX))
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(JKtxt_Xd, "ERROR: podana wartość dla Xd nie należy do przedziału zbieżności szeregu");
                // przerwanie pobierania danych
                return false;
            }
            */
            if (JKXd >= JKDGprzedzialuX && JKXd <= JKGGprzedzialuX)
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(JKtxt_Xd, "ERROR: podana wartość dla Xd nie należy do przedziału zbieżności szeregu");
                // przerwanie pobierania danych
                return false;
            }
            // pobranie Xg
            if (!float.TryParse(JKtxt_Xg.Text, out JKXg))
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(JKtxt_Xg, "ERROR: w podanym zapisie wartości dla Xg wystąpił niedozwolony znak");
                // przerwanie pobierania danych
                return false;
            }

            if ((JKXg >= JKDGprzedzialuX && JKXg <= JKGGprzedzialuX))
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(JKtxt_Xg, "ERROR: podana wartość dla Xg nie należy do przedziału zbieżności szeregu");
                // przerwanie pobierania danych
                return false;
            }

            if ((JKXd < -3 && JKXg > -1) || (JKXd > -1 && JKXg < -3))
            {
                // był błąd, to musimy go sygnalizować
                errorProvider1.SetError(JKtxt_Xg, "ERROR: podana wartość dla Xg nie należy do przedziału zbieżności szeregu");
                // przerwanie pobierania danych
                return false;
            }

            // sprawdzenie tzw. warunku wejściowego (logicznego) nakładanego na granice przedziału zmiana wartości zmiennej X
            if (JKXd > JKXg)
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(JKtxt_Xg, "ERROR: nie jest spełniony tzw. warunek wejściowy nałożony na granice przedziału zmiana wartości zmiennej X");
                // przerwanie pobierania danych
                return false;
            }
            // pobranie przyrostu 'h'
            if (!float.TryParse(JKtxt_H.Text, out JKH))
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(JKtxt_H, "ERROR: w zapisie wartości przyrostu 'h' wystąpił niedozwolony znak");
                // przerwanie pobierania danych
                return false;
            }
            // sprawdzenie warunku wejściowego nałożonego na 'h': 0 < h < 1.0
            if ((JKH <= 0.0F) || (JKH >= 0.5F))
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(JKtxt_H, "ERROR: podana wartość przyrostu 'h' nie spełnia warunku wejściowego: 0 < h < 0.5");
                // przerwanie pobierania danych
                return false;
            }

            // zwrotne przekazanie wartości 'true' gdy nie było błędów
            return true;
        }

        private void JKbtn_animacja_Click(object sender, EventArgs e)
        {
            JKpb_szereg.Visible = false;
            JKpb_rysownica.Visible = true;
            // zgaszenie kontrolki errorProvider
            errorProvider1.Dispose();
            // pobranie danych wejściowych z kontrolek formularza
            if (!JKPobierzDaneWejściowe(out JKXd, out JKXg, out JKH))
                // bezwarunkowe zakończenie obsługi zdarzenia Click
                return;
            // wyznaczenie liczby podprzedziałów 'h' w przedziale: [Xd, Xg]
            JKLiczbaPrzedzialowH = (int)((JKXg - JKXd) / JKH) + 1;
            // utworzenie egzemplarza tablicy TWS
            JKTWS = new float[JKLiczbaPrzedzialowH, 3];
            // tablicowanie wartości szeregu
            JKTablicowanieWartościSzeregu(JKTWS, JKXd, JKXg, JKH);
            // ustalenie op==początkowego położenia OA (Obiekt Animacji)
            JKIndexPOA = 0;
            // ustalenie końcowego położenia OA (Obiekt Animacji)
            JKMaxIndexPOA = JKTWS.GetLength(0) - 1;
            timer1.Enabled = true;
            // ustawienie stanu braku aktywności przycisku btnAnimacja
            JKbtn_animacja.Enabled = false;
            JKpb_rysownica.Visible = true;
            JKbtn_WizualizacjaTabelaryczna.Enabled = true;
            JKdgvTablicowanieWartosciSzeregu.Visible = false;
            JKbtn_WizualizacjaGraficzna.Enabled = true;
            JKchtWykresSzeregu.Visible = false;

        }

        private void JKbtn_Reset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        void JKWpisanieWynikuDoKontrolkiDataGridView(float[,] JKTWS, DataGridView JKdgvTablicaWartosciSzeregu)
        {
            //wyczyszczenie kontrolki DataGdidView
            JKdgvTablicaWartosciSzeregu.Rows.Clear();
            //wpisywanie danych z tablicy TWS do kontrolki DataGridView
            for (int JKi = 0; JKi < JKTWS.GetLength(0); JKi++)
            {
                //dodajemy do kontrolki DataGridView nowy, pusty wiersz 
                JKdgvTablicaWartosciSzeregu.Rows.Add();
                //wpisanie danych z TWS do kolejnych komorek dodanego wiersza do kontrolki DGV 
                JKdgvTablicaWartosciSzeregu.Rows[JKi].Cells[0].Value = string.Format("{0:0.00}", JKTWS[JKi, 0]);
                JKdgvTablicaWartosciSzeregu.Rows[JKi].Cells[1].Value = string.Format("{0:0.00}", JKTWS[JKi, 1]);
                JKdgvTablicaWartosciSzeregu.Rows[JKi].Cells[2].Value = string.Format("{0}", (ushort)JKTWS[JKi, 2]);
            }
        }

        private void JKbtn_WizualizacjaTabelaryczna_Click(object sender, EventArgs e)
        {
            /*
            float JKXd, JKXg, JKH;
            if (!JKPobierzDaneWejściowe(out JKXd, out JKXg, out JKH))
            {
                return;
            }
            if (JKTWS is null)
            {
                JKTablicowanieWartościSzeregu(JKTWS, JKXd, JKXg, JKH);
            }
            JKWpisanieWynikuDoKontrolkiDataGridView(JKTWS, JKdgvTablicowanieWartosciSzeregu);
            JKbtn_WizualizacjaGraficzna.Enabled = true;
            JKdgvTablicowanieWartosciSzeregu.Visible = true;
            */
            // "zgaszenie" kontrolki errorProvider
            JKpb_szereg.Visible = false;
            errorProvider1.Dispose();
            // obranie danych wejściowych
            if (!JKPobierzDaneWejściowe(out JKXd, out JKXg, out JKH))
                // przerwanie obsługi zdarzenia Click, gdyż w danych wejściowych wykryto błąd
                return;
            // określenie liczby przedziałow o szerokości 'h' w przedziale: [Xd, Xg]
            JKLiczbaPrzedzialowH = (int)((JKXg - JKXd) / JKH) + 1;
            // utworzenie egzemplarza tablicy TWS
            JKTWS = new float[JKLiczbaPrzedzialowH, 3];
            // stablicowanie szeregu
            JKTablicowanieWartościSzeregu(JKTWS, JKXd, JKXg, JKH);

            // Stablicowanie szeregu
            // sprawdzenie, czy został już utworzony egzemplarz tablicy TWS i szereg został stablicowany
            if (JKTWS is null)
                JKTablicowanieWartościSzeregu(JKTWS, JKXd, JKXg, JKH);
            // wpisanie wyników tablicowania wartości szeregu do kontrolki DataGridView
            JKWpisanieWynikuDoKontrolkiDataGridView(JKTWS, JKdgvTablicowanieWartosciSzeregu);
            // odsłonięcie kontrolki dgvTWS
            JKdgvTablicowanieWartosciSzeregu.Visible = true;
            JKpb_rysownica.Visible = false;
            JKbtn_animacja.Enabled = true;
            JKbtn_WizualizacjaTabelaryczna.Enabled = false;
            JKbtn_WizualizacjaGraficzna.Enabled = true;
            JKchtWykresSzeregu.Visible = false;
            // ustawienie stanu braku aktywności dla obsługiwanego przycisku poleceń
        }

        private void zmianaKoloruRysownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog JKPaletaKolorow = new ColorDialog();
            if (JKPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                JKkolortła = JKPaletaKolorow.Color;
                JKpb_rysownica.Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // sprawdzenie czy OA (Obiekt Animacji) "doszedł" do prawej krawędzi
            if (JKIndexPOA >= JKMaxIndexPOA)
                // cofnięcie oA do lewej krawędzi
                JKIndexPOA = 0;
            else
                JKIndexPOA++;
            string JKpredkoscAnimacji = JKtrackbar.Value.ToString();
            int trackbar = int.Parse(JKpredkoscAnimacji) - 4;
            timer1.Interval = 100 - trackbar * 10;

            JKpb_rysownica.Refresh();
        }

        float JKObliczenieWartościSzeregu(float X, out ushort k)
        {
            const float Eps = 0.0000001f;
            //ushort k;
            float w, S;
            // ustalenie początkowego stanu obliczeń

            //w = X;
            k = 0;
            //S = w;
            S = 0.0f;
            w = (-1) / (X + 2);

            while (Math.Abs(w) > Eps)
            {
                k++; // zwiększenie licznika wyrazów 
                // obliczenie k-tego wyrazu szeregu
                //w = w * (-1) * X / k;
                w = w * (-1) / (X + 2);
                S = S + w;
            }
            // zwrotne przekazanie wyniku obliczeń
            return S;  
        }

        private void JKbtn_WizualizacjaGraficzna_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if(!JKPobierzDaneWejściowe(out JKXd, out JKXg, out JKH))
                // przerwanie obsługi zdarzenia Click, gdyż w danych wejściowych wykryto błąd
                return;
            JKLiczbaPrzedzialowH = (int)((JKXg - JKXd) / JKH) + 1;
            // utworzenie egzemplarza tablicy TWS
            JKTWS = new float[JKLiczbaPrzedzialowH, 3];
            // stablicowanie szeregu
            JKTablicowanieWartościSzeregu(JKTWS, JKXd, JKXg, JKH);

            // Stablicowanie szeregu
            // sprawdzenie, czy został już utworzony egzemplarz tablicy TWS i szereg został stablicowany
            if (JKTWS is null)
                JKTablicowanieWartościSzeregu(JKTWS, JKXd, JKXg, JKH);
            // wpisanie wyników tablicowania wartości szeregu do kontrolki DataGridView
            JKWpisanieWynikuDoKontrolkiDataGridView(JKTWS, JKdgvTablicowanieWartosciSzeregu);
            WpisanieWynikowDoKontrolkiChart(JKTWS, JKchtWykresSzeregu);
            JKdgvTablicowanieWartosciSzeregu.Visible = false;
            JKchtWykresSzeregu.Visible = true;
            JKbtn_WizualizacjaGraficzna.Enabled = false;
            JKbtn_WizualizacjaTabelaryczna.Enabled = true;
            JKdgvTablicowanieWartosciSzeregu.Visible = false;
            JKpb_szereg.Visible = false;
        }

        private void restartProgramuiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void zmianaKoloruTłaAplikacjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //okno dialogowe z paleta kolorow
            ColorDialog PaletaKolorow = new ColorDialog();
            //zaznaczenie w PalecieKolorow bierzacego koloru formularza
            PaletaKolorow.Color = this.BackColor;
            //wyswietlenie palety kolorow i "odczytanie" wybranego koloru przez urzytkownika
            if (PaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                //dokonujemy zmiany koloru tla formularza
                this.BackColor = PaletaKolorow.Color;
                //zwolnienie egzemplarza PaletyKolorow
                PaletaKolorow.Dispose();
            }
        }

        private void zmianaKoloruLiniiToruToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //okno dialogowe z paleta kolorow
            ColorDialog PaletaKolorow = new ColorDialog();
            //zaznaczenie w PalecieKolorow bierzacego koloru formularza
            PaletaKolorow.Color = JKPioroLiniiToru.Color;
            //wyswietlenie palety kolorow i "odczytanie" wybranego koloru przez urzytkownika
            if (PaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                //dokonujemy zmiany koloru tla formularza
                JKPioroLiniiToru.Color = PaletaKolorow.Color;
                //zwolnienie egzemplarza PaletyKolorow
                PaletaKolorow.Dispose();
            }
        }

        private void liniaKreskowadashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioroLiniiToru.DashStyle = DashStyle.Dash;
        }

        private void liniaKreskowokropkowadashdotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioroLiniiToru.DashStyle = DashStyle.DashDot;
        }

        private void liniaKreskowokropkowakropkowadashdotdotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioroLiniiToru.DashStyle = DashStyle.DashDotDot;
        }

        private void liniaKropkowadotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioroLiniiToru.DashStyle = DashStyle.Dot;
        }

        private void liniaCiaglaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioroLiniiToru.DashStyle = DashStyle.Solid;
        }

        private void zmianaKoloruObiektuAnimowanegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog JKPaletaKolorow = new ColorDialog();
            if (JKPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                JKpedzel.Color = JKPaletaKolorow.Color;
            }
        }

        private void zapisBitMapyWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aby zapisać rysownice, należy wybrać miejsce docelowe zapisu", "Zapisywanie BitMapy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            using (SaveFileDialog PlikDoZapisu = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                if (PlikDoZapisu.ShowDialog() == DialogResult.OK)
                {
                    JKpb_rysownica.Image.Save(PlikDoZapisu.FileName);
                }
            }
        }

        private void odczytBitMapyZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aby odczytać plik z rysownicą, należy wybrać wcześniej zapisany plik", "Odczytywanie BitMapy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFileDialog PlikDoOdczytu = new OpenFileDialog();
            PlikDoOdczytu.ShowDialog();
            string sciezka = PlikDoOdczytu.FileName;
            try
            {
                JKpb_rysownica.Image = Image.FromFile(sciezka);
            }
            catch (ArgumentException) { }

            JKrysownica = Graphics.FromImage(JKpb_rysownica.Image);
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            JKPioroLiniiToru.Width = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            JKPioroLiniiToru.Width = 2;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            JKPioroLiniiToru.Width = 3;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            JKPioroLiniiToru.Width = 4;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            JKPioroLiniiToru.Width = 5;
        }

        private void kołoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKfigura = 0;
        }

        private void kwadratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKfigura = 1;
        }

        private void prostokatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKfigura = 2;
        }

        private void małyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKwielkoscObiektu = 2;
        }

        private void średniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKwielkoscObiektu = 3;
        }

        private void dużyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKwielkoscObiektu = 4;
        }

        void JKTablicowanieWartościSzeregu(float[,] JKTWS, float JKXd, float JKXg, float JKH)
        {
            // deklaracje pomocnicze
            float JKX;
            int JKi; // licznik podprzedziałów 'h'
            ushort Licznik = 0;
            for (JKX = JKXd, JKi = 0; JKi < JKTWS.GetLength(0); JKX = JKXd + JKi * JKH, JKi++) // X => ............
            {
                // wpisanie do i-tego wiersz TWS wartości X oraz Wartości szeregu (X) 
                JKTWS[JKi, 0] = JKX;
                JKTWS[JKi, 1] = JKObliczenieWartościSzeregu(JKX, out Licznik);
                JKTWS[JKi, 2] = Licznik;
            }
        }
        void WpisanieWynikowDoKontrolkiChart(float[,] TWS, Chart chtWykresSzeregu)
        {
            chtWykresSzeregu.BorderlineWidth = 2;
            chtWykresSzeregu.BorderlineColor = Color.Red;
            chtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.DashDotDot;
            try
            {
                chtWykresSzeregu.Titles.RemoveAt(0);
            }
            catch (Exception) { }
            chtWykresSzeregu.Titles.Add("Wykres zmian wartości szeregu S(X)");
            chtWykresSzeregu.Legends.FindByName("Legend1").Docking = Docking.Bottom;
            chtWykresSzeregu.BackColor = Color.LightSkyBlue;
            chtWykresSzeregu.ChartAreas[0].AxisX.Title = "Wartości X";
            chtWykresSzeregu.ChartAreas[0].AxisY.Title = "Wartości S(X)";
            chtWykresSzeregu.ChartAreas[0].AxisX.LabelStyle.Format = "{0:f2}";
            chtWykresSzeregu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:f2}";
            chtWykresSzeregu.Series.Clear();
            chtWykresSzeregu.Series.Add("Seria 0");
            chtWykresSzeregu.Series[0].XValueMember = "X";
            chtWykresSzeregu.Series[0].YValueMembers = "Y";
            chtWykresSzeregu.Series[0].IsVisibleInLegend = true;
            chtWykresSzeregu.Series[0].Name = "Wartość szeregu potęgowego S(X)";
            chtWykresSzeregu.Series[0].ChartType = SeriesChartType.Line;
            chtWykresSzeregu.Series[0].Color = Color.Black;
            chtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Solid;
            chtWykresSzeregu.Series[0].BorderWidth = 1;
            for (int i = 0; i < TWS.GetLength(0); i++)
                chtWykresSzeregu.Series[0].Points.AddXY(TWS[i, 0], TWS[i, 1]);
        }
    }
}
