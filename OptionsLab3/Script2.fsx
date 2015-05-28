// Author: Conrad D'Cruz
// Email: netswirl@gmail.com
// Twitter: @netswirl
// Url: http://www.netswirl.com
// Date: 05/26/2015

#r @"C:\Users\netswirl\Documents\Visual Studio 2013\Projects\OptionsLab3\packages\FSharp.Data.2.2.1\lib\net40\FSharp.Data.dll"
#r "System.Web.Extensions.dll"

open System
open System.Net
open FSharp.Data

open System.Collections.Generic
open System.Web.Script.Serialization

let url = "http://www.google.com/finance/option_chain?q=AAPL&output=json"

let wc = new WebClient()
let data = wc.DownloadString(url)

type optins= JsonProvider<"{}">

let docAsync = optins.AsyncLoad(url)

for record in docAsync.Array do
    record.Value |> Option.iter (fun value -> printfn record.Value)

