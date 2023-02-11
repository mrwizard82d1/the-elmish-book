import { Union, Record } from "./fable_modules/fable-library.3.7.17/Types.js";
import { union_type, record_type, list_type, string_type } from "./fable_modules/fable-library.3.7.17/Reflection.js";
import { ofArray, append, singleton } from "./fable_modules/fable-library.3.7.17/List.js";
import { createElement } from "react";
import { equals, createObj } from "./fable_modules/fable-library.3.7.17/Util.js";
import { join } from "./fable_modules/fable-library.3.7.17/String.js";
import { Interop_reactApi } from "./fable_modules/Feliz.1.66.0/./Interop.fs.js";
import { map, delay, toList } from "./fable_modules/fable-library.3.7.17/Seq.js";

export class State extends Record {
    constructor(ToDoList, ToAdd) {
        super();
        this.ToDoList = ToDoList;
        this.ToAdd = ToAdd;
    }
}

export function State$reflection() {
    return record_type("ToDoList.State", [], State, () => [["ToDoList", list_type(string_type)], ["ToAdd", string_type]]);
}

export class Msg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["SetToAdd", "ToAdd"];
    }
}

export function Msg$reflection() {
    return union_type("ToDoList.Msg", [], Msg, () => [[["Item", string_type]], []]);
}

export function ToDoList_init() {
    return new State(singleton("Learn F#"), "");
}

export function ToDoList_update(msg, state) {
    if (msg.tag === 1) {
        if (state.ToAdd === "") {
            return state;
        }
        else {
            return new State(append(state.ToDoList, singleton(state.ToAdd)), "");
        }
    }
    else {
        const toAddText = msg.fields[0];
        return new State(state.ToDoList, toAddText);
    }
}

export const ToDoList_renderAppTitle = createElement("h1", {
    className: "title",
    children: "Elmish To Do List",
});

export function ToDoList_renderToAdd(state, dispatch) {
    let elems_3, elems, value_3, elems_2, elems_1;
    return createElement("div", createObj(ofArray([["className", join(" ", ["field", "has-addons"])], (elems_3 = [createElement("div", createObj(ofArray([["className", join(" ", ["control", "is-expanded"])], (elems = [createElement("input", createObj(ofArray([["className", join(" ", ["input", "is-medium"])], (value_3 = state.ToAdd, ["ref", (e) => {
        if ((!(e == null)) && (!equals(e.value, value_3))) {
            e.value = value_3;
        }
    }]), ["onChange", (ev) => {
        dispatch(new Msg(0, ev.target.value));
    }]])))], ["children", Interop_reactApi.Children.toArray(Array.from(elems))])]))), createElement("div", createObj(ofArray([["className", "control"], (elems_2 = [createElement("button", createObj(ofArray([["className", join(" ", ["button", "is-primary", "is-medium"])], ["onClick", (_arg) => {
        dispatch(new Msg(1));
    }], (elems_1 = [createElement("i", {
        className: join(" ", ["fa", "fa-plus"]),
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems_1))])])))], ["children", Interop_reactApi.Children.toArray(Array.from(elems_2))])])))], ["children", Interop_reactApi.Children.toArray(Array.from(elems_3))])])));
}

export function ToDoList_renderToDoItems(state, dispatch) {
    let elems;
    return createElement("ul", createObj(singleton((elems = toList(delay(() => map((toDo) => createElement("li", {
        className: join(" ", ["box", "subtitle"]),
        children: toDo,
    }), state.ToDoList))), ["children", Interop_reactApi.Children.toArray(Array.from(elems))]))));
}

export function ToDoList_render(state, dispatch) {
    let elems;
    return createElement("div", createObj(ofArray([["style", {
        padding: 20,
    }], (elems = [ToDoList_renderAppTitle, ToDoList_renderToAdd(state, dispatch), ToDoList_renderToDoItems(state, dispatch)], ["children", Interop_reactApi.Children.toArray(Array.from(elems))])])));
}

//# sourceMappingURL=Components.fs.js.map
