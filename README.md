# Analyzing Logs

This is a test project created as part of a coding task to demonstrate skills in C# development, object-oriented programming (OOP), and unit testing. The goal of this project is to parse event logs, calculate statistical information for each event, and display the results in a formatted table.

## Features

- **Log Parsing**: Reads a log file and extracts events with their processing times.
- **Event Aggregation**: Computes the minimum, maximum, average processing times, and counts for each event type.
- **Formatted Output**: Displays the event statistics in a clean and readable table in the console.
- **Unit Testing**: Includes unit tests to validate log parsing and aggregation logic.

## Project Structure

```
Analyzing_logs/
  |-- Analyzing_logs/          # Main project folder
  |     |-- LogParser.cs       # Responsible for reading and parsing log files
  |     |-- EventStats.cs      # Represents statistics for individual events
  |     |-- EventAggregator.cs # Aggregates statistics for all events
  |     |-- Program.cs         # Entry point of the application
  |
  |-- Analyzing_logs.Tests/    # Unit test project
        |-- LogParserTests.cs  # Tests for LogParser
        |-- EventAggregatorTests.cs # Tests for EventAggregator
```

## Example

### Input (log file)

Example of a log file used by the program:

```
[Event] Processing MoveBroiEvent
[Performance] MoveBroiEvent with Tid 12 has been processed in 100 ms
[Performance] MoveCroiEvent with Tid 14 has been processed in 300 ms
[Performance] MoveBroiEvent with Tid 13 has been processed in 200 ms
```

### Output (console)

The program generates the following output in the console:

```
Event Statistics:
-------------------------------------------------------------
Event Name           Min Time   Max Time   Avg Time   Count     
-------------------------------------------------------------
MoveBroiEvent        100        200        150.00     2         
MoveCroiEvent        300        300        300.00     1         
-------------------------------------------------------------
```

## How to Run

1. Clone the repository:
   ```
   git clone https://github.com/<your-username>/Analyzing_logs.git
   ```

2. Open the solution file (`Analyzing_logs.sln`) in Visual Studio.

3. Build and run the main project (`Analyzing_logs`).

4. Place your log file in the same directory as the executable or specify its path in the code.

## How to Test

1. Open the solution in Visual Studio.

2. Build the solution to restore dependencies.

3. Open the Test Explorer (**Test > Run All Tests**) and verify that all tests pass.

## Tools and Technologies

- **Language**: C#
- **Framework**: .NET Core 8.0
- **Testing**: MSTest
- **IDE**: Visual Studio
---

Feel free to review the code and provide feedback! 😊
