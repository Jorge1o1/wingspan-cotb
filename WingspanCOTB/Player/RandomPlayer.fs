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

        member this.Prompt(game) =
            match game.Phase with
            | PickBirdsAndFood choices -> promptPickBirdsAndFood choices this.RNG
            | PickBonusCards choices -> promptPickBonusCard choices this.RNG
            | _ -> DrawCards

        member this.Apply(game, move) =
            { game with CurrentPlayer = { this with State = this.State.Apply(game, move)}}
        
        interface IPlayer with
            member this.Name = this.Name
            member this.Prompt(game) = this.Prompt(game)
            member this.Apply(game, move) = this.Apply(game, move)


    let rec promptPickBirdsAndFood allChoices rng =
        let legalMoves = Util.comb 5 allChoices
        let index = rng.Next(0,legalMoves.Length)
        Move.PickBirdsAndFood(List.item index legalMoves)   

    let rec promptPickBonusCard allChoices rng =
        let index = rng.Next(0,allChoices.Length)
        Move.PickBonusCard(List.item index allChoices)
