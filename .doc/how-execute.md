[Back to README](../README.md)


# How to Configure

This documentation helps the developer start the project evaluation.

## Requirements

- .NET Core 8.0  
- Docker Desktop  

## Steps to Run

First, adjust your Docker Compose configuration in the project to ensure it works correctly.

Once the project is configured, you can run it using:
```sh
docker-compose up -d
```

The services will start on your operating system.

If you are using Linux or macOS, remember to change the environment variable in Docker Compose to `HOME`, or keep it as is if you are using Windows.

## How to Execute Project

### Running in Visual Studio with Docker Compose

1. Open the project in Visual Studio.
2. Ensure Docker Desktop is running.
3. Set the project to use Docker Compose as the startup project.
4. Click the "Run" button or use the terminal to execute:
   ```sh
   docker-compose up -d
   ```

### Running on Linux or macOS

1. Open a terminal and navigate to the project directory.
2. Ensure Docker is installed and running.
3. Run the following command:
   ```sh
   docker-compose up -d
   ```
4. If needed, update environment variables for Linux/macOS by modifying `HOME` in Docker Compose.

## Entity Framework (EF)

For the project, it is necessary to set up the tables using EF migrations.

Run the following command inside the project directory:
```sh
cd src/Ambev.DeveloperEvaluation.WebApi
```
```sh
dotnet ef database update
```

After this, the tables will be initialized.

Inside the project, there is a warmup process that loads product tables from the fake `fakestoreapi`.

Simply start the project, and the tables will be created along with a generated product feed.

## Environments

- API: `localhost:8080`
  - Health Check: `8081`
- Database:
  - PostgreSQL: Port `5432`
  - Redis: Port `6379`
  - MongoDB: Port `27071`

