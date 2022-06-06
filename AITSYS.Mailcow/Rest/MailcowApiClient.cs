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
using AITSYS.Mailcow;
using AITSYS.Mailcow.Entities;
using AITSYS.Mailcow.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AITSYS.Mailcow.Rest
{
    public sealed class MailcowApiClient
    {
        /// <summary>
        /// Gets the mailcow client.
        /// </summary>
        internal MailcowClient Mailcow { get; }

        internal HttpClient Client { get; }

        internal const string API_HEADER = "X-API-Key";

        /// <summary>
        /// Initializes a new instance of the <see cref="MailcowApiClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        internal MailcowApiClient(MailcowClient client)
        {
            this.Mailcow = client;
            var _httpHandler = new HttpClientHandler() { CookieContainer = new CookieContainer(), AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.None };
            this.Client = new HttpClient(_httpHandler);
        }

        #region Internals

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
        /// <param name="headers">The headers.</param>
        /// <param name="payload">The payload.</param>
        /// <returns>A Task.</returns>
        internal async Task<HttpResponseMessage> DoRequestAsync(MailcowClient client, Uri url, HttpMethod method, IReadOnlyDictionary<string, string> headers = null, string payload = null)
        {
            HttpRequestMessage request = new(method, $"{url}");
            request.Headers.Add(API_HEADER, client.Configuration.Token);
            request.Headers.Add("User-Agent", Utilities.VersionHeader);
            request.Headers.Add("Accept", "*/*");
            if (headers != null)
                foreach (var header in headers)
                    request.Headers.Add(header.Key, header.Value);
            if (payload != null)
                request.Content = new StringContent(payload, Utilities.UTF8, "application/json");

            var response = await this.Client.SendAsync(request, HttpCompletionOption.ResponseContentRead);

            return !response.IsSuccessStatusCode || response.Content.ReadAsStringAsync().Result == "{}"
                ? throw new MailcowRestException(response, client.Configuration, response.ReasonPhrase ?? null)
                : response;
        }
        #endregion

        internal async Task<MailcowDomain> GetDomainAsync(string domain)
        {
            var route = $"{Endpoints.GET}{Endpoints.DOMAIN}/:domain";
            Bucket.GetBucket(route, new { domain }, out var path);
            var url = Utilities.GetApiUriFor(path, this.Mailcow.Configuration);
            var result = await this.DoRequestAsync(this.Mailcow, url, HttpMethod.Get);

            var domain_json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MailcowDomain>(domain_json);
        }

        internal async Task<IReadOnlyCollection<MailcowDomain>> GetAllDomainsAsync()
        {
            var route = $"{Endpoints.GET}{Endpoints.DOMAIN}{Endpoints.ALL}";
            Bucket.GetBucket(route, new { }, out var path);
            var url = Utilities.GetApiUriFor(path, this.Mailcow.Configuration);
            var result = await this.DoRequestAsync(this.Mailcow, url, HttpMethod.Get);

            var domain_json = await result.Content.ReadAsStringAsync();
            var domains = JsonConvert.DeserializeObject<List<MailcowDomain>>(domain_json);
            return domains.AsReadOnly();
        }

        internal async Task<MailcowMailbox> GetMailboxAsync(string mailbox)
        {
            var route = $"{Endpoints.GET}{Endpoints.DOMAIN}/:mailbox";
            Bucket.GetBucket(route, new { mailbox }, out var path);
            var url = Utilities.GetApiUriFor(path, this.Mailcow.Configuration);
            var result = await this.DoRequestAsync(this.Mailcow, url, HttpMethod.Get);

            var mailbox_json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MailcowMailbox>(mailbox_json);
        }

        internal async Task<IReadOnlyCollection<MailcowMailbox>> GetAllMailboxesAsync(bool reduced)
        {
            var route = reduced ? $"{Endpoints.GET}{Endpoints.MAILBOX}{Endpoints.REDUCED}" : $"{Endpoints.GET}{Endpoints.MAILBOX}{Endpoints.ALL}";
            Bucket.GetBucket(route, new { }, out var path);
            var url = Utilities.GetApiUriFor(path, this.Mailcow.Configuration);
            var result = await this.DoRequestAsync(this.Mailcow, url, HttpMethod.Get);

            var mailbox_json = await result.Content.ReadAsStringAsync();
            var mailboxes = JsonConvert.DeserializeObject<List<MailcowMailbox>>(mailbox_json);
            return mailboxes.AsReadOnly();
        }

        internal async Task<MailcowStatus> GetMailcowStatusAsync()
        {
            var route = $"{Endpoints.GET}{Endpoints.STATUS}{Endpoints.CONTAINERS}";
            Bucket.GetBucket(route, new { }, out var path);
            var url = Utilities.GetApiUriFor(path, this.Mailcow.Configuration);
            var result = await this.DoRequestAsync(this.Mailcow, url, HttpMethod.Get);

            var json = await result.Content.ReadAsStringAsync();
            var mailcow_status = JsonConvert.DeserializeObject<MailcowStatus>(json);
            return mailcow_status;
        }

        internal async Task<SolrStatus> GetSolrStatusAsync()
        {
            var route = $"{Endpoints.GET}{Endpoints.STATUS}{Endpoints.SOLR}";
            Bucket.GetBucket(route, new { }, out var path);
            var url = Utilities.GetApiUriFor(path, this.Mailcow.Configuration);
            var result = await this.DoRequestAsync(this.Mailcow, url, HttpMethod.Get);

            var json = await result.Content.ReadAsStringAsync();
            var mailcow_status = JsonConvert.DeserializeObject<SolrStatus>(json);
            return mailcow_status;
        }

        internal async Task<VmailStatus> GetVmailStatusAsync()
        {
            var route = $"{Endpoints.GET}{Endpoints.STATUS}{Endpoints.VMAIL}";
            Bucket.GetBucket(route, new { }, out var path);
            var url = Utilities.GetApiUriFor(path, this.Mailcow.Configuration);
            var result = await this.DoRequestAsync(this.Mailcow, url, HttpMethod.Get);

            var json = await result.Content.ReadAsStringAsync();
            var mailcow_status = JsonConvert.DeserializeObject<VmailStatus>(json);
            return mailcow_status;
        }
    }
}
