using System.Windows;
using System.Windows.Documents;

using Markdig;

namespace MDEditor
{
    public partial class MainWindow : Window
    {
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
    }
}
