# Online Bank

This is a Windows Form application that allows users to manage basic banking system. It provides features for creating user profile, managing accounts, and requesting for loans. Users can add transactions, apply for loan, and view their banking information in a user-friendly interface. The application also supports admin access system to monitor the banking system from the application.

## Getting Started

To get a local copy of the project up and running, follow these steps:

### Prerequisites

- [.NET Framework](https://dotnet.microsoft.com/download) installed on your machine.

### Database Setup

This application uses a MySQL database for storing and managing data. Follow these steps to set up the database:

1. Ensure that you have MySQL Server and MySQL Workbench installed on your machine.  
2. Open MySQL Workbench and establish a connection to your local MySQL Server.
3. In MySQL Workbench, go to File > Open Model and navigate to the repository's database file (bank.sql).
4. Once the model is open, click on Database > Forward Engineer to generate the SQL script for creating the database.
5. Review the generated script and click Next to execute it. This will create the necessary tables, columns, and relationships in the database.
6. After the script is executed successfully, you should have the database set up and ready to be used by the Windows Form application.
7. Update the connection string in your application's code to point to the newly created database. The connection string typically includes the server, username, password, and database name.
  ```
  string connectionString = "server=localhost;user=root;password=yourpassword;database=yourdatabase;";
  ```
### Installation

1. Clone the repository:
   ```shell
   git clone https://github.com/asiftm/OnlineBank.
   ```
2. Open the solution file (OnlineBank.sln) in Visual Studio.

3. Build the solution to restore NuGet packages and compile the project.

4. Run the application using the Visual Studio debugger or by pressing Ctrl + F5.

### Features
1. User registration and login functionality.

2. Dashboard displaying an overview of the user's banking information.

3. Accounts : User's ability to open ultiple bank accounts and managing them.

4. Transacton : Send and receive functionality.

5. Loan management: Apply and pay the loan in installments.

6. User details modification including profile picture.

7. Admin access.

### Screenshots
![Screenshot 1]([Screenshots\Screenshot 2023-06-13 041026.png](https://github.com/asiftm/OnlineBank/blob/main/Screenshots/Screenshot%202023-06-13%20041026.png))
