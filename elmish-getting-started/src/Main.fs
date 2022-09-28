module Main

open App
open Elmish
open Elmish.React
open Feliz

// Collecting user (numeric) input
type State =
    { NumberInput: Validated<int> }
    
// Messages that cause state to change
type Msg =
    | SetNumberInput of Validated<int>
    
// Calculate the initial state of the application
let init () =
    { NumberInput = Validated.createEmpty() }
    
// Update the state based on messages received
let update (msg: Msg) (state: State): State =
    match msg with
    | SetNumberInput toNumber ->
        { state with NumberInput = toNumber }
        
let tryParseInt (toParse: string): Validated<int> =
    try Validated.success toParse (int toParse)
    with | _ -> Validated.failure toParse
    
// Calculate text color based on Validated
let validatedTextColor validated =
    match validated.Parsed with
    | Some _ -> color.green
    | None -> color.red
        
// The view function (called `render` to communicate with developers familiar with React)
let render state dispatch =
    Html.div [
        prop.style [ style.padding 20 ]
        prop.children [
            Html.input [
                prop.valueOrDefault state.NumberInput.Raw
                prop.onChange (tryParseInt >> SetNumberInput >> dispatch)
            ]
            
            Html.h1 [
                prop.style [ style.color (validatedTextColor state.NumberInput) ]
                prop.text state.NumberInput.Raw
            ]
        ]
    ]
    
Program.mkSimple init update render
|> Program.withReactSynchronous "feliz-app"
|> Program.run