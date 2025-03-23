using Darks.Dispatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Integrations.Discord.Formatters;
internal class ExecutableJobFormatter
{
    public void Format(ExecutableJob job, StringBuilder builder)
    {
        builder.AppendLine($"""
                ```bf
                Local-UUID:         {job.UUID}
                Job-BluePrint-Type: {job.Blueprint.GetType().Name}
                Job-Blueprint-Id:   {job.Blueprint.Id}
                ```
                """);
    }

    public StringBuilder Format(ExecutableJob job)
    {
        StringBuilder builder = new();
        Format(job, builder);
        return builder;
    }
}
