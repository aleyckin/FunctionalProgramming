open System.IO

// Функция для чтения файла и нахождения самого длинного слова
let findLongestWord filePath = 
    let text = File.ReadAllText(filePath)
    let words = text.Split([|' '; '\n'; '\r'; '\t'; ','; '.'; ';'; ':'; '!'|], System.StringSplitOptions.RemoveEmptyEntries)
    
    // Находим самое длинное слово
    let longestWord = 
        words 
        |> Seq.maxBy (fun word -> word.Length)
    
    longestWord

// Указываем путь к файлу
let filePath = "file.txt"

// Вызываем функцию и выводим результат
let longestWord = findLongestWord filePath
printfn "Самое длинное слово: %s, его длина: %d" longestWord longestWord.Length
