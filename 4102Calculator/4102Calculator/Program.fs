open System

type Number = float
type Calculate = CalculatorInput * CalculatorState -> CalculatorState 
and CalculatorState = {
    display: CalculatorDisplay
    pendingOp: (CalculatorMathOp * Number) option
    }
and CalculatorDisplay = string
and CalculatorInput = 
    | Digit of CalculatorDigit
    | Op of CalculatorMathOp
    | Action of CalculatorAction
and CalculatorDigit = 
    | Zero | One | Two | Three | Four 
    | Five | Six | Seven | Eight | Nine
    | DecimalSeparator
and CalculatorMathOp = 
    | Add | Subtract | Multiply | Divide
and CalculatorAction = 
    | Equals | Clear

type UpdateDisplayFromDigit = CalculatorDigit * CalculatorDisplay -> CalculatorDisplay
type DoMathOperation = CalculatorMathOp * Number * Number -> Number
and MathOperationResult = 
    | Success of Number 
    | Failure of MathOperationError
and MathOperationError = 
    | DivideByZero

type GetDisplayNumber = CalculatorDisplay -> Number option
type SetDisplayNumber = Number -> CalculatorDisplay

type InitState = unit -> CalculatorState 
type CalculatorServices = {
    updateDisplayFromDigit: UpdateDisplayFromDigit 
    doMathOperation: DoMathOperation 
    getDisplayNumber: GetDisplayNumber 
    setDisplayNumber: SetDisplayNumber 
    initState: InitState 
    }

//type Calculate = CalculatorInput * CalculatorState -> CalculatorState 
//and CalculatorState = {
//    display: CalculatorDisplay
//    }
//and CalculatorDisplay = string
//and CalculatorInput = 
//    | Digit of CalculatorDigit
//    | Add | Subtract | Multiply | Divide
//    | Equals | Clear

//type UpdateDisplayFromDigit = CalculatorDigit * CalculatorDisplay -> CalculatorDisplay
//and CalculatorDigit = 
//    | Zero | One | Two | Three | Four 
//    | Five | Six | Seven | Eight | Nine
//    | DecimalSeparator

//let convertInputToDigit (input: CalculatorInput) =
//    match input with 
//        | CalculatorInput.Zero -> CalculatorDigit.Zero
//        | CalculatorInput.One -> CalculatorDigit.One
//        | CalculatorInput.Two -> CalculatorDigit.Two
//        | CalculatorInput.Three -> CalculatorDigit.Three
//        | CalculatorInput.Four -> CalculatorDigit.Four
//        | CalculatorInput.Five -> CalculatorDigit.Five
//        | CalculatorInput.Six -> CalculatorDigit.Six
//        | CalculatorInput.Seven -> CalculatorDigit.Seven
//        | CalculatorInput.Eight -> CalculatorDigit.Eight
//        | CalculatorInput.Nine -> CalculatorDigit.Nine
//        //| CalculatorInput.Add -> ???
//        //| CalculatorInput.Clear -> ???

//let demo() = 
//    printfn "test commit"

//demo()
Console.ReadKey() |>ignore 
