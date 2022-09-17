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
        
// // The view function (called `render` to communicate with developers familiar with React)
// let render (state: State) (dispatch: Msg -> unit) =
//     let headerText =
//         if state.Count % 2 = 0
//         then "Count is even"
//         else "Count is odd"
//         
//     let oddOrEvenMessage = Html.h1 headerText
//         
//     Html.div [
//         yield Html.button [ prop.onClick (fun _ -> dispatch Increment); prop.text "+" ]
//         yield Html.div state.Count
//         yield Html.button [ prop.onClick (fun _ -> dispatch Decrement); prop.text "-" ]
//         if state.Count >= 0 then yield oddOrEvenMessage
//     ]

let render _state _dispatch =
    Html.div [
        prop.className "hidden"
        prop.text "You cannot see me"
    ]
    
Program.mkSimple init update render
|> Program.withReactSynchronous "feliz-app"
|> Program.run