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
        public object MaxNewMailboxQuota;

        [JsonProperty("def_new_mailbox_quota")]
        public object DefNewMailboxQuota;

        [JsonProperty("quota_used_in_domain")]
        public string QuotaUsedInDomain;

        [JsonProperty("bytes_total")]
        public string BytesTotal;

        [JsonProperty("msgs_total")]
        public string MsgsTotal;

        [JsonProperty("mboxes_in_domain")]
        public int MboxesInDomain;

        [JsonProperty("mboxes_left")]
        public int MboxesLeft;

        [JsonProperty("domain_name")]
        public string DomainName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("max_num_aliases_for_domain")]
        public int MaxNumAliasesForDomain;

        [JsonProperty("max_num_mboxes_for_domain")]
        public int MaxNumMboxesForDomain;

        [JsonProperty("def_quota_for_mbox")]
        public object DefQuotaForMbox;

        [JsonProperty("max_quota_for_mbox")]
        public object MaxQuotaForMbox;

        [JsonProperty("max_quota_for_domain")]
        public object MaxQuotaForDomain;

        [JsonProperty("relayhost")]
        public string RelayHost;

        [JsonProperty("backupmx")]
        internal MailcowBool _backupMx;
        [JsonIgnore]
        public bool BackupMx
            => Utilities.GetBool(_backupMx);

        [JsonProperty("backupmx_int")]
        public int BackupmxInt;

        [JsonProperty("gal")]
        internal MailcowBool _gal;
        [JsonIgnore]
        public bool Gal
            => Utilities.GetBool(_gal);

        [JsonProperty("gal_int")]
        public int GalInt;

        [JsonProperty("rl")]
        public bool Rl;

        [JsonProperty("active")]
        internal MailcowBool _active;
        [JsonIgnore]
        public bool Active
            => Utilities.GetBool(_active);

        [JsonProperty("active_int")]
        public int ActiveInt;

        [JsonProperty("relay_all_recipients")]
        internal MailcowBool _relayAllRecipients;
        [JsonIgnore]
        public bool RelayAllRecipients
            => Utilities.GetBool(_relayAllRecipients);

        [JsonProperty("relay_all_recipients_int")]
        public int RelayAllRecipientsInt;

        [JsonProperty("relay_unknown_only")]
        internal MailcowBool _relayUnknownOnly;
        [JsonIgnore]
        public bool RelayUnknownOnly
            => Utilities.GetBool(_relayUnknownOnly);

        [JsonProperty("relay_unknown_only_int")]
        public int RelayUnknownOnlyInt;

        [JsonProperty("aliases_in_domain")]
        public int AliasesInDomain;

        [JsonProperty("aliases_left")]
        public int AliasesLeft;

        [JsonProperty("domain_admins")]
        public string DomainAdmins;

        internal MailcowDomain() { }
    }
}
