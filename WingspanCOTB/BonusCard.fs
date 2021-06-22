namespace WingspanCOTB

module BonusCard =
    open WingspanCOTB.Bird
    open WingspanCOTB.Board

    type IBonusCard = 
        abstract member Name : string
        abstract member MeetsRequirement: Bird -> bool
        abstract member GetScore : Board -> Bird list -> int
