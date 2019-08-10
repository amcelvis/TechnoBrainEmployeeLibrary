
using NUnit.Framework;
using System;

namespace TechnoBrainEmployeeLibrary {
    [TestFixture]
    class TechnoBrainEmployeeLibraryTests {
        [Test]
        public void LoadCSV_throwExceptionFileNotFound() {
            Assert.Throws<Exception>(() => new Employees().loadCSV_into_Array("test filepath string"));
            //Assert.That(ex.Message, Is.EqualTo());
        }
        [Test]
        public void validateCSVSalaries_throwExceptionFormatException() {
            Assert.Throws<Exception>(() => new Employees().validateSalariesCSV());
        }

       [Test] 
       public void SalaryBudget_isNotNull() { //Test Salary Budget is not Null
            Employees emp = new Employees();
            var salaryBudget = emp.salaryBudget("Employee4");
            Assert.IsNotNull(salaryBudget); //check that the salary is 
        }

        [Test]
        public void checkifCEO_returns_bool() {
            string[,] employeeD = new string[2,2] { {"","" }, { "", "" } };
            Employees emp = new Employees();
            Assert.IsFalse(emp.CheckifOnlyCEO(employeeD)); 
        }
    }
}
