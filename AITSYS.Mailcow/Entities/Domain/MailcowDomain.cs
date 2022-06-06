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

using System.Collections.Generic;
using AITSYS.Mailcow.Enums;
using Newtonsoft.Json;

namespace AITSYS.Mailcow.Entities
{
    public class MailcowDomain
    {
        [JsonProperty("max_new_mailbox_quota")]
        public ulong NaxNewMailboxQuota { get; internal set; }

        [JsonProperty("def_new_mailbox_quota")]
        public ulong DefaultNewMailboxQuota { get; internal set; }

        [JsonProperty("quota_used_in_domain")]
        public string QuotaUsedInDomain { get; internal set; }

        [JsonProperty("bytes_total")]
        public string TotalBytes { get; internal set; }

        [JsonProperty("msgs_total")]
        public string TotalMails { get; internal set; }

        [JsonProperty("mboxes_in_domain")]
        public int MailboxCount { get; internal set; }

        [JsonProperty("mboxes_left")]
        public int AvailableMailboxes { get; internal set; }

        [JsonProperty("domain_name")]
        public string DomainName { get; internal set; }

        [JsonProperty("description")]
        public string Description { get; internal set; }

        [JsonProperty("max_num_aliases_for_domain")]
        public int MaxAliases { get; internal set; }

        [JsonProperty("max_num_mboxes_for_domain")]
        public int MaxMailboxes { get; internal set; }

        [JsonProperty("def_quota_for_mbox")]
        public ulong DefaultMailboxQuota { get; internal set; }

        [JsonProperty("max_quota_for_mbox")]
        public ulong MaxMailboxQuota { get; internal set; }

        [JsonProperty("max_quota_for_domain")]
        public ulong MaxDomainQuota { get; internal set; }

        [JsonProperty("relayhost")]
        public string RelayHost { get; internal set; }

        [JsonProperty("backupmx")]
        public bool BackupMx { get; internal set; }

        [JsonProperty("backupmx_int")]
        public int BackupmxInt { get; set; }

        [JsonProperty("gal")]
        public bool Gal { get; internal set; }

        [JsonProperty("gal_int")]
        public int GalInt { get; internal set; }

        [JsonProperty("rl")]
        public bool Rl { get; internal set; }

        [JsonProperty("active")]
        public bool Active { get; internal set; }

        [JsonProperty("active_int")]
        public int ActiveInt { get; internal set; }

        [JsonProperty("relay_all_recipients")]
        public bool RelayAllRecipients { get; internal set; }

        [JsonProperty("relay_all_recipients_int")]
        public int RelayAllRecipientsInt { get; internal set; }

        [JsonProperty("relay_unknown_only")]
        public bool RelayUnknownOnly { get; internal set; }

        [JsonProperty("relay_unknown_only_int")]
        public int RelayUnknownOnlyInt { get; internal set; }

        [JsonProperty("aliases_in_domain")]
        public int AliasesCount { get; internal set; }

        [JsonProperty("aliases_left")]
        public int AvailableAliases { get; internal set; }

        [JsonProperty("domain_admins")]
        public List<string> DomainAdmins { get; internal set; }

        public MailcowDomain() { }
    }
}
