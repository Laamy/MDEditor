using System.Collections.Generic;
using System;
using System.IO;
using System.Web.Script.Serialization;

public class MarkdownProject
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Author { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime LastModified { get; private set; }
    public string ProjectSource { get; private set; }
    public string ProjectAssets { get; private set; }
    public Dictionary<string, string> MarkdownFiles { get; private set; }

    public MarkdownProject(string projectFilePath)
    {
        LoadProject(projectFilePath);
        LoadMarkdownFiles();
    }

    private void LoadProject(string projectFilePath)
    {
        string json = File.ReadAllText(projectFilePath);
        var serializer = new JavaScriptSerializer();
        dynamic projectData = serializer.Deserialize<dynamic>(json);

        Title = projectData["title"];
        Description = projectData["description"];
        Author = projectData["author"];
        CreatedDate = DateTimeOffset.FromUnixTimeMilliseconds((long)projectData["created_date"]).DateTime;
        LastModified = DateTimeOffset.FromUnixTimeMilliseconds((long)projectData["last_modified"]).DateTime;
        ProjectSource = projectData["settings"]["project-source"];
        ProjectAssets = projectData["settings"]["project-assets"];
    }

    private void LoadMarkdownFiles()
    {
        MarkdownFiles = new Dictionary<string, string>();

        // Load Markdown files from the source directory
        string[] markdownFiles = Directory.GetFiles(ProjectSource, "*.md");

        foreach (var file in markdownFiles)
        {
            string content = File.ReadAllText(file);
            MarkdownFiles[Path.GetFileName(file)] = content;
        }
    }
}