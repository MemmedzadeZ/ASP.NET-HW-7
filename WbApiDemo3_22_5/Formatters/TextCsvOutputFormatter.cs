using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using WbApiDemo3_22_5.Dtos;

namespace WbApiDemo3_22_5.Formatters
{
    public class TextCsvOutputFormatter : TextOutputFormatter
    {

        public TextCsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var reponse = context.HttpContext.Response;
            var  sb =new StringBuilder();
            
            sb.AppendLine("Id-FullName-SeriaNo-Age-Score");
            if(context.Object is IEnumerable<StudentDto> studenetlist)
            {
                foreach(var item in studenetlist)
                {
                    FormatCsvCard(sb, item);    

                }
            }
            else if(context.Object is StudentDto studenet)
            {
                FormatCsvCard(sb, studenet);
            }
            await reponse.WriteAsync(sb.ToString());
        }

        private void FormatCsvCard(StringBuilder sb, StudentDto item)
        {
            sb.AppendLine($"{item.Id}-{item.Fullname}-{item.SeriaNo}-{item.Age}-{item.Score}");

        }
    }
}
