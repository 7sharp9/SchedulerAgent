open AgentUtilities
open System
open System.Threading

let scheduler = SchedulerAgent<_>()
let printer message = 
    printfn "%s: %s" (DateTime.Now.TimeOfDay.ToString()) message

let singlecancel = scheduler.Schedule(printer, 
                                      "Hello from the scheduler", 
                                      TimeSpan(0,0,0,5))

let multicancel = scheduler.Schedule( printer, 
                                      "Hello from the multi scheduler", 
                                      TimeSpan(0,0,0,5),
                                      TimeSpan(0,0,0,0,500))

printfn "Press any key to cancel."
Console.ReadKey() |> ignore

//Cancel the multi scheduler
multicancel.Cancel()
printfn "Cancelled, press any key to exit."
Console.ReadKey() |> ignore