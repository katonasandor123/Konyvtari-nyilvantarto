using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nyilvantarto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Konyv> KonyvVmiNev = new List<Konyv>();
        List<Kolcsonzes> KolcsonzesVmiNev = new List<Kolcsonzes>();
        List<Tag> TagVmiNev = new List<Tag>();

        public MainWindow()
        {
            InitializeComponent();
            KonyvAdatokbeolvasasa("konyvek.txt");
            KolcsonzesAdatokbeolvasasa("kolcsonzesek.txt");
            TagAdatokbeolvasasa("tagok.txt");
        }

        public void KonyvAdatokbeolvasasa(string nev)
        {
            KonyvekLista.ItemsSource = KonyvVmiNev;
            foreach (var item in File.ReadAllLines(nev))
            {
                KonyvVmiNev.Add(new Konyv(item));
            }
        }
        public void KolcsonzesAdatokbeolvasasa(string nev)
        {
            KolcsonzesekLista.ItemsSource = KolcsonzesVmiNev;
            foreach (var item in File.ReadAllLines(nev))
            {
                KolcsonzesVmiNev.Add(new Kolcsonzes(item));
            }
        }
        public void TagAdatokbeolvasasa(string nev)
        {
            TagokLista.ItemsSource = TagVmiNev;
            foreach (var item in File.ReadAllLines(nev))
            {
                TagVmiNev.Add(new Tag(item));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Én megmondtam!");
        }

        private void keresoKonyvLista_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (keresoKonyvLista.Text == "")
            {
                KonyvekLista.ItemsSource = KonyvVmiNev;
            }
            else
            {
                var keres1 = KonyvVmiNev.Where(x => x.Szerzo.StartsWith(keresoKonyvLista.Text) || x.Cim.StartsWith(keresoKonyvLista.Text) || x.KiadasEv.StartsWith(keresoKonyvLista.Text) || x.Kiado.StartsWith(keresoKonyvLista.Text));
                KonyvekLista.ItemsSource = keres1;
            }
        }

        private void hoz1_Click(object sender, RoutedEventArgs e)
        {
            var hozzaadas1 = KonyvVmiNev.Where(x => x.Szerzo.StartsWith(keresoKonyvLista.Text) || x.Cim.StartsWith(keresoKonyvLista.Text) || x.KiadasEv.StartsWith(keresoKonyvLista.Text) || x.Kiado.StartsWith(keresoKonyvLista.Text));
            KonyvekLista.ItemsSource = hozzaadas1;
            Konyv Uj = new Konyv("");
            Uj.ID = KonyvVmiNev.Count + 1;
            Uj.Szerzo = szer1.Text;
            Uj.Cim = cim1.Text;
            Uj.KiadasEv = kiad1.Text;
            Uj.Kiado = kiado1.Text;
            Uj.Kolcsonzes = true;
            KonyvVmiNev.Add(Uj);
            KonyvekLista.ItemsSource = KonyvVmiNev;
        }

        private void tor1_Click(object sender, RoutedEventArgs e)
        {
            KonyvekLista.ItemsSource = KonyvVmiNev;
            var torles1 = KonyvekLista;
            if (KonyvekLista.SelectedIndex >= 0)
            {
                KonyvVmiNev.RemoveAt(torles1.SelectedIndex);
                torles1.Items.Refresh();
            }
        }

        private void keresoKolcsonzesekLista_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (keresoKolcsonzesekLista.Text == "")
            {
                KolcsonzesekLista.ItemsSource = KolcsonzesVmiNev;
            }
            else
            {
                var keres2 = KolcsonzesVmiNev.Where(x => x.KolcsID.StartsWith(keresoKolcsonzesekLista.Text) || x.KolcsKonyvID.StartsWith(keresoKolcsonzesekLista.Text) || x.KolcsOlvasoID.StartsWith(keresoKolcsonzesekLista.Text) || x.Kolcs1.StartsWith(keresoKolcsonzesekLista.Text) || x.Kolcs2.StartsWith(keresoKolcsonzesekLista.Text));
                KonyvekLista.ItemsSource = keres2;
            }
        }

        private void hoz2_Click(object sender, RoutedEventArgs e)
        {
            var hozzadas2 = KolcsonzesVmiNev.Where(x => x.KolcsID.StartsWith(keresoKolcsonzesekLista.Text) || x.KolcsKonyvID.StartsWith(keresoKolcsonzesekLista.Text) || x.KolcsOlvasoID.StartsWith(keresoKolcsonzesekLista.Text) || x.Kolcs1.StartsWith(keresoKolcsonzesekLista.Text) || x.Kolcs2.StartsWith(keresoKolcsonzesekLista.Text));
            KolcsonzesekLista.ItemsSource = hozzadas2;
            Kolcsonzes Uj2 = new Kolcsonzes("a");
            try
            {
                Uj2.KolcsID = Convert.ToInt32(id2.Text);
                Uj2.KolcsKonyvID = Convert.ToInt32(kid2.Text);
                Uj2.KolcsOlvasoID = oid2.Count + 1;
                Uj2.Kolcs1 = kk2.Text;
                Uj2.Kolcs2 = kv2.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Helytelen");

            }
            KolcsonzesVmiNev.Add(Uj2);
            KolcsonzesekLista.ItemsSource = KolcsonzesVmiNev;
        }

        private void tor2_Click(object sender, RoutedEventArgs e)
        {
            KolcsonzesekLista.ItemsSource = KolcsonzesVmiNev;
            var torles2 = KolcsonzesekLista;
            if (torles2.SelectedIndex >= 0)
            {
                KolcsonzesVmiNev.RemoveAt(torles2.SelectedIndex);
                torles2.Items.Refresh();
            }
        }

        private void keresoTagokLista_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (keresoTagokLista.Text == "")
            {
                TagokLista.ItemsSource = TagVmiNev;
            }
            else
            {
                var kereso3 = TagVmiNev.Where(x => x.TID.StartsWith(keresoTagokLista.Text) || x.Nev.StartsWith(keresoTagokLista.Text) || x.Datum.StartsWith(keresoTagokLista.Text));

                TagokLista.ItemsSource = kereso3;
            }
        }

        private void hoz3_Click(object sender, RoutedEventArgs e)
        {
            var hozzaadas3 = TagVmiNev.Where(x => x.TID.StartsWith(keresoTagokLista.Text) || x.Nev.StartsWith(keresoTagokLista.Text) || x.Datum.StartsWith(keresoTagokLista.Text));
            TagokLista.ItemsSource = hozzaadas3;
            Tag Uj3 = new Tag("");
            Uj3.TID = TagVmiNev.Count + 1;
            Uj3.Nev = nev3.Text;
            Uj3.Datum = dat3.Text;
            TagVmiNev.Add(Uj3);
            TagokLista.ItemsSource = TagVmiNev;
        }

        private void tor3_Click(object sender, RoutedEventArgs e)
        {
            TagokLista.ItemsSource = TagVmiNev;
            var torles3 = TagokLista;
            if (torles3.SelectedIndex >= 0)
            {
                TagVmiNev.RemoveAt(torles3.SelectedIndex);
                torles3.Items.Refresh();
            }
        }
    }
}
