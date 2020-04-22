+ Test Suite ID: TS001
+ Test Case ID:  TC001
+ Test Case Summary:
   + To veryfy that clicking Load Button loads data from file
+ Related Requirement:	RS001
+ Prerequisites   
   1. Target data file exists in workspace
+ Test Procedure
   1. Start and run the program 
   2. Click Load Button
+ Test Data	
   1. Valid test data file in csv 
   2. Corrupted file with wrong format 
   3. Empty file
+ Expected Result	
   1. File loaded and success message pops up 
   2. Fail message pops up 
   3. File loaded with empty chart and success message
+ Actual Result   
   1. File loaded and success message pops up 
   2. Fail message pops up 
   3. File loaded with empty chart and success message
+ Status:   Pass
+ Remarks:
+ Created By:jzhang182
+ Date of Creation:4/22/2020
+ Executed By:jzhang182
+ Date of Execution:4/22/2020
+ Test Environment   
   1. OS: Windows 10 
   2. Software: Visual Studio Professional 2019
---
+ Test Suite ID: TS001
+ Test Case ID:  TC002
+ Test Case Summary:
   + To veryfy that clicking Save Button saves data to file
+ Related Requirement	RS001
+ Prerequisites   
+ Test Procedure
   1. Start and run the program 
   2. Click Save Button
+ Test Data	
   1. Valid data in program grid view
   2. Empty grid view
+ Expected Result	
   1. File saved and success message pops up, csv file is valid
   2. File saved and success message pops up, csv file is valid
+ Actual Result   
   1. File saved and success message pops up, csv file is valid
   2. File saved and success message pops up, csv file is valid
+ Status:   Pass
+ Remarks:
+ Created By:jzhang182
+ Date of Creation:4/22/2020
+ Executed By:jzhang182
+ Date of Execution:4/22/2020
+ Test Environment   
   1. OS: Windows 10 
   2. Software: Visual Studio Professional 2019
---
+ Test Suite ID: TS001
+ Test Case ID:  TC003
+ Test Case Summary:
   + To veryfy that clicking AddNew Button calls up subform
+ Related Requirement	RS001
+ Prerequisites   
+ Test Procedure
   1. Start and run the program 
   2. Click AddNew Button
+ Test Data	
+ Expected Result	
   1. Edit form pops up with correct label texts
+ Actual Result   
   1. Edit form pops up with correct label texts
+ Status:   Pass
+ Remarks:
+ Created By:jzhang182
+ Date of Creation:4/22/2020
+ Executed By:jzhang182
+ Date of Execution:4/22/2020
+ Test Environment   
   1. OS: Windows 10 
   2. Software: Visual Studio Professional 2019
---
+ Test Suite ID: TS001
+ Test Case ID:  TC004
+ Test Case Summary:
   + To veryfy that subform for AddNew is adding new profile into database
+ Related Requirement	RS001
+ Prerequisites   
   1. Program is running with valid database
+ Test Procedure
   1. Click AddNew Button
   2. Enter test data and click save
+ Test Data	
   1. Valid test data
   2. Invalid test data with wrong input format
   3. Empty input
+ Expected Result	
   1. Profile saved and success message pops up 
   2. Fail message pops up with input suggestions
   3. Fail message pops up with input suggestions
+ Actual Result   
   1. Profile saved and success message pops up 
   2. Fail message pops up with input suggestions
   3. Fail message pops up with input suggestions
+ Status:   Pass
+ Remarks:
+ Created By:jzhang182
+ Date of Creation:4/22/2020
+ Executed By:jzhang182
+ Date of Execution:4/22/2020
+ Test Environment   
   1. OS: Windows 10 
   2. Software: Visual Studio Professional 2019
---
+ Test Suite ID: TS001
+ Test Case ID:  TC005
+ Test Case Summary:
   + To veryfy that clicking Delete Button delete data from database
+ Related Requirement	RS001
+ Prerequisites   
   1. Program is running with valid database
+ Test Procedure
   1. Search record with gin and call up search form
   2. Click Delete Button
+ Test Data	
   1. Valid input gin with corresponding record in database
   2. Valid input gin without corresponding record in database
   3. Invalid input gin in wrong format
