
.\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe 
-register:user -target:"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\MSTest.exe" 
-targetargs:"/noresults /noisolation /testcontainer:"".\UnitTests\bin\Debug\UnitTests.dll"  
-excludebyattribute:*.ExcludeFromCodeCoverage* 
-hideskipped:All 
-output:.\MyProject_coverage.xml