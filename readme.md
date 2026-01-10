# String Redact API

## Building the Application

1. Open a terminal window and navigate to `./src`
2. Enter the build command `dotnet build`

## Running the Tests

1. Open a terminal window and navigate to `./src`
2. Enter the test command `dotnet test`


## Running the Application

1. Open a terminal window and navigate to `./src/Alliance.Api`
2. Enter the run command (`dotnet run`)
    1. Enter `CTRL+C` exit the application 

## Specifying a Port

By default, the service is available on port `8080`.  To change this port, pass the port parameter when running the 
application:

```sh
dotnet run --Server:Port=1234
```

## Time Taken

- About 2 hours of coding

## Notes

I know from past lives that redaction is quite detailed, and often involves parsing a significant amount of text.  The implementation here is meant to involve a single pass over the input string, but solutions for more detailed unigram identification are more complex.  Immediate concerns include "captured" punctuation (like the apostrophe in "o'clock").

I'm letting Serilog deal with the timestamps in log messages, but would likely need to implement a time provider if we were doing so manually:
https://github.com/craigduggan90/demo-api/tree/main/src/pkg/Demo.Common/Providers

We have no error handling in this API but, if I were to implement it, it would likely follow the implementation in my nascent demo API:
https://github.com/craigduggan90/demo-api/blob/main/src/api/Demo.Api/Infrastructure/Errors/Startup.cs

