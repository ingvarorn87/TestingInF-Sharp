module ParseName

open System
open Xunit
open FsCheck
open FsCheck.Xunit

module PropertyTests =

    [<Property>]
    let ``A string doesn't contain a letter Z`` (s: string) =
        s.Contains"Z"|> not