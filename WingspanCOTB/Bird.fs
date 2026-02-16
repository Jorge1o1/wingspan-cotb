namespace WingspanCOTB

module Bird =
    open WingspanCOTB.Food

    type Nest =
        | Platform
        | Bowl
        | Cavity
        | Ground
        | Wild

    type Habitat =
        | Forest
        | Grassland
        | Ocean

    type NameCharacteristic =
        | Color
        | BodyPart
        | Geography
        | Person

    type Bird =
        { Name: string
          ScientificName: string
          IsPredator: bool
          IsFlocking: bool
          EggLimit: int
          Habitats: Habitat list
          FoodCosts: FoodCost list
          VictoryPoints: int
          Nest: Nest
          Wingspan: int
          Characteristics: NameCharacteristic list }
