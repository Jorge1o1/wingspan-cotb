namespace WingspanCOTB

open WingspanCOTB.Bird

module Board =
    type Board = {
        Forest: Bird list
        Grassland: Bird list
        Ocean: Bird list
    }

    let empty = {
        Forest = []
        Grassland = []
        Ocean = []
    }

    let getAllBirds board =
        board.Forest @ board.Grassland @ board.Ocean