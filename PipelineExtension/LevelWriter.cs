using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace PipelineExtension;

[ContentTypeWriter]
public class LevelWriter : ContentTypeWriter<Level>
{
    public override string GetRuntimeReader(TargetPlatform targetPlatform) => "PipelineExtension.LevelReader, PipelineExtension";

    protected override void Write(ContentWriter output, Level value) => output.Write(value.LevelStringEncoding);
}