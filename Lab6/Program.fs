open System.Text

//Задать интерпретацию команд и построить первые итерации в задаваемом
//количестве для следующей L-системы:
//Вариант - 1. F++F++F++, F -> F-F++F-F

// Функция для замены символов по правилам L-системы
let rec applyRules (axiom: string) (rules: Map<char, string>) (iterations: int) =
    let rec iterate (input: string) (n: int) =
        if n = 0 then input
        else
            let sb = StringBuilder()
            for ch in input do
                if rules.ContainsKey(ch) then
                    sb.Append(rules.[ch]) |> ignore
                else
                    sb.Append(ch) |> ignore
            sb.ToString()
    
    // Проходим по всем итерациям и выводим результат каждой итерации
    let mutable current = axiom
    for i in 0..iterations do
        printfn "Итерация %d: %s" i current
        current <- iterate current 1

// Задаем правила для символов L-системы
let rules = Map.ofList [('F', "F-F++F-F")]

// Аксиома (начальная строка)
let axiom = "F++F++F++"

// Количество итераций
let iterations = 2

// Генерация результата и вывод промежуточных итераций
applyRules axiom rules iterations