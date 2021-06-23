namespace WingspanCOTB.Player

module rec HumanPlayer =
    open WingspanCOTB
    open WingspanCOTB.Game
    open WingspanCOTB.Bird
    open WingspanCOTB.Board
    open WingspanCOTB.StartingChoice
    open WingspanCOTB.Food

    type HumanPlayer =
        { 
            Name: string
            Board: Board
            Hand: Bird list
            Supply: Food list
            BonusCards: BonusCard.IBonusCard list
         }

        member this.Prompt(game) =
            match game.Phase with
            | PickBirdsAndFood choices -> promptPickBirdsAndFood choices
            | PickBonusCards choices -> promptPickBonusCard choices
            | _ -> PlayBird

        member this.Apply(game, move) =
            match move with
            | Move.PickBirdsAndFood choices -> 
                let newplayer = List.fold addStartingChoice this choices
                { game with CurrentPlayer = newplayer}
            | Move.PickBonusCard bc -> { game with CurrentPlayer = addBonusCard bc this }
            | _ -> game
        
        interface IPlayer with
            member this.Name = this.Name
            member this.Prompt(game) = this.Prompt(game)
            member this.Apply(game, move) = this.Apply(game, move)

    let rec promptPickBirdsAndFood allChoices =
        printfn "Time to Pick Food and Birds. Please Choose 5 From:"
        Seq.iter (printfn "\t%O") allChoices
        printfn "Your turn! Type in choices separated by semicolon: "
        let inputs = System.Console.ReadLine().Split(';')
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

    let addFood food player =
        { player with Supply = food :: player.Supply }

    let addBird bird player =
        { player with Hand = bird :: player.Hand }
    
    let addBonusCard bc player =
        { player with BonusCards = bc :: player.BonusCards }
    
    let addStartingChoice player choice  =
        match choice with
        | PickFood f -> addFood f player
        | PickBird b -> addBird b player