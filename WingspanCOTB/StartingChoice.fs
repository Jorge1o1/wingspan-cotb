namespace WingspanCOTB

module StartingChoice =
    open System.Collections.Generic
    open WingspanCOTB.Food
    open WingspanCOTB.Bird

    type StartingChoice =
        | PickBird of Bird
        | PickFood of Food
        with override this.ToString() =
                match this with
                | PickBird b -> b.Name
                | PickFood f -> f.ToString()

    let lookupByName (choices: StartingChoice list) (name : string) =
        try
            Some(List.find (fun sc -> sc.ToString().ToUpper() = name.ToUpper()) choices)
        with
            | :? KeyNotFoundException -> None

    let legalCombinations (choices : StartingChoice list) =
        Util.comb 5 choices