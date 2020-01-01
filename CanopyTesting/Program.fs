// Learn more about F# at http://fsharp.org

module Main =

    open System
    open canopy.runner.classic
    open canopy.configuration
    open canopy.classic
    open OpenQA.Selenium

    module Initialize =
           chromeDir <- @"C:/"
           start chrome

    [<AutoOpen>]
  
     module Selectors = 
          let ``build a bouquet`` = "#nav_main > ul > li:nth-child(3) > a > span"
          let ``calla lillies`` = "#bab_grid > li:nth-child(1) > a > span > img" 
          let ``color`` = "#colorCL"
          let ``qty`` = "#qtyCL"
          let ``add to basket`` = "#bab_form > input.btn.checkout"
          let ``basket total`` = "#drawer_grand_total"

   

    "I can order a bouquet" &&& fun _ -> 

        url @"http://585248.youcanlearnit.net/improved"

        click ``build a bouquet``
        click ``calla lillies``
        click ``color``

        press Keys.ArrowDown

        click ``qty``

        press Keys.Backspace
        press Keys.NumberPad2
        press Keys.Enter

        click ``add to basket``
        
        ``basket total`` == "$60.00"

        run()

        printfn "Press [Enter] to exit"
        Console.ReadKey() |> ignore

        quit()






