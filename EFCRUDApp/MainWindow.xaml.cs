using EFCRUDApp.Database.Entities;
using EFCRUDApp.Database.Repositories;

using System.Linq;
using System.Windows;

namespace EFCRUDApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeRepository _employeeRepo;
        Employee NewEmployee = new Employee();
        Employee selectedEmployee = new Employee();

        public MainWindow(EmployeeRepository empRepo)
        {
            this._employeeRepo = empRepo;
            InitializeComponent();

            GetEmployees();

            NewEmployeeGrid.DataContext = NewEmployee;
        }


        private void GetEmployees()
        {
            EmployeeDG.ItemsSource = _employeeRepo.GetAllEmployees().ToList();
        }

        private async void AddItem(object s, RoutedEventArgs e)
        {
            await _employeeRepo.CreateEmployeeAsync(NewEmployee);

            GetEmployees();

            NewEmployee = new Employee();
            NewEmployeeGrid.DataContext = NewEmployee;
        }

        private async void UpdateItem(object s, RoutedEventArgs e)
        {
            if (selectedEmployee.Id == 0)
            {
                MessageBox.Show("No item selected to update");
                return;
            }

            await _employeeRepo.UpdateEmployeeAsync(selectedEmployee);
            GetEmployees();
        }

        private void SelectEmployeeToEdit(object s, RoutedEventArgs e)
        {
            selectedEmployee = (s as FrameworkElement).DataContext as Employee;
            UpdateEmployeeGrid.DataContext = selectedEmployee;
        }

        private async void DeleteEmployee(object s, RoutedEventArgs e)
        {
            var EmployeeToDelete = (s as FrameworkElement).DataContext as Employee;
            await _employeeRepo.DeleteEmployeeAsync(EmployeeToDelete.Id);
            GetEmployees();
        }
    }
}
