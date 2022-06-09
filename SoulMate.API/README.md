Issue #1 Enable CORS
CORS Configuration
	Add Cors Policy to builder Services(Program.cs)
	In app UseCors (Program.cs)

Issue #2 Configure Logging
    Logging with Serilog and SeQ
    Nuget dependencies: Serilog.ASPNetCore, Serilog.Expression, Serilog.SInks.Seq
	Add Serilog to builder (Program.cs)
	Add logging configuration at (appsettings.json)
	Install and run SeQ Log aggregator