namespace NameParser

open System
open Xunit
open NameParser.Parser

module Tests = 

    [<Fact>]
    let ``I can write a test``() =
        let expected = true
        let actual = true
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``A null string produces an argument null exeption``() =
        let rawName : string = null
        Assert.Throws(typeof<System.ArgumentNullException>,
        (fun () -> parseName rawName |> ignore))

    [<Fact>]
       let ``An empty string produces an argument exeption``() =
           let rawName : string = ""
           Assert.Throws(typeof<System.ArgumentException>,
           (fun () -> parseName rawName |> ignore))
            