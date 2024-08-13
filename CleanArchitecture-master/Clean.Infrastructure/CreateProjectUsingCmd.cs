using System.Diagnostics;
namespace Clean.Infrastructure
{
    public class CreateProjectUsingCmd
    {
        public void CreateProjectCmd() {
            string targetFolder = @"D:\My Projects";
            string projectName = "TestProject";
            ExecuteCommand("dotnet", $"new sln -n {projectName}", targetFolder);

            // Step 3: Create Domain Project
            ExecuteCommand("dotnet", $"new classlib --framework net6.0 -n {projectName}.Domain -o {projectName}.Domain", targetFolder);
            ExecuteCommand("dotnet", $"sln add {projectName}.Domain/{projectName}.Domain.csproj", targetFolder);

            // Step 4: Create Infrastructure Project
            ExecuteCommand("dotnet", $"new classlib --framework net6.0 -n {projectName}.Infrastructure -o {projectName}.Infrastructure", targetFolder);
            ExecuteCommand("dotnet", $"sln add {projectName}.Infrastructure/{projectName}.Infrastructure.csproj", targetFolder);

            // Step 5: Create Application Project
            ExecuteCommand("dotnet", $"new classlib --framework net6.0 -n {projectName}.Application -o {projectName}.Application", targetFolder);
            ExecuteCommand("dotnet", $"sln add {projectName}.Application/{projectName}.Application.csproj", targetFolder);

            // Step 6: Create API Project
            ExecuteCommand("dotnet", $"new webapi --framework net6.0 -n {projectName}.API -o {projectName}.API", targetFolder);
            ExecuteCommand("dotnet", $"sln add {projectName}.API/{projectName}.API.csproj", targetFolder);

            // Step 7: Add Project References
            ExecuteCommand("dotnet", $"add {projectName}.Application/{projectName}.Application.csproj reference {projectName}.Domain/{projectName}.Domain.csproj", targetFolder);
            ExecuteCommand("dotnet", $"add {projectName}.Infrastructure/{projectName}.Infrastructure.csproj reference {projectName}.Domain/{projectName}.Domain.csproj", targetFolder);
            ExecuteCommand("dotnet", $"add {projectName}.API/{projectName}.API.csproj reference {projectName}.Application/{projectName}.Application.csproj", targetFolder);
            ExecuteCommand("dotnet", $"add {projectName}.API/{projectName}.API.csproj reference {projectName}.Infrastructure/{projectName}.Infrastructure.csproj", targetFolder);

            // Step 8: Modify Project Files (you would need to programmatically modify the .cs files)

            // Step 9: Build the Solution
            ExecuteCommand("dotnet", "build", targetFolder);

            // Step 10: Run the API Project
            //ExecuteCommand("dotnet", "run", "{projectName}.API", targetFolder);

            // Step 10: Run the API Project
            //   ExecuteCommand("dotnet", "run", "{projectName}.API");

        }
        static void ExecuteCommand(string command, string arguments, string workingDirectory = "")
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = workingDirectory
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(output))
                    Console.WriteLine(output);

                if (!string.IsNullOrEmpty(error))
                    Console.WriteLine(error);
            }
        }
    }
}

