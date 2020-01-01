module Tests

open Xunit
open canopy.parallell

[<Fact>]
let ``Hightlight Olivercoding Image Test`` () =
    use browser = functions.start canopy.types.Chrome
    functions.url "https://www.olivercoding.com/" browser
    functions.highlight "#mainLogoDiv" browser
    functions.sleep 5
    Assert.True(true)