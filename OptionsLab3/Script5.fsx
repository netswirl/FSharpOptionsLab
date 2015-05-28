#r @"C:\Users\netswirl\documents\visual studio 2013\Projects\OptionsLab3\packages\Deedle.1.0.7\lib\net40\Deedle.dll"
#r @"C:\Users\netswirl\documents\visual studio 2013\Projects\OptionsLab3\packages\FSharp.Charting.0.90.10\lib\net40\FSharp.Charting.dll"
#r @"C:\Users\netswirl\Documents\Visual Studio 2013\Projects\OptionsLab3\packages\FSharp.Data.2.2.1\lib\net40\FSharp.Data.dll"

open System
open Deedle
open FSharp.Charting
open FSharp.Data
open System.Drawing
open System.Windows.Forms

//let puts = CsvFile.Load("c:\\puts.csv")
//let calls = CsvFile.Load("c:\\calls.csv")

let putsCsv = Frame.ReadCsv("c:\\puts.csv")
//let callsCsv = Frame.ReadCsv("c:\\calls.csv")

let xa = putsCsv.GetColumn<float>("Strike") |> Series.values
let ya = putsCsv.GetColumn<float>("Open Int") |> Series.values

Chart.Point (Seq.zip xa ya, 
    Name = sprintf "Open Interest for Strikes")
|> Chart.WithLegend (Docking = ChartTypes.Docking.Top)
|> Chart.WithXAxis (Enabled = true)
|> Chart.WithYAxis (Enabled = true)







