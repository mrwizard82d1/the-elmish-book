import { randomNext, createAtom } from "./.fable/fable-library.3.2.9/Util.js";
import { sleep, startImmediate } from "./.fable/fable-library.3.2.9/Async.js";
import { singleton } from "./.fable/fable-library.3.2.9/AsyncBuilder.js";
import { interpolate, toText } from "./.fable/fable-library.3.2.9/String.js";

export const incrementButton = document.getElementById("increment");

export const decrementButton = document.getElementById("decrement");

export const delayedIncrementButton = document.getElementById("delayedIncrement");

export const countView = document.getElementById("countView");

export let counter = createAtom(0);

export const rnd = {};

export function runAfter(ms, callback) {
    startImmediate(singleton.Delay(() => singleton.Bind(sleep(ms), () => {
        callback();
        return singleton.Zero();
    })));
}

export function render() {
    countView.innerText = toText(interpolate("Count is at %P()", [counter()]));
}

render();

incrementButton.onclick = ((_arg1) => {
    counter(counter() + randomNext(5, 10), true);
    render();
});

decrementButton.onclick = ((_arg2) => {
    counter(counter() - randomNext(5, 10), true);
    render();
});

delayedIncrementButton.onclick = ((_arg3) => {
    runAfter(1000, () => {
        counter(counter() + randomNext(5, 10), true);
        render();
    });
});

