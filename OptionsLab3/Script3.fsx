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

//let jss = new JavaScriptSerializer();

//let dict = jss.Deserialize<Dictionary<string,obj>>(data)

//let info = JsonValue.Parse(data)

type Token =
 | OpenBracket | CloseBracket
 | OpenArray | CloseArray
 | Colon | Comma
 | String of string
 | Number of string

let tokenize source =
 
let rec parseString acc = function
 | '\\' :: '"' :: t -> parseString (acc + "\"") t
 | '"' :: t -> acc, t
| c :: t -> // otherwise accumulate
parseString (acc + (c.ToString())) t
| _ -> failwith "Malformed string."
 
let rec token acc = function
| (')' :: _) as t -> acc, t // closing paren terminates
| (':' :: _) as t -> acc, t // colon terminates
| (',' :: _) as t -> acc, t // comma terminates
| w :: t when Char.IsWhiteSpace(w) -> acc, t // whitespace terminates
| [] -> acc, [] // end of list terminates
| c :: t -> token (acc + (c.ToString())) t // otherwise accumulate chars

let rec tokenize' acc = function
| w :: t when Char.IsWhiteSpace(w) -> tokenize' acc t   // skip whitespace
| '{' :: t -> tokenize' (OpenBracket :: acc) t
| '}' :: t -> tokenize' (CloseBracket :: acc) t
| '[' :: t -> tokenize' (OpenArray :: acc) t
| ']' :: t -> tokenize' (CloseArray :: acc) t
| ':' :: t -> tokenize' (Colon :: acc) t
| ',' :: t -> tokenize' (Comma :: acc) t
| '"' :: t -> // start of string
let s, t' = parseString "" t
tokenize' (Token.String(s) :: acc) t'
| '-' :: d :: t when Char.IsDigit(d) -> 
    let n, t' = token ("-" + d.ToString()) t
tokenize' (Token.Number(n) :: acc) t'
| '+' :: d :: t | d :: t when Char.IsDigit(d) -> // start of positive number
let n, t' = token (d.ToString()) t
tokenize' (Token.Number(n) :: acc) t'
| [] -> List.rev acc // end of list terminates
| _ -> failwith "Tokinzation error"
tokenize' [] source

