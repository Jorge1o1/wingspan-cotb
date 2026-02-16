namespace WingspanCOTB

module Bird =
    open WingspanCOTB.Food

    type Nest =
        | Platform
        | Bowl
        | Cavity
        | Ground
        | WildNest

    type Habitat =
        | Forest
        | Grassland
        | Wetland

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

    let BlackChinnedHummingbird =
        { Name = "Black-Chinned Hummingbird"
          ScientificName = "Archilochus alexandri"
          IsPredator = false
          IsFlocking = false
          EggLimit = 2
          Habitats = [ Forest; Grassland; Wetland ]
          FoodCosts = [ Wild ]
          VictoryPoints = 4
          Nest = Bowl
          Wingspan = 8
          Characteristics = [] }

    let Brant =
        { Name = "Brant"
          ScientificName = "Branta bernicla"
          Habitats = [ Wetland ]
          IsPredator = false
          IsFlocking = false
          EggLimit = 2
          FoodCosts = [ Wild; SpecificFood Seed ]
          VictoryPoints = 3
          Nest = Ground
          Wingspan = 114
          Characteristics = [] }

    let BroadWingedHawk =
        { Name = "Broad-Winged Hawk"
          ScientificName = "Buteo platypterus"
          IsPredator = true
          IsFlocking = false
          EggLimit = 2
          Habitats = [ Forest ]
          FoodCosts = [ SpecificFood Rodent ]
          VictoryPoints = 4
          Nest = Platform
          Wingspan = 85
          Characteristics = [ BodyPart ] }

    let CaliforniaCondor =
        { Name = "California Condor"
          ScientificName = "Gymnogyps californianus"
          IsPredator = false
          IsFlocking = false
          EggLimit = 1
          Habitats = [ Grassland; Forest; Wetland ]
          FoodCosts = []
          VictoryPoints = 1
          Nest = Platform
          Wingspan = 277
          Characteristics = [ Geography ] }

    let CassinsFinch =
        { Name = "Cassin's Finch"
          ScientificName = "Haemorhous cassinii"
          IsPredator = false
          IsFlocking = false
          EggLimit = 3
          Habitats = [ Forest ]
          FoodCosts = [ SpecificFood Fruit; SpecificFood Seed ]
          VictoryPoints = 4
          Nest = Bowl
          Wingspan = 30
          Characteristics = [ Person ] }

    let GreatEgret =
        { Name = "Great Egret"
          ScientificName = "Ardea alba"
          IsPredator = false
          IsFlocking = false
          EggLimit = 3
          Habitats = [ Wetland ]
          FoodCosts = [ SpecificFood Fish; SpecificFood Food.Fish; SpecificFood Food.Rodent ]
          VictoryPoints = 7
          Nest = Platform
          Wingspan = 130
          Characteristics = [] }

    let PaintedWhitestart =
        { Name = "Painted Whitestart"
          ScientificName = "Myioborus pictus"
          IsPredator = false
          IsFlocking = false
          EggLimit = 3
          Habitats = [ Forest ]
          FoodCosts = [ SpecificFood Food.Invertebrate ]
          VictoryPoints = 1
          Nest = Ground
          Wingspan = 22
          Characteristics = [ Color ] }

    let PygmyNuthatch =
        { Name = "Pygmy Nuthatch"
          ScientificName = "Sitta pygmaea"
          IsPredator = false
          IsFlocking = true
          EggLimit = 2
          Habitats = [ Forest ]
          FoodCosts = [ SpecificFood Food.Invertebrate; SpecificFood Food.Seed ]
          VictoryPoints = 2
          Nest = Cavity
          Wingspan = 20
          Characteristics = [] }

    let RedBreastedMerganser =
        { Name = "Red-Breasted Merganser"
          ScientificName = "Mergus serrator"
          IsPredator = false
          IsFlocking = false
          EggLimit = 4
          Habitats = [ Wetland ]
          FoodCosts = [ SpecificFood Food.Invertebrate; SpecificFood Food.Fish ]
          VictoryPoints = 3
          Nest = Ground
          Wingspan = 78
          Characteristics = [ Color; BodyPart ] }

    let RedTailedHawk =
        { Name = "Red-Tailed Hawk"
          ScientificName = "Buteo jamaicensis"
          IsPredator = true
          IsFlocking = false
          EggLimit = 2
          Habitats = [ Forest; Grassland; Wetland ]
          FoodCosts = [ SpecificFood Food.Rodent; SpecificFood Food.Rodent ]
          VictoryPoints = 5
          Nest = Platform
          Wingspan = 124
          Characteristics = [ Color; BodyPart ] }

    let RoseBreastedGrosbeak =
        { Name = "Rose-Breasted Grosbeak"
          ScientificName = "Pheucticus ludovicianus"
          IsPredator = false
          IsFlocking = false
          EggLimit = 3
          Habitats = [ Forest ]
          FoodCosts =
            [ SpecificFood Food.Fruit
              SpecificFood Food.Invertebrate
              SpecificFood Food.Seed ]
          VictoryPoints = 6
          Nest = Bowl
          Wingspan = 33
          Characteristics = [ Color; BodyPart ] }

    let ScissorTailedFlycatcher =
        { Name = "Scissor-Tailed Flycatcher"
          ScientificName = "Tyrannus forficatus"
          IsPredator = false
          IsFlocking = false
          EggLimit = 2
          Habitats = [ Grassland ]
          FoodCosts =
            [ SpecificFood Food.Invertebrate
              SpecificFood Food.Invertebrate
              SpecificFood Food.Fruit ]
          VictoryPoints = 8
          Nest = Bowl
          Wingspan = 38
          Characteristics = [ BodyPart ] }

    let SongSparrow =
        { Name = "Song Sparrow"
          ScientificName = "Melospiza melodia"
          IsPredator = false
          IsFlocking = false
          EggLimit = 3
          Habitats = [ Forest; Grassland; Wetland ]
          FoodCosts = [ PickOneOf [ Food.Invertebrate; Food.Seed; Food.Fruit ] ]
          VictoryPoints = 0
          Nest = Bowl
          Wingspan = 20
          Characteristics = [] }

    let TreeSwallow =
        { Name = "Tree Swallow"
          ScientificName = "Tachycineta bicolor"
          IsPredator = false
          IsFlocking = true
          EggLimit = 4
          Habitats = [ Wetland ]
          FoodCosts = [ SpecificFood Food.Fruit; SpecificFood Food.Invertebrate ]
          VictoryPoints = 3
          Nest = Cavity
          Wingspan = 38
          Characteristics = [] }

    let WelcomeSwallow =
        { Name = "Welcome Swallow"
          ScientificName = "Hirundo neoxena"
          IsPredator = false
          IsFlocking = false
          EggLimit = 5
          Habitats = [ Wetland; Grassland ]
          FoodCosts = [ SpecificFood Food.Invertebrate; SpecificFood Food.Invertebrate ]
          VictoryPoints = 1
          Nest = WildNest
          Wingspan = 28
          Characteristics = [] }

    let WhiteBreastedNuthatch =
        { Name = "White-Breasted Nuthatch"
          ScientificName = "Sitta carolinensis"
          IsPredator = false
          IsFlocking = false
          EggLimit = 3
          Habitats = [ Forest ]
          FoodCosts = [ SpecificFood Food.Invertebrate; SpecificFood Food.Seed ]
          VictoryPoints = 2
          Nest = Cavity
          Wingspan = 28
          Characteristics = [] }

    let WoodDuck =
        { Name = "Wood Duck"
          ScientificName = "Aix sponsa"
          IsPredator = false
          IsFlocking = false
          EggLimit = 4
          Habitats = [ Forest; Wetland ]
          FoodCosts = [ SpecificFood Food.Seed; SpecificFood Food.Fruit ]
          VictoryPoints = 4
          Nest = Cavity
          Wingspan = 76
          Characteristics = [ Color ] }

    let VauxsSwift =
        { Name = "Vaux's Swift"
          ScientificName = "Chaetura vauxi"
          IsPredator = false
          IsFlocking = true
          EggLimit = 3
          Habitats = [ Forest ]
          FoodCosts = [ SpecificFood Food.Invertebrate ]
          VictoryPoints = 2
          Nest = Cavity
          Wingspan = 31
          Characteristics = [ Person ] }

    let YellowBelliedSapsucker =
        { Name = "Yellow-Bellied Sapsucker"
          ScientificName = "Sphyrapicus varius"
          IsPredator = false
          IsFlocking = false
          EggLimit = 3
          Habitats = [ Forest ]
          FoodCosts = [ SpecificFood Food.Invertebrate; SpecificFood Food.Fruit ]
          VictoryPoints = 3
          Nest = Cavity
          Wingspan = 41
          Characteristics = [ Color; BodyPart ] }

    let allBirds =
        [ BlackChinnedHummingbird
          Brant
          BroadWingedHawk
          CaliforniaCondor
          CassinsFinch
          GreatEgret
          PaintedWhitestart
          PygmyNuthatch
          RedBreastedMerganser
          RedTailedHawk
          RoseBreastedGrosbeak
          ScissorTailedFlycatcher
          SongSparrow
          TreeSwallow
          WelcomeSwallow
          WhiteBreastedNuthatch
          WoodDuck
          VauxsSwift
          YellowBelliedSapsucker ]
