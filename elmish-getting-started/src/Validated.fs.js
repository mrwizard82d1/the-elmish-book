import { Record } from "./fable_modules/fable-library.3.7.17/Types.js";
import { record_type, option_type, string_type } from "./fable_modules/fable-library.3.7.17/Reflection.js";
import { some } from "./fable_modules/fable-library.3.7.17/Option.js";

export class Validated$1 extends Record {
    constructor(Raw, Parsed) {
        super();
        this.Raw = Raw;
        this.Parsed = Parsed;
    }
}

export function Validated$1$reflection(gen0) {
    return record_type("App.Validated`1", [gen0], Validated$1, () => [["Raw", string_type], ["Parsed", option_type(gen0)]]);
}

export function Validated_createEmpty() {
    return new Validated$1("", void 0);
}

export function Validated_success(raw, value) {
    return new Validated$1(raw, some(value));
}

export function Validated_failure(raw) {
    return new Validated$1(raw, void 0);
}

//# sourceMappingURL=Validated.fs.js.map
