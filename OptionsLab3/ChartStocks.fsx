#light
#load @"C:\Users\netswirl\Documents\Visual Studio 2013\Projects\OptionsLab2\packages\FSharp.Charting.0.90.10\FSharp.Charting.fsx"

open FSharp.Charting
open System
open System.Net
open System.Windows.Forms.DataVisualization.Charting

// URL of a service that generates price data
let url = "http://ichart.finance.yahoo.com/table.csv?s="

/// Returns prices (as tuple) of a given stock for a 
/// specified number of days (starting from the most recent)
let getStockPrices stock count =
    // Download the data and split it into lines
    let wc = new WebClient()
    let data = wc.DownloadString(url + stock)
    let dataLines = 
        data.Split([| '\n' |], StringSplitOptions.RemoveEmptyEntries) 

    // Parse lines of the CSV file and take specified
    // number of days using in the oldest to newest order
    seq { for line in dataLines |> Seq.skip 1 do
              let infos = line.Split(',')
              yield float infos.[1], float infos.[2], 
                    float infos.[3], float infos.[4] }
    |> Seq.take count |> Array.ofSeq |> Array.rev

[ for o,h,l,c in getStockPrices "FFIV" 3000 do
        yield (o + c) / 2.0 ] |> Chart.Line

[ for o,h,l,c in getStockPrices "FFIV" 3000 do
        yield (o + c) / 2.0 ] |> Chart.Renko

[ for o,h,l,c in getStockPrices "SPY" 3000 do
        yield (o + c) / 2.0 ] |> Chart.Renko

[ for o,h,l,c in getStockPrices "SPY" 60 do
        yield (o + c) / 2.0 ] 
|> Chart.Renko
|> Chart.WithArea.AxisY(Minimum = 100.0, Maximum = 600.0)


[ for o,h,l,c in getStockPrices "AAPL" 300 do
    yield (o) ]
|> Chart.Renko
|> Chart.WithArea.AxisY(Minimum = 100.0, Maximum = 920.0)



[ for o,h,l,c in getStockPrices "MSFT" 60 do
    yield h, l, o, c ]
|> Chart.Candlestick
|> Chart.WithArea.AxisY(Minimum = 36.0, Maximum = 52.0)

[ for o,h,l,c in getStockPrices "FFIV" 3000 do
        yield (c) ] |> Chart.Line

[ for o,h,l,c in getStockPrices "GOOGL" 300 do
    yield h, l, o, c ]
|> Chart.Candlestick
|> Chart.WithArea.AxisY(Minimum = 470.0, Maximum = 610.0)

[ for o, h, l, c in getStockPrices "MSFT" 600 -> l, h ]
|> Chart.Range
|> Chart.WithArea.AxisY(Minimum = 25.0, Maximum = 50.0)

[ for o, h, l, c in getStockPrices "MSFT" 300 -> l, h ]
|> Chart.Range
|> Chart.WithArea.AxisY(Minimum = 35.0, Maximum = 50.0)
|> Chart.WithSeries.Style
     ( Color = Drawing.Color.FromArgb(32, 135, 206, 250), 
       BorderColor = Drawing.Color.SkyBlue, BorderWidth = 1)


let createPriceLine stock color =
  Chart.Line
    ( [ for o,h,l,c in getStockPrices stock 310 -> o ], Name = stock)
  |> Chart.WithSeries.Style(Color = color, BorderWidth = 2)

Chart.Combine
  [ createPriceLine "SPY" Drawing.Color.SkyBlue
    createPriceLine "FFIV" Drawing.Color.Red ]
|> Chart.WithArea.AxisY(Minimum = 15.0, Maximum = 300.0)


let dashGrid = 
    Grid ()
//    Grid( LineColor = Drawing.Color.Gainsboro, 
//          LineDashStyle = ChartDashStyle.Dash )

Chart.Combine
  [ createPriceLine "MSFT" Drawing.Color.SkyBlue
    createPriceLine "YHOO" Drawing.Color.Red ]
|> Chart.WithArea.AxisY
    ( Minimum = 15.0, Maximum = 30.0, MajorGrid = dashGrid ) 
|> Chart.WithArea.AxisX(MajorGrid = dashGrid)
|> Chart.WithMargin(0.0, 10.0, 2.0, 0.0)
|> Chart.WithLegend
    ( InsideArea = false, Font = new Font("Arial", 8.0f), 
      Alignment = StringAlignment.Center, Docking = Docking.Top)