
#I __SOURCE_DIRECTORY__
#I "../../../../../packages/FSharp.Data/lib/netstandard2.0"
#I "../../../packages/FSharp.Data/lib/netstandard2.0"
#I "../packages/FSharp.Data/lib/netstandard2.0"
#I "../FSharp.Data/lib/netstandard2.0"
#I "../../../../../packages/FSharp.Data.3.1.1/lib/netstandard2.0"
#I "../../../packages/FSharp.Data.3.1.1/lib/netstandard2.0"
#I "../packages/FSharp.Data.3.1.1/lib/netstandard2.0"
#I "../FSharp.Data.3.1.1/lib/netstandard2.0"

#r "netstandard"
#r "System.Net.Http"
#r "Fsharp.Data.dll"
#r "FsHttp.dll"

// for debugging purpose
// #r "./bin/Debug/netstandard2.0/FsHttp.dll"

type PrintableResponse = | PrintableResponse of FsHttp.Domain.Response

let printTransformer (r:FsHttp.Domain.Response) =
    match r.printHint.isEnabled with
    | true -> (PrintableResponse r) :> obj
    | false -> null
fsi.AddPrintTransformer printTransformer

let printer (r:PrintableResponse) =
    let (PrintableResponse inner) = r
    try FsHttp.FsiPrinting.print inner
    with ex -> ex.ToString()
fsi.AddPrinter printer
