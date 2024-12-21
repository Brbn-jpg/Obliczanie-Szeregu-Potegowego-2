using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;

namespace ProjektNr1_Kuźnicki_61961
{
    public partial class LaboratoriumNr1 : Form
    {
        const int Margines = 10;
        const int PromieńOA = 5; //OA: Obiekt Animowany

        const double DGprzedziałuX = double.MinValue;
        const double GGprzedziałuX = double.MaxValue;
        // deklaracje zmiennych dla przechowania pobranych wartości danych we.......
        //float h; // przyrost zmian wartości zmiennej niezależnej X w przedziale
        int LiczbaPrzedziałówH;
        Graphics Rysownica;
        Pen PióroXY = new Pen(Color.Blue, 0.5F);
        Pen JKRamka = new Pen(Color.Red);
        Pen PióroLiniiToru;
        double[,] TWS;
        int IndexPOA; // POA: Położenie Obiektu Animowanego
        int MaxIndexPOA;
        double Xd, Xg, h;
        static LaboratoriumNr1 UchwytFormularza;
        
        public LaboratoriumNr1()
        {
            InitializeComponent();
            UchwytFormularza = this;
            // utworzenie egzemplarza PióraLiniiToru
            PióroLiniiToru = new Pen(Color.Black, 1.5F);
            // ustawienie linii kropkowej
            PióroLiniiToru.DashStyle = DashStyle.Dot;
            // wstępne sformatowanie kontrolki PictureBox
            pb_rysownica.BackColor = Color.LightSeaGreen;
            pb_rysownica.BorderStyle = BorderStyle.Fixed3D;
            // utworzenie BitMapy i podpięcie jej do PictureBox
            pb_rysownica.Image = new Bitmap(pb_rysownica.Width, pb_rysownica.Height);
            // utworzenie egzemplarza powierzchni graficznej na BitMapie
            Rysownica = Graphics.FromImage(pb_rysownica.Image);
        }

        private void LaboratoriumNr1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // utworzenie okna dialogowego dla spytania Użytkownika
            DialogResult OknoMessage = MessageBox.Show("Czy chcesz zamknąć bieżący formularz i przejść do formularza głównego? (Utracisz niezapisane dane w bieżącym formularzu)", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // sprawdzenie odpowiedzi Użytkownika programu
            if (OknoMessage == DialogResult.Yes)
            {// odszukanie formularza głównego w kolekcji OpenForms
                foreach (Form Formularz in Application.OpenForms)
                    // czy to jest formularz główny
                    if (Formularz.Name == "KokpitProjektuNr1")
                    {// ukrycie bieżącego formularza
                        MessageBox.Show("Samoocena sprawdzianu Nr1 = 5, gdyz zostaly zrealizowane 4 z 4 zadań. Jakub Kuźnicki: 61961");
                        this.Hide();
                        // odsłonięcie znalezionego egzemplarza formularza głównego
                        Formularz.Show();
                        // zakończenie obsługi zdarzenia FormClosing
                        return;
                    }
                // jeżeli znajdziemy się tutaj, to znaczy, że "ktoś" usunął egzemplarz formularza głównego z kolekcji OpenForms
                MessageBox.Show("AWARIA: 'ktoś' usunął egzemplarz formularza głównego i program nie może działać dalej!!!", this.Text);
                // zamknięcie wszystkich formularzy i wątków (procesów równoległych)
                Application.ExitThread();
            }
            else
                //skasowanie zdarzenia FormClosing
                e.Cancel = true;
        }

