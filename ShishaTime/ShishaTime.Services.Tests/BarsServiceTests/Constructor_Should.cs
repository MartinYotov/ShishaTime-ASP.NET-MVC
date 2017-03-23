﻿using NUnit.Framework;
using System;

namespace ShishaTime.Services.Tests.BarsServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDataIsNull()
        {
            //Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BarsService(null));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenDataIsNull()
        {
            //Arrange, Act & Assert
            Assert.That(() => new BarsService(null),
               Throws.ArgumentNullException.With.Message.Contains("Data cannot be null."));
        }
    }
}
