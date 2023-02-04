using Microsoft.Xna.Framework.Content.Pipeline;
using System.IO;

using TImport = System.String;

namespace PipelineExtension
{
    [ContentImporter(".txt", DisplayName = "LevelImporter", DefaultProcessor = "LevelProcessor")]
    public class LevelImporter : ContentImporter<TImport>
    {
        public override TImport Import(string filename, ContentImporterContext context) => File.ReadAllText(filename);
    }
}