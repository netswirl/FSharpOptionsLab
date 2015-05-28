# FSharpOptionsLab
Lab files for .NET F# Meetup @ Met Life on 05/26/2015

JSONDictSerializer.fsx - Trying out the JavaScriptSerializer that downloads JSON. Download options data from Google. 
JSON is malformed since the dictionary keys do not have double quotes but this serializer appears to solve that problem.

ChartStocks.fsx - Get stock data from yahoo and get the data ready for chart drawing. Code samples for several different
charting styles are available in this file.  

OpenInterestPuts.fsx - Run the code against c:\data\puts.csv (sample options data for MSFT)

OpenInterestCalls.fsx - Run the code against c:\data\calls.csv (sample options data for MSFT)

Data files available in repository.
