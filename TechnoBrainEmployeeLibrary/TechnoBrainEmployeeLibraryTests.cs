
using NUnit.Framework;
using System;
using System.IO;

namespace TechnoBrainEmployeeLibrary {
    [TestFixture]
    class TechnoBrainEmployeeLibraryTests {
        [Test]
        public void LoadCSV_throwExceptionFileNotFound() {
            Assert.Throws<FileNotFoundException>(() => new Employees().loadCSV_into_Array("test filepath string"));
            
        }
        [Test]
        public void validateCSVSalaries_throwExceptionFormatException() {//if salary column doesn't contain valid integers ensure exception is thrown
            Assert.Throws<FormatException>(() => new Employees().validateSalariesCSV(new string[5, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" }, { "", "", "" }, { "", "", "" } }));
        }

       [Test] 
       public void SalaryBudget_isNotNull() { //Test Salary Budget is not Null
            Employees emp = new Employees();
            var salaryBudget = emp.salaryBudget("Employee4", new string[5, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" }, { "", "", "" }, { "", "", "" } });
            Assert.IsNotNull(salaryBudget); //check that the salaryBudget Function is not Null
        }

        [Test]
        public void checkIfOnlyCEO_returns_bool() {
            string[,] employeeD = new string[5, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" }, { "", "", "" }, { "", "", "" } };
            Employees emp = new Employees();
            Assert.AreEqual(false,emp.checkIfOnlyCEO(employeeD)); 
        }
    }
}
