// This file is part of the DisCatSharp project.
//
// Copyright (c) 2021 AITSYS
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DisCatSharp.Mailcow.Rest
{
    public sealed class MailcowApiClient
    {
        /// <summary>
        /// Gets the mailcow client.
        /// </summary>
        internal MailcowClient Mailcow { get; }

        internal HttpClient _client = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="MailcowApiClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        internal MailcowApiClient(MailcowClient client)
        {
            this.Mailcow = client;
        }

        /// <summary>
        /// Builds the query string.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="post">If true, post.</param>
        /// <returns>A string.</returns>
        private static string BuildQueryString(IDictionary<string, string> values, bool post = false)
        {
            if (values == null || values.Count == 0)
                return string.Empty;

            var vals_collection = values.Select(xkvp =>
                $"{WebUtility.UrlEncode(xkvp.Key)}={WebUtility.UrlEncode(xkvp.Value)}");
            var vals = string.Join("&", vals_collection);

            return !post ? $"?{vals}" : vals;
        }

        /// <summary>
        /// Executes a rest request.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="url">The url.</param>
        /// <param name="method">The method.</param>
        /// <param name="route">The route.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="payload">The payload.</param>
        /// <returns>A Task.</returns>
        internal Task<HttpResponseMessage> DoRequestAsync(MailcowClient client, Uri url, HttpMethod method, string route, IReadOnlyDictionary<string, string> headers = null, string payload = null)
        {
            HttpRequestMessage request = new(method, $"{url}{route}");
            request.Headers.Add("X-API-Key", client.Configuration.Token);
            request.Headers.Add("User-Agent", Utilities.VersionHeader);
            request.Headers.Add("Accept", "application/json");
            foreach(var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            if (payload != null)
            {
                request.Content = new StringContent(payload, Utilities.UTF8, "application/json");
            }

            return _client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
        }

        internal async Task<string> TestAsync()
        {
            var route = $"{Endpoints.GET}{Endpoints.STATUS}{Endpoints.CONTAINERS}";
            Bucket.GetBucket(route, new { }, out var path);

            var url = Utilities.GetApiUriFor(path, this.Mailcow.Configuration);
            var result = await this.DoRequestAsync(this.Mailcow, url, HttpMethod.Get, route);

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }
            else
            {
                this.Mailcow.Logger.LogError(LoggerEvents.RestError, result.ReasonPhrase);
                this.Mailcow.Logger.LogError(LoggerEvents.RestError, result.Content.ReadAsStringAsync().Result);
                return null;
            }
        }
        
    }
}
