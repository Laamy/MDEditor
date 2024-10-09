using System.Collections.Generic;

class TemplateInfo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string FileName { get; set; }
}

class Templates
{
    public static Templates Instance { get; private set; } = new Templates();

    public List<TemplateInfo> Items = new List<TemplateInfo>()
    {
        new TemplateInfo()
        {
            Name = "Sample Template",
            Description = "A basic sample project to get you started",
            FileName = "SimpleTemplate.zip"
        }
    };
}