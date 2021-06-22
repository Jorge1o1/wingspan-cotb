namespace WingspanCOTB.Player

module HumanPlayer =
    open WingspanCOTB.Game
    open WingspanCOTB.Bird
    open WingspanCOTB.Board
    open WingspanCOTB.BonusCard
    open WingspanCOTB.Food

    let isBirdWithName name choice =
        match choice with
        | PickFood _ -> false
        | PickBird b -> b.Name = name

    let pickBirdOrFood allChoices text =
        match text with
        | "FRUIT" -> PickFood(Food.Fruit)
        | "FISH" -> PickFood(Food.Fish)
        | "INV" -> PickFood(Food.Invertebrate)
        | "RAT" -> PickFood(Food.Rodent)
        | "SEED" -> PickFood(Food.Seed)
        | n -> List.find (isBirdWithName n) allChoices

    let rec promptPickBirdsAndFood allChoices =
        printfn "Starting Choices: %A" allChoices
        printfn "Your turn! Type in choices separated by semicolon: "
        let inputs = System.Console.ReadLine().ToUpper().Split(';')
        let choices = 
            try
                Some(Array.toList (Array.map (pickBirdOrFood allChoices) inputs))
            with
                | :? System.Collections.Generic.KeyNotFoundException -> None
        match choices with
        | Some c -> Move.PickBirdsAndFood(c)
        | None -> 
            printfn "Bad input!"
            promptPickBirdsAndFood allChoices

    type HumanPlayer(name: string, board: Board, hand: Bird list, supply: Food list, bonusCards: IBonusCard list) as self =
        let applyStartingChoice game choice =
            match choice with
            | PickFood f -> { game with CurrentPlayer = self.AddFood(f) }
            | PickBird b -> { game with CurrentPlayer = self.AddBirdToHand(b)}
        
        member this.AddFood food =
            HumanPlayer(name, board, hand, food :: supply, bonusCards)
        
        member this.AddBirdToHand bird =
            HumanPlayer(name, board, bird :: hand, supply, bonusCards)

        member this.AddBonusCard bc =
            HumanPlayer(name, board, hand, supply, bc :: bonusCards)
        
        member this.Prompt game =
            match game.Phase with
            | PickBirdsAndFood choices -> promptPickBirdsAndFood choices
            | _ -> PlayBird

        member this.Apply game move =
            match move with
            | Move.PickBirdsAndFood choices -> List.fold applyStartingChoice game choices
            | Move.PickBonusCard bc -> { game with CurrentPlayer = self.AddBonusCard(bc)}
            | _ -> game
        
        interface IPlayer with
            member this.Name = name
            member this.Prompt game = this.Prompt game
            member this.Apply game move = this.Apply game move