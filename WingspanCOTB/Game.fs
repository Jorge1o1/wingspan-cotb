namespace WingspanCOTB

module Game =
    open WingspanCOTB
    open WingspanCOTB.Food
    open WingspanCOTB.StartingChoice
    open WingspanCOTB.BonusCard

    type Config = {
        StartingChoices : StartingChoice list
        BonusCardChoices: IBonusCard list
        BirdfeederSeries: FoodDie list
        Deck: Bird.Bird list
    }
    type Move =
        | PickBirdsAndFood of StartingChoice list
        | PickBonusCard of IBonusCard
        | PlayBird of Bird.Bird
        | GainFood
        | LayEggs
        | DrawCards
        | AutomaDrawCards
        | AutomaPlayBirds
        | AutomaLayEggs of int
        | AutomaGainFood of FoodDie list
        | AutomaAddToGoal
        | AutomaRemoveFromGoal
        | AutomaActivateAllPink
        | Chain of Move list
    and InProgressPhase = {
        Round: int
        Turn: int
        Tray: Bird.Bird list
        Birdfeeder: FoodDie list
    }
    and FinalPhase = {
        Winner: IPlayer
        Score: int
    }
    and Phase =
        | PickBirdsAndFood of StartingChoice list
        | PickBonusCards of IBonusCard list
        | InProgress of InProgressPhase
        | Final of FinalPhase
    and IPlayer = 
        abstract member Name: string
        abstract member Prompt: Game -> Move
        abstract member Apply: Game * Move -> Game //TODO: should return IPlayer?
    and Game = {
        Phase: Phase
        Config: Config
        CurrentPlayer: IPlayer
        OtherPlayer: IPlayer
    }

    let rerollBirdfeeder game =
        let (InProgress ipPhase) = game.Phase
        let nextDice = List.take 5 game.Config.BirdfeederSeries
        let bfSeries = List.skip 5 game.Config.BirdfeederSeries
        { game with
            Phase = InProgress({ ipPhase with Birdfeeder = nextDice})
            Config = {game.Config with BirdfeederSeries = bfSeries}
        }

    let refillTray game =
        let (InProgress ipPhase) = game.Phase
        let n = 3 - ipPhase.Tray.Length
        let newTray = (List.take n game.Config.Deck) @ ipPhase.Tray
        let remainingDeck = List.skip n game.Config.Deck
        { game with
            Phase = InProgress({ ipPhase with Tray = newTray})
            Config = {game.Config with Deck = remainingDeck}
        }

    let advanceToInProgress game = 
        { game with Phase = InProgress({Round = 1; Turn = 0; Birdfeeder = []; Tray = []})}
        |> rerollBirdfeeder
        |> refillTray
    
    let advanceToFinal game = 
        { game with Phase = Final({Winner = game.CurrentPlayer; Score = 10})}

    let isEndOfRound phase = (phase.Round * 2) + phase.Turn = 18

    let advanceToNextRound game =
        game

    let applyPostTurn game move phase =
        refillTray game

    let applyPinkMove game moveOption phase =
        game

    let advanceWithinRound game move phase =
        let next = applyPostTurn game move phase
        let pinkMove = None // Promt for pink here
        let next = applyPinkMove next pinkMove phase
        { next with 
            CurrentPlayer = game.OtherPlayer
            OtherPlayer = game.CurrentPlayer
            Phase = InProgress({phase with Turn = phase.Turn + 1})}

    let advance game move =
        let nextState = game.CurrentPlayer.Apply(game, move)
        match (move, game.Phase) with
        | (Move.PickBirdsAndFood _, PickBirdsAndFood _) -> { nextState with Phase = PickBonusCards(nextState.Config.BonusCardChoices)}
        | (Move.PickBonusCard _, PickBonusCards _) -> advanceToInProgress nextState
        | (_, InProgress p) when p.Round = 4 && isEndOfRound p -> advanceToFinal game
         // be careful here, pinks should fire after last turn but not during endofround
        | (_, InProgress p) when isEndOfRound p -> advanceToNextRound game
        | (_, InProgress p) -> advanceWithinRound game move p
        | (_, _) -> raise (System.ArgumentException("Unsupported combination of move and phase"))

    let rec loop game =
        match game.Phase with
        | Final f -> (f.Winner, f.Score)
        | s ->
            let move = game.CurrentPlayer.Prompt(game)
            let nextState = advance game move
            loop nextState