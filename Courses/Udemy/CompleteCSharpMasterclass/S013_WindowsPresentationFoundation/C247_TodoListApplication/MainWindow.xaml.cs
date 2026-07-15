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

namespace C247_TodoListApplication
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

        private void CreateTodoListItemButton_Click(object sender, RoutedEventArgs e)
        {
            string newTodoListItemText = TodoListItemTextBox.Text;
            if (!string.IsNullOrEmpty(newTodoListItemText))
            {
                // Create a new TextBlock for the todo list item
                TextBlock newTodoListItem = new TextBlock();
                // Set the text and styling for the new todo list item
                newTodoListItem.Text = newTodoListItemText.Trim();
                newTodoListItem.Margin = new Thickness(2);
                newTodoListItem.SetResourceReference(TextBlock.BackgroundProperty, SystemColors.ControlLightLightBrushKey);
                newTodoListItem.SetResourceReference(TextBlock.ForegroundProperty, SystemColors.ControlTextBrushKey);
                newTodoListItem.TextWrapping = TextWrapping.Wrap;
                // Add the new todo list item to the StackPanel
                TodoListStackPanel.Children.Add(newTodoListItem);
                // Clear the TextBox after adding the item
                TodoListItemTextBox.Clear();
            } else {
                // Show a message box if the TextBox is empty
                MessageBox.Show("Please enter a todo list item.");
            }
        }
    }
}