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

using DisCatSharp.Mailcow.Enums;
using Newtonsoft.Json;

namespace DisCatSharp.Mailcow.Entities
{
    public class MailcowDomain
    {
        [JsonProperty("max_new_mailbox_quota")]
        public int NaxNewMailboxQuota { get; internal set; }

        [JsonProperty("def_new_mailbox_quota")]
        public int DefaultNewMailboxQuota { get; internal set; }

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
        public int DefaultMailboxQuota { get; internal set; }

        [JsonProperty("max_quota_for_mbox")]
        public int MaxMailboxQuota { get; internal set; }

        [JsonProperty("max_quota_for_domain")]
        public int MaxDomainQuota { get; internal set; }

        [JsonProperty("relayhost")]
        public string RelayHost { get; internal set; }

        [JsonProperty("backupmx")]
        internal MailcowBool InternalBackupMx { get; set; }
        [JsonIgnore]
        public bool BackupMx
            => Utilities.GetBool(this.InternalBackupMx);

        [JsonProperty("backupmx_int")]
        public int BackupmxInt { get; set; }

        [JsonProperty("gal")]
        internal MailcowBool InternalGal { get; set; }
        [JsonIgnore]
        public bool Gal
            => Utilities.GetBool(this.InternalGal);

        [JsonProperty("gal_int")]
        public int GalInt { get; internal set; }

        [JsonProperty("rl")]
        public bool Rl { get; internal set; }

        [JsonProperty("active")]
        internal MailcowBool InternalActive { get; set;  }
        [JsonIgnore]
        public bool Active
            => Utilities.GetBool(this.InternalActive);

        [JsonProperty("active_int")]
        public int ActiveInt { get; internal set; }

        [JsonProperty("relay_all_recipients")]
        internal MailcowBool InternalRelayAllRecipients { get; set; }
        [JsonIgnore]
        public bool RelayAllRecipients
            => Utilities.GetBool(this.InternalRelayAllRecipients);

        [JsonProperty("relay_all_recipients_int")]
        public int RelayAllRecipientsInt { get; internal set; }

        [JsonProperty("relay_unknown_only")]
        internal MailcowBool InternalRelayUnknownOnly { get; set; }
        [JsonIgnore]
        public bool RelayUnknownOnly
            => Utilities.GetBool(this.InternalRelayUnknownOnly);

        [JsonProperty("relay_unknown_only_int")]
        public int RelayUnknownOnlyInt { get; internal set; }

        [JsonProperty("aliases_in_domain")]
        public int AliasesCount { get; internal set; }

        [JsonProperty("aliases_left")]
        public int AvailableAliases { get; internal set; }

        [JsonProperty("domain_admins")]
        public string DomainAdmins { get; internal set; }

        internal MailcowDomain() { }

        public MailcowDomain(MailcowDomain other)
        {
            this.DomainName = other.DomainName;
            this.Description = other.Description;
        }
    }
}
