namespace App
    type Validated<'t> =
        {
          Raw: string
          Parsed: Option<'t>
        }
    
    module Validated =
        let createEmpty() : Validated<_> =
            { Raw = ""; Parsed = None }
            
        let success raw value : Validated<_> =
            { Raw = raw; Parsed = Some value }
            
        let failure raw : Validated<_> =
            { Raw = raw; Parsed = None }

