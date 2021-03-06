﻿using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CleanKludge.Server.Extensions
{
    public static class HttpRequestExtensions
    {
        public static async Task<string> ReadAsStringAsync(this HttpRequest self)
        {
            if (self.Body == null || self.Body == Stream.Null)
                return null;

            using (var bodyReader = new StreamReader(self.Body))
            {
                var body = await bodyReader.ReadToEndAsync();
                self.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
                return body;
            }
        }

        public static async Task<byte[]> ReadAsByteArrayAsync(this HttpRequest self)
        {
            if (self.Body == null || self.Body == Stream.Null)
                return null;

            using (var bodyReader = new MemoryStream())
            {
                await self.Body.CopyToAsync(bodyReader);

                var byteArray = bodyReader.ToArray();
                self.Body = new MemoryStream(byteArray);
                return byteArray;
            }
        }
    }
}