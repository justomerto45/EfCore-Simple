using EfCore_Easy_Wpf.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp;

namespace EfCore_Easy_Wpf.ViewModel
{
    public class AddOrEditViewModel : INotifyPropertyChanged
    {
        private string name;
        private bool isEditMode;
        private readonly AppDbContext dbContext;

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

        public bool IsEditMode
        {
            get { return isEditMode; }
            private set
            {
                isEditMode = value;
                OnPropertyChanged(nameof(IsEditMode));
            }
        }

        public Person Person { get; private set; }

        public RelayCommand<object> SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public AddOrEditViewModel()
        {
            dbContext = new AppDbContext();

            SaveCommand = new RelayCommand<object>(Save, CanSave);
            CancelCommand = new RelayCommand<object>(Cancel);
        }

        public void SetEditMode(Person person)
        {
            IsEditMode = true;
            Person = person;
            Name = person.Name;
        }

        private void Save(object parameter)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                if (!IsEditMode)
                {
                    Person = new Person { Name = Name };
                    dbContext.People.Add(Person);
                }
                else
                {
                    Person.Name = Name;
                    dbContext.Entry(Person).State = EntityState.Modified;
                }

                dbContext.SaveChanges();

                ((AddEditWindow)parameter).DialogResult = true;
            }
        }

        private bool CanSave(object parameter)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void Cancel(object parameter)
        {
            ((AddEditWindow)parameter).Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
