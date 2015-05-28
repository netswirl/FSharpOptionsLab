# FSharpOptionsLab
Lab files for .NET F# Meetup @ Met Life on 05/26/2015

JSONDictSerializer.fsx - Trying out the JavaScriptSerializer that downloads JSON. Download options data from Google. 
JSON is malformed since the dictionary keys do not have double quotes but this serializer appears to solve that problem.

ChartStocks.fsx - Get stock data from yahoo and get the data ready for chart drawing. Code samples for several different
charting styles are available in this file.  

OpenInterestPuts.fsx - Run the code against c:\data\puts.csv (sample options data for MSFT)

OpenInterestCalls.fsx - Run the code against c:\data\calls.csv (sample options data for MSFT)

Data files available in repository in the project folder (puts.csv and calls.csv)

The files Script2.fsx, Script3.fsx, Script4.fsx, Script5.fsx are underdevelopment and working code will eventually be merged into the file script file that will draw the stock chart and the open interest calls and puts charts.

Fell free to branch and modify code and document changes, enhancements and gotchas.

Thanks
Conrad D'Cruz
