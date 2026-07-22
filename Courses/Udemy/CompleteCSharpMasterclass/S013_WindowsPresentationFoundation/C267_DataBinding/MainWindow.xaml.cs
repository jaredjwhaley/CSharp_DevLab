using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using C267_DataBinding.Data;

/// <summary>
/// URL: https://github.com/tutorialseu/csharp-masterclass-wpf-data-binding
/// <\summary>
namespace C267_DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person person = new Person
        {
            Name = "John Doe",
            Age = 30
        };
        public MainWindow()
        {
            InitializeComponent();

            // The DataContext property is used to set the data context for the entire window.
            // This means that any data binding in the window will use this object as its source.
            this.DataContext = person;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string personData = $"{person.Name} is {person.Age} years old.";
            MessageBox.Show(personData);
        }
    }
}