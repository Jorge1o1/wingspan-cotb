namespace WingspanCOTB.Player

module AutomaPlayer =
    open WingspanCOTB.Game

    type AutomaPlayer =
        { 
            Name: string
            Moves: Move list
        }

        member this.Prompt(state) =
            match this.Moves with
            | hd :: tl -> hd
            | [] -> raise (System.IndexOutOfRangeException("No more Automa moves"))
        
        member this.Apply(game, move) =
            { game with CurrentPlayer = { this with Moves = this.Moves.Tail}}
        
        interface IPlayer with
            member this.Name = this.Name
            member this.Prompt(game) = this.Prompt(game)
            member this.Apply(game, move) = this.Apply(game, move)