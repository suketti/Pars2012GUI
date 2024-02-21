using System.Windows;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Pars2012GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Versenyzo> Versenyzok { get; set; } = new ObservableCollection<Versenyzo>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (string line in File.ReadAllLines("./Selejtezo2012.txt").Skip(1))
                {
                    Versenyzok.Add(new Versenyzo(line));
                }

                cbVersenyzo.ItemsSource = Versenyzok;
                cbVersenyzo.DisplayMemberPath = "Név";

               cbVersenyzo.SelectedIndex = Versenyzok.IndexOf(Versenyzok.Where(v => v.Név == "Pars Krisztián").FirstOrDefault() ?? throw new Exception("Hibás alapadatok"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Window_Loaded", MessageBoxButton.OK, MessageBoxImage.Error);   
            }
        }

        private void VersenyzoCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                Versenyzo selectedVersenyzo = (Versenyzo)cbVersenyzo.SelectedItem;
                LoadVersenyzoAdatai(selectedVersenyzo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem sikerult betolteni");
            }
        }

        private void LoadVersenyzoAdatai(Versenyzo versenyzo)
        {
            try
            {
                lblVersenyzoNev.Content = $"Név: {versenyzo.Név}";
                lblVersenyzoCsoport.Content = $"Csoport: {versenyzo.Csoport}";
                lblVersenyzoNemzet.Content = $"Nemzet: {versenyzo.Nemzet2}";
                lblVersenyzoNemzetKod.Content = $"Kód: {versenyzo.Kód}";
                lblVersenyzoSorozat.Content = $"Sorozat: {versenyzo.Sorozat}";
                lblVersenyzoEredmeny.Content = $"Eredmény: {versenyzo.Eredmény2()}";

                // Load Versenyzo Image
                imgVersenyzoZaszlo.Source = new BitmapImage(new Uri($"./Images/{versenyzo.Kód}.png", UriKind.Relative));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadVersenyzoAdatai", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}