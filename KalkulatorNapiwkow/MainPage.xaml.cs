namespace KalkulatorNapiwkow
{
    public partial class MainPage : ContentPage
    {
        int procent;
        double kwota;
        int liczbaOsob;


        public MainPage()
        {
            InitializeComponent();
        }

        private void OnObliczBtnClicked(object? sender, EventArgs e)
        {
            if(double.TryParse(Kwota.Text, out kwota) && kwota>0)
            {
                procent = (int)Procent.Value;
                liczbaOsob = (int)LiczbaOsob.Value;

                double kwotaNapiwku = kwota * procent / 100;
                KwotaNapiwku.TextColor = Colors.Black;
                KwotaNapiwku.Text = "Kwota napiwku: " + kwotaNapiwku.ToString();
                double suma = kwota + kwotaNapiwku;
                SumaDoZaplaty.Text = "Suma do zapłaty: " + suma.ToString();
                double kwotaNaOsobe = suma / liczbaOsob;
                KwotaNaOsobe.Text = "Kwota na osobę: " + kwotaNaOsobe.ToString();
            }
            else
            {
                KwotaNapiwku.TextColor = Colors.Red;
                KwotaNapiwku.Text = "Nie prawidłowa wartość kwoty.";
                KwotaNaOsobe.Text = "";
                SumaDoZaplaty.Text = "";
            }
            
        }

        private void OnWyczyscBtnClicked(object? sender, EventArgs e) {
            Procent.Value = 0;
            Kwota.Text = "";
            LiczbaOsobLabel.Text = "Liczba osób: 1";
            ProcentLabel.Text = "Procent napiwku (0%-30%)";
            LiczbaOsob.Value = 1;

            KwotaNaOsobe.Text = "";
            SumaDoZaplaty.Text = "";
            KwotaNapiwku.Text = "";
        }

        private void OnLiczbaOsobChanged(object? sender, EventArgs e) { 
            LiczbaOsobLabel.Text = "Liczba osób: "+LiczbaOsob.Value.ToString();
        }
        private void OnProcentChanged(object? sender, EventArgs e)
        {
            int procentValue= (int)Procent.Value;
            ProcentLabel.Text= "Procent napiwku (0%-30%): "+procentValue.ToString();
        }
    }
}
