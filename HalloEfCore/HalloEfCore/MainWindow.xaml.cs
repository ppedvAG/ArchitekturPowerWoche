using HalloEfCore.Data;
using HalloEfCore.Model;
using System;
using System.Collections.Generic;
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
using Microsoft.EntityFrameworkCore;
using HalloEfCore.Contracts;

namespace HalloEfCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        IRepository repo = new EfRepository();

        private void LoadMitarbeiter(object sender, RoutedEventArgs e)
        {
            myGrid.ItemsSource = repo.Query<Mitarbeiter>().Where(x => x.Name.StartsWith("F"))
                                                    .Include(x => x.Abteilungen)
                                                    .ToList();
        }

        private void CreateDemoData(object sender, RoutedEventArgs e)
        {
            var abt1 = new Abteilung() { Bezeichnung = "Holz" };
            var abt2 = new Abteilung() { Bezeichnung = "Steine" };

            for (int i = 0; i < 100; i++)
            {
                var m = new Mitarbeiter()
                {
                    Name = $"Fred #{i:000}",
                    GebDatum = DateTime.Now.AddDays(i * 17).AddYears(-40),
                    Beruf = "Macht dinge",
                };

                if (i % 2 == 0)
                    m.Abteilungen.Add(abt1);

                if (i % 3 == 0)
                    m.Abteilungen.Add(abt2);

                repo.Add(m);
            }
            repo.SaveAll();
        }

        private void NewMitarbeiter(object sender, RoutedEventArgs e)
        {
            var m = new Mitarbeiter()
            {
                Name = $"Frida",
                GebDatum = DateTime.Now.AddDays( 17).AddYears(-40),
                Beruf = "Ist die Cheffin",
            };

            repo.Add(m);
            repo.SaveAll();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            repo.SaveAll();
        }

        private void DeleteSelectedMitarbeiter(object sender, RoutedEventArgs e)
        {
            if(myGrid.SelectedItem  is Mitarbeiter m)
            {
                var dlg = MessageBox.Show($"Soll {m.Name} wirklich gelöscht werden?", 
                                          "",
                                          MessageBoxButton.YesNo);

                if(dlg == MessageBoxResult.Yes)
                {
                    repo.Delete(m);
                    repo.SaveAll();
                }
            }
        }
    }
}
