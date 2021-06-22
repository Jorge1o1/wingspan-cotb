namespace WingspanCOTB

module Bird =
    open WingspanCOTB.Food

    type Nest = 
        | Platform
        | Garden
        | Box
        | Enclosure
        | Star

    type Habitat =
        | Forest
        | Grassland
        | Ocean
    
    type NameCharacteristic =
        | Color
        | BodyPart
        | Geography
        | Person

    type Bird = {
        Name: string
        Habitats: Habitat list
        FoodCosts: Food list
        Points: int
        Nest: Nest
        Wingspan: int
        Characteristics: NameCharacteristic list
    }