namespace WingspanCOTB

module Util =

    /// Shameless rip from https://stackoverflow.com/a/1231711
    let rec comb n l = 
        match n, l with
        | 0, _ -> [[]]
        | _, [] -> []
        | k, (x::xs) -> List.map ((@) [x]) (comb (k-1) xs) @ comb k xs