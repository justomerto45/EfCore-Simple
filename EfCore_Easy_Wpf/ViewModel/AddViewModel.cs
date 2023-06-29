using EfCore_Easy_Wpf.Model;
using EfCore_Easy_Wpf.View;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows.Input;
using WpfApp;

namespace EfCore_Easy_Wpf.ViewModel
{
    public class AddViewModel : INotifyPropertyChanged
    {
        private string name;
        private readonly AppDbContext dbContext;
        public Person Person { get; private set; }

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

        public AddViewModel()
        {
            dbContext = new AppDbContext();

            SaveCommand = new RelayCommand<object>(Save, CanSave);
            CancelCommand = new RelayCommand<object>(Cancel);
        }

        private void Save(object parameter)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var person = new Person { Name = Name };
                dbContext.People.Add(person);
                dbContext.SaveChanges();

                ((AddWindow)parameter).DialogResult = true;
            }
        }

        private bool CanSave(object parameter)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void Cancel(object parameter)
        {
            ((AddWindow)parameter).Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
