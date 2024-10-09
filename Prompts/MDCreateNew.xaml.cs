using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

public class ProjectTemplate
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ProjectTemplate(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

namespace MDEditor.Prompts
{
    public partial class MDCreateNew : Window
    {
        MainWindow Main;

        public MDCreateNew(MainWindow main)
        {
            InitializeComponent();

            Main = main;
            DataContext = this;

            LoadTemplates();
        }

        private void LoadTemplates()
        {
            //TemplateListBox.Items.Add(new ProjectTemplate("Template 1", "A basic template for quick start."));

            foreach (TemplateInfo template in Templates.Instance.Items)
            {
                TemplateListBox.Items
                    .Add(new ProjectTemplate(template.Name, template.Description));
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            Main.IsEnabled = true;

            base.OnClosed(e);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (TemplateListBox.SelectedItem == null)
                return; // cancel event

            if (!Directory.Exists("Projects"))
                Directory.CreateDirectory("Projects");

            foreach (TemplateInfo template in Templates.Instance.Items)
            {
                if (template.Name == (TemplateListBox.SelectedItem as ProjectTemplate).Name)
                {
                    string path = Path.Combine("Projects", (TemplateListBox.SelectedItem as ProjectTemplate).Name);

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    var content = ResourceFetcher.GetResource("MDEditor.Templates." + template.FileName);
                    var bytes = System.Text.Encoding.UTF8.GetBytes(content);
                    TemplateHandler.CreateProject(bytes, "Project\\" + ProjectNameTextBox.Text);
                }
            }
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
