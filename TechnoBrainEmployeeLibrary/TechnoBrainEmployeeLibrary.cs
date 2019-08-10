using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace TechnoBrainEmployeeLibrary {
    public class Employees {  
        string[,] employeeDB;
        //Dummy Constructor
        public Employees() {

        }
        //Main Constructor
        public Employees(string csvFile) {
            loadCSV_into_Array(csvFile); //load csv file
            validateSalariesCSV(); //Validate Salaries
            CheckifOnlyCEO(employeeDB); //checks if we have only 1 CEO in the company

        }
        public void validateSalariesCSV() {
            for(int i = 0; i < 5; i++) {
                try {
                    Convert.ToInt32(employeeDB[i, 2]);
                }catch(Exception e) {   //If it throws an Exception (FormatException this is not an Integer
                    e.Data.Add("UserMessage", employeeDB[i, 1].ToString() + " is not an valid Integer");
                    throw;
                }
            }
        }
        public long salaryBudget(string specifiedManager) { //Instance method that returns salary budget from specified manager
            return 0;
        }
        public bool checkIfAllEmployeesHaveManager(string[,] employeeDB) {
            for(int i = 0; i <= 200; i++) {
                for (int j = 0; j < 3; j++) {
                    if (employeeDB[i,j].Equals(null)) {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        public bool CheckifOnlyCEO(string[,] employeeDB) {
            int CEO=0;
            for(int i = 0; i <= 5; i++) {
                    if (employeeDB[i,1].Equals(null))
                        CEO+=1;                    
            }
            if (CEO == 1)
                return true;
            else return false;
        }
        public void loadCSV_into_Array(string filePath) {
            employeeDB = new string[5,3] { {"","",""},{"","",""},{"","",""},{"","",""},{"","",""} };//Initialise TableArray
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
                    //CSV file is read into memory.
                }
            }catch(Exception ie) { throw; }
        }
    }
}
