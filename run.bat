dotnet build -o old
dotnet build -o new /p:MassTransitVersion=8.0.11
.\old\MassTransitSerializationRepro.exe
.\new\MassTransitSerializationRepro.exe