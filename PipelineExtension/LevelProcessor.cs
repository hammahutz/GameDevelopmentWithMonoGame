using Microsoft.Xna.Framework.Content.Pipeline;

using TInput = System.String;
using TOutput = PipelineExtension.Level;

namespace PipelineExtension
{
    [ContentProcessor(DisplayName = "LevelProcessor")]
    internal class LevelProcessor : ContentProcessor<TInput, TOutput>
    {
        public override TOutput Process(TInput input, ContentProcessorContext context) => new TOutput(input);
    }
}