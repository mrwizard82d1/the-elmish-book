import { Union, Record } from "./fable_modules/fable-library.3.7.17/Types.js";
import { union_type, record_type, bool_type, string_type } from "./fable_modules/fable-library.3.7.17/Reflection.js";
import { createElement } from "react";
import { equals, createObj } from "./fable_modules/fable-library.3.7.17/Util.js";
import { ofArray } from "./fable_modules/fable-library.3.7.17/List.js";
import { Interop_reactApi } from "./fable_modules/Feliz.1.66.0/./Interop.fs.js";
import { ProgramModule_mkSimple, ProgramModule_run } from "./fable_modules/Fable.Elmish.3.1.0/program.fs.js";
import { Program_withReactSynchronous } from "./fable_modules/Fable.Elmish.React.3.0.1/react.fs.js";

export class State extends Record {
    constructor(TextInput, Capitalized) {
        super();
        this.TextInput = TextInput;
        this.Capitalized = Capitalized;
    }
}

export function State$reflection() {
    return record_type("Main.State", [], State, () => [["TextInput", string_type], ["Capitalized", bool_type]]);
}

export class Msg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["SetTextInput", "SetCapitalized"];
    }
}

export function Msg$reflection() {
    return union_type("Main.Msg", [], Msg, () => [[["Item", string_type]], [["Item", bool_type]]]);
}

export function init() {
    return new State("", false);
}

export function update(msg, state) {
    if (msg.tag === 1) {
        const capitalized = msg.fields[0];
        return new State(state.TextInput, capitalized);
    }
    else {
        const text = msg.fields[0];
        return new State(text, state.Capitalized);
    }
}

export function render(state, dispatch) {
    let elems, value_3, children, value_19;
    return createElement("div", createObj(ofArray([["style", {
        padding: 20,
    }], (elems = [createElement("input", createObj(ofArray([(value_3 = state.TextInput, ["ref", (e) => {
        if ((!(e == null)) && (!equals(e.value, value_3))) {
            e.value = value_3;
        }
    }]), ["onChange", (ev) => {
        dispatch(new Msg(0, ev.target.value));
    }]]))), (children = ofArray([createElement("label", {
        htmlFor: "checkbox-capitalized",
        children: "Capitalized",
    }), createElement("input", {
        style: {
            margin: 5,
        },
        id: "checkbox-capitalized",
        type: "checkbox",
        checked: state.Capitalized,
        onChange: (ev_1) => {
            dispatch(new Msg(1, ev_1.target.checked));
        },
    })]), createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children)),
    })), (value_19 = (state.Capitalized ? state.TextInput.toLocaleUpperCase() : state.TextInput), createElement("span", {
        children: [value_19],
    }))], ["children", Interop_reactApi.Children.toArray(Array.from(elems))])])));
}

ProgramModule_run(Program_withReactSynchronous("feliz-app", ProgramModule_mkSimple(init, update, render)));

//# sourceMappingURL=Main.fs.js.map
