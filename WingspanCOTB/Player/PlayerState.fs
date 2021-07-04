namespace WingspanCOTB.Player

module rec PlayerState =
    open WingspanCOTB
    open WingspanCOTB.Bird
    open WingspanCOTB.Food
    open WingspanCOTB.BonusCard
    open WingspanCOTB.Game
    open WingspanCOTB.StartingChoice

    type PlayerState = 
        {
            Board: Board.Board
            Hand: Bird list
            Supply: Food list
            BonusCards: IBonusCard list
        }

        member this.ApplyStartingChoices(choices) =
            List.fold applyStartingChoice this choices
        
        member this.ApplyStartingBonusCard(choice) =
            addBonusCard this choice

        member this.ApplyAction(game, move) =
            match move with
            | Action.DrawCards -> applyDrawCards this game
            | _ -> this

    let empty = { Board = Board.empty; Hand = []; Supply = []; BonusCards = []}

    let addFood ps food =
        { ps with Supply = food :: ps.Supply }

    let addBird ps bird =
        { ps with Hand = bird :: ps.Hand }
    
    let addBonusCard ps bc =
        { ps with BonusCards = bc :: ps.BonusCards }

    let applyStartingChoice ps choice  =
        match choice with
        | PickFood f -> addFood ps f
        | PickBird b -> addBird ps b
    
    let applyDrawCards ps game = 
        let cardsDrawn = List.take (Board.numCardsDrawable ps.Board) game.Deck
        List.fold addBird ps cardsDrawn