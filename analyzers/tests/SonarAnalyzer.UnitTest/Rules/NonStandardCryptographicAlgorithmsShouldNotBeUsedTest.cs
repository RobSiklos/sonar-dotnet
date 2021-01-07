﻿/*
 * SonarAnalyzer for .NET
 * Copyright (C) 2015-2021 SonarSource SA
 * mailto: contact AT sonarsource DOT com
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

extern alias csharp;
extern alias vbnet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonarAnalyzer.Common;
using SonarAnalyzer.UnitTest.MetadataReferences;
using SonarAnalyzer.UnitTest.TestFramework;
using CSharp = csharp::SonarAnalyzer.Rules.CSharp;
using VisualBasic = vbnet::SonarAnalyzer.Rules.VisualBasic;

namespace SonarAnalyzer.UnitTest.Rules
{
    [TestClass]
    public class NonStandardCryptographicAlgorithmsShouldNotBeUsedTest
    {
        [TestMethod]
        [TestCategory("Rule")]
        public void NonStandardCryptographicAlgorithmsShouldNotBeUsed_CSharp() =>
            Verifier.VerifyAnalyzer(@"TestCases\NonStandardCryptographicAlgorithmsShouldNotBeUsed.cs",
                                    new CSharp.NonStandardCryptographicAlgorithmsShouldNotBeUsed(AnalyzerConfiguration.AlwaysEnabled),
                                    additionalReferences: MetadataReferenceFacade.GetSystemSecurityCryptography());

        [TestMethod]
        [TestCategory("Rule")]
        public void NonStandardCryptographicAlgorithmsShouldNotBeUsed_CSharp_Disabled() =>
            Verifier.VerifyNoIssueReported(@"TestCases\NonStandardCryptographicAlgorithmsShouldNotBeUsed.cs",
                                           new CSharp.NonStandardCryptographicAlgorithmsShouldNotBeUsed(),
                                           additionalReferences: MetadataReferenceFacade.GetSystemSecurityCryptography());

        [TestMethod]
        [TestCategory("Rule")]
        public void NonStandardCryptographicAlgorithmsShouldNotBeUsed_VB() =>
            Verifier.VerifyAnalyzer(@"TestCases\NonStandardCryptographicAlgorithmsShouldNotBeUsed.vb",
                                    new VisualBasic.NonStandardCryptographicAlgorithmsShouldNotBeUsed(AnalyzerConfiguration.AlwaysEnabled),
                                    additionalReferences: MetadataReferenceFacade.GetSystemSecurityCryptography());

        [TestMethod]
        [TestCategory("Rule")]
        public void NonStandardCryptographicAlgorithmsShouldNotBeUsed_VB_Disabled() =>
            Verifier.VerifyNoIssueReported(@"TestCases\NonStandardCryptographicAlgorithmsShouldNotBeUsed.vb",
                                           new VisualBasic.NonStandardCryptographicAlgorithmsShouldNotBeUsed(),
                                           additionalReferences: MetadataReferenceFacade.GetSystemSecurityCryptography());
    }
}