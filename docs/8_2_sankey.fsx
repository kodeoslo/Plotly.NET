(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Sankey charts

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=8_2_sankey.ipynb)

*Summary:* This example shows how to create sankey charts in F#.

Sankey charts are a visualization of multiple, linked graphs layed out linearly. 
These are usually used to depict flow between nodes or stations.
To create Sankey, a set of nodes and links between them are required. 
These are created using the provided Node and Link structures.
*)

open Plotly.NET 

// create nodes
let n1 = Node.Create("a",color="Black")
let n2 = Node.Create("b",color="Red")
let n3 = Node.Create("c",color="Purple")
let n4 = Node.Create("d",color="Green")
let n5 = Node.Create("e",color="Orange")

// create links between nodes
let link1 = Link.Create(n1,n2,value=1.0)
let link2 = Link.Create(n2,n3,value=2.0)
let link3 = Link.Create(n1,n5,value=1.3)
let link4 = Link.Create(n4,n5,value=1.5)
let link5 = Link.Create(n3,n5,value=0.5)

let sankey1 = 
    Chart.Sankey(
        [n1;n2;n3;n4;n5],
        [link1;link2;link3;link4;link5]
    )
    |> Chart.withTitle "Sankey Sample"

(*** condition: ipynb ***)
#if IPYNB
sankey1
#endif // IPYNB

(***hide***)
sankey1 |> GenericChart.toChartHTML
(***include-it-raw***)

