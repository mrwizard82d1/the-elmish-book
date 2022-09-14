module App

// Provides access from F# to the JavaScript Browse DOM API
open Browser.Dom

// Dom references for UI elements
let incrementButton = document.getElementById("increment")
let decrementButton = document.getElementById("decrement")
let countView = document.getElementById("countView")

// The model (state) of our application
let mutable counter = 0

let render = fun () ->
    // Update the view based on the model
    countView.innerText <- $"Count is at {counter}"
    
// Perform the initial render
render ()

// Attach event handlers to buttons
incrementButton.onclick <- fun _eventArgs ->
    // Update the model...
    counter <- counter + 1
    
    render ()

decrementButton.onclick <- fun _eventArgs ->
    // Update the model 
    counter <- counter - 1
    
    render ()