+ Expected Result	
   1. Record deleted with success message pops up
   2. No corresponding record message pops up
   3. Invalid input message pops up
+ Actual Result   
   1. Record deleted with success message pops up
   2. No corresponding record message pops up
   3. Invalid input message pops up
+ Status:   Pass
+ Remarks:
+ Created By:jzhang182
+ Date of Creation:4/22/2020
+ Executed By:jzhang182
+ Date of Execution:4/22/2020
+ Test Environment   
   1. OS: Windows 10 
   2. Software: Visual Studio Professional 2019
---
+ Test Suite ID: TS001
+ Test Case ID:  TC006
+ Test Case Summary:
   + To veryfy that clicking Edit Button loads data from file
+ Related Requirement	RS001
+ Prerequisites   
   1. Subform is called with Edit option
+ Test Procedure
   1. Start and run the program 
   2. Click Edit Button
+ Test Data	
   1. Valid input gin with corresponding record in database
   2. Valid input gin without corresponding record in database
   3. Invalid input gin in wrong format
+ Expected Result	
   1. Success message pops up and subform is called with edit option
   2. No corresponding record message pops up
   3. Invalid input message pops up
+ Actual Result   
   1. Success message pops up and subform is called with edit option
   2. No corresponding record message pops up
   3. Invalid input message pops up
+ Status:   Pass
+ Remarks:
+ Created By:jzhang182
+ Date of Creation:4/22/2020
+ Executed By:jzhang182
+ Date of Execution:4/22/2020
+ Test Environment   
   1. OS: Windows 10 
   2. Software: Visual Studio Professional 2019
---
+ Test Suite ID: TS001
+ Test Case ID:  TC007
+ Test Case Summary:
   + To veryfy that treeView nodes works properly
+ Related Requirement	RS001
+ Prerequisites   
   1. Valid database is loaded
+ Test Procedure
   1. Click on nodes displayed in treeView
+ Test Data	
   1. Valid database in grid view
+ Expected Result	
   1. All nodes works as filters when selected
+ Actual Result   
   1. All nodes works as filters when selected
+ Status:   Pass
+ Remarks:
+ Created By:jzhang182
+ Date of Creation:4/22/2020
+ Executed By:jzhang182
+ Date of Execution:4/22/2020
+ Test Environment   
   1. OS: Windows 10 
   2. Software: Visual Studio Professional 2019
---
+ Test Suite ID: TS001
+ Test Case ID:  TC008
+ Test Case Summary:
   + To veryfy that sort radiobutton works properly
+ Related Requirement	RS001
+ Prerequisites   
   1. Valid database is loaded
+ Test Procedure
   1. Click on radio buttons and check grid view
+ Test Data	
   1. Valid database in grid view
+ Expected Result	
   1. When "Date" option is selected, grid view sort data by date
   2. When "Employee" option is selected, grid view sort data by employee's name
+ Actual Result   
   1. When "Date" option is selected, grid view sort data by date
   2. When "Employee" option is selected, grid view sort data by employee's name
+ Status:   Pass
+ Remarks:
+ Created By:jzhang182
+ Date of Creation:4/22/2020
+ Executed By:jzhang182
+ Date of Execution:4/22/2020
+ Test Environment   
   1. OS: Windows 10 
   2. Software: Visual Studio Professional 2019
---
+ Test Suite ID: TS001
+ Test Case ID:  TC009
+ Test Case Summary:
   + To veryfy that clicking both Close Button terminate the subform properly
+ Related Requirement	RS001
+ Prerequisites   
   1. Program is started and running
   2. Subform is called
+ Test Procedure
   1. Click the Close button
+ Test Data	
+ Expected Result	
   1. Subform is closed without any modification of database
+ Actual Result   
   1. Subform is closed without any modification of database
+ Status:   Pass
+ Remarks:
+ Created By:jzhang182
+ Date of Creation:4/22/2020
+ Executed By:jzhang182
+ Date of Execution:4/22/2020
+ Test Environment   
   1. OS: Windows 10 
   2. Software: Visual Studio Professional 2019
---
