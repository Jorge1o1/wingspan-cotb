# Compiling and Running the Project (Ubuntu)

This project is written in F# and uses the .NET SDK. To build and run it on Ubuntu:

## Prerequisites

- Install the .NET SDK (if not already installed):
	- [Install .NET SDK](https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu)
	- You can check your installation with:
		```bash
		dotnet --version
		```

## Build the Project

From the project root directory:

```bash
dotnet build WingspanCOTB/WingspanCOTB.fsproj
```

## Run the Project

```bash
dotnet run --project WingspanCOTB/WingspanCOTB.fsproj
```

## Troubleshooting

- If you encounter errors, ensure your .NET SDK is up to date.
- Restore dependencies if needed:
	```bash
	dotnet restore WingspanCOTB/WingspanCOTB.fsproj
	```

---
# wingspan-cotb
An F# Representation &amp; Symbolic AI for the Wingspan video game's Champ of the Birds mode.
