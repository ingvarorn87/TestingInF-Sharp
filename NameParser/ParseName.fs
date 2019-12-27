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
        { 
            Title = null
            FirstName = null
            LastName = null
        }

