namespace WingspanCOTB.Data

module Week35 =
    open WingspanCOTB
    open WingspanCOTB.Game
    open WingspanCOTB.Food
    open WingspanCOTB.StartingChoice

    let automaBonusCard = BonusCard.Anatomist

    let automaMoves =
        [ AutomaMove(AutomaDrawCards, AutomaRemoveFromGoal)
          AutomaMove(AutomaLayEggs(3), AutomaAddToGoal)
          AutomaMove(AutomaLayEggs(3), AutomaAddToGoal)
          AutomaMove(
              AutomaGainFood(
                  [ InvertebrateOrSeed
                    SingleFace Invertebrate
                    SingleFace Seed
                    SingleFace Rodent
                    SingleFace Fish
                    SingleFace Fruit ]
              ),
              AutomaActivateAllPink
          )
          AutomaMove(AutomaPlayBirds, AutomaAddToGoal)
          AutomaMove(AutomaPlayBirds, AutomaAddToGoal)
          AutomaMove(
              AutomaGainFood(
                  [ SingleFace Rodent
                    SingleFace Fish
                    SingleFace Fruit
                    InvertebrateOrSeed
                    SingleFace Invertebrate
                    SingleFace Seed ]
              ),
              AutomaActivateAllPink
          )
          AutomaMove(AutomaDrawCards, AutomaAddToGoal)
          AutomaMove(
              AutomaGainFood(
                  [ InvertebrateOrSeed
                    SingleFace Invertebrate
                    SingleFace Seed
                    SingleFace Rodent
                    SingleFace Fish
                    SingleFace Fruit ]
              ),
              AutomaActivateAllPink
          ) ]

    let startingChoices =
        [ PickBird(Bird.BroadWingedHawk)
          PickBird(Bird.PaintedWhitestart)
          PickBird(Bird.Brant)
          PickBird(Bird.VauxsSwift)
          PickBird(Bird.RedBreastedMerganser)
          PickFood(Food.Fruit)
          PickFood(Food.Seed)
          PickFood(Food.Invertebrate)
          PickFood(Food.Rodent)
          PickFood(Food.Fish) ]

    let bonusCardChoices = [ BonusCard.WetlandScientist; BonusCard.LargeBirdSpecialist ]

    let birdfeeder =
        [ SingleFace Fruit
          InvertebrateOrSeed
          InvertebrateOrSeed
          SingleFace Fish
          SingleFace Fish
          InvertebrateOrSeed
          SingleFace Seed
          SingleFace Seed
          SingleFace Seed
          SingleFace Fish
          SingleFace Seed ]

    let birdDeck =
        [ Bird.YellowBelliedSapsucker
          Bird.GreatEgret
          Bird.TreeSwallow
          Bird.PygmyNuthatch
          Bird.ScissorTailedFlycatcher ]
