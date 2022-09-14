module App

// Provides access from F# to the JavaScript Browse DOM API
open Browser.Dom

// Locate the "printMsg" button in the DOM
let printMsgButton = document.getElementById "printMsg"

// Change (mutate) the `onClick` handler to print a message to the debug console when I press the
// `printMsg` button.
printMsgButton.onclick <- fun eventArgs ->
    printfn "Button clicked"
    