        private void pb_rysownica_Paint(object sender, PaintEventArgs e)
        {
            
            // dodatkowe zabezpieczenie gdy TWS jest puste
            if (TWS is null)
                return;
            // "wymazanie" obrazu animacji
            Rysownica.Clear(Color.LightSeaGreen);
            // wykreślenie osi Y
            Rysownica.DrawLine(PióroXY,
                PrzeliczanieWspółrzędnych.WspX(0),
                PrzeliczanieWspółrzędnych.WspY(PrzeliczanieWspółrzędnych.Ymin),
                PrzeliczanieWspółrzędnych.WspX(0),
                PrzeliczanieWspółrzędnych.WspY(PrzeliczanieWspółrzędnych.Ymax));
            // wykreślenie osi 
            Rysownica.DrawRectangle(JKRamka, 10, 10, pb_rysownica.Width-30, pb_rysownica.Height-30);
            Rysownica.DrawLine(PióroXY,
                PrzeliczanieWspółrzędnych.WspX(PrzeliczanieWspółrzędnych.Xmin),
                PrzeliczanieWspółrzędnych.WspY(0),
                PrzeliczanieWspółrzędnych.WspX(PrzeliczanieWspółrzędnych.Xmax),
                PrzeliczanieWspółrzędnych.WspY(0));
            // wykreślenie linii toru
            for (int j = 0; j < TWS.GetLength(0) - 1; j++)
                Rysownica.DrawLine(PióroLiniiToru,
                PrzeliczanieWspółrzędnych.WspX(TWS[j, 0]),
                PrzeliczanieWspółrzędnych.WspY(TWS[j, 1]),
                PrzeliczanieWspółrzędnych.WspX(TWS[j + 1, 0]),
                PrzeliczanieWspółrzędnych.WspY(TWS[j + 1, 1]));

            // wykreślenie OA w nowym położeniu określonym przez IndexPOA
            Rysownica.FillEllipse(Brushes.Yellow,
                PrzeliczanieWspółrzędnych.WspX(TWS[IndexPOA, 0]) - PromieńOA,
                PrzeliczanieWspółrzędnych.WspY(TWS[IndexPOA, 1]) - PromieńOA,
                2 * PromieńOA, 2 * PromieńOA);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // sprawdzenie, czy OA "doszedł" do prawej krawędzi powierzchni graficznej
            if (IndexPOA >= MaxIndexPOA)
                // "przedstawienie" OA na początku linii toru
                IndexPOA = 0;
            else
                IndexPOA++;
            // teraz musi nastąpić odrysowanie obrazu animacji
            pb_rysownica.Refresh();
        }
        // deklaracja klasy statycznej, która będzie udostępniała metody: WspX(...) i WspY(...)
        static class PrzeliczanieWspółrzędnych
        {
            // deklaracja zmiennych przechowujących wartości współczynników skali po osi X i osi Y oraz przesunięcia wzdłuż osi X i osi Y
            static double Sx, Sy;
            static double Dx, Dy;
            // deklaracja zmiennych opisujcych rozmiar powierzchni graficznej
            static int Xe_min, Xe_max, Ye_min, Ye_max;
            // deklaracja właściwości opisujących rozmiar powierzchni rzeczywistej
            static public double Xmin
            {
                get;
                private set;
            }
            static public double Xmax
            {
                get;
                private set;
            }
            static public double Ymin
            {
                get;
                private set;
            }
            static public double Ymax
            {
                get;
                private set;
            }
            // wyznaczenie rozmiarów i współczynników
            // deklaracja konstruktora klasy statycznej
            static PrzeliczanieWspółrzędnych()
            {// wyznaczenie rozmiaru powierzchni rzeczywistej
                Xmin = UchwytFormularza.Xd;
                Xmax = UchwytFormularza.Xg;
                Ymin = Class1.MinSx(UchwytFormularza.TWS);
                Ymax = Class1.MaxSx(UchwytFormularza.TWS);
                //wyznaczenie rozmiaru powierzchni graficznej na formularzu (kontrolce PictureBox)
                Xe_min = Margines;
                Xe_max = UchwytFormularza.pb_rysownica.Width - (Margines + Margines);
                Ye_min = Margines;
                Ye_max = UchwytFormularza.pb_rysownica.Height - (Margines + Margines);
                // wyznaczenie współczynników skali: Sx i Sy
                Sx = (Xe_max - Xe_min) / (Xmax - Xmin);
                Sy = (Ye_max - Ye_min) / (Ymax - Ymin);
                // obliczenie przesunięć: Dx i Dy
                Dx = Xe_min - Xmin * Sx;
                Dy = Ye_min - Ymin * Sy;
            } // koniec deklaracji konstruktora
            // deklaracja publicznych metod: WspX i WspY
            public static int WspX(double x)
            {
                return (int)(Sx * x + Dx);
            }
            static public int WspY(double y)
            {
                return (int)(Sy * y + Dy);
            }
        } // koniec deklaracji klasy statycznej PrzeliczanieWspółrzędnych

