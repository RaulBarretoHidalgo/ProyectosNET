 
 dotnet new sln --name EP_Planning_Back			 
 
 dotnet new classlib -lang C# -o EP_Planning_BackMicroservice.Infraestructure  -f net5.0
 dotnet sln .\EP_Planning_Back.sln add .\EP_Planning_BackMicroservice.Infraestructure\EP_Planning_BackMicroservice.Infraestructure.csproj -s "01. Layer Infraestructure"
 
 dotnet new classlib -lang C# -o EP_Planning_BackMicroservice.Repository  -f net5.0
 dotnet sln .\EP_Planning_Back.sln add .\EP_Planning_BackMicroservice.Repository\EP_Planning_BackMicroservice.Repository.csproj -s "01. Layer Infraestructure"
 
 dotnet new classlib -lang C# -o EP_Planning_BackMicroservice.Domain  -f net5.0
 dotnet sln .\EP_Planning_Back.sln add .\EP_Planning_BackMicroservice.Domain\EP_Planning_BackMicroservice.Domain.csproj -s "02. Layer Domain"
 
 dotnet new classlib -lang C# -o EP_Planning_BackMicroservice.Entities  -f net5.0
 dotnet sln .\EP_Planning_Back.sln add .\EP_Planning_BackMicroservice.Entities\EP_Planning_BackMicroservice.Entities.csproj -s "02. Layer Domain"	
 
 mkdir "EP_Planning_BackMicroservice.Entities/Enums"
 mkdir "EP_Planning_BackMicroservice.Entities/Filter"
 mkdir "EP_Planning_BackMicroservice.Entities/Model"
 mkdir "EP_Planning_BackMicroservice.Entities/Request"
 mkdir "EP_Planning_BackMicroservice.Entities/Response"
 
 dotnet new classlib -lang C# -o EP_Planning_BackMicroservice.Exceptions  -f net5.0
 dotnet sln .\EP_Planning_Back.sln add .\EP_Planning_BackMicroservice.Exceptions\EP_Planning_BackMicroservice.Exceptions.csproj -s "02. Layer Domain"
  
 dotnet new classlib -lang C# -o EP_Planning_BackMicroservice.Service  -f net5.0
 dotnet sln .\EP_Planning_Back.sln add .\EP_Planning_BackMicroservice.Service\EP_Planning_BackMicroservice.Service.csproj -s "03. Layer Api"	
 
 dotnet new classlib -lang C# -o Util  -f net5.0
 dotnet sln .\EP_Planning_Back.sln add .\Util\Util.csproj -s "04. Util"
 
 dotnet new webapi --name EP_Planning_BackMicroservice.Api
 dotnet sln .\EP_Planning_Back.sln add .\EP_Planning_BackMicroservice.Api	-s "03. Layer Api"
 


 dotnet add .\Util\Util.csproj package System.Composition -v 1.4.0
 dotnet add .\Util\Util.csproj package Microsoft.Extensions.Configuration -v 3.1.3

 dotnet add .\EP_Planning_BackMicroservice.Repository\EP_Planning_BackMicroservice.Repository.csproj reference .\EP_Planning_BackMicroservice.Entities\EP_Planning_BackMicroservice.Entities.csproj


 dotnet add .\EP_Planning_BackMicroservice.Infraestructure\EP_Planning_BackMicroservice.Infraestructure.csproj package Dapper -v 2.0.35
 dotnet add .\EP_Planning_BackMicroservice.Infraestructure\EP_Planning_BackMicroservice.Infraestructure.csproj package System.Composition -v 1.4.0
 dotnet add .\EP_Planning_BackMicroservice.Infraestructure\EP_Planning_BackMicroservice.Infraestructure.csproj package Microsoft.Extensions.Configuration -v 3.1.3
  
 dotnet add .\EP_Planning_BackMicroservice.Infraestructure\EP_Planning_BackMicroservice.Infraestructure.csproj reference .\EP_Planning_BackMicroservice.Entities\EP_Planning_BackMicroservice.Entities.csproj
 dotnet add .\EP_Planning_BackMicroservice.Infraestructure\EP_Planning_BackMicroservice.Infraestructure.csproj reference .\EP_Planning_BackMicroservice.Repository\EP_Planning_BackMicroservice.Repository.csproj
 dotnet add .\EP_Planning_BackMicroservice.Infraestructure\EP_Planning_BackMicroservice.Infraestructure.csproj reference .\Util\Util.csproj
 
 
 dotnet add .\EP_Planning_BackMicroservice.Domain\EP_Planning_BackMicroservice.Domain.csproj package System.Composition -v 1.4.0

 dotnet add .\EP_Planning_BackMicroservice.Domain\EP_Planning_BackMicroservice.Domain.csproj reference .\EP_Planning_BackMicroservice.Entities\EP_Planning_BackMicroservice.Entities.csproj
 dotnet add .\EP_Planning_BackMicroservice.Domain\EP_Planning_BackMicroservice.Domain.csproj reference .\EP_Planning_BackMicroservice.Exceptions\EP_Planning_BackMicroservice.Exceptions.csproj
 dotnet add .\EP_Planning_BackMicroservice.Domain\EP_Planning_BackMicroservice.Domain.csproj reference .\EP_Planning_BackMicroservice.Repository\EP_Planning_BackMicroservice.Repository.csproj
 dotnet add .\EP_Planning_BackMicroservice.Domain\EP_Planning_BackMicroservice.Domain.csproj reference .\Util\Util.csproj
 
 
 dotnet add .\EP_Planning_BackMicroservice.Service\EP_Planning_BackMicroservice.Service.csproj reference .\EP_Planning_BackMicroservice.Domain\EP_Planning_BackMicroservice.Domain.csproj
 dotnet add .\EP_Planning_BackMicroservice.Service\EP_Planning_BackMicroservice.Service.csproj reference .\EP_Planning_BackMicroservice.Entities\EP_Planning_BackMicroservice.Entities.csproj
 dotnet add .\EP_Planning_BackMicroservice.Service\EP_Planning_BackMicroservice.Service.csproj reference .\EP_Planning_BackMicroservice.Exceptions\EP_Planning_BackMicroservice.Exceptions.csproj
 

 dotnet add .\EP_Planning_BackMicroservice.Api\EP_Planning_BackMicroservice.Api.csproj reference .\EP_Planning_BackMicroservice.Entities\EP_Planning_BackMicroservice.Entities.csproj
 dotnet add .\EP_Planning_BackMicroservice.Api\EP_Planning_BackMicroservice.Api.csproj reference .\EP_Planning_BackMicroservice.Infraestructure\EP_Planning_BackMicroservice.Infraestructure.csproj	
 dotnet add .\EP_Planning_BackMicroservice.Api\EP_Planning_BackMicroservice.Api.csproj reference .\EP_Planning_BackMicroservice.Service\EP_Planning_BackMicroservice.Service.csproj	
 dotnet add .\EP_Planning_BackMicroservice.Api\EP_Planning_BackMicroservice.Api.csproj reference .\Util\Util.csproj	
 
 
 dotnet add .\EP_Planning_BackMicroservice.Api\EP_Planning_BackMicroservice.Api.csproj package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 3.1.2
 dotnet add .\EP_Planning_BackMicroservice.Api\EP_Planning_BackMicroservice.Api.csproj package Swashbuckle.AspNetCore -v 5.4.1
 
 
 
 
 
 
 
 
 
 

 
 
 