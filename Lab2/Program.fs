open System.IO

// Лабораторная работа 2 - Последовательности
// 1. Для текстового файла определить длину самого длинного слова


let findLongestWord filePath = 
    let text = File.ReadAllText(filePath)
    let words = text.Split([|' '; '\n'; '\r'; '\t'; ','; '.'; ';'; ':'; '!'|], System.StringSplitOptions.RemoveEmptyEntries)
    
    let longestWord = 
        words 
        |> Seq.maxBy (fun word -> word.Length)
    
    longestWord

let filePath = "file.txt"

let longestWord = findLongestWord filePath
printfn "Самое длинное слово: %s, его длина: %d" longestWord longestWord.Length
