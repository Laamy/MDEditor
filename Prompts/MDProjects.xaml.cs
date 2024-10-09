using MDEditor.Prompts;

using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MDEditor
{
    public partial class MDProjects : Window
    {
        MainWindow Main;
        public MDProjects(MainWindow main)
        {
            InitializeComponent();

            Main = main;
        }

        protected override void OnClosed(EventArgs e)
        {
            Main.IsEnabled = true;

            base.OnClosed(e);
        }

        private void NewProjectBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            NewProjectBorder.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50)); // Change to a lighter color
        }
        
        private void NewProjectBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            NewProjectBorder.Background = new SolidColorBrush(Color.FromRgb(32, 32, 32)); // Revert to original color
        }
        
        private void LoadProjectBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            LoadProjectBorder.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50)); // Change to a lighter color
        }
        
        private void LoadProjectBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            LoadProjectBorder.Background = new SolidColorBrush(Color.FromRgb(32, 32, 32)); // Revert to original color
        }

        private void LoadProjectBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void NewProjectBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MDCreateNew prompt = new MDCreateNew(Main);
            prompt.Show();

            Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MaximizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
