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

        public Task<MailcowStatus> GetContainerStatusAsync()
            => this.ApiClient.GetMailcowStatusAsync();

        public Task<SolrStatus> GetSolrStatusAsync()
            => this.ApiClient.GetSolrStatusAsync();

        public Task<VmailStatus> GetVmailStatusAsync()
            => this.ApiClient.GetVmailStatusAsync();

        /// <summary>
        /// Disposes this client.
        /// </summary>
        public void Dispose() { }
    }
}
