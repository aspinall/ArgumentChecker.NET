﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using static Aspinall.ArgumentChecker.FluentChecker;

namespace Aspinall.ArgumentChecker.Tests
{
    [TestClass]
    public class ArgumentCheckerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsEqualTo_ThrowsException_WhenNotEqual()
        {
            var foo = "foo";

            CheckThat(foo, nameof(foo)).IsEqualTo("bar");
        }

        [TestMethod]
        public void IsEqualTo_ReturnsSelf_WhenEqual()
        {
            var foo = "foo";
            var checker = new ArgumentChecker<string>(foo, nameof(foo));

            Assert.AreSame(checker, checker.IsEqualTo("foo"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsNotDefaultValue_ThrowsException_WhenDefaultValue()
        {
            Guid guid = new Guid();

            CheckThat(guid, nameof(guid)).IsNotDefaultValue();
        }

        [TestMethod]
        public void IsNotDefaultValue_ReturnsSelf_WhenNotDefaultValue()
        {
            Guid guid = Guid.NewGuid();
            var checker = new ArgumentChecker<Guid>(guid, nameof(guid));

            Assert.AreSame(checker, checker.IsNotDefaultValue());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsNotEmpty_ThrowsException_WhenCollectionIsEmpty()
        {
            var collection = new List<string>();

            CheckThat(collection, nameof(collection)).IsNotEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsNotEmpty_ThrowsException_WhenArrayIsEmpty()
        {
            var array = new string[0];

            CheckThat(array, nameof(array)).IsNotEmpty();
        }

        [TestMethod]
        public void IsNotEmpty_ReturnsSelf_WhenNotEmpty()
        {
            var collection = new List<string>
            {
                "foo"
            };
            var checker = new ArgumentChecker<ICollection>(collection, nameof(collection));

            Assert.AreSame(checker, checker.IsNotEmpty());
        }

        [TestMethod]
        public void IsNotEmpty_ReturnsSelf_WhenNotCollection()
        {
            var foo = "foo";
            var checker = new ArgumentChecker<string>(foo, nameof(foo));

            Assert.AreSame(checker, checker.IsNotEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsNotNull_ThrowsException_WhenNull()
        {
            object foo = null;

            CheckThat(foo, nameof(foo)).IsNotNull();
        }

        [TestMethod]
        public void IsNotNull_ReturnsSelf_WhenNotNull()
        {
            var foo = new Object();
            var checker = new ArgumentChecker<Object>(foo, nameof(foo));

            Assert.AreSame(checker, checker.IsNotNull());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsNotNullOrWhitespace_ThrowsException_WhenNull()
        {
            string foo = null;

            CheckThat(foo, nameof(foo)).IsNotNullOrWhitespace();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsNotNullOrWhitespace_ThrowsException_WhenEmptyString()
        {
            var empty = "";

            CheckThat(empty, nameof(empty)).IsNotNullOrWhitespace();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsNotNullOrWhitespace_ThrowsException_WhenBlankString()
        {
            var blank = " ";

            CheckThat(blank, nameof(blank)).IsNotNullOrWhitespace();
        }

        [TestMethod]
        public void IsNotNull_ReturnsSelf_WhenNotNullEmptyOrBlank()
        {
            var foo = "foo";
            var checker = new ArgumentChecker<string>(foo, nameof(foo));

            Assert.AreSame(checker, checker.IsNotNullOrWhitespace());
        }

        [TestMethod]
        public void IsNotNull_ReturnsSelf_WhenNotString()
        {
            var foo = 1234;
            var checker = new ArgumentChecker<int>(foo, nameof(foo));

            Assert.AreSame(checker, checker.IsNotNullOrWhitespace());
        }

        [TestMethod]
        public void Value_ReturnsOriginalValue()
        {
            var foo = "foo";
            var checker = new ArgumentChecker<string>(foo, nameof(foo));

            Assert.AreSame(foo, checker.Value);
        }

        [TestMethod]
        public void IsGreaterThan_ReturnsSelf_WhenGreaterThan()
        {
            var foo = 1;
            var checker = new ArgumentChecker<int>(foo, nameof(foo));

            Assert.AreSame(checker, checker.IsGreaterThan(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsGreaterThan_ThrowsException_WhenEqual()
        {
            var foo = 1;
            CheckThat(foo, nameof(foo)).IsGreaterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsGreaterThan_ThrowsException_WhenLessThan()
        {
            var foo = 1;
            CheckThat(foo, nameof(foo)).IsGreaterThan(2);
        }

        [TestMethod]
        public void IsLessThan_ReturnsSelf_WhenLessThan()
        {
            var foo = 1;
            var checker = new ArgumentChecker<int>(foo, nameof(foo));

            Assert.AreSame(checker, checker.IsLessThan(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsLessThan_ThrowsException_WhenEqual()
        {
            var foo = 1;
            CheckThat(foo, nameof(foo)).IsLessThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsLessThan_ThrowsException_WhenGreaterThan()
        {
            var foo = 1;
            CheckThat(foo, nameof(foo)).IsLessThan(0);
        }
    }
}
