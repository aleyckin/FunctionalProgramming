let doubleEvenElements (arr: int[]) =
    for i = 0 to arr.Length - 1 do
        if arr.[i] % 2 = 0 then
            arr.[i] <- arr.[i] * 2

let A = [|1; 3; 4; 5; 6|]

printfn "Исходный массив: %A" A

doubleEvenElements A

printfn "Измененный массив: %A" A
