namespace WingspanCOTB.Player

module rec HumanPlayer =
    open WingspanCOTB
    open WingspanCOTB.Game
    open WingspanCOTB.StartingChoice
    open WingspanCOTB.Player.PlayerState

    type HumanPlayer =
        { 
            Name: string
            State: PlayerState
        }

        member this.Prompt(game) =
            match game.Phase with
            | PickBirdsAndFood choices -> promptPickBirdsAndFood choices
            | PickBonusCards choices -> promptPickBonusCard choices
            | _ -> DrawCards

        member this.Apply(game, move) =
            { game with CurrentPlayer = { this with State = this.State.Apply(game, move)}}
        
        interface IPlayer with
            member this.Name = this.Name
            member this.Prompt(game) = this.Prompt(game)
            member this.Apply(game, move) = this.Apply(game, move)

    let rec promptPickBirdsAndFood allChoices =
        printfn "Time to Pick Food and Birds. Please Choose 5 From:"
        Seq.iter (printfn "\t%O") allChoices
        printfn "Your turn! Type in choices separated by semicolon: "
        let inputs = System.Console.ReadLine().Split(';')
        if inputs.Length <> 5 then
            printfn "Pick only 5!"
            promptPickBirdsAndFood allChoices    
        else
            let choices = Array.toList <| Array.map (lookupByName allChoices) inputs
            try
                Move.PickBirdsAndFood(List.map Option.get choices)
            with
            | :? System.ArgumentException ->
                printfn "Bad input!"
                promptPickBirdsAndFood allChoices           

    let rec promptPickBonusCard allChoices =
        printfn "Time to Pick Bonus Card. Please Choose From:"
        Seq.iter (printfn "\t%O") allChoices
        printfn "Your turn! Type in your choice"
        let input = System.Console.ReadLine()
        let choice = BonusCard.lookupByName allChoices input
        match choice with
        | Some bc -> Move.PickBonusCard(bc)
        | None ->
            printfn "Bad input!"
            promptPickBonusCard allChoices