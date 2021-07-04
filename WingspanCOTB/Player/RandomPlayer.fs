namespace WingspanCOTB.Player

module rec RandomPlayer =
    open WingspanCOTB
    open WingspanCOTB.Game
    open WingspanCOTB.Player.PlayerState

    type RandomPlayer =
        {
            RNG: System.Random 
            Name: string
            State: PlayerState
         }

        member this.PromptStartingChoices(game, choices) =
            let possibleMoves = StartingChoice.legalCombinations choices
            let index = this.RNG.Next(0,possibleMoves.Length)
            List.item index possibleMoves

        member this.PromptStartingBonusCard(game, choices : BonusCard.IBonusCard list) =
            let index = this.RNG.Next(0,choices.Length)
            List.item index choices

        member this.PromptAction(game) =
            match game.Phase with
            | _ -> DrawCards

        member this.CanUseBirdPower(game) = false
        
        interface IPlayer with
            member this.Name = this.Name
            member this.PromptStartingChoices(game, choices) = this.PromptStartingChoices(game, choices)
            member this.PromptStartingBonusCard(game, choices) = this.PromptStartingBonusCard(game, choices)
            member this.PromptAction(game) = this.PromptAction(game)
            member this.CanUseBirdPower(game) = this.CanUseBirdPower(game)
            member this.ApplyStartingChoices(choices) = 
                { this with State = this.State.ApplyStartingChoices choices } :> IPlayer
            member this.ApplyStartingBonusCard(choice) = 
                { this with State = this.State.ApplyStartingBonusCard choice } :> IPlayer
            member this.ApplyAction(game, move) =
                { this with State = this.State.ApplyAction(game, move)} :> IPlayer
