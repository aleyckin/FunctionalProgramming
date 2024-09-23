let numbers = [1..100]

let isMultiple3and5 x = (x % 3 = 0 || x % 5 = 0)

let sum =
    numbers
    |> List.filter isMultiple3and5
    |> List.sum

printf "Сумма чисел кратных 3 и 5 равна => %d" sum