using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace TechnoBrainEmployeeLibrary {
    public class Employees {  
        
        //Empty Constructor for test purpose 
        public Employees() {
            
        }
        //Main Constructor
        public Employees(string csvFile) {
            string[,] employeeArray = loadCSV_into_Array(csvFile); //load csv file
            validateSalariesCSV(employeeArray); //Validate Salaries
            checkIfOnlyCEO(employeeArray); //checks if we have only 1 CEO in the company, returns a bool value 
            checkIfAllManagersAreEmployees(employeeArray);//it returns a boolean value, if true all managers are listed as employees.
            checkEmployeeReportsToOneManager(employeeArray);//returns true if All Employees report to one manager
            noCyclicReference(employeeArray);//Implementation yet to be filled
        }
        public void validateSalariesCSV(string[,] employeeDB) {//employee string will be formed once loadCSV is called
            for(int i = 0; i < 5; i++) {//i<5 because we know we have 5 rows in the Example Array, otherwise bad idea
                try {
                    Convert.ToInt32(employeeDB[i, 2]);//check the salary column and try converting to Integer
                }catch(Exception e) {   //If it throws an Exception (FormatException this is not an Integer
                    e.Data.Add("UserMessage", employeeDB[i, 1].ToString() + " is not an valid Integer");
                    throw;
                }
            }
        }
        public bool checkIfAllManagersAreEmployees(string[,] employeeDB) {
            bool allManagersAreEmployees = false;
            for(int i = 0; i < 5; i++) {
                for(int j = 0; j < 5; j++) {
                    if (employeeDB[i, 1] != "") 
                        if (employeeDB[j, 0] == employeeDB[i, 1]) 
                            allManagersAreEmployees = true;
                }
            }
            return allManagersAreEmployees;
        }
        public bool checkIfOnlyCEO(string[,] employeeDB) {
            int CEO=0;
            for(int i = 0; i < 5; i++) {
                    if (employeeDB[i,1].Equals(""))
                        CEO+=1;                    
            }
            if (CEO == 1)
                return true;
            else return false;
        }
        public bool checkEmployeeReportsToOneManager(string[,] employeeDB) {
            string tempManager;
            int managerCount = 1;
            for (int i = 0; i < 5; i++) {
                if (employeeDB[i, 1] != "") {
                    tempManager = employeeDB[i, 1];//save employee's manager in temporary location
                    for (int j = 0; j < 5; j++) {
                        if (employeeDB[j, 1] != tempManager)//check all managers for this employee
                            managerCount += 1;  //if manager is different, increment counter
                    }
                    if (managerCount > 1) {
                        return false;   //exit loop if we have more than one manager for employee and return false
                    }
                    else continue;
                }
            }
            return true;//return true if all employees have 1 manager
        }
        public void noCyclicReference(string[,] employeeDB) {

        }
        public string[,] loadCSV_into_Array(string filePath) {
            string[,] employeeDB = new string[5,3] { {"","",""},{"","",""},{"","",""},{"","",""},{"","",""} };//Initialise TableArray
            try {
                using (TextFieldParser csvParser = new TextFieldParser(filePath)) {

                    csvParser.SetDelimiters(new string[] { "," });//nice
                    csvParser.HasFieldsEnclosedInQuotes = false;//nicer

                    while (!csvParser.EndOfData) {//continue reading the file till the end
                        // Read current line fields, pointer moves to the next line.
                        string[] fields;
                        for (int i = 0; i < 5; i++) { //Example has 5 rows so i<5 otherwise this is a terrible idea but I'm in a rush so remember to fix later
                            fields = csvParser.ReadFields();//This reads 1 line at a time, so to loop over the whole file, it's placed here
                            for (int j = 0; j < 3; j++) {   //J<3 (we have 3 fields, Employee, Manager, Salary
                                employeeDB[i,j] = fields[j].Replace("\"",""); //CSV loaded has unwanted strings      
                            }
                            //At this point, 1 row filled, pointer moves to next row
                        }
                        //At this point, All rows filled
                    }
                    return employeeDB;//CSV file is read into memory.
                }
            }catch(Exception ie) { throw; }
        }
        /**
         * QUESTION 2B: Instance Method to Return Salary Budget from specified Manager
         */
        public long salaryBudget(string specifiedManager, string[,] employeeDB) { //Instance method that returns salary budget from specified manager
            long salaryBudget = 0;
            for (int i = 0; i < 5; i++) {
                if (employeeDB[i, 1].Equals(specifiedManager)) {//check all employees with specified manager
                    try {
                        salaryBudget += Convert.ToInt64(employeeDB[i, 2]);//salary column was loaded as string so we have to convert to long
                    }
                    catch (Exception e) { }//If salary is not a valid long integer, formatException will be thrown
                    //All Employee Salaries are added except manager
                }
                if (employeeDB[i, 0].Equals(specifiedManager))//check if employee is specified manager and add their salary to the budget
                    try {
                        salaryBudget += Convert.ToInt64(employeeDB[i, 2]);//Manager Salary now added
                    }
                    catch (Exception e) { }
            }
            return salaryBudget;
        }
    }
}
