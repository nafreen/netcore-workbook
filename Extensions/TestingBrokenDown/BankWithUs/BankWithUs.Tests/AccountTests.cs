using System;
using System.Threading.Tasks;
using BankWithUs.Controllers;
using BankWithUs.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BankWithUs.Tests
{
    public class AccountTests
    {
        [Fact]
        public async Task Test_Account_Create()
        {
            //Assemble
            AccountsController controller = new AccountsController();

            //Act
            IActionResult result = await controller.Create(new Account() { Name = "Test", SSN = "078-05-1120" });

            //Assert
            Assert.True(result is ViewResult, "Assert 1");
            var response = (result as ViewResult);
            var responseItem = response.Model as Account;
            Assert.True(responseItem.Name == "Test", "Assert 2");
            Assert.True(responseItem.SSN == "078-05-1120", "Assert 3");
            Assert.True(responseItem.DateCreated != null, "Assert 4");
        }
    }
}
