namespace Library

module Actors =
    open System.Threading
    
    type Msg = 
        | Increment of int
        | Decrement of int
        | Get of AsyncReplyChannel<int>

    let processor = MailboxProcessor.Start (fun inbox ->
        let rec loop state =
            async {
                let! msg = inbox.Receive ()
                match msg with
                | Increment(x) -> return! loop (state + x)
                | Decrement(x) -> return! loop (state - x)
                | Get(channel) ->
                    channel.Reply(state)
                    return! loop(state)
            }
        loop 0
    )
