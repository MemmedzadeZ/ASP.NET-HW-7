using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.Text;
using WbApiDemo3_22_5.Dtos;

namespace WbApiDemo3_22_5.Formatters
{
    public class TextCsvInputFormatter : TextInputFormatter
    {

        public TextCsvInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
       
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var _context = context.HttpContext.Request;
            using var streamRender = new StreamReader(_context.Body, encoding);
            string?content = await streamRender.ReadToEndAsync();

            var split = content.Split('-');
            if(split.Length ==5)
            {
                var studentDto = new StudentAddDto()
                {
                    Fullname = split[1],
                    SeriaNo = split[2],
                    Age = int.Parse(split[3]),
                    Score = int.Parse(split[4]),

                };
                return await InputFormatterResult.SuccessAsync(studentDto);

            }
            return await InputFormatterResult.FailureAsync();


        
    
        }
    }
}


