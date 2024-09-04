
# Ocelot API Gateway Project

This repository demonstrates the implementation of an API Gateway using Ocelot in an ASP.NET Core project. The API Gateway handles routing and load balancing for multiple microservices, providing a unified entry point to the underlying services.

## Project Structure

- **Ocelot API Gateway**: Manages routing, authentication, and other gateway features.
- **Student Service**: Exposes student-related APIs.
- **Teacher Service**: Exposes teacher-related APIs.

## Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or any other preferred IDE
- [Ocelot](https://ocelot.readthedocs.io/en/latest/introduction/gettingstarted.html) NuGet package

## Getting Started

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/manojtharindu11/Ocelot-API-Gateway-Project.git
   cd Ocelot-API-Gateway-Project
   ```

2. **Restore Dependencies**:
   Navigate to each project directory (Gateway, Student, Teacher) and run:
   ```bash
   dotnet restore
   ```

3. **Build the Projects**:
   ```bash
   dotnet build
   ```

4. **Run the Services**:
   You can run each service individually from their respective project directories:
   ```bash
   dotnet run
   ```

   Ensure that the services are running on the following URLs:
   - **Student Service**: `https://localhost:44354/swagger/index.html`
   - **Teacher Service**: `https://localhost:44387/swagger/index.html`

5. **Run the API Gateway**:
   Navigate to the Gateway project directory and run:
   ```bash
   dotnet run
   ```
   The gateway will be available at `https://localhost:5003`.

## Configuration

The `ocelot.json` file contains the routing configurations. Below is a sample configuration:

```json
{
  "GlobalConfiguration": {
    "BaseUrl": "https://localhost:5003"
  },
  "Routes": [
    {
      "UpstreamPathTemplate": "/gateway/student",
      "UpstreamHttpMethod": [ "Get" ],
      "DownstreamPathTemplate": "/api/student",
      "DownstreamScheme": "https",
      "DownstreamHostAndPorts": [
        {
          "Host": "localhost",
          "Port": 44354
        }
      ]
    },
    {
      "UpstreamPathTemplate": "/gateway/teacher",
      "UpstreamHttpMethod": [ "Get" ],
      "DownstreamPathTemplate": "/api/teacher",
      "DownstreamScheme": "https",
      "DownstreamHostAndPorts": [
        {
          "Host": "localhost",
          "Port": 44387
        }
      ]
    }
  ]
}
```

## Usage

Once everything is running, you can access the APIs through the gateway:

- **Student API**: `https://localhost:5003/gateway/student`
- **Teacher API**: `https://localhost:5003/gateway/teacher`

These routes will forward the requests to the respective downstream services.

## Troubleshooting

- **502 Bad Gateway**: Ensure that all services (Student, Teacher) are running on the correct ports and URLs as configured in `ocelot.json`.
- **HTTPS Redirection Issues**: Make sure the HTTPS ports in your Ocelot configuration match the ports where your services are running.
