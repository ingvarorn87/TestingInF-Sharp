module ParseName

open System
open Xunit
open FsCheck
open FsCheck.Xunit
open NameParser.Parser


module PropertyTests =

    [<AutoOpen>]
    module Dependencies =

        open System.Text.RegularExpressions
        let gapCount(s :string) =
            Regex.Replace(s," +", " ")
            |> Seq.filter ((=) ' ')
            |> Seq.length

   // [<Property>]
   // let ``A string doesn't contain a letter Z`` (s: string) =
   //     s.Contains"Z"|> not

   // [<Property>]
   // let ``A non string doesn't contain a letter Z`` (s: NonNull<string>) =
   //     s.Get.Contains"Z"|> not

    [<Property>]
    let ``A non string without the letter Z doesn't contain a letter Z`` (s: NonNull<string>) =
        (s.Get.IndexOf('Z') = -1) ==> lazy (s.Get.Contains"Z"|> not)

   // [<Property>]
   // let ``A successful parse always populates a last name(naive)`` (rawName :NonNull<string>) =
   //   let isTitle = fun _ -> false
   //   let parsed = parseName isTitle rawName.Get
   //   parsed.LastName


    //[<Property(MaxTest=1000)>]
    // let ``A successful parse always populates a last name(naive 2)`` (rawName :NonEmptyString) =
    //   let isTitle = fun _ -> false
    //   let parsed = parseName isTitle rawName.Get
    //   parsed.LastName

    //[<Property(MaxTest=1000)>]
    //    let ``A successful parse always populates a last name(naive 3)`` (rawName :NonEmptyString) =
    //      let isTitle = fun _ -> false
    //      let rawName = rawName.Get.Trim()
    //      (rawName.Length > 0) ==> 
    //        lazy    
    //            let parsed = parseName isTitle rawName
    //            parsed.LastName

    [<Property(MaxTest=1000)>]
           let ``A successful parse always populates a last name(naive 3)`` (rawName :NonEmptyString) =
             let isTitle = fun _ -> false
             let rawName = rawName.Get.Trim()
             (rawName.Length > 0 && gapCount rawName < 3) ==> 
               lazy    
                   let parsed = parseName isTitle rawName
                   parsed.LastName