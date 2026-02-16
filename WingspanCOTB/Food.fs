namespace WingspanCOTB

module Food =
    type Food =
        | Rodent
        | Invertebrate
        | Seed
        | Fish
        | Fruit

    type FoodCost =
        | SpecificFood of Food
        | PickOneOf of Food list
        | Wild

    type FoodDie =
        | Rodent
        | Invertebrate
        | Seed
        | Fish
        | Fruit
        | InvertebrateOrSeed
