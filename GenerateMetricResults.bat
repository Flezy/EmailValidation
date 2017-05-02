packages\OpenCover.4.6.519\tools\OpenCover.Console -target:packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe -targetargs:UnitTests\bin\Debug\UnitTests.dll -register:user

packages\ReportGenerator.2.5.7\tools\ReportGenerator.exe -reports:results.xml -targetdir:MetricResults