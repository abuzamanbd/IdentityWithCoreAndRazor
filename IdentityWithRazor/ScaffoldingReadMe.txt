Support for ASP.NET Core Identity was added to your project.

For setup and configuration information, see https://go.microsoft.com/fwlink/?linkid=2116645.

//DBContext update command
Scaffold-DbContext "server=RTL-DEV-11;persistsecurityinfo=True;database=Identity" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DAL/Models -f
