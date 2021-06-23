namespace WingspanCOTB

module BonusCard =
    open System.Collections.Generic
    open WingspanCOTB.Bird
    open WingspanCOTB.Board

    type IBonusCard = 
        abstract member Name : string
        abstract member MeetsRequirement: Bird -> bool
        abstract member GetScore : Board -> Bird list -> int

    let lookupByName (choices: IBonusCard list) (name : string) =
        try
            Some(List.find (fun (bc : IBonusCard) -> bc.Name.ToUpper() = name.ToUpper()) choices)
        with
            | :? KeyNotFoundException -> None