﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace Microsoft.AspNetCore.Razor.Language
{
    public abstract class RazorIRPassBase : RazorEngineFeatureBase
    {
        /// <summary>
        /// The default implementation of the <see cref="IRazorEngineFeature"/>s that run in a
        /// <see cref="IRazorEnginePhase"/> will use this value for its Order property.
        /// </summary>
        /// <remarks>
        /// This value is chosen in such a way that the default implementation runs after the other
        /// custom <see cref="IRazorEngineFeature"/> implementations for a particular <see cref="IRazorEnginePhase"/>.
        /// </remarks>
        public static readonly int DefaultFeatureOrder = 1000;

        public virtual int Order { get; }

        public void Execute(RazorCodeDocument codeDocument, DocumentIRNode irDocument)
        {
            if (codeDocument == null)
            {
                throw new ArgumentNullException(nameof(codeDocument));
            }

            if (irDocument == null)
            {
                throw new ArgumentNullException(nameof(irDocument));
            }

            if (Engine == null)
            {
                throw new InvalidOperationException(Resources.FormatPhaseMustBeInitialized(nameof(Engine)));
            }

            ExecuteCore(codeDocument, irDocument);
        }

        protected abstract void ExecuteCore(RazorCodeDocument codeDocument, DocumentIRNode irDocument);
    }
}
