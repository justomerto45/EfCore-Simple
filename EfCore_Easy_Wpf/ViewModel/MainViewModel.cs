using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using EfCore_Easy_Wpf.Model;
using Microsoft.EntityFrameworkCore;
using WpfApp;
using EfCore_Easy_Wpf.View;

namespace EfCore_Easy_Wpf.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly AppDbContext dbContext;

        private ObservableCollection<Person> people;
        private Person selectedPerson;

        public ObservableCollection<Person> People
        {
            get { return people; }
            set
            {
                people = value;
                OnPropertyChanged(nameof(People));
            }
        }

        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
            }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public MainViewModel()
        {
            dbContext = new AppDbContext();

            AddCommand = new RelayCommand<object>(Add, CanAdd);
            EditCommand = new RelayCommand<object>(Edit, CanEdit);
            DeleteCommand = new RelayCommand<object>(Delete, CanDelete);

            LoadPeople();
        }

        private void LoadPeople()
        {
            People = new ObservableCollection<Person>(dbContext.People);
        }

        private bool CanAdd(object parameter)
        {
            return true; // Der "Add"-Befehl kann immer ausgeführt werden
        }

        private void Add(object parameter)
        {
            AddWindow addWindow = new AddWindow();
            var addViewModel = new AddViewModel();

            addWindow.DataContext = addViewModel;

            bool? result = addWindow.ShowDialog();

            if (result == true) // Speichern
            {
                var newPerson = addViewModel.Person;
                dbContext.People.Add(newPerson);
                dbContext.SaveChanges();

                LoadPeople(); // Lädt die aktualisierten Personen aus der Datenbank
            }
        }

        private bool CanEdit(object parameter)
        {
            return SelectedPerson != null; // Der "Edit"-Befehl kann nur ausgeführt werden, wenn eine Person ausgewählt ist
        }

        private void Edit(object parameter)
        {
            EditWindow editWindow = new EditWindow();
            var editViewModel = new EditViewModel(SelectedPerson);

            editWindow.DataContext = editViewModel;

            bool? result = editWindow.ShowDialog();

            if (result == true) // Speichern
            {
                dbContext.SaveChanges(); // Speichert die Änderungen in der Datenbank

                LoadPeople(); // Lädt die aktualisierten Personen aus der Datenbank
            }
        }

        private bool CanDelete(object parameter)
        {
            return SelectedPerson != null; // Der "Delete"-Befehl kann nur ausgeführt werden, wenn eine Person ausgewählt ist
        }

        private void Delete(object parameter)
        {
            var result = MessageBox.Show("Möchten Sie diese Person wirklich löschen?", "Löschen", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                int deletedPersonId = SelectedPerson.Id; // Speichern der ID der zu löschenden Person
                dbContext.People.Remove(SelectedPerson); // Entfernt die ausgewählte Person aus der Datenbank
                dbContext.SaveChanges(); // Speichert die Änderungen in der Datenbank

                LoadPeople(); // Lädt die aktualisierten Personen aus der Datenbank

                // Aktualisierung der IDs für die verbleibenden Personen
                foreach (var person in People)
                {
                    if (person.Id > deletedPersonId)
                    {
                        person.Id--; // Reduziert die ID um 1
                        dbContext.Entry(person).State = EntityState.Modified;
                    }
                }

                dbContext.SaveChanges(); // Speichert die Änderungen in der Datenbank erneut
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
