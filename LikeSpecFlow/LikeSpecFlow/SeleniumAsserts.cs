﻿using System;
using Xunit;

namespace LikeSpecFlow
{
    public static class SeleniumAsserts
    {
        public static Test AssertForElement_Exists(this Test test, string selector, Action<IWebElement> action = null)
        {
            test.Report(selector);
            var wrapper = test.Get<SeleniumWrapper>();
            var element = wrapper.Find(selector);
            Assert.NotNull(element);
            action?.Invoke(element);
            return test;
        }
    }
}
