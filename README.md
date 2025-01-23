# CodeCoverageAndTestCoverage

1. Clone the app
2. dotnet sonarscanner begin /k:"--project--" /d:sonar.host.url="--url--"  /d:sonar.token="--token--"
3. dotnet build
4. dotnet sonarscanner end /d:sonar.token="--token--"