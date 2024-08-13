namespace Clean.Infrastructure
{
    public class CreateCrudProject
    {
        public void CraeteAProject()
        {
            // Specify the desired root path for the folder structure
            string rootPath = @"D:\My Projects"; // Replace with your preferred path

            // Create the main "Test" folder
            Directory.CreateDirectory(rootPath);

            // Create the subfolders
            Directory.CreateDirectory(Path.Combine(rootPath, "Test.Application"));
            Directory.CreateDirectory(Path.Combine(rootPath, "Test.Domain"));
            Directory.CreateDirectory(Path.Combine(rootPath, "Test.Infrastructure"));
            Directory.CreateDirectory(Path.Combine(rootPath, "Test.API"));
            Directory.CreateDirectory(Path.Combine(rootPath, "Test.API", "Properties"));

            // Create the files within each subfolder
            CreateFile("Test.Application.csproj", rootPath + @"\Test.Application\", GetApplicationProjectContent());
            CreateFile("Test.Domain.csproj", rootPath + @"\Test.Domain\", GetDomainProjectContent());
            CreateFile("Test.Domain.sln", rootPath + @"\Test.Domain\", GetSolutionFileContent());
            CreateFile("Test.Infrastructure.csproj", rootPath + @"\Test.Infrastructure\", GetInfrastructureProjectContent());
            CreateFile("Test..API.csproj", rootPath + @"\Test.API", GetAPIProjectContent());
            CreateFile("Test..API.csproj.user", rootPath + @"\Test.API", GetAPIUserProjectContent());
            CreateFile("appsettings.json", rootPath + @"\Test.API", GetAppSettingContent());
            CreateFile("appsettings.Development.json", rootPath + @"\Test.API", GetAppSettingDevelopmentContent());
            CreateFile("Program.cs", rootPath + @"\Test.API", GetProgramCsContent());
            CreateFile("launchSettings.json", rootPath + @"\Test.API\Properties", GetLaunchSettingsContent());
            Console.WriteLine("Folders and files created successfully!");
        }
        static void CreateFile(string fileName, string filePath, string fileContent)
        {
            try
            {
                File.WriteAllText(Path.Combine(filePath, fileName), fileContent);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error creating file: " + ex.Message);
            }
        }

        // Methods to provide file content for different files
        static string GetApplicationProjectContent()
        {
            return @"<Project Sdk=""Microsoft.NET.Sdk"">
                      <PropertyGroup>
                        <TargetFramework>net6.0</TargetFramework>
                        <ImplicitUsings>enable</ImplicitUsings>
                        <Nullable>enable</Nullable>
                      </PropertyGroup>

                      <ItemGroup>
                        <PackageReference Include=""AutoMapper"" Version=""12.0.1"" />
                      </ItemGroup>

                      <ItemGroup>
                        <ProjectReference Include=""..\Test.Domain\Test.Domain.csproj"" />
                      </ItemGroup>

                    </Project>";
        }
        static string GetDomainProjectContent()
        {
            return @"<Project Sdk=""Microsoft.NET.Sdk"">
                      <PropertyGroup>
                        <TargetFramework>net6.0</TargetFramework>
                        <ImplicitUsings>enable</ImplicitUsings>
                        <Nullable>enable</Nullable>
                      </PropertyGroup>

                </Project>";
        }
        static string GetSolutionFileContent()
        {
            return @"Microsoft Visual Studio Solution File, Format Version 12.00
                    # Visual Studio Version 17
                    VisualStudioVersion = 17.8.34330.188
                    MinimumVisualStudioVersion = 10.0.40219.1
                    Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Test.Domain"", ""Test.Domain.csproj"", ""{992F8400-62BB-4B65-9FE0-407DC29E63C7}""
                    EndProject
                    Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Test.Application"", ""..\Test.Application\Test.Application.csproj"", ""{9E829E80-C640-4874-9ED4-4C82562F86D5}""
                    EndProject
                    Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Test.Infrastructure"", ""..\Test.Infrastructure\Test.Infrastructure.csproj"", ""{63662DA9-EFDA-40E3-80DD-4154309DDC7C}""
                    EndProject
                    Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Test.API"", ""..\Test.API\Test.API.csproj"", ""{CF7FF730-9423-4324-BD96-F348DD9826E0}""
                    EndProject
                    Global
                        GlobalSection(SolutionConfigurationPlatforms) = preSolution
                            Debug | Any CPU = Debug | Any CPU
                            Release | Any CPU = Release | Any CPU
                        EndGlobalSection
                        GlobalSection(ProjectConfigurationPlatforms) = postSolution
                            {992F8400-62BB-4B65-9FE0-407DC29E63C7}.Debug | Any CPU.ActiveCfg = Debug | Any CPU
                            {992F8400-62BB-4B65-9FE0-407DC29E63C7}.Debug | Any CPU.Build.0 = Debug | Any CPU
                            {992F8400-62BB-4B65-9FE0-407DC29E63C7}.Release | Any CPU.ActiveCfg = Release | Any CPU
                            {992F8400-62BB-4B65-9FE0-407DC29E63C7}.Release | Any CPU.Build.0 = Release | Any CPU
                            {9E829E80-C640-4874-9ED4-4C82562F86D5}.Debug | Any CPU.ActiveCfg = Debug | Any CPU
                            {9E829E80-C640-4874-9ED4-4C82562F86D5}.Debug | Any CPU.Build.0 = Debug | Any CPU
                            {9E829E80-C640-4874-9ED4-4C82562F86D5}.Release | Any CPU.ActiveCfg = Release | Any CPU
                            {9E829E80-C640-4874-9ED4-4C82562F86D5}.Release | Any CPU.Build.0 = Release | Any CPU
                            {63662DA9-EFDA-40E3-80DD-4154309DDC7C}.Debug | Any CPU.ActiveCfg = Debug | Any CPU
                            {63662DA9-EFDA-40E3-80DD-4154309DDC7C}.Debug | Any CPU.Build.0 = Debug | Any CPU
                            {63662DA9-EFDA-40E3-80DD-4154309DDC7C}.Release | Any CPU.ActiveCfg = Release | Any CPU
                            {63662DA9-EFDA-40E3-80DD-4154309DDC7C}.Release | Any CPU.Build.0 = Release | Any CPU
                            {CF7FF730-9423-4324-BD96-F348DD9826E0}.Debug | Any CPU.ActiveCfg = Debug | Any CPU
                            {CF7FF730-9423-4324-BD96-F348DD9826E0}.Debug | Any CPU.Build.0 = Debug | Any CPU
                            {CF7FF730-9423-4324-BD96-F348DD9826E0}.Release | Any CPU.ActiveCfg = Release | Any CPU
                            {CF7FF730-9423-4324-BD96-F348DD9826E0}.Release | Any CPU.Build.0 = Release | Any CPU
                        EndGlobalSection
                        GlobalSection(SolutionProperties) = preSolution
                            HideSolutionNode = FALSE
                        EndGlobalSection
                        GlobalSection(ExtensibilityGlobals) = postSolution
                            SolutionGuid = {E24ADB49-B3A3-41C1-8C95-BF17B715A361}
                        EndGlobalSection
                    EndGlobal";
        }
        static string GetInfrastructureProjectContent()
        {
            return @"<Project Sdk=""Microsoft.NET.Sdk"">
                      <PropertyGroup>
                        <TargetFramework>net6.0</TargetFramework>
                        <ImplicitUsings>enable</ImplicitUsings>
                        <Nullable>enable</Nullable>
                      </PropertyGroup>

                      <ItemGroup>
                        <PackageReference Include=""AutoMapper"" Version=""12.0.1"" />
                        <PackageReference Include=""Microsoft.EntityFrameworkCore.Design"" Version=""6.0.25"">
                          <PrivateAssets>all</PrivateAssets>
                          <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
                        </PackageReference>
                        <PackageReference Include=""Microsoft.EntityFrameworkCore.SqlServer"" Version=""6.0.25"" />
                      </ItemGroup>

                      <ItemGroup>
                        <ProjectReference Include=""..\Test.Application\Test.Application.csproj"" />
                        <ProjectReference Include=""..\Test.Domain\Test.Domain.csproj"" />
                      </ItemGroup>

                   </Project>";
        }
        static string GetAPIProjectContent()
        {
            return @"<Project Sdk=""Microsoft.NET.Sdk.Web"">
                      <PropertyGroup>
                        <TargetFramework>net6.0</TargetFramework>
                        <Nullable>enable</Nullable>
                        <ImplicitUsings>enable</ImplicitUsings>
                      </PropertyGroup>

                      <ItemGroup>
                        <PackageReference Include=""AutoMapper.Extensions.Microsoft.DependencyInjection"" Version=""12.0.1"" />
                        <PackageReference Include=""Microsoft.EntityFrameworkCore.Tools"" Version=""6.0.25"">
                          <PrivateAssets>all</PrivateAssets>
                          <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
                        </PackageReference>
                        <PackageReference Include=""Swashbuckle.AspNetCore"" Version=""6.5.0"" />
                      </ItemGroup>

                      <ItemGroup>
                        <ProjectReference Include=""..\Test.Application\Test.Application.csproj"" />
                        <ProjectReference Include=""..\Test.Domain\Test.Domain.csproj"" />
                        <ProjectReference Include=""..\Test.Infrastructure\Test.Infrastructure.csproj"" />
                      </ItemGroup>

                    </Project>";
        }
        static string GetAPIUserProjectContent()
        {
            return @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <Project ToolsVersion=""Current"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
                      <PropertyGroup>
                        <Controller_SelectedScaffolderID>ApiControllerEmptyScaffolder</Controller_SelectedScaffolderID>
                        <Controller_SelectedScaffolderCategoryPath>root/Common/Api</Controller_SelectedScaffolderCategoryPath>
                      </PropertyGroup>
                    </Project>";
        }
        static string GetAppSettingContent()
        {
            return @"{
                      ""Logging"": {
                        ""LogLevel"": {
                          ""Default"": ""Information"",
                          ""Microsoft.AspNetCore"": ""Warning""
                        }
                      },
                      ""ConnectionStrings"": {
                        ""DefaultConnection"": ""Server=DESKTOP-4CAQ0SM;Database=TestDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;""
                      },
                      ""AllowedHosts"": ""*""
                    }";
        }
        static string GetAppSettingDevelopmentContent()
        {
            return @"{
                      ""Logging"": {
                        ""LogLevel"": {
                          ""Default"": ""Information"",
                          ""Microsoft.AspNetCore"": ""Warning""
                        }
                      }
                    }";
        }
        static string GetProgramCsContent()
        {
            return @"using Teest.Infrastructure;
                    using Microsoft.EntityFrameworkCore;
                    var builder = WebApplication.CreateBuilder(args);

                    // Add services to the container.
                    builder.Services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString(""DefaultConnection"")));

                    builder.Services.AddControllers();
                    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                    builder.Services.AddEndpointsApiExplorer();
                    builder.Services.AddSwaggerGen();

                    var app = builder.Build();

                    // Configure the HTTP request pipeline.
                    if (app.Environment.IsDevelopment())
                    {
                        app.UseSwagger();
                        app.UseSwaggerUI();
                    }

                    app.UseHttpsRedirection();

                    app.UseAuthorization();

                    app.MapControllers();

                    app.Run();
                    ";
        }
        static string GetLaunchSettingsContent()
        {
            return @"{
                      ""$schema"": ""https://json.schemastore.org/launchsettings.json"",
                      ""iisSettings"": {
                        ""windowsAuthentication"": false,
                        ""anonymousAuthentication"": true,
                        ""iisExpress"": {
                          ""applicationUrl"": ""http://localhost:54795"",
                          ""sslPort"": 44333
                        }
                      },
                      ""profiles"": {
                        ""Clean.API"": {
                          ""commandName"": ""Project"",
                          ""dotnetRunMessages"": true,
                          ""launchBrowser"": true,
                          ""launchUrl"": ""swagger"",
                          ""applicationUrl"": ""https://localhost:7059;http://localhost:5220"",
                          ""environmentVariables"": {
                            ""ASPNETCORE_ENVIRONMENT"": ""Development""
                          }
                        },
                        ""IIS Express"": {
                          ""commandName"": ""IISExpress"",
                          ""launchBrowser"": true,
                          ""launchUrl"": ""swagger"",
                          ""environmentVariables"": {
                            ""ASPNETCORE_ENVIRONMENT"": ""Development""
                          }
                        }
                      }
                    }";
        }
    }
}
