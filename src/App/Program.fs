open Library.Actors

[<EntryPoint>]
let main argv =
    processor.Post (Increment 47)
    processor.Post (Decrement 10)
    processor.Post (Increment 2)
    let state = processor.PostAndReply (fun reply -> Get reply)
    printfn "State: %d" state
    0 // return an integer exit code