//Calculator Prototype 1

open System

let mutable condition = true

while (condition) do

    Console.WriteLine("Choose a function: \n1.Addition\n2.Subtraction\n3.Multiplication\n4.Division\n5.Modulo\n6.Select All")

    let userInput = Console.ReadLine()

    Console.WriteLine("Enter in 2 numbers: ")

    let firstNum = Console.ReadLine()
    let secNum = Console.ReadLine()

    let first : int = int32 firstNum
    let second : int = int32 secNum
    (*======= Fuctions =======*)

    let add x y = x + y
    let sub x y = x - y
    let mul x y = x * y
    let div x y = x / y
    let MOD x y = x % y

    (*========================*)

    (*========= Print =========*)
    let selall() =
        printfn("The Results for two numbers: ")
        printfn("1. The result is: %d") (add first second)
        printfn("2. The result is: %d") (sub first second)
        printfn("3. The result is: %d") (mul first second)
        printfn("4. The result is: %d") (div first second)
        printfn("5. The result is: %d") (MOD first second)
    (*========================*)

    match userInput with
    |   "1" -> printfn("1. The result is: %d") (add first second)
    |   "2" -> printfn("2. The result is: %d") (sub first second)
    |   "3" -> printfn("3. The result is: %d") (mul first second)
    |   "4" -> printfn("4. The result is: %d") (div first second)
    |   "5" -> printfn("5. The result is: %d") (MOD first second)
    |   "6" -> selall()
    |   _ -> printfn("Choose between 1 to 6!")
     
    Console.WriteLine("Would you like to restart the calculator again? y/n")
    let final = Console.ReadLine()

    if final = "n" then
        condition <- false
    else 
        Console.Clear()
