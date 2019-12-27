namespace NameParser

open System

module Parser =
    
    let parseName rawName = 
        
        if rawName = null then
            raise <| ArgumentNullException()
        else
             raise <| ArgumentException()

