## <div align="center">Dr. Sillystringz's Factory</div>
#### <div align="center"> *An application used to track the engineers and machines in Dr Sillystringz's Factory* </div> 
***<p align="center">Made by: Levi Kohler***</p>   
<p align="center">
<br>

<img alt="Made with C#" src="https://img.shields.io/badge/c%23%20-%23239120.svg?&style=for-the-badge&logo=c-sharp&logoColor=white"/>
</p>

___
## 🚩 *Description*:    
### *This is my independent project for week 11 at Epicodus. This application utilizes a Many-To-Many relationship between engineers and machines. Users can add, edit, delete, or pair engineers with machines and vice versa.*


## 🔧 *Setup/Installation instructions:*

* Clone this repository to your Dekstop.
* Navigate to the directory named 'Factory' in the terminal 
* Type 'dotnet restore' in the terminal to download all dependencies   
* Still in the 'Factory' directory, create a file titled 'appsettings.json'
* In 'appsettings.json' copy and paste this code: {
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database={YourFirstName_YourLastName};uid=root;pwd={YourPassword};"
  }
}
* Replace {YourFirstName_YourLastName} with the name of your database, and replace {YourPassword} with your password
* Still in the 'Factory' directory, type 'dotnet ef database update' to download all databases.
* Navigate back to the 'Factory' directory and type 'dotnet run' into the terminal
* Open a browser window and navigate to the URL 'http://localhost:5000'


⚠️ *Note: To run this project locally you will need to have .NET Core. You can check if you have .NET Core by running dotnet --version in the command line. If you do not have .NET Core please find more information and download [here](https://dotnet.microsoft.com/download/dotnet)*

## 🛠️ *Technologies used:*
* C# 9
* Entity Framework Core
* .NET v5.0
* ASP.NET
* REPL
* MySQL Workbench
* Git and GitHub

## 🐛 *Known bugs:*
* No known bugs

## 📬 Contact Information
#### For any questions *[email Levi](mailto:kohler.la01@gmail.com)*



## 📘 *License and copyright:*

> ***© Levi Kohler 2021***  
> ⚖️ *[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)*