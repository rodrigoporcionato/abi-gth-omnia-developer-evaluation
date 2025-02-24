Claro! Aqui está o guia em formato Markdown (MD) que você pode adicionar ao seu repositório Git:

```markdown
# Guide to Adding and Applying Migrations with Entity Framework Core

This guide describes the steps to add and apply migrations to your project using Entity Framework Core. Follow the instructions below to ensure your database is always up-to-date with the changes in the data model.

## Step 1: Navigate to the WebApi Project Folder

Before adding or applying migrations, it's important to be in the correct folder that contains your ASP.NET Core WebAPI application.

In the terminal, navigate to the WebApi project folder:

```bash
cd src/Ambev.DeveloperEvaluation.WebApi
```

## Step 2: Add a New Migration

To add a new migration, run the command below. This command will create a new migration based on the changes that have been made to the data model since the last migration.

```bash
dotnet ef migrations add <MigrationName> --startup-project ../Ambev.DeveloperEvaluation.WebApi
```

**Example:**

```bash
dotnet ef migrations add FixSaleIdType --startup-project ../Ambev.DeveloperEvaluation.WebApi
```

## Step 3: Update the Database

After adding the migration, you need to apply the changes to the database. Run the following command to update the database:

```bash
dotnet ef database update --startup-project ../Ambev.DeveloperEvaluation.WebApi
```

This command applies the newly created migration (and any pending migrations) to the database, ensuring that the database schema is in sync with the data model.

## Useful Tips

1. **Ensure Entity Framework Core is Installed:**
   Before running migration commands, make sure you have Entity Framework Core installed in your project.

   ```bash
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Microsoft.EntityFrameworkCore.Design
   ```

2. **Make Sure dotnet-ef Tool is Installed:**
   Install the tool globally if necessary:

   ```bash
   dotnet tool install --global dotnet-ef
   ```

3. **Check Project References:**
   Ensure that the ORM project (which contains the DbContext and entities) references the WebAPI project, and vice versa as needed.

4. **Review and Test:**
   Review the code and the generated migrations. Test to ensure that the changes were applied correctly and that there are no errors.

