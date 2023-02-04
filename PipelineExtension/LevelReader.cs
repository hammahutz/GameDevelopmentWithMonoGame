using Microsoft.Xna.Framework.Content;

namespace PipelineExtension
{
    public class LevelReader : ContentTypeReader<Level>
    {
        protected override Level Read(ContentReader input, Level existingInstance) => new Level(input.ReadString());
    }
}
