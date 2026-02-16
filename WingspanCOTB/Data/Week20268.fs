namespace WingspanCOTB.Data

module Week20268 =
    open WingspanCOTB
    open WingspanCOTB.Game
    open WingspanCOTB.Food
    open WingspanCOTB.StartingChoice

    let automaBonusCard = BonusCards.Anatomist

    let automaMoves =
        [ AutomaMove(AutomaDrawCards, AutomaRemoveFromGoal)
          AutomaMove(AutomaLayEggs(3), AutomaAddToGoal)
          AutomaMove(AutomaLayEggs(3), AutomaAddToGoal)
          AutomaMove(
              AutomaGainFood([ InvertebrateOrSeed; Invertebrate; Seed; Rodent; Fish; Fruit ]),
              AutomaActivateAllPink
          )
          AutomaMove(AutomaPlayBirds, AutomaAddToGoal)
          AutomaMove(AutomaPlayBirds, AutomaAddToGoal)
          AutomaMove(
              AutomaGainFood([ Rodent; Fish; Fruit; InvertebrateOrSeed; Invertebrate; Seed ]),
              AutomaActivateAllPink
          )
          AutomaMove(AutomaDrawCards, AutomaAddToGoal)
          AutomaMove(
              AutomaGainFood([ InvertebrateOrSeed; Invertebrate; Seed; Rodent; Fish; Fruit ]),
              AutomaActivateAllPink
          ) ]

    let startingChoices =
        [ PickBird(Birds.CaliforniaCondor)
          PickBird(Birds.BlackChinnedHummingbird)
          PickBird(Birds.WoodDuck)
          PickBird(Birds.WhiteBreastedNuthatch)
          PickBird(Birds.WelcomeSwallow)
          PickFood(Food.Fruit)
          PickFood(Food.Seed)
          PickFood(Food.Invertebrate)
          PickFood(Food.Rodent)
          PickFood(Food.Fish) ]

    let bonusCardChoices =
        [ BonusCards.WetlandScientist; BonusCards.LargeBirdSpecialist ]

    let birdfeeder =
        [ Fruit
          InvertebrateOrSeed
          InvertebrateOrSeed
          Fish
          Fish
          InvertebrateOrSeed
          Seed
          Seed
          Seed
          Fish
          Seed ]

    let birdDeck =
        [ Birds.YellowBelliedSapsucker
          Birds.GreatEgret
          Birds.TreeSwallow
          Birds.PygmyNuthatch
          Birds.ScissorTailedFlycatcher ]
