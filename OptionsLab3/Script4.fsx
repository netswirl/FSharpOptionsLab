﻿// Author: Conrad D'Cruz
// Email: netswirl@gmail.com
// Twitter: @netswirl
// Url: http://www.netswirl.com
// Date: 05/26/2015
//Note: This file is under development and will be renamed when completed

open System.IO
open System.Drawing
open System.Windows.Forms
open FSharp.Data

let form = new Form(Visible = true, Text = "A Smple F# Form", TopMost = true, Size = Size(600,600))
let data = new DataGridView(Dock=DockStyle.Fill, Text = "F# Programming is Fun!", Font = new Font("Lucida Console",12.0f), ForeColor = Color.DarkBlue)


data.DataSource = File.ReadLines("c:\\puts.csv")


