using System.IO;
using System;
using System.IO.Compression;

public static class TemplateHandler
{
    public static MarkdownProject CreateProject(byte[] zipFileBytes, string projectFilePath)
    {
        string tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDirectory);

        using (var memoryStream = new MemoryStream(zipFileBytes))
        using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Read))
        {
            foreach (var entry in zipArchive.Entries)
            {
                string destinationPath = Path.Combine(tempDirectory, entry.FullName);
                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                using (var entryStream = entry.Open())
                using (var fileStream = new FileStream(destinationPath, FileMode.Create))
                {
                    entryStream.CopyTo(fileStream);
                }
            }
        }

        return new MarkdownProject(projectFilePath);
    }
}