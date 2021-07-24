namespace WingspanCOTB.Data

module Birds =
    open WingspanCOTB.Bird
    open WingspanCOTB.Food

    let Brant = {
        Name = "Brant"
        Habitats = [Ocean]
        FoodCosts = [Wild; Food.Seed]
        Points = 3
        Nest = Enclosure
        Wingspan = 114
        Characteristics = []
    }
    
    let BroadWingedHawk = {
        Name = "Broad-Winged Hawk"
        Habitats = [Forest]
        FoodCosts = [Food.Rodent]
        Points = 4
        Nest = Platform
        Wingspan = 85
        Characteristics = [BodyPart]
    }

    let CassinsFinch = {
        Name = "Cassin's Finch"
        Habitats = [Forest]
        FoodCosts = [Food.Fruit; Food.Seed]
        Points = 4
        Nest = Garden
        Wingspan = 30
        Characteristics = [Person]
    }

    let GreatEgret = {
        Name = "Great Egret"
        Habitats = [Ocean]
        FoodCosts = [Food.Fish; Food.Fish; Food.Rodent]
        Points = 7
        Nest = Platform
        Wingspan = 130
        Characteristics = []
    }

    let PaintedWhitestart = {
        Name = "Painted Whitestart"
        Habitats = [Forest]
        FoodCosts = [Food.Invertebrate]
        Points = 1
        Nest = Enclosure
        Wingspan = 22
        Characteristics = [Color]
    }

    let PygmyNuthatch = {
        Name = "Pygmy Nuthatch"
        Habitats = [Forest]
        FoodCosts = [Food.Invertebrate; Food.Seed]
        Points = 2
        Nest = Box
        Wingspan = 20
        Characteristics = []
    }

    let RedBreastedMerganser = {
        Name = "Red-Breasted Merganser"
        Habitats = [Ocean]
        FoodCosts = [Food.Invertebrate; Food.Fish]
        Points = 3
        Nest = Enclosure
        Wingspan = 78
        Characteristics = [Color; BodyPart]
    }

    let RedTailedHawk = {
        Name = "Red-Tailed Hawk"
        Habitats = [Forest; Grassland; Ocean]
        FoodCosts = [Food.Rodent; Food.Rodent]
        Points = 5
        Nest = Platform
        Wingspan = 124
        Characteristics = [Color; BodyPart]
    }

    let RoseBreastedGrosbeak = {
        Name = "Rose-Breasted Grosbeak"
        Habitats = [Forest]
        FoodCosts = [Food.Fruit; Food.Invertebrate; Food.Seed]
        Points = 6
        Nest = Garden
        Wingspan = 33
        Characteristics = [Color; BodyPart]
    }

    let ScissorTailedFlycatcher = {
        Name = "Scissor-Tailed Flycatcher"
        Habitats = [Grassland]
        FoodCosts = [Food.Invertebrate; Food.Invertebrate; Food.Fruit]
        Points = 8
        Nest = Garden
        Wingspan = 38
        Characteristics = [BodyPart]
    }

    let SongSparrow = {
        Name = "Song Sparrow"
        Habitats = [Forest; Grassland; Ocean]
        FoodCosts = [Food.Wild] //TODO: not actually wild
        Points = 0
        Nest = Garden
        Wingspan = 20
        Characteristics = []
    }

    let TreeSwallow = {
        Name = "Tree Swallow"
        Habitats = [Ocean]
        FoodCosts = [Food.Fruit; Food.Invertebrate]
        Points = 3
        Nest = Box
        Wingspan = 38
        Characteristics = []
    }

    let VauxsSwift = {
        Name = "Vaux's Swift"
        Habitats = [Forest]
        FoodCosts = [Food.Invertebrate]
        Points = 2
        Nest = Box
        Wingspan = 31
        Characteristics = [Person]
    }

    let YellowBelliedSapsucker = {
        Name = "Yellow-Bellied Sapsucker"
        Habitats = [Forest]
        FoodCosts = [Food.Invertebrate; Food.Fruit]
        Points = 3
        Nest = Box
        Wingspan = 41
        Characteristics = [Color; BodyPart]
    }