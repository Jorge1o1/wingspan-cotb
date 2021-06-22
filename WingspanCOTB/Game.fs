namespace WingspanCOTB

module Game =
    open WingspanCOTB.Food
    open WingspanCOTB.Bird
    open WingspanCOTB.Board
    open WingspanCOTB.BonusCard

    type StartingChoice =
        | PickBird of Bird
        | PickFood of Food  
    type Config = {
        StartingChoices : StartingChoice list
        BonusCardChoices: IBonusCard list
    }
    type Move =
        | PickBirdsAndFood of StartingChoice list
        | PickBonusCard of IBonusCard
        | PlayBird
        | GetFood
        | GetEggs
        | GetCards
        | AutomaDrawCards
        | AutomaPlayBirds
        | AutomaLayEggs of int
        | AutomaGainFood of FoodDie list
        | AutomaAddToGoal
        | AutomaRemoveFromGoal
        | AutomaActivateAllPink
        | Chain of Move list
    type PickBirdsAndFoodPhase = StartingChoice list
    and PickBonusCardsPhase = IBonusCard list
    and InProgressPhase = {
        Round: int
        Turn: int
    }
    and FinalPhase = {
        Winner: IPlayer
        Score: int
    }
    and Phase =
        | PickBirdsAndFood of PickBirdsAndFoodPhase
        | PickBonusCards of PickBonusCardsPhase
        | InProgress of InProgressPhase
        | Final of FinalPhase
    and IPlayer = 
        abstract member Name: string
        abstract member Prompt: Game -> Move
        abstract member Apply: Game -> Move -> Game
    and Game = {
        Phase: Phase
        Config: Config
        CurrentPlayer: IPlayer
        OtherPlayer: IPlayer
    }
         
    let advance game move =
        let nextState = game.CurrentPlayer.Apply game move
        match (move, game.Phase) with
        | (Move.PickBirdsAndFood _, _) -> { nextState with Phase = PickBonusCards(nextState.Config.BonusCardChoices)}
        | (Move.PickBonusCard _, _) -> { nextState with Phase = InProgress({Round = 0; Turn = 0})}
        | (_, InProgress p) when p.Round = 4 && p.Turn = 10 ->
            let winner = game.CurrentPlayer
            { nextState with Phase = Final({Winner = winner; Score = 10})}
        | (_, InProgress p) -> { nextState with CurrentPlayer = nextState.OtherPlayer }
        | (_, _) -> raise (System.ArgumentException("No moves in final phase"))

    let rec loop game =
        match game.Phase with
        | Final f -> (f.Winner, f.Score)
        | s ->
            let move = game.CurrentPlayer.Prompt(game)
            let nextState = advance game move
            loop nextState