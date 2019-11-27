using System;
using HelloMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloMVC.Tests
{
    [TestClass]
    public class AdminControllerTests
    {
        [TestMethod]
        public void CanChangeLoginName()
        {
            User user = new User() { LoginName = "Bob" };
            //FakeReoi
        }
    }
}
