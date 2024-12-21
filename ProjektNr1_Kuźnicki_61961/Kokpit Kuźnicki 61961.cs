using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr1_Kuźnicki_61961
{
    public partial class KokpitProjektuNr1 : Form
    {
        public KokpitProjektuNr1()
        {
            InitializeComponent();
        }

        private void btn_laboratoriumnr1_Click(object sender, EventArgs e)
        {//sprawdzenie czy juz byl utworzony egzemplarz formularza LaboratoriumNr1 
            foreach (Form Formularz in Application.OpenForms)
            //sprawdzenie, czy zostal znaleziony formularz LaboratoriumNr1
                if (Formularz.Name == "LaboratoriumNr1")
                {//ukrycie biezacego formularza 
                 this.Hide();
                 //odsloniecie formularza znalezionego
                 Formularz.Show();
                 //bezwarunkowe zakonczenie obslugi zdarzenia click
                 return;
                }
                /*gdy bedziemy tutaj, to poszuwiany formularz LaboratoriumNr1 nie zostal znaleziony
                a to oznacza, ze nalezy utworzyc egzemplarz i go odslonic*/
                LaboratoriumNr1 FormLaboratoriumNr1 = new LaboratoriumNr1();
                //ukrycie biezacego formularza
                this.Hide();
                //odlosniecie formularza FormLaboratoriumNr1
                FormLaboratoriumNr1.Show();
        }
        private void KokpitProjektuNr1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*utworzenie okna dialogowego i jego wyswietlenie dla spytania uzytkownika, czy na pewno
            chce zamknac formularz i zakonczyc dzialanie programu*/
            DialogResult Oknomessage = MessageBox.Show("Czy na pewno chcesz zamknąć formularz główny i zakończyć działanie programu?"
                ,this.Text, MessageBoxButtons.YesNo);
            //sprawdzenie podjetej decyzji przez uzytkownika programu
            if (Oknomessage == DialogResult.Yes)
            {//zamkniecie wszystkich formularzy i zakonczenie dzialania programu
                Application.ExitThread();
            }
            else
            {//skasowanie zdarzenia FormClosing
                e.Cancel = true;
            }
        }

        private void btn_indywidualnynr1_Click(object sender, EventArgs e)
        {
            //sprawdzenie czy juz byl utworzony egzemplarz formularza LaboratoriumNr1 
            foreach (Form Formularz in Application.OpenForms)
                //sprawdzenie, czy zostal znaleziony formularz LaboratoriumNr1
                if (Formularz.Name == "ProjektNr1_Kuźnicki_61961")
                {//ukrycie biezacego formularza 
                    this.Hide();
                    //odsloniecie formularza znalezionego
                    Formularz.Show();
                    //bezwarunkowe zakonczenie obslugi zdarzenia click
                    return;
                }
            /*gdy bedziemy tutaj, to poszuwiany formularz LaboratoriumNr1 nie zostal znaleziony
            a to oznacza, ze nalezy utworzyc egzemplarz i go odslonic*/
            ProjektNr1_Kuźnicki_61961 FormProjektNr1 = new ProjektNr1_Kuźnicki_61961();
            //ukrycie biezacego formularza
            this.Hide();
            //odlosniecie formularza FormLaboratoriumNr1
            FormProjektNr1.Show();
        }
    }
}
