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
using Microsoft.Extensions.Logging;

namespace DisCatSharp.Mailcow
{
    /// <summary>
    /// Represents a mailcow configuration
    /// </summary>
    public sealed class MailcowConfiguration
    {
        /// <summary>
        /// Sets the token used to identify the client.
        /// </summary>
        public string Token
        {
            internal get => this._token;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "Token cannot be null, empty, or all whitespace.");

                this._token = value.Trim();
            }
        }
        private string _token = "";

        /// <summary>
        /// Sets the host url used to use the api.
        /// Example: https://mail.example.com.
        /// </summary>
        public string Host
        {
            internal get => this._host;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "Host cannot be null, empty, or all whitespace.");

                this._host = value;
            }
        }
        private string _host = "";

        /// <summary>
        /// Sets the host url used to use the api.
        /// Example: https://mail.example.com.
        /// </summary>
        public string ApiVersion
        {
            internal get => this._apiVersion;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "API version cannot be null, empty, or all whitespace.");

                this._apiVersion = value;
            }
        }
        private string _apiVersion = "v2";

        /// <summary>
        /// <para>Sets the minimum logging level for messages.</para>
        /// <para>Typically, the default value of <see cref="Microsoft.Extensions.Logging.LogLevel.Information"/> is ok for most uses.</para>
        /// </summary>
        public LogLevel MinimumLogLevel { internal get; set; } = LogLevel.Information;

        /// <summary>
        /// <para>Allows you to overwrite the time format used by the internal debug logger.</para>
        /// <para>Only applicable when <see cref="LoggerFactory"/> is set left at default value. Defaults to ISO 8601-like format.</para>
        /// </summary>
        public string LogTimestampFormat { internal get; set; } = "yyyy-MM-dd HH:mm:ss zzz";

        /// <summary>
        /// <para>Sets the logger implementation to use.</para>
        /// <para>To create your own logger, implement the <see cref="Microsoft.Extensions.Logging.ILoggerFactory"/> instance.</para>
        /// <para>Defaults to built-in implementation.</para>
        /// </summary>
        public ILoggerFactory LoggerFactory { internal get; set; } = null;

        /// <summary>
        /// Creates a new configuration with default values.
        /// </summary>
        public MailcowConfiguration()
        { }

        /// <summary>
        /// Creates a clone of another mailcow configuration.
        /// </summary>
        /// <param name="other">Client configuration to clone.</param>
        public MailcowConfiguration(MailcowConfiguration other)
        {
            this.Token = other.Token;
            this.Host = other.Host;
            this.MinimumLogLevel = other.MinimumLogLevel;
            this.LogTimestampFormat = other.LogTimestampFormat;
            this.LoggerFactory = other.LoggerFactory;
            this.ApiVersion = other.ApiVersion;
        }
    }
}
