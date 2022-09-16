module Main

open Elmish
open Elmish.React
open Feliz

// A simple counter
type State =
    { Count: int }
    
// Messages that cause state to change
type Msg =
    | Increment
    | Decrement
    
// Calculate the initial state of the application
let init () =
    { Count = 0 }
    
// Update the state based on messages received
let update (msg: Msg) (state: State): State =
    match msg with
    | Increment ->
        { state with Count = state.Count + 1 }
    | Decrement ->
        { state with Count = state.Count - 1 }
        
// The view function (called `render` to communicate with developers familiar with React)
let render (state: State) (dispatch: Msg -> unit) =
    let headerText =
        if state.Count % 2 = 0
        then "Count is even"
        else "Count is odd"
        
    let oddOrEvenMessage =
        if state.Count > 0
        then Html.h1 headerText
        else Html.none
        
    Html.div [
        Html.button [ prop.onClick (fun _ -> dispatch Increment); prop.text "+" ]
        Html.div state.Count
        Html.button [ prop.onClick (fun _ -> dispatch Decrement); prop.text "-" ]
        oddOrEvenMessage
    ]
    
Program.mkSimple init update render
|> Program.withReactSynchronous "feliz-app"
|> Program.run