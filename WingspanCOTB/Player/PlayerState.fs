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

        member this.Apply(game, move) =
            match move with
            | Move.PickBirdsAndFood choices -> List.fold applyStartingChoices this choices
            | Move.PickBonusCard bc ->  addBonusCard this bc 
            | Move.DrawCards -> applyDrawCards this move game
            | _ -> this

    let empty = { Board = Board.empty; Hand = []; Supply = []; BonusCards = []}

    let addFood ps food =
        { ps with Supply = food :: ps.Supply }

    let addBird ps bird =
        { ps with Hand = bird :: ps.Hand }
    
    let addBonusCard ps bc =
        { ps with BonusCards = bc :: ps.BonusCards }

    let applyStartingChoices ps choice  =
        match choice with
        | PickFood f -> addFood ps f
        | PickBird b -> addBird ps b
    
    let applyDrawCards ps move game = 
        let cardsDrawn = List.take (Board.numCardsDrawable ps.Board) game.Config.Deck
        List.fold addBird ps cardsDrawn



        // let applyDrawCards game player =
    //     let cardsDrawn = List.take (numCardsDrawable player.Board) game.Config.Deck
    //     let newDeck = List.skip (numCardsDrawable player.Board) game.Config.Deck
    //     
    //     { game with CurrentPlayer = newPlayer; Config = { game.Config with Deck = newDeck}}