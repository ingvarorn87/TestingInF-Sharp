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

    [<Theory>]
    [<InlineData("")>]
    [<InlineData(" ")>]
    [<InlineData("\t")>]
    let ``An blank string produces an argument exeption`` rawName =
       Assert.Throws(typeof<System.ArgumentException>,
       (fun () -> parseName rawName |> ignore))

    
    
    [<Fact>]
    let ``The function produces a title, first name and a last name`` () =
         let rawName : string = "Ms Jane Doe"
         let actual = parseName rawName
         Assert.IsType<Parser.Name>(actual)
