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
using Newtonsoft.Json;

namespace DisCatSharp.Mailcow.Entities
{
    public class MailcowMailboxAttributes
    {
        [JsonProperty("force_pw_update")]
        public bool ForcePwUpdate;

        [JsonProperty("tls_enforce_in")]
        public bool TlsEnforceIn;

        [JsonProperty("tls_enforce_out")]
        public bool TlsEnforceOut;

        [JsonProperty("sogo_access")]
        public bool SogoAccess;

        [JsonProperty("imap_access")]
        public bool ImapAccess;

        [JsonProperty("pop3_access")]
        public bool Pop3Access;

        [JsonProperty("smtp_access")]
        public bool SmtpAccess;

        [JsonProperty("relayhost")]
        public bool Relayhost;

        [JsonProperty("passwd_update")]
        public DateTime? PasswdUpdate;

        [JsonProperty("mailbox_format")]
        public string MailboxFormat;

        [JsonProperty("quarantine_notification")]
        public string QuarantineNotification;

        [JsonProperty("quarantine_category")]
        public string QuarantineCategory;

        [JsonProperty("sieve_access")]
        public bool SieveAccess;

        public MailcowMailboxAttributes() { }
    }
}
