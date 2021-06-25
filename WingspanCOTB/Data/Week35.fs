namespace WingspanCOTB.Data

module Week35 = 
    open WingspanCOTB
    open WingspanCOTB.Game
    open WingspanCOTB.Food
    open WingspanCOTB.StartingChoice

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
        PickBird(Birds.VauxsSwift); PickBird(Birds.RedBreastedMerganser); PickFood(Food.Fruit);
        PickFood(Food.Seed); PickFood(Food.Invertebrate); PickFood(Food.Rodent); PickFood(Food.Fish)]
    let bonusCardChoices = [ BonusCards.WetlandScientist; BonusCards.LargeBirdSpecialist ]
    let birdfeeder = [
        Fruit; InvertebrateOrSeed; InvertebrateOrSeed; Fish; Fish; InvertebrateOrSeed; Seed; Seed; 
        Seed; Fish; Seed]
    let birdDeck = [
        Birds.YellowBelliedSapsucker; Birds.GreatEgret; Birds.TreeSwallow
    ]