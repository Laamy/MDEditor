using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Markdig;

namespace MDEditor
{
    public partial class MainWindow : Window
    {
        private bool _isResizing;
        private Point _startPoint;

        public MainWindow()
        {
            InitializeComponent();

            this.Title += $" | {Config.Version}";

            // some sample markdown
            {
                var content = ResourceFetcher.GetResource("MDEditor.Content.ExampleMarkdown.md");
                Paragraph sampleText = new Paragraph(new Run(content));

                TextEditor.Document = new FlowDocument(sampleText);
            }
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void TextEditor_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string markdownText = new TextRange(TextEditor.Document.ContentStart, TextEditor.Document.ContentEnd).Text;

            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseEmojiAndSmiley()
                .Build();

            string htmlContent = Markdown.ToHtml(markdownText, pipeline);

            var content = ResourceFetcher.GetResource("MDEditor.Content.MarkdownDisplay.html");
            string styledContent = content.Replace("{HTMLContent}", htmlContent);

            MarkdownDisplay.NavigateToString(styledContent);
        }

        private void Projects_Click(object sender, RoutedEventArgs e)
        {
            MDProjects projects = new MDProjects(this);
            projects.Show();

            IsEnabled = false;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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
    }
}
