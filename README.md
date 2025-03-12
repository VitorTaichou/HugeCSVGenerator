# HugeCSVGenerator

## Description
A simple & efficient console application that generates a `.csv` file with random data on fixed columns.

## Features
- Generates a CSV file with structured random data.
- Includes various data types such as GUIDs, strings, integers, floats, doubles, decimals, and boolean values.
- Accepts user input for the number of lines to be generated.

## Requirements
- .NET 6.0 or later

## Usage
### Run the application
You can run the application by providing the number of lines to be generated as a command-line argument:
```sh
 dotnet run -- 1000
```
Or, if no argument is provided, the program will prompt for user input:
```sh
 dotnet run
```
Then, enter the desired number of lines when prompted.

### Output
The application generates a `.csv` file in the current directory with the format:
```csv
Guid,String,Int,Long,Float,Double,Decimal,Boolean,String Array,Int Array,Float Array
<random data>
...
```
The file is named using the current timestamp: `ddMMyyyyHHmmss.csv` at the same location as the console application.

## License
This project is open-source and available under the MIT License.