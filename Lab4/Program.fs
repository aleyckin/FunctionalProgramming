//Создать иерархию классов и интерфейсов для предметной области
//(класса 3 – 4, из них хотя бы один класс должен являться наследником другого класса)
// Вариант - 1 : Библиотека

// Интерфейс для пользователя библиотеки
type IBookUser =
    abstract member Name: string
    abstract member Role: string
    abstract member PrintUserDetails: unit -> unit

// Интерфейс IBook
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

// Класс для библиотекаря, реализующий интерфейс IBookUser
type Librarian(name: string) =
    member this.Name = name

    interface IBookUser with
        member this.Name = this.Name
        member this.Role = "Librarian"
        member this.PrintUserDetails() =
            printfn "Librarian: %s" this.Name

    // Метод для добавления книг в библиотеку
    member this.AddBookToLibrary (library: Library) (book: IBook) =
        printfn "Librarian %s adds a book to the library." this.Name
        library.AddBook(book)

// Класс для читателя, реализующий интерфейс IBookUser
type Reader(name: string) =
    member this.Name = name

    interface IBookUser with
        member this.Name = this.Name
        member this.Role = "Reader"
        member this.PrintUserDetails() =
            printfn "Reader: %s" this.Name

    // Метод для чтения информации о книгах
    member this.ViewBooks (library: Library) =
        printfn "%s is viewing books in the library." this.Name
        library.PrintAllBooks()

// Пример использования
let main() =
    // Создаем библиотеку
    let library = Library()

    // Создаем библиотекаря
    let librarian = Librarian("Alice")

    // Создаем печатную книгу
    let printedBook = PrintedBook("The Catcher in the Rye", "J.D. Salinger", 277) :> IBook

    // Создаем электронную книгу
    let eBook = EBook("1984", "George Orwell", 1.25) :> IBook

    // Библиотекарь добавляет книги в библиотеку
    librarian.AddBookToLibrary library printedBook
    librarian.AddBookToLibrary library eBook

    // Создаем читателя
    let reader = Reader("Bob")

    // Читатель просматривает все книги в библиотеке
    reader.ViewBooks library

// Запускаем пример
main()
