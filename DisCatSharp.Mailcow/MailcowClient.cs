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
using System.Reflection;
using System.Threading.Tasks;
using DisCatSharp.Mailcow.Entities;
using DisCatSharp.Mailcow.Rest;
using Microsoft.Extensions.Logging;

namespace DisCatSharp.Mailcow
{
    public sealed class MailcowClient : IDisposable
    {
        internal MailcowApiClient ApiClient { get; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        internal MailcowConfiguration Configuration { get; }

        /// <summary>
        /// Gets the instance of the logger for this client.
        /// </summary>
        public ILogger<MailcowClient> Logger { get; }

        /// <summary>
        /// Gets the string representing the version of bot lib.
        /// </summary>
        public string VersionString { get; }

        /// <summary>
        /// Gets the library name.
        /// </summary>
        public string Library { get; }

        /// <summary>
        /// Initializes this Discord API client.
        /// </summary>
        /// <param name="config">Configuration for this client.</param>
        public MailcowClient(MailcowConfiguration config)
        {
            this.Configuration = new MailcowConfiguration(config);

            if (this.Configuration.LoggerFactory == null)
            {
                this.Configuration.LoggerFactory = new DefaultLoggerFactory();
                this.Configuration.LoggerFactory.AddProvider(new DefaultLoggerProvider(this));
            }
            this.Logger = this.Configuration.LoggerFactory.CreateLogger<MailcowClient>();

            this.ApiClient = new MailcowApiClient(this);
            
            var a = typeof(MailcowClient).GetTypeInfo().Assembly;

            var iv = a.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (iv != null)
            {
                this.VersionString = iv.InformationalVersion;
            }
            else
            {
                var v = a.GetName().Version;
                var vs = v.ToString(3);

                if (v.Revision > 0)
                    this.VersionString = $"{vs}, CI build {v.Revision}";
            }

            this.Library = "DisCatSharp.Mailcow";
        }

        #region Methods

        /// <summary>
        /// Gets a specific mailcow domain.
        /// </summary>
        /// <param name="domain">The domain to get.</param>
        /// <returns>The requested domain</returns>
        public Task<MailcowDomain> GetDomainAsync(string domain)
            => this.ApiClient.GetDomainAsync(domain);

        /// <summary>
        /// Gets all domains from mailcow.
        /// </summary>
        /// <returns>A collection of domains</returns>
        public Task<IReadOnlyCollection<MailcowDomain>> GetAllDomainsAsync()
            => this.ApiClient.GetAllDomainsAsync();

        /// <summary>
        /// Gets a specific mailbox from mailcow.
        /// </summary>
        /// <param name="mailbox">The mailbox to get.</param>
        /// <returns>The requested mailbox</returns>
        public Task<MailcowMailbox> GetMailboxAsync(string mailbox)
            => this.ApiClient.GetMailboxAsync(mailbox);

        /// <summary>
        /// Get all mailboxes from mailcow.
        /// </summary>
        /// <param name="reduced">Whether to get reduced infos.</param>
        /// <returns>A collection of all mailboxes.</returns>
        public Task<IReadOnlyCollection<MailcowMailbox>> GetAllMailboxesAsync(bool reduced = false)
            => this.ApiClient.GetAllMailboxesAsync(reduced);

        /// <summary>
        /// Gets the docker container status.
        /// </summary>
        public Task<MailcowStatus> GetContainerStatusAsync()
            => this.ApiClient.GetMailcowStatusAsync();

        /// <summary>
        /// Gets the solr status.
        /// </summary>
        public Task<SolrStatus> GetSolrStatusAsync()
            => this.ApiClient.GetSolrStatusAsync();

        /// <summary>
        /// Gets the vmail status.
        /// </summary>
        public Task<VmailStatus> GetVmailStatusAsync()
            => this.ApiClient.GetVmailStatusAsync();

        #endregion

        /// <summary>
        /// Disposes this client.
        /// </summary>
        public void Dispose() { }
    }
}
