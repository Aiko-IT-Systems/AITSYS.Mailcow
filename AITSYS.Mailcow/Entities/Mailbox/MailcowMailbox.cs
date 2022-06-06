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
using AITSYS.Mailcow.Enums;
using Newtonsoft.Json;

namespace AITSYS.Mailcow.Entities
{
    public class MailcowMailbox
    {
        [JsonProperty("username")]
        public string Username;

        [JsonProperty("active")]
        public MailboxState Active;

        [JsonProperty("active_limited")]
        public bool ActiveLimited;

        [JsonProperty("active_full")]
        public bool ActiveFull;

        [JsonProperty("domain")]
        public string Domain;

        /*[JsonProperty("relayhost", NullValueHandling = NullValueHandling.Ignore)]
        public object Relayhost;*/

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("local_part")]
        public string LocalPart;

        [JsonProperty("quota")]
        public ulong Quota;

        [JsonProperty("messages")]
        public int Messages;

        [JsonProperty("attributes")]
        public MailcowMailboxAttributes Attributes;

        [JsonProperty("quota_used")]
        public int QuotaUsed;

        [JsonProperty("percent_in_use")]
        public string PercentInUse;

        [JsonProperty("percent_class")]
        public string PercentClass;

        [JsonProperty("last_imap_login")]
        internal long? _lastImapLoginRaw;
        [JsonIgnore]
        public DateTimeOffset? LastImapLogin
            => this._lastImapLoginRaw.HasValue ? DateTimeOffset.FromUnixTimeSeconds(_lastImapLoginRaw.Value) : null;

        [JsonProperty("last_smtp_login")]
        internal long? _lastSmtpLoginRaw;
        [JsonIgnore]
        public DateTimeOffset? LastSmtpLogin
            => this._lastSmtpLoginRaw.HasValue ? DateTimeOffset.FromUnixTimeSeconds(_lastSmtpLoginRaw.Value) : null;

        [JsonProperty("last_pop3_login")]
        internal long? _lastPop3LoginRaw;
        [JsonIgnore]
        public DateTimeOffset? LastPop3Login
            => this._lastPop3LoginRaw.HasValue ? DateTimeOffset.FromUnixTimeSeconds(_lastPop3LoginRaw.Value) : null;

        [JsonProperty("max_new_quota", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxNewQuota;

        [JsonProperty("spam_aliases", NullValueHandling = NullValueHandling.Ignore)]
        public int? SpamAliases;

        [JsonProperty("pushover_active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PushoverActive;

        [JsonProperty("rl", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rl;

        [JsonProperty("rl_scope", NullValueHandling = NullValueHandling.Ignore)]
        public string RlScope;

        [JsonProperty("is_relayed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRelayed;

        public MailcowMailbox() { }
    }
}
