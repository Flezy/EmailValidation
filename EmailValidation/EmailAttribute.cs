﻿//
// EmailValidator.cs
//
// Author: Michel Feinstein <michel@feinstein.com.br>
//
// Copyright (c) 2013-2016 Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.ComponentModel.DataAnnotations;

namespace EmailValidation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EmailAttribute : ValidationAttribute
    {
        public EmailAttribute() : this(false, false) { }

        public EmailAttribute(bool allowTopLevelDomains) : this(allowTopLevelDomains, false) { }

        public EmailAttribute (bool allowTopLevelDomains, bool allowInternational)
		{
			AllowTopLevelDomains = allowTopLevelDomains;
			AllowInternational = allowInternational;
		}

		public bool AllowTopLevelDomains { get; }

		public bool AllowInternational { get; }

		protected override ValidationResult IsValid (object value, ValidationContext validationContext)
		{
            if (validationContext == null || validationContext.MemberName == null)
                throw new ArgumentException("Context or the MemberName is null");

			var memberNames = new string[] { validationContext.MemberName };

			if (value == null)
				return new ValidationResult ("Email can't be null", memberNames);

			if (EmailValidator.Validate ((string) value, AllowTopLevelDomains, AllowInternational))
				return ValidationResult.Success;

			return new ValidationResult ("Email invalid", memberNames);
		}
	}
}
