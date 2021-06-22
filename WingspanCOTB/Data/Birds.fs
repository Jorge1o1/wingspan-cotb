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

    let PaintedWhitestart = {
        Name = "Painted Whitestart"
        Habitats = [Forest]
        FoodCosts = [Food.Invertebrate]
        Points = 1
        Nest = Enclosure
        Wingspan = 22
        Characteristics = [Color]
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

    let VauxsSwift = {
        Name = "Vaux's Swift"
        Habitats = [Forest]
        FoodCosts = [Food.Invertebrate]
        Points = 2
        Nest = Box
        Wingspan = 31
        Characteristics = [Person]
    }