// Author: Conrad D'Cruz
// Email: netswirl@gmail.com
// Twitter: @netswirl
// Url: http://www.netswirl.com
// Date: 05/26/2015

// Filename: JSONDictSerializer.fsx: 
// Description: JSONDictSerializer.fsx - Trying out the JavaScriptSerializer that downloads JSON. Download options data from Google. JSON is malformed since the dictionary keys do not have double quotes but this serializer appears to solve that problem.


#r @"C:\Users\netswirl\Documents\Visual Studio 2013\Projects\OptionsLab3\packages\FSharp.Data.2.2.1\lib\net40\FSharp.Data.dll"

open System
open System.Net
open FSharp.Data
#r "System.Web.Extensions.dll"

open System.Collections.Generic
open System.Web.Script.Serialization

let url = "http://www.google.com/finance/option_chain?q=AAPL&output=json"

let wc = new WebClient()
let data = wc.DownloadString(url)

let jss = new JavaScriptSerializer();
let dic = jss.DeserializeObject(data) :?> Dictionary<string, obj>
let keyList = dic.Keys |> Seq.toList
printfn "%A" keyList

//let info = 
//    JsonValue.Parse(data)

//type optins = JsonProvider<"c:\options.json">
//let doc = optins.GetSample();

let puts = CsvFile.Load("c:\\puts.csv")
let calls = CsvFile.Load("c:\\calls.csv")

