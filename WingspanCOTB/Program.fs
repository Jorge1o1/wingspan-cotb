open System
open Serilog

open WingspanCOTB.Game
open WingspanCOTB.Player.RandomPlayer
open WingspanCOTB.Player.AutomaPlayer
open WingspanCOTB.Player
open WingspanCOTB.Data
open WingspanCOTB.StartingChoice

[<EntryPoint>]
let main argv =
    Log.Logger <- LoggerConfiguration().WriteTo.Console().CreateLogger()
    Log.Information "Starting WingspanCOTB application..."

    let config =
        { StartingChoices = randomStartingChoices 42
          BonusCardChoices = Week35.bonusCardChoices
          BirdfeederSeries = Week35.birdfeeder }

    // let player1 = { HumanPlayer.Name = "Jorge"; Board = Board.empty; Hand = []; Supply = []; BonusCards = [] }
    let player1 =
        { RandomPlayer.Name = "RND"
          RNG = Random(123)
          State = PlayerState.empty }

    let player2 =
        { AutomaPlayer.Name = "QT-1"
          Moves = Week35.automaMoves }

    let game =
        { Phase = PickStartingBirdsAndFood(Week35.startingChoices)
          Config = config
          CurrentPlayer = player1
          OtherPlayer = player2
          Deck = Week35.birdDeck
          Tray = []
          Birdfeeder = [] }

    let (winner, score) = loop game
    printfn "Congratulations %s! You had %i points!" winner.Name score
    Log.CloseAndFlush()
    1
