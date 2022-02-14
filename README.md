
HCA Lap Report 

This Api appication has used to store and managae the patient test result information and generate the report.

IDE and Library

 - Visual studio 2022
 - Asp.net core
 - InMemory Databse used
 - Swagger
 - Implemented JwtToken authentication

API Reference

login services
 
  POST https://localhost:7282/api/login/Authentication
  GET https://localhost:7282/api/Login/GetCretentialList
  GET https://localhost:7282/api/Login/GetCretentialById?Id
  POST https://localhost:7282/api/Login/AddCretential
  PUT https://localhost:7282/api/Login/ModifyCretential
  DELETE https://localhost:7282/api/Login/DeleteCretential
  
Patient Details Services

  GET https://localhost:7282/api/PatientDetails/GetPatientDetails
  GET https://localhost:7282/api/PatientDetails/GetPatientDetailById?Id
  POST https://localhost:7282/api/PatientDetails/AddPatientDetails
  PUT https://localhost:7282/api/PatientDetails/ModifyPatientDetails
  DELETE https://localhost:7282/api/PatientDetails/DeletePatientDetails?Id

Sample Data
[	  
  {
    "patientId": 1,
    "patientName": "Selvaraj",
    "dob": "11-05-1986",
    "gender": "Male",
    "address": "No 7, Main Road, Anna Nagar",
    "city": "Chennai",
    "state": "Tamil Nadu",
    "country": "India",
    "postalCode": 600077,
    "phone": 93456538
  }
]



Type Of Test Services

  GET https://localhost:7282/api/TypeOfTest/GetTestTypes
  GET https://localhost:7282/api/TypeOfTest/GetTestTypesById?Id
  POST https://localhost:7282/api/TypeOfTest/AddTestTypes
  PUT https://localhost:7282/api/TypeOfTest/AddTestTypes
  DELETE https://localhost:7282/api/TypeOfTest/DeleteTestTypes?Id

Sample Data
[
  {
    "typeId": 1,
    "patientId": 1,
    "testName": "Glugose",
    "isTest": true,
    "enteredDate": "02-11-2022",
    "timeOfTest": "03:10"
  },
  {
    "typeId": 2,
    "patientId": 1,
    "testName": "Complate Blood Count",
    "isTest": true,
    "enteredDate": "02-11-2022",
    "timeOfTest": "03:10"
  },
  {
    "typeId": 3,
    "patientId": 1,
    "testName": "Lipid Panel",
    "isTest": true,
    "enteredDate": "02-11-2022",
    "timeOfTest": "03:10"
  }
]

Test Result Services

  GET https://localhost:7282/api/TestResult/GetTestResult
  GET https://localhost:7282/api/TestResult/GetTestResultById?Id
  POST https://localhost:7282/api/TestResult/AddTestResult
  PUT https://localhost:7282/api/TestResult/AddTestResult
  DELETE https://localhost:7282/api/TestResult/DeleteTestResult?Id

Sample Data

[
  {
    "resultId": 1,
    "patientId": 1,
    "typeId": 1,
    "testSummary": [
      {
        "detailId": 1,
        "resultId": 1,
        "test": "FPG",
        "result": "6"
      },
      {
        "detailId": 2,
        "resultId": 1,
        "test": "OGTT",
        "result": "7.8"
      }
    ]
  },
  {
    "resultId": 2,
    "patientId": 1,
    "typeId": 2,
    "testSummary": [
      {
        "detailId": 3,
        "resultId": 2,
        "test": "Plate Count",
        "result": "300000"
      },
      {
        "detailId": 4,
        "resultId": 2,
        "test": "Hemoglobin",
        "result": "11"
      }
    ]
  },
  {
    "resultId": 3,
    "patientId": 1,
    "typeId": 3,
    "testSummary": [
      {
        "detailId": 5,
        "resultId": 3,
        "test": "Total Cholesterol",
        "result": "200"
      },
      {
        "detailId": 6,
        "resultId": 3,
        "test": "HDL",
        "result": "130"
      }
    ]
  }

Test Report Services

  GET https://localhost:7282/api/TestReports/GetTestReports
  GET https://localhost:7282/api/TestReports/GetTestReportsById?Id
  POST https://localhost:7282/api/TestReports/AddTestReport
  PUT https://localhost:7282/api/TestReports/AddTestReport
  DELETE https://localhost:7282/api/TypeOfTest/DeleteTestReport?Id

Sample Data
[
  {
    "reportId": 1,
    "patientId": 1,
    "reportName": "master Checkup",
    "reportStatus": "Completed",
    "reportDate": "02-11-2022",
    "descriptionSummary": "Normal"
  }
]

Final Generate Report Services

  GET https://localhost:7282/api/GenerateReport/GetGenerateReports
  GET https://localhost:7282/api/TestReports/GetTestReportsByDate?startDate && endDate

Sample Data

[
  {
    "reportId": 1,
    "patientId": 1,
    "patientName": "Selvaraj",
    "reportName": "master Checkup",
    "reportStatus": "Completed",
    "reportDate": "02-11-2022",
    "descriptionSummary": "Normal",
    "typeOfTestCollections": [
      {
        "typeId": 1,
        "typeName": "Glugose",
        "enteredDate": "02-11-2022",
        "timeOfTest": "03:10",
        "testResultCollections": {
          "resultId": 1,
          "resultDetailsCollections": [
            {
              "detailId": 1,
              "test": "FPG",
              "result": "6"
            },
            {
              "detailId": 2,
              "test": "OGTT",
              "result": "7.8"
            }
          ]
        }
      },
      {
        "typeId": 2,
        "typeName": "Complate Blood Count",
        "enteredDate": "02-11-2022",
        "timeOfTest": "03:10",
        "testResultCollections": {
          "resultId": 2,
          "resultDetailsCollections": [
            {
              "detailId": 3,
              "test": "Plate Count",
              "result": "300000"
            },
            {
              "detailId": 4,
              "test": "Hemoglobin",
              "result": "11"
            }
          ]
        }
      },
      {
        "typeId": 3,
        "typeName": "Lipid Panel",
        "enteredDate": "02-11-2022",
        "timeOfTest": "03:10",
        "testResultCollections": {
          "resultId": 3,
          "resultDetailsCollections": [
            {
              "detailId": 5,
              "test": "Total Cholesterol",
              "result": "200"
            },
            {
              "detailId": 6,
              "test": "HDL",
              "result": "130"
            }
          ]
        }
      }
    ]
  }
]

--------------------------------------------------****--------------------------------------------------

