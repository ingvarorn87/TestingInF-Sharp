namespace NameParser

open System

module Parser =

    type Name = 
        { 
            Title: string
            FirstName: string
            LastName: string
        }
    
    let parseName (rawName : string) = 
        
        if rawName = null then
            raise <| ArgumentNullException()
        elif rawName.Trim() = "" then
             raise <| ArgumentException()
        else
            let parts = rawName.Split([|' '|])
            match parts with
            | ([|p1|]) ->
                {Title = null
                 FirstName = null
                 LastName = p1}
            | ([|p1; p2|]) ->
                {Title = null
                 FirstName = p1
                 LastName = p2}
            | ([|p1; p2; p3|]) ->
                {Title = p1
                 FirstName = p2
                 LastName = p3}
            | _ -> raise <| Exception()

            

