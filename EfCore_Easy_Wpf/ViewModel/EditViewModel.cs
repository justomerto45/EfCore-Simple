using EfCore_Easy_Wpf.Model;
using EfCore_Easy_Wpf.View;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows.Input;
using WpfApp;

namespace EfCore_Easy_Wpf.ViewModel
{
    public class EditViewModel : INotifyPropertyChanged
    {
        private string name;
        private readonly AppDbContext dbContext;
        private Person selectedPerson;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public RelayCommand<object> SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public Person Person { get; private set; }

        public EditViewModel(Person person)
        {
            dbContext = new AppDbContext();
            selectedPerson = person;

            Name = selectedPerson.Name;

            SaveCommand = new RelayCommand<object>(Save, CanSave);
            CancelCommand = new RelayCommand<object>(Cancel);
        }

        private void Save(object parameter)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                selectedPerson.Name = Name;
                dbContext.Entry(selectedPerson).State = EntityState.Modified;
                dbContext.SaveChanges();

                ((EditWindow)parameter).DialogResult = true;
            }
        }

        private bool CanSave(object parameter)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void Cancel(object parameter)
        {
            ((EditWindow)parameter).Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
