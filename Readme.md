# AzureBlobStorage

## Description

This project is a .NET library that enables storing and retrieving objects in the cloud, regardless of their size. It leverages Azure Cosmos DB and Azure Blob Storage for efficient data management.

## Features

- **Cloud Object Storage**: The library provides functionality to store and retrieve objects in the cloud.
- **Scalability**: Leveraging Azure Cosmos DB and Azure Blob Storage allows for handling objects of any size and accommodating increased storage requirements.

## Requirements
To use this library, you need the following:

- **.NET Framework**: The library is built for the .NET framework (version X.X or higher).
- **Azure Account**: You must have an Azure account with access to Azure Cosmos DB and Azure Blob Storage services.

## Installation

1. Clone the repository:

```bash
git clone https://github.com/OldSinner/AzureBlobStorage.git
```

2. Open the project in Visual Studio or your preferred .NET IDE.

3. Build the project to restore the NuGet packages.

4. Configure Azure Cosmos DB and Azure Blob Storage credentials in the project's configuration file (`appsettings.json`).

```jsonc
{
    "AzureConfiguration":{
        "AzureBlobConnectionString":"", // Connection String to AzureBlobStorage
        "AzureTableConnectionString":"", // Connetion String to Azure Table
        "ContainerName":"filestests", // Name of Container for file
        "TableName":"filesset", // Name of Table for info of files
        "MaxSeqSize":1048576, // Max Size of file
        "FilePartition":"fileshost" // Partition Key for file info
    }
}
```

5. Run the project, and you're ready to start using the library for cloud object storage.

