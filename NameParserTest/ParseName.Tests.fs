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

    [<Fact>]
    let ``Given a single item the item is placed in LastName`` () =
         let rawName : string = "Doe"
         let expected : string = "Doe"
         let actual = (Parser.parseName rawName).LastName
         Assert.Equal(expected, actual)

    [<Fact>]
    let ``Given two items the items is placed in FirstName and LastName`` () =
         let rawName  = "Jane Doe"
         let expected = "Jane", "Doe"
         let parsed = parseName rawName
         let actual = parsed.FirstName, parsed.LastName
         Assert.Equal(expected, actual)

    [<Fact>]
    let ``Given three items the items is placed in Title, FirstName and LastName`` () =
         let rawName  = "Ms Jane Doe"
         let expected = "Ms", "Jane", "Doe"
         let parsed = parseName rawName
         let actual = parsed.Title,parsed.FirstName, parsed.LastName
         Assert.Equal(expected, actual)
    
    [<Fact>]
       let ``Given three items when the first is not a title the items is placed in FirstName and LastName`` () =
            let rawName  = "Jane A Doe"
            let expected = "Jane A", "Doe"
            let parsed = parseName rawName
            let actual = parsed.FirstName, parsed.LastName
            Assert.Equal(expected, actual)

    [<Theory>]
    [<InlineData("Ms")>]
    [<InlineData("Mrs")>]
    [<InlineData("Mr")>]
    [<InlineData("Prof")>]
    [<InlineData("Dr")>]
    let  ``Given a title amd two other items the items are placed in title, FirstName and LastName`` title =
        let rawName = sprintf "%s Jane Doe" title
        let expected = title, "Jane", "Doe"
        let parsed = parseName rawName
        let actual = parsed.Title, parsed.FirstName, parsed.LastName
        Assert.Equal(expected, actual)