        // deklaracje metod pomocniczych
        bool PobierzDaneWejściowe (out double Xd, out double Xg, out double h)
        { // pomocnicze ustalenie tzw. wartości technicznych dla parametrów wyjściowych
            Xd = Xg = h = 0.0F;
            // pobranie Xd
            if (!double.TryParse(txt_Xd.Text, out Xd))
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(txt_Xd, "ERROR: w podanym zapisie wartości dla Xd wystąpił niedozwolony znak");
                // przerwanie pobierania danych
                return false;
            }
            // sprawdzenie, czy Xd należy do przedziału zbieżności szeregu
            if ((Xd < DGprzedziałuX) || (Xd > GGprzedziałuX))
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(txt_Xd, "ERROR: podana wartość dla Xd nie należy do przedziału zbieżności szeregu");
                // przerwanie pobierania danych
                return false;
            }
            // pobranie Xg
            if (!double.TryParse(txt_Xg.Text, out Xg))
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(txt_Xg, "ERROR: w podanym zapisie wartości dla Xg wystąpił niedozwolony znak");
                // przerwanie pobierania danych
                return false;
            }
            // sprawdzenie, czy Xg należy do przedziału zbieżności szeregu
            if ((Xg < DGprzedziałuX) || (Xg > GGprzedziałuX))
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(txt_Xg, "ERROR: podana wartość dla Xg nie należy do przedziału zbieżności szeregu");
                // przerwanie pobierania danych
                return false;
            }
            // sprawdzenie tzw. warunku wejściowego (logicznego) nakładanego na granice przedziału zmiana wartości zmiennej X
            if (Xd > Xg)
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(txt_Xg, "ERROR: nie jest spełniony tzw. warunek wejściowy nałożony na granice przedziału zmiana wartości zmiennej X");
                // przerwanie pobierania danych
                return false;
            }
            // pobranie przyrostu 'h'
            if (!double.TryParse(txt_H.Text, out h))
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(txt_H, "ERROR: w zapisie wartości przyrostu 'h' wystąpił niedozwolony znak");
                // przerwanie pobierania danych
                return false;
            }
            // sprawdzenie warunku wejściowego nałożonego na 'h': 0 < h < 1.0
            if ((h < 0.0F) || (h > 1.0F))
            {// był błąd, to musimy go sygnalizować
                errorProvider1.SetError(txt_H, "ERROR: podana wartość przyrostu 'h' nie spełnia warunku wejściowego: 0 < h < 1.0");
                // przerwanie pobierania danych
                return false;
            }

            // zwrotne przekazanie wartości 'true' gdy nie było błędów
            return true;
        }
        void TablicowanieWartościSzeregu(double[,] TWS, double Xd, double Xg, double h)
        {
            // deklaracje pomocnicze
            double X;
            int i; // licznik podprzedziałów 'h'
            for (X = Xd, i = 0; i < TWS.GetLength(0); X = Xd + i *h, i++) // X => ............
            {
                // wpisanie do i-tego wiersz TWS wartości X oraz Wartości szeregu (X) 
                TWS[i, 0] = X;
                TWS[i, 1] = ObliczenieWartościSzeregu(X);
            }
        }

        private void kolorLiniiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog JKPaletaKolorow = new ColorDialog();
            JKPaletaKolorow.Color = JKRamka.Color;
            if (JKPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                JKRamka.Color = JKPaletaKolorow.Color;
                JKPaletaKolorow.Dispose();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            JKRamka.Width = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            JKRamka.Width = 2;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            JKRamka.Width = 3;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            JKRamka.Width = 4;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            JKRamka.Width = 5;
        }

        private void liniaKreskowadashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKRamka.DashStyle = DashStyle.Dash;
        }

        private void liniaKreskowokropkowadashdotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKRamka.DashStyle = DashStyle.DashDot;
        }

        private void liniaKreskowokropkowakropkowadashdotdotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKRamka.DashStyle = DashStyle.DashDotDot;
        }

        private void liniaKropkowadotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKRamka.DashStyle = DashStyle.Dot;
        }

        private void liniaCiaglasolidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKRamka.DashStyle = DashStyle.Solid;
        }

        double ObliczenieWartościSzeregu(double x)
        {
            // deklaracje pomocnicze
            const double Eps = 0.000001F;
            ushort k;
            double w, S;
            // ustalenie początkowego stanu obliczeń
            k = 0;
            w = x;
            S = w;
            // iteracyjne obliczanie sumy wyrazów szeregu
            while (Math.Abs(w) > Eps)
            {// zwiększenie licznika wyrazów szeregu
                k++;
                // obliczenie wartości k-ego wyrazu szeregu
                w = w * ((-1.0F) * x * x) / (2 * k * (2 * k + 1));

                // obliczenie sumy k wyrazów szeregu
                S = S + w;
            }
            // zwrotne przekazanie wyniku obliczeń
            return S;
        }
        private void btn_animacja_Click(object sender, EventArgs e)
        {
            // zgaszenie kontrolki errorProvider
            errorProvider1.Dispose();
            // pobranie danych wejściowych z kontrolek formularza
            if (!PobierzDaneWejściowe(out Xd, out Xg, out h))
                // bezwarunkowe zakończenie obsługi zdarzenia Click
                return;
            // wyznaczenie liczby podprzedziałów 'h' w przedziale: [Xd, Xg]
            LiczbaPrzedziałówH = (int)((Xg - Xd) / h) + 1;
            // utworzenie egzemplarza tablicy TWS
            TWS = new double[LiczbaPrzedziałówH, 2];
            // tablicowanie wartości szeregu
            TablicowanieWartościSzeregu(TWS, Xd, Xg, h);
            // ustalenie op==początkowego położenia OA (Obiekt Animacji)
            IndexPOA = 0;
            // ustalenie końcowego położenia OA (Obiekt Animacji)
            MaxIndexPOA = TWS.GetLength(0) -1;
            timer1.Enabled = true;
            // ustawienie stanu braku aktywności przycisku btnAnimacja
            btn_animacja.Enabled = false;
        }
    }
}
