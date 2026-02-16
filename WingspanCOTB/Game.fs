namespace WingspanCOTB

module Game =
    open WingspanCOTB
    open WingspanCOTB.Food
    open WingspanCOTB.StartingChoice
    open WingspanCOTB.BonusCard
    open Serilog

    type GameConfig =
        { StartingChoices: StartingChoice list
          BonusCardChoices: IBonusCard list
          BirdfeederSeries: FoodDie list }

    type AutomaPrimary =
        | AutomaDrawCards
        | AutomaPlayBirds
        | AutomaLayEggs of int
        | AutomaGainFood of FoodDie list

    type AutomaSecondary =
        | AutomaAddToGoal
        | AutomaRemoveFromGoal
        | AutomaActivateAllPink

    type Action =
        | DrawCards
        | GainFood
        | PlayBird of Bird.Bird
        | LayEggs of Bird.Bird list
        | AutomaMove of AutomaPrimary * AutomaSecondary

    type InProgressState = { Round: int; Turn: int }
    type FinalState = { Winner: IPlayer; Score: int }

    and Phase =
        | PickStartingBirdsAndFood of StartingChoice list
        | PickStartingBonusCard of IBonusCard list
        | PickAction of InProgressState
        | OpponentsPickPinkPower
        | CurrentPickBirdPower
        | EndOfTurn
        | Final of FinalState

    and Game =
        { Phase: Phase
          Config: GameConfig
          CurrentPlayer: IPlayer
          OtherPlayer: IPlayer
          Deck: Bird.Bird list
          Tray: Bird.Bird list
          Birdfeeder: FoodDie list }

    and IPlayer =
        abstract member Name: string
        abstract member PromptStartingChoices: Game * StartingChoice list -> StartingChoice list
        abstract member ApplyStartingChoices: StartingChoice list -> IPlayer
        abstract member PromptStartingBonusCard: Game * IBonusCard list -> IBonusCard
        abstract member ApplyStartingBonusCard: IBonusCard -> IPlayer
        abstract member PromptAction: Game -> Action
        abstract member ApplyAction: Game * Action -> IPlayer
        abstract member CanUseBirdPower: Game -> bool

    let rerollBirdfeeder game =
        let nextDice = List.take 5 game.Config.BirdfeederSeries
        let bfSeries = List.skip 5 game.Config.BirdfeederSeries

        { game with
            Birdfeeder = nextDice
            Config =
                { game.Config with
                    BirdfeederSeries = bfSeries } }

    let refillTray game =
        let n = 3 - game.Tray.Length

        { game with
            Tray = (List.take n game.Deck) @ game.Tray
            Deck = List.skip n game.Deck }

    let applyStartingChoices game choices =
        { game with
            CurrentPlayer = game.CurrentPlayer.ApplyStartingChoices(choices)
            Phase = PickStartingBonusCard(game.Config.BonusCardChoices) }

    let applyStartingBonusCard game choice =
        { game with
            CurrentPlayer = game.CurrentPlayer.ApplyStartingBonusCard(choice)
            Phase = PickAction({ Round = 1; Turn = 0 }) }
        |> rerollBirdfeeder
        |> refillTray

    let applyAction game action =
        // First we modify the player's state
        let game =
            { game with
                CurrentPlayer = game.CurrentPlayer.ApplyAction(game, action) }
        // TODO: here modify the game's state
        // TODO: apply pink powers if necessary
        let nextPhase =
            match game.CurrentPlayer.CanUseBirdPower(game) with
            | true -> CurrentPickBirdPower
            | false -> EndOfTurn

        { game with Phase = nextPhase }


    let rec loop game =
        Log.Information("Entering loop with phase: {Phase}", game.Phase)

        match game.Phase with
        | PickStartingBirdsAndFood allChoices ->
            let choices = game.CurrentPlayer.PromptStartingChoices(game, allChoices)
            loop (applyStartingChoices game choices)
        | PickStartingBonusCard allChoices ->
            let choice = game.CurrentPlayer.PromptStartingBonusCard(game, allChoices)
            loop (applyStartingBonusCard game choice)
        | PickAction pa ->
            let action = game.CurrentPlayer.PromptAction(game)
            loop (applyAction game action)
        | OpponentsPickPinkPower -> raise (System.NotImplementedException())
        | CurrentPickBirdPower -> raise (System.NotImplementedException())
        | EndOfTurn -> raise (System.NotImplementedException())
        | Final f -> (f.Winner, f.Score)
