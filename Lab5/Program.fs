open System
open System.IO
open System.Threading.Tasks

//Для массива текстовых файлов выполнить задание в парадигме
//параллельного программирования и сформировать единый выходной файл.
//Вариант - 1. Для текстового файла определить длину самого длинного слова


// Функция для нахождения самого длинного слова в файле
let findLongestWordInFile (filePath: string) =
    let text = File.ReadAllText(filePath)
    let words = text.Split([|' '; '\n'; '\r'; '\t'; ','; '.'; ';'; ':'; '!'|], StringSplitOptions.RemoveEmptyEntries)
    words |> Seq.maxBy (fun word -> word.Length)

// Функция для обработки списка файлов параллельно
let findLongestWordInFilesParallel (filePaths: string list) =
    let tasks = 
        filePaths
        |> List.map (fun filePath -> Task.Run(fun () -> findLongestWordInFile filePath))
    
    // Ожидаем завершения всех задач и собираем результаты
    Task.WhenAll(tasks) |> Async.AwaitTask |> Async.RunSynchronously
    |> Array.maxBy (fun word -> word.Length) // Находим самое длинное слово среди всех файлов

// Функция для записи результата в выходной файл
let writeResultToFile (outputPath: string) (longestWord: string) =
    File.WriteAllText(outputPath, $"Самое длинное слово: {longestWord}")

// Основная программа
let main () =
    // Список файлов
    let filePaths = ["file1.txt"; "file2.txt"; "file3.txt"]

    // Выходной файл
    let outputPath = "output.txt"

    // Параллельно находим самое длинное слово среди всех файлов
    let longestWord = findLongestWordInFilesParallel filePaths

    // Записываем результат в выходной файл
    writeResultToFile outputPath longestWord

    // Печатаем результат в консоль
    printfn "Самое длинное слово: %s" longestWord

// Запускаем программу
main()
