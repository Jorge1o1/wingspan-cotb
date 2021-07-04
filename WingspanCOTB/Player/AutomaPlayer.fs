namespace WingspanCOTB.Player

module AutomaPlayer =
    open WingspanCOTB.Game

    type AutomaPlayer =
        { 
            Name: string
            Moves: Action list
        }

        member this.PromptAction(game) = this.Moves.Head
        
        member this.Apply(game, move) =
            // TODO: the scorekeeping and stuff
            { this with Moves = this.Moves.Tail } :> IPlayer
        
        interface IPlayer with
            member this.Name = this.Name
            member this.PromptStartingChoices(_,_) = raise (System.NotSupportedException("Automa"))
            member this.PromptStartingBonusCard(_,_) = raise (System.NotSupportedException("Automa"))
            member this.ApplyStartingChoices(_) = raise (System.NotSupportedException("Automa"))
            member this.ApplyStartingBonusCard(_) = raise (System.NotSupportedException("Automa"))
            member this.PromptAction(game) = this.Moves.Head
            member this.ApplyAction(game, move) = this.Apply(game, move)
            member this.CanUseBirdPower(game) = false