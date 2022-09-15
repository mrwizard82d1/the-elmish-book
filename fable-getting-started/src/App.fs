module App

// Provides access from F# to the JavaScript Browse DOM API
open Browser.Dom

// Dom references for UI elements
let incrementButton = document.getElementById("increment")
let decrementButton = document.getElementById("decrement")
let delayedIncrementButton = document.getElementById("delayedIncrement")
let countView = document.getElementById("countView")

// The model (state) of our application
let mutable counter = 0

// A random number generator
let rnd = System.Random()

// Utility function to run another function after a supplied delay
let runAfter (ms: int) callback =
    async {
        do! Async.Sleep ms
        do callback()
    }
    |> Async.StartImmediate

let render = fun () ->
    // Update the view based on the model
    countView.innerText <- $"Count is at {counter}"
    
// Perform the initial render
render ()

// Attach event handlers to buttons
incrementButton.onclick <- fun _ ->
    // Update the model...
    counter <- counter + rnd.Next(5, 10)
    
    render ()

decrementButton.onclick <- fun _ ->
    // Update the model 
    counter <- counter - rnd.Next(5, 10)
    
    render ()

delayedIncrementButton.onclick <- fun _ ->
    runAfter 1000 (fun () -> 
        // Update the model...
        counter <- counter + rnd.Next(5, 10)
        
        render ()
    )
