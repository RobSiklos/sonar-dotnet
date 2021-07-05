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

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using SonarAnalyzer.CFG.Helpers;
using StyleCop.Analyzers.Lightup;

namespace SonarAnalyzer.Extensions
{
    public static class PatternSyntaxWrapperExtensions
    {
        public static bool IsNull(this PatternSyntaxWrapper patternSyntaxWrapper) =>
            patternSyntaxWrapper.RemoveParentheses() is var syntaxNode
            && ConstantPatternSyntaxWrapper.IsInstance(syntaxNode)
            && (ConstantPatternSyntaxWrapper)syntaxNode is var constantPattern
            && constantPattern.Expression.Kind() == SyntaxKind.NullLiteralExpression;

        public static bool IsNot(this PatternSyntaxWrapper patternSyntaxWrapper) =>
            patternSyntaxWrapper.RemoveParentheses().Kind() == SyntaxKindEx.NotPattern;

        public static SyntaxNode RemoveParentheses(this PatternSyntaxWrapper patternSyntaxWrapper) =>
            patternSyntaxWrapper.SyntaxNode.RemoveParentheses();
    }
}