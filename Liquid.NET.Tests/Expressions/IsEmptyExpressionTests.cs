﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Liquid.NET.Tests.Expressions
{
    [TestFixture]
    public class IsEmptyExpressionTests
    {
        [Test]
        [TestCase("\"\"", "==", true)]
        [TestCase("\" \"", "==", false)]
        [TestCase("\"x\"", "==", false)]
        [TestCase("x", "==", false)]  // nil != empty
        [TestCase("0", "==", false)]
        [TestCase("-1", "==", false)]
        [TestCase("\"  \"", "==", false)]
        [TestCase("null", "==", false)]
        [TestCase("null", "!=", true)]
        [TestCase("\"\"", "!=", false)]
        [TestCase("\" \"", "!=", true)]
        [TestCase("0", "!=", true)]
        public void It_Should_Test_That_A_Value_Is_Empty(String val, String op, bool expected)
        {
            // Arrange
            var expectedStr = expected ? "EMPTY" : "NOT EMPTY";

            // Act
            var tmpl = @"Result : {% if "+val+" "+op+" empty %}EMPTY{% else %}NOT EMPTY{% endif %}";
            Console.WriteLine(tmpl);
            var result = RenderingHelper.RenderTemplate(tmpl);
            Console.WriteLine("Value is " + result);
            // Assert
            Assert.That(result, Is.EqualTo("Result : " + expectedStr));

                
        }

        [Test]
        [TestCase("\"\"", true)]
        [TestCase("\"x\"", false)]
        [TestCase("x", false)]  // nil != empty
        [TestCase("0", false)]
        [TestCase("-1", false)]
        [TestCase("\"  \"", false)]
        public void It_Should_Test_That_Empty_WIth_Question_Mark_Is_Alias(String val, bool expected)
        {
            // Arrange
            var expectedStr = expected ? "EMPTY" : "NOT EMPTY";

            // Act
            var tmpl = @"Result : {% if " + val + ".empty? %}EMPTY{% else %}NOT EMPTY{% endif %}";
            Console.WriteLine(tmpl);
            var result = RenderingHelper.RenderTemplate(tmpl);
            Console.WriteLine("Value is " + result);
            // Assert
            Assert.That(result, Is.EqualTo("Result : " + expectedStr));


        }

    }


}