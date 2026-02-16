namespace WingspanCOTB.Data

module BonusCards =
    open WingspanCOTB.Bird
    open WingspanCOTB.Board
    open WingspanCOTB.BonusCard
    open WingspanCOTB.Game

    let Anatomist =
        { new IBonusCard with
            member this.Name = "Anatomist"

            member this.MeetsRequirement bird =
                List.contains BodyPart bird.Characteristics

            member this.GetScore board hand =
                let birds = getAllBirds board

                match List.filter this.MeetsRequirement birds |> List.length with
                | n when n >= 4 -> 7
                | n when n >= 2 -> 3
                | _ -> 0 }

    let Ecologist =
        { new IBonusCard with
            member this.Name = "Ecologist"
            member this.MeetsRequirement bird = true

            member this.GetScore board hand =
                let birds = List.minBy List.length [ board.Forest; board.Grassland; board.Ocean ]
                birds.Length * 2 }

    let LargeBirdSpecialist =
        { new IBonusCard with
            member this.Name = "Large Bird Specialist"
            member this.MeetsRequirement bird = bird.Wingspan > 65

            member this.GetScore board hand =
                let birds = getAllBirds board

                match List.filter this.MeetsRequirement birds |> List.length with
                | n when n >= 6 -> 6
                | n when n >= 4 -> 3
                | _ -> 0 }

    let NestBoxBuilder =
        { new IBonusCard with
            member this.Name = "Nest Box Builder"

            member this.MeetsRequirement bird =
                (bird.Nest = Cavity || bird.Nest = Wild)

            member this.GetScore board hand =
                let birds = getAllBirds board

                match List.filter this.MeetsRequirement birds |> List.length with
                | n when n >= 6 -> 7
                | n when n >= 4 -> 4
                | _ -> 0 }

    let PrairieManager =
        { new IBonusCard with
            member this.Name = "Prairie Manager"
            member this.MeetsRequirement bird = bird.Habitats = [ Grassland ]

            member this.GetScore board hand =
                let birds = getAllBirds board

                match List.filter this.MeetsRequirement birds |> List.length with
                | n when n >= 4 -> 8
                | n when n >= 2 -> 3
                | _ -> 0 }

    let WetlandScientist =
        { new IBonusCard with
            member this.Name = "Wetland Scientist"

            member this.MeetsRequirement bird =
                match bird.Habitats with
                | [ Ocean ] -> true
                | _ -> false

            member this.GetScore board hand =
                let birds = getAllBirds board

                match List.filter this.MeetsRequirement birds |> List.length with
                | n when n >= 5 -> 7
                | n when n >= 3 -> 3
                | _ -> 0 }
