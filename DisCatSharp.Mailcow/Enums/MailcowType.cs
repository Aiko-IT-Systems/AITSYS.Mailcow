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
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace DisCatSharp.Mailcow.Enums
{
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    internal class CustomMailcowType : Enumeration
    {
        internal static CustomMailcowType Information = new(0, "info");
        internal static CustomMailcowType Success = new(1, "success");
        internal static CustomMailcowType Danger = new(2, "danger");
        internal static CustomMailcowType Error = new(3, "error");

        internal CustomMailcowType(int id, string name) : base(id, name) { }
    }

    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MailcowType
    {
        Info,
        Success,
        Warning,
        Danger,
        Error
    }
}
