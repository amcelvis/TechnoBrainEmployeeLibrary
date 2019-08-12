
using NUnit.Framework;
using System;
using System.IO;

namespace TechnoBrainEmployeeLibrary {
    [TestFixture]
    class TechnoBrainEmployeeLibraryTests {
        [Test]
        public void LoadCSV_throwExceptionFileNotFound() {//random string "filepath" should throw a FileNotfoundException
            Assert.Throws<FileNotFoundException>(() => new Employees().loadCSV_into_Array("filepath"));
            
        }
        [Test]
        public void validateCSVSalaries_throwExceptionFormatException() {//format Exception is thrown because "" cannot convert to Integer
            Assert.Throws<FormatException>(() => new Employees().validateSalariesCSV(new string[5, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" }, { "", "", "" }, { "", "", "" } }));
        }
        [Test]
        public void checkEmployeeReportsToOneManager_returns_true() {
            //returns true if All Employees report to one manager, example here employees a,c,d,e report to manager b
            Assert.AreEqual(true, new Employees().checkEmployeeReportsToOneManager(new string[5, 3] { { "a", "b", "" }, { "c", "b", "" }, { "d", "b", "" }, { "e", "b", "" }, { "f", "b", "" } }));
        }
        [Test]
        public void checkEmployeeReportsToOneManager_returns_false() {
            //returns true if All Employees report to one manager, employee a reports to manager b & c in this test case
            Assert.AreEqual(false, new Employees().checkEmployeeReportsToOneManager(new string[5, 3] { { "a", "b", "" }, { "a", "c", "" }, { "d", "b", "" }, { "e", "b", "" }, { "f", "b", "" } }));
        }
        [Test] 
       public void SalaryBudget_isNotNull() { //Test Salary Budget is not Null
            Employees emp = new Employees();
            var salaryBudget = emp.salaryBudget("Employee4", new string[5, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" }, { "", "", "" }, { "", "", "" } });
            Assert.IsNotNull(salaryBudget); //check that the salaryBudget Function is not Null
        }
        [Test]
        public void SalaryBudget_returns_long() { //Test Salary Budget with the new test case provided for manager b as Input
            Employees emp = new Employees();
            long expectedValue = 1850;//1850 is expected value based on the provided scenario, 1000+500+200+100+50 with 1000 being salary for manager b (specified manager)
            var salaryBudget = emp.salaryBudget("b", new string[5, 3] { { "b", "", "1000" }, { "c", "b", "500" }, { "d", "b", "200" }, { "e", "b", "100" }, { "f", "b", "50" } });
            Assert.AreEqual(expectedValue,salaryBudget); //check that the salaryBudget is equal to 1850
        }
        [Test]
        public void checkIfOnlyCEO_returns_false() {//2 CEOs provided in this test case CEO b & c, should return false
            string[,] employeeDB = new string[5, 3] { { "a", "b", "" }, { "b", "", "" }, { "c", "", "" }, { "e", "b", "" }, { "f", "c", "" } };//example with 2 CEOs
            Employees emp = new Employees();
            Assert.AreEqual(false,emp.checkIfOnlyCEO(employeeDB)); 
        }
        [Test]
        public void checkIfOnlyCEO_returns_true() {//1 CEOs provided in this test case CEO b, should return true
            string[,] employeeDB = new string[5, 3] { { "a", "b", "" }, { "b", "", "" }, { "c", "b", "" }, { "e", "b", "" }, { "f", "c", "" } };//example with 1 CEOs
            Employees emp = new Employees();
            Assert.AreEqual(true, emp.checkIfOnlyCEO(employeeDB));
        }
        [Test]
        public void checkIfAllManagersAreEmployee_returns_true() {
            //returns true if All Managers Are Listed in the Employees Column, Manager b here is listed in the employee Column it should return true
            Assert.AreEqual(true, new Employees().checkIfAllManagersAreEmployees(new string[5, 3] { { "a", "b", "" }, { "c", "b", "" }, { "b", "", "" }, { "e", "b", "" }, { "f", "b", "" } }));
        }
        [Test]
        public void checkIfAllManagersAreEmployee_returns_false() {
            //returns true if All Managers Are Listed in the Employees Column, Manager b here is not listed in the employee Column it should return false
            Assert.AreEqual(false, new Employees().checkIfAllManagersAreEmployees(new string[5, 3] { { "a", "b", "" }, { "c", "b", "" }, { "d", "b", "" }, { "e", "b", "" }, { "f", "b", "" } }));
        }
    }
}
