module Main

open Elmish
open Elmish.React
open Feliz

// A simple counter
type State =
    { TextInput: string }
    
// Messages that cause state to change
type Msg =
    | SetTextInput of string
    
// Calculate the initial state of the application
let init () =
    { TextInput = "" }
    
// Update the state based on messages received
let update (msg: Msg) (state: State): State =
    match msg with
    | SetTextInput toText ->
        { state with TextInput = toText }
        
// The view function (called `render` to communicate with developers familiar with React)
let render (state: State) (dispatch: Msg -> unit) =
    Html.div [
        Html.input [
            prop.className "has-background-primary"
            prop.type' "text" // default value
            prop.value state.TextInput
            // Compose `SetTextInput` with `dispatch`. The composition results in invoking `SetTextInput` with
            // the "to text" and invoking `dispatch` with the result of the `SetTextInput toText` function.
            prop.onChange (SetTextInput >> dispatch)
        ]
        Html.span [
            prop.className "has-background-success"
            prop.text state.TextInput
        ]
    ]
    
Program.mkSimple init update render
|> Program.withReactSynchronous "feliz-app"
|> Program.run