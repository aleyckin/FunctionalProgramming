//Создать иерархию классов и интерфейсов для предметной области
//(класса 3 – 4, из них хотя бы один класс должен являться наследником другого класса)
// Вариант - 1 : Библиотека

// Определяем интерфейс IBook
type IBook =
    abstract member GetTitle: unit -> string
    abstract member GetAuthor: unit -> string
    abstract member PrintDetails: unit -> unit

// Базовый класс Book
type Book(title: string, author: string) =
    member this.Title = title
    member this.Author = author

    // Обычная информация о книге
    member this.GetBasicInfo() =
        sprintf "Title: %s, Author: %s" this.Title this.Author

// Класс для печатной книги, наследующий Book и реализующий интерфейс IBook
type PrintedBook(title: string, author: string, pages: int) =
    inherit Book(title, author)

    // Количество страниц в книге
    member this.Pages = pages

    interface IBook with
        member this.GetTitle() = this.Title
        member this.GetAuthor() = this.Author
        member this.PrintDetails() =
            printfn "Printed Book - %s, Author: %s, Pages: %d" this.Title this.Author this.Pages

// Класс для электронной книги, наследующий Book и реализующий интерфейс IBook
type EBook(title: string, author: string, fileSize: float) =
    inherit Book(title, author)

    // Размер файла книги в мегабайтах
    member this.FileSize = fileSize

    interface IBook with
        member this.GetTitle() = this.Title
        member this.GetAuthor() = this.Author
        member this.PrintDetails() =
            printfn "EBook - %s, Author: %s, File size: %.2f MB" this.Title this.Author this.FileSize

// Класс библиотеки, который хранит книги
type Library() =
    // Список книг
    let mutable books: IBook list = []

    // Метод добавления книги
    member this.AddBook (book: IBook) =
        books <- book :: books

    // Метод для печати всех книг в библиотеке
    member this.PrintAllBooks() =
        books |> List.iter (fun book -> book.PrintDetails())

// Пример использования
let main() =
    // Создаем библиотеку
    let library = Library()

    // Создаем печатную книгу
    let printedBook = PrintedBook("The Catcher in the Rye", "J.D. Salinger", 277) :> IBook

    // Создаем электронную книгу
    let eBook = EBook("1984", "George Orwell", 1.25) :> IBook

    // Добавляем книги в библиотеку
    library.AddBook(printedBook)
    library.AddBook(eBook)

    // Печатаем информацию о всех книгах в библиотеке
    library.PrintAllBooks()

// Запускаем пример
main()
