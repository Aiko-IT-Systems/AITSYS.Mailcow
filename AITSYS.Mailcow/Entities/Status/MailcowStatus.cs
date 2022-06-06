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

using Newtonsoft.Json;

namespace AITSYS.Mailcow.Entities
{
    public class MailcowStatus
    {
        [JsonProperty("rspamd-mailcow")]
        public ContainerStatus Rspamd { get; internal set; }

        [JsonProperty("ofelia-mailcow")]
        public ContainerStatus Ofelia { get; internal set; }

        [JsonProperty("netfilter-mailcow")]
        public ContainerStatus Netfilter { get; internal set; }

        [JsonProperty("acme-mailcow")]
        public ContainerStatus Acme { get; internal set; }

        [JsonProperty("dovecot-mailcow")]
        public ContainerStatus Dovecot { get; internal set; }

        [JsonProperty("postfix-mailcow")]
        public ContainerStatus Postfix { get; internal set; }

        [JsonProperty("nginx-mailcow")]
        public ContainerStatus Nginx { get; internal set; }

        [JsonProperty("mysql-mailcow")]
        public ContainerStatus Mysql { get; internal set; }

        [JsonProperty("php-fpm-mailcow")]
        public ContainerStatus PhpFpm { get; internal set; }

        [JsonProperty("clamd-mailcow")]
        public ContainerStatus Clamd { get; internal set; }

        [JsonProperty("watchdog-mailcow")]
        public ContainerStatus Watchdog { get; internal set; }

        [JsonProperty("sogo-mailcow")]
        public ContainerStatus Sogo { get; internal set; }

        [JsonProperty("solr-mailcow")]
        public ContainerStatus Solr { get; internal set; }

        [JsonProperty("unbound-mailcow")]
        public ContainerStatus Unbound { get; internal set; }

        [JsonProperty("memcached-mailcow")]
        public ContainerStatus Memcached { get; internal set; }

        [JsonProperty("olefy-mailcow")]
        public ContainerStatus Olefy { get; internal set; }

        [JsonProperty("redis-mailcow")]
        public ContainerStatus Redis { get; internal set; }

        [JsonProperty("dockerapi-mailcow")]
        public ContainerStatus Dockerapi { get; internal set; }

        internal MailcowStatus() { }
    }
}
