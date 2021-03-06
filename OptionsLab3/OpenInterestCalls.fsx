﻿// Author: Conrad D'Cruz
// Email: netswirl@gmail.com
// Twitter: @netswirl
// Url: http://www.netswirl.com
// Date: 05/26/2015

// Filename: OpenInterestCalls.fsx 
// Description: Run the code against c:\data\calls.csv (sample options data for MSFT)
// Note: calls.csv file is available in the repository. Place anyplace convenient in your filesystem
// and update the line in the code below to point to the new location. Recommended location is c:\data

#r "../packages/Deedle.1.0.7/lib/net40/Deedle.dll"
#r "../packages/FSharp.Charting.0.90.10/lib/net40/FSharp.Charting.dll"
//#r "../packages/FSharp.Data.2.2.2/lib/net40/FSharp.Data.dll"
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.Windows.Forms.DataVisualization.dll"
#r @"C:\Users\netswirl\Documents\Visual Studio 2013\Projects\OptionsLab3\packages\FSharp.Data.2.2.1\lib\net40\FSharp.Data.dll"


open System
open Deedle
open FSharp.Charting
open FSharp.Data
open System.Drawing
open System.Windows.Forms

let putsCsv = Frame.ReadCsv(@"c:\data\calls.csv")

let xa = putsCsv.GetColumn<float>("Strike") |> Series.values
let ya = putsCsv.GetColumn<float>("Open Int") |> Series.values

let chart = Chart.Point (Seq.zip xa ya, Name = sprintf "Open Interest for Strikes - CALLS")
            |> Chart.WithLegend (Docking = ChartTypes.Docking.Top)
            |> Chart.WithXAxis (Enabled = true)
            |> Chart.WithYAxis (Enabled = true)

chart.ShowChart()


