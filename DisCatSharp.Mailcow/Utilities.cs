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
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DisCatSharp.Mailcow.Enums;
using DisCatSharp.Mailcow.Rest;
using Microsoft.Extensions.Logging;

namespace DisCatSharp.Mailcow
{
    public static class Utilities
    {
        /// <summary>
        /// Gets the version of the library
        /// </summary>
        internal static string VersionHeader { get; set; }

        /// <summary>
        /// Gets the utf8 encoding
        /// </summary>
        internal static UTF8Encoding UTF8 { get; } = new UTF8Encoding(false);

        /// <summary>
        /// Initializes a new instance of the <see cref="Utilities"/> class.
        /// </summary>
        static Utilities()
        {
            var a = typeof(MailcowClient).GetTypeInfo().Assembly;

            var vs = "";
            var iv = a.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (iv != null)
                vs = iv.InformationalVersion;
            else
            {
                var v = a.GetName().Version;
                vs = v.ToString(3);
            }

            VersionHeader = $"Bot (https://github.com/Aiko-IT-Systems/DisCatSharp.Mailcow, v{vs})";
        }

        /// <summary>
        /// Gets the api base uri.
        /// </summary>
        /// <param name="config">The config</param>
        /// <returns>A string.</returns>
        internal static string GetApiBaseUri(MailcowConfiguration config)
            => $"{config.Host}{Endpoints.API_ENDPOINT}";

        /// <summary>
        /// Gets the api uri for.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="config">The config</param>
        /// <returns>An Uri.</returns>
        internal static Uri GetApiUriFor(string path, MailcowConfiguration config)
            => new($"{GetApiBaseUri(config)}{path}");

        /// <summary>
        /// Gets the api uri for.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="config">The config</param>
        /// <returns>An Uri.</returns>
        internal static Uri GetApiUriFor(string path, string queryString, MailcowConfiguration config)
            => new($"{GetApiBaseUri(config)}{path}{queryString}");

        /// <summary>
        /// Gets the api uri builder for.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="config">The config</param>
        /// <returns>A QueryUriBuilder.</returns>
        internal static QueryUriBuilder GetApiUriBuilderFor(string path, MailcowConfiguration config)
            => new($"{GetApiBaseUri(config)}{path}");

        /// <summary>
        /// Gets the base headers.
        /// </summary>
        /// <returns>A Dictionary.</returns>
        internal static Dictionary<string, string> GetBaseHeaders()
            => new();

        internal static bool GetBool(MailcowBool mailcowBool)
        {
            return mailcowBool switch
            {
                MailcowBool.True => true,
                MailcowBool.False => false,
                _ => false,
            };
        }

        /// <summary>
        /// Helper method to create a <see cref="System.DateTimeOffset"/> from Unix time seconds for targets that do not support this natively.
        /// </summary>
        /// <param name="unixTime">Unix time seconds to convert.</param>
        /// <param name="shouldThrow">Whether the method should throw on failure. Defaults to true.</param>
        /// <returns>Calculated <see cref="System.DateTimeOffset"/>.</returns>
        public static DateTimeOffset GetDateTimeOffset(long unixTime, bool shouldThrow = true)
        {
            try
            {
                return DateTimeOffset.FromUnixTimeSeconds(unixTime);
            }
            catch (Exception)
            {
                if (shouldThrow)
                    throw;

                return DateTimeOffset.MinValue;
            }
        }

        /// <summary>
        /// Helper method to create a <see cref="System.DateTimeOffset"/> from Unix time milliseconds for targets that do not support this natively.
        /// </summary>
        /// <param name="unixTime">Unix time milliseconds to convert.</param>
        /// <param name="shouldThrow">Whether the method should throw on failure. Defaults to true.</param>
        /// <returns>Calculated <see cref="System.DateTimeOffset"/>.</returns>
        public static DateTimeOffset GetDateTimeOffsetFromMilliseconds(long unixTime, bool shouldThrow = true)
        {
            try
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(unixTime);
            }
            catch (Exception)
            {
                if (shouldThrow)
                    throw;

                return DateTimeOffset.MinValue;
            }
        }

        /// <summary>
        /// Helper method to calculate Unix time seconds from a <see cref="System.DateTimeOffset"/> for targets that do not support this natively.
        /// </summary>
        /// <param name="dto"><see cref="System.DateTimeOffset"/> to calculate Unix time for.</param>
        /// <returns>Calculated Unix time.</returns>
        public static long GetUnixTime(DateTimeOffset dto)
            => dto.ToUnixTimeMilliseconds();

        /// <summary>
        /// Checks whether this string contains given characters.
        /// </summary>
        /// <param name="str">String to check.</param>
        /// <param name="characters">Characters to check for.</param>
        /// <returns>Whether the string contained these characters.</returns>
        public static bool Contains(this string str, params char[] characters)
        {
            foreach (var xc in str)
                if (characters.Contains(xc))
                    return true;

            return false;
        }

        /// <summary>
        /// Logs the task fault.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="level">The level.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="message">The message.</param>
        internal static void LogTaskFault(this Task task, ILogger logger, LogLevel level, EventId eventId, string message)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            if (logger == null)
                return;

            task.ContinueWith(t => logger.Log(level, eventId, t.Exception, message), TaskContinuationOptions.OnlyOnFaulted);
        }

        /// <summary>
        /// Deconstruct.
        /// </summary>
        /// <param name="kvp">The key-value pair.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        internal static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, out TKey key, out TValue value)
        {
            key = kvp.Key;
            value = kvp.Value;
        }
    }
}
