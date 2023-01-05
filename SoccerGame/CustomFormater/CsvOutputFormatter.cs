using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Text;

namespace SoccerGame.CustomFormater
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type? type)
        {
            if(typeof(TeamDto).IsAssignableFrom(type)
                || typeof(IEnumerable<TeamDto>).IsAssignableFrom(type))
            {
               
                return base.CanWriteType(type);
            }
            return false;

        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {

            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<TeamDto>)
            {
                foreach (var team in (IEnumerable<TeamDto>)context.Object)
                {
                    FormatCsv(buffer, team);
                }
            }
            else
            {
                FormatCsv(buffer, (TeamDto)context.Object!);
            }
            await response.WriteAsync(buffer.ToString());
        }
        private static void FormatCsv(StringBuilder buffer, TeamDto team)
        {
            buffer.AppendLine($"{team.Id},\"{team.Name},\"{team.Country}\"");
        }

    }
}
