namespace WingspanCOTB.Data

module Week35 = 
    open WingspanCOTB
    open WingspanCOTB.Game
    open WingspanCOTB.Food

    let automaBonusCard = BonusCards.Anatomist
    let automaMoves = [
        Chain([AutomaDrawCards; AutomaRemoveFromGoal])
        Chain([AutomaLayEggs(3); AutomaAddToGoal])
        Chain([AutomaLayEggs(3); AutomaAddToGoal])
        Chain([AutomaGainFood([InvertebrateOrSeed; Invertebrate; Seed; Rodent; Fish; Fruit]); AutomaActivateAllPink])
        Chain([AutomaPlayBirds; AutomaAddToGoal])
        Chain([AutomaPlayBirds; AutomaAddToGoal])
        Chain([AutomaGainFood([Rodent; Fish; Fruit; InvertebrateOrSeed; Invertebrate; Seed]); AutomaActivateAllPink])
        Chain([AutomaDrawCards; AutomaAddToGoal])
        Chain([AutomaGainFood([InvertebrateOrSeed; Invertebrate; Seed; Rodent; Fish; Fruit]); AutomaActivateAllPink])
    ]
    let startingChoices = [
        PickBird(Birds.BroadWingedHawk); PickBird(Birds.PaintedWhitestart); PickBird(Birds.Brant); 
        PickBird(Birds.VauxsSwift); PickBird(Birds.RedBreastedMerganser); PickFood(Food.Fruit)]
    let bonusCardChoices = [ BonusCards.WetlandScientist; BonusCards.LargeBirdSpecialist ]