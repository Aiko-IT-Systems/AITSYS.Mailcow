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

namespace DisCatSharp.Mailcow.Entities
{
    public class MailcowStatus
    {
        [JsonProperty("rspamd-mailcow")]
        public ContainerStatus Rspamd;

        [JsonProperty("ofelia-mailcow")]
        public ContainerStatus Ofelia;

        [JsonProperty("netfilter-mailcow")]
        public ContainerStatus Netfilter;

        [JsonProperty("acme-mailcow")]
        public ContainerStatus Acme;

        [JsonProperty("dovecot-mailcow")]
        public ContainerStatus Dovecot;

        [JsonProperty("postfix-mailcow")]
        public ContainerStatus Postfix;

        [JsonProperty("nginx-mailcow")]
        public ContainerStatus Nginx;

        [JsonProperty("mysql-mailcow")]
        public ContainerStatus Mysql;

        [JsonProperty("php-fpm-mailcow")]
        public ContainerStatus PhpFpm;

        [JsonProperty("clamd-mailcow")]
        public ContainerStatus Clamd;

        [JsonProperty("watchdog-mailcow")]
        public ContainerStatus Watchdog;

        [JsonProperty("sogo-mailcow")]
        public ContainerStatus Sogo;

        [JsonProperty("solr-mailcow")]
        public ContainerStatus Solr;

        [JsonProperty("unbound-mailcow")]
        public ContainerStatus Unbound;

        [JsonProperty("memcached-mailcow")]
        public ContainerStatus Memcached;

        [JsonProperty("olefy-mailcow")]
        public ContainerStatus Olefy;

        [JsonProperty("redis-mailcow")]
        public ContainerStatus Redis;

        [JsonProperty("dockerapi-mailcow")]
        public ContainerStatus Dockerapi;

        internal MailcowStatus() { }
    }
}
