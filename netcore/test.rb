system ("ruby build.rb")

system("dotnet restore test/Crud.Net.Core.Tests")
system("dotnet build -c Release test/Crud.Net.Core.Tests")
system("dotnet test -c Release test/Crud.Net.Core.Tests")

system("dotnet restore test/Crud.Net.EntityFramework.Tests")
system("dotnet build -c Release test/Crud.Net.EntityFramework.Tests")
system("dotnet test -c Release test/Crud.Net.EntityFramework.Tests")

system("dotnet restore test/Crud.Net.Web.Tests")
system("dotnet build -c Release test/Crud.Net.Web.Tests")
system("dotnet test -c Release test/Crud.Net.Web.Tests")

system ("rm TestResult.xml")