module Main

open App
open Elmish
open Elmish.React
open Feliz

// Collecting user (checkbox) input
type State =
    { TextInput: string
      Capitalized: bool }
    
// Messages that cause state to change
type Msg =
    | SetTextInput of string
    | SetCapitalized of bool
    
// Calculate the initial state of the application
let init () =
    { TextInput = ""; Capitalized = false }
    
// Update the state based on messages received
let update (msg: Msg) (state: State): State =
    match msg with
    | SetTextInput text ->
        { state with TextInput = text }
    | SetCapitalized capitalized ->
        { state with Capitalized = capitalized }
    
        
// The view function (called `render` to communicate with developers familiar with React)
let render state dispatch =
    Html.div [
        prop.style [ style.padding 20 ]
        prop.children [
            Html.input [
                prop.valueOrDefault state.TextInput
                prop.onChange (SetTextInput >> dispatch)
            ]
            
            Html.div [
                Html.label [
                    prop.htmlFor "checkbox-capitalized"
                    prop.text "Capitalized"
                ]
                
                Html.input [
                    prop.style [ style.margin 5 ]
                    prop.id "checkbox-capitalized"
                    prop.type'.checkbox
                    prop.isChecked state.Capitalized
                    prop.onChange (SetCapitalized >> dispatch)
                ]
            ]
            
            Html.span (
                if state.Capitalized
                then state.TextInput .ToUpper()
                else state.TextInput
            )
        ]
    ]
    
Program.mkSimple init update render
|> Program.withReactSynchronous "feliz-app"
|> Program.run