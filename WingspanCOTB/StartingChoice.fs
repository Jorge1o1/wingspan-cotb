namespace WingspanCOTB

module StartingChoice =
    open System.Collections.Generic
    open WingspanCOTB.Food
    open WingspanCOTB.Bird
    open System

    type StartingChoice =
        | PickBird of Bird
        | PickFood of Food

        override this.ToString() =
            match this with
            | PickBird b -> b.Name
            | PickFood f -> f.ToString()

    let lookupByName (choices: StartingChoice list) (name: string) =
        try
            Some(List.find (fun sc -> sc.ToString().ToUpper() = name.ToUpper()) choices)
        with :? KeyNotFoundException ->
            None

    let legalCombinations (choices: StartingChoice list) = Util.comb 5 choices

    let allChoices =
        let birds = Bird.allBirds |> List.map PickBird
        let foods = Food.allFoods |> List.map PickFood
        birds @ foods

    let randomStartingChoices (seed: int) =
        Random(seed).GetItems(allChoices |> List.toArray, 5) |> List.ofArray
