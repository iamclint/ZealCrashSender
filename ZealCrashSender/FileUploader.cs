using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ZealCrashSender
{
    public class FileUploader
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task UploadFileAsync(string filePath, string uploadUrl)
        {
            using (var form = new MultipartFormDataContent())
            {
                // Read the file content
                var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filePath));
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                // Add file content to the form
                form.Add(fileContent, "file", System.IO.Path.GetFileName(filePath));

                // Send POST request
                var response = await client.PostAsync(uploadUrl, form);
                response.EnsureSuccessStatusCode(); // Throws if not a success code.

                // Optional: Read and handle response
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
            }
        }
    }
}
