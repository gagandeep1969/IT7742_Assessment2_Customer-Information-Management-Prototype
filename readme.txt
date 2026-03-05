# Customer + Bank Prototype for IT7742 Assessment2

____Overview
This repository has two parts.

________________Task 1 (Customer MVC Prototype)
This part is a prototype to manage customer details using the MVC pattern.
It stores basic customer data like:
- Customer ID
- First Name
- Last Name

The code is separated into:
- Model (Customer data class)
- Controller (handles add, update, delete, and validation)
- View (WinForms UI)


______________Task 2 (Bank Accounts + Exception + Unit Tests)
This part is based on Assessment 1 consoleapp code.
It includes:
- Account classes (Everyday, Investment, Omni)
- A custom exception for failed withdrawals (`FailedWithdrawalException`)
- Unit tests (MSTest) for deposit, withdraw, interest, and customer contact update

When a withdrawal fails, the account still applies the failed fee like before, and now it also throws the exception.

___________________________________________________________________________________________________________________

## Requirements
- Visual Studio 2022 
- .NET 6 or later 

---

## How to Open the Solution
1. Download or clone the repository.
2. Open the `.sln` file in Visual Studio.

---

## Task 1
1. In Visual Studio, select the Task 1 project as the Startup Project.
   - Right click the Task 1 project and Set as Startup Project
2. Build:
 Build Solution
3. Run:
Press F5 or click the green Run button

### What to test in the UI
- Add a new customer (unique ID)
- Update an existing customer (same ID)
- Delete an existing customer
- Try invalid input (empty name, negative ID) and see error messages

---

## Task 2: MS Tests using code from Assessment 1
1. In Visual Studio, select `BankApp` as the Startup Project.
   - Right click `BankApp` and Set as Startup Project
2. Build:
   - Build Solution
3. Run:
   - Go to Test > Test Explorer > Run All Tests 

## Expected result
All tests should show as **Passed** in Test Explorer.


## Submission Folder Contains 
- Task 1 Folder :
  - Models (Customer)
  - Controllers (CustomerController)
  - Views (WinForms forms)
  - Req. Analysis and Controller Design report
  - Video Demo of WInForm (MVC Prototype)
- Task 2 Folder  contains:
  - Bank App Project form Assessment 1 
  - Exceptions/FailedWithdrawalException.cs`
  - BankAppTests

________________________________________________________________________________________
