// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open WingspanCOTB
open WingspanCOTB.Game
open WingspanCOTB.Player.HumanPlayer
open WingspanCOTB.Player.AutomaPlayer
open WingspanCOTB.Data

[<EntryPoint>]
let main argv =
    let config = {
        StartingChoices = Week35.startingChoices
        BonusCardChoices = Week35.bonusCardChoices
    }
    let player1 = { HumanPlayer.Name = "Jorge"; Board = Board.empty; Hand = []; Supply = []; BonusCards = [] }
    let player2 = { AutomaPlayer.Name = "QT-1"; Moves = Week35.automaMoves}
    let game = {
        Phase = PickBirdsAndFood(Week35.startingChoices)
        Config = config
        CurrentPlayer = player1
        OtherPlayer = player2
    }
    let (winner, score) = loop game
    printfn "Congratulations %s! You had %i points!" winner.Name score
    1