

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

let putsCsv = Frame.ReadCsv(@"c:\data\puts.csv")

let xa = putsCsv.GetColumn<float>("Strike") |> Series.values
let ya = putsCsv.GetColumn<float>("Open Int") |> Series.values

let chart = Chart.Point (Seq.zip xa ya, Name = sprintf "Open Interest for Strikes - PUTS")
            |> Chart.WithLegend (Docking = ChartTypes.Docking.Top)
            |> Chart.WithXAxis (Enabled = true)
            |> Chart.WithYAxis (Enabled = true)

chart.ShowChart()

