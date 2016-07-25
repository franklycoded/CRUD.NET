system("dotnet restore src/Crud.Net.Core")
system("dotnet build -c Release src/Crud.Net.Core")
system("dotnet pack -c Release src/Crud.Net.Core")

system("dotnet restore src/Crud.Net.EntityFramework")
system("dotnet build -c Release src/Crud.Net.EntityFramework")
system("dotnet pack -c Release src/Crud.Net.EntityFramework")

system("dotnet restore src/Crud.Net.Web")
system("dotnet build -c Release src/Crud.Net.Web")
system("dotnet pack -c Release src/Crud.Net.Web")