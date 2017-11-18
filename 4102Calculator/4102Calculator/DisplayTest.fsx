open System
open System.Windows.Forms
open System.Drawing

//set up constants for all format methods
let form = new Form()
let numButtonWidth = 70
let numButtonHeight = 50
let buttonSize = Size(numButtonWidth, numButtonHeight)
let buttonSpacing = 10
let mutable displayText = ""
let textDisplayHeight = 50//going with 50, it seems like a nice height  
form.Text <- "Pocket Calculator"
let width = (4 * numButtonWidth) + (5 * buttonSpacing)
let height = (9 * buttonSpacing) + (6 * numButtonHeight) + textDisplayHeight
form.ClientSize <- Size(width, height)
let displayFont = new Font(FontFamily.GenericSansSerif, 16.f)
let buttonFont = new Font("Calibri", 13.f)
let mutable numbuttonArray:Control[] = [||]
let mutable operationButtonArray:Control[] = [||]
let mutable clearButtons:Control[] = [||]
let mutable labelDisplay = new Label()
let mutable operationList = ["+"]

let formatDisplay = 
    let displayLocation = Point(buttonSpacing, buttonSpacing)
    let displaySize = Size((width - 20),textDisplayHeight)
    labelDisplay <- new Label(Text = displayText, Size = displaySize, TextAlign = System.Drawing.ContentAlignment.MiddleRight, Location = displayLocation, BackColor = Color.LightGray, Font = displayFont)
    form.Controls.Add(labelDisplay)

let setButtonLocation x y = 
    let xValue = (buttonSpacing * x) + (numButtonWidth * (x - 1))
    let yValue = height - (y * buttonSpacing) - (y * numButtonHeight)
    Point (xValue, yValue)

let formatButtons = 
    //bottom row (row 6)
    let buttonNegative = new Button(Text = "( - )", Size = buttonSize, Location = setButtonLocation 1 1, Font = buttonFont)
    let buttonZero = new Button(Text = "0", Size = buttonSize, Location = setButtonLocation 2 1, Font = buttonFont)
    let buttonDot = new Button(Text = ".", Size = buttonSize, Location = setButtonLocation 3 1, Font = buttonFont)
    let buttonEquals = new Button(Text = "=", Size = buttonSize, Location = setButtonLocation 4 1, Font = buttonFont)

    //next row up (row 5)
    let buttonOne = new Button(Text = "1", Size = buttonSize, Location = setButtonLocation 1 2, Font = buttonFont)
    let buttonTwo = new Button(Text = "2", Size = buttonSize, Location = setButtonLocation 2 2, Font = buttonFont)
    let buttonThree = new Button(Text = "3", Size = buttonSize, Location = setButtonLocation 3 2, Font = buttonFont)
    let buttonPlus = new Button(Text = "+", Size = buttonSize, Location = setButtonLocation 4 2, Font = buttonFont)

    //row 4
    let buttonFour = new Button(Text = "4", Size = buttonSize, Location = setButtonLocation 1 3, Font = buttonFont)
    let buttonFive = new Button(Text = "5", Size = buttonSize, Location = setButtonLocation 2 3, Font = buttonFont)
    let buttonSix = new Button(Text = "6", Size = buttonSize, Location = setButtonLocation 3 3, Font = buttonFont)
    let buttonMinus = new Button(Text = "-", Size = buttonSize, Location = setButtonLocation 4 3, Font = buttonFont)

    //row 3
    let buttonSeven = new Button(Text = "7", Size = buttonSize, Location = setButtonLocation 1 4, Font = buttonFont)
    let buttonEight = new Button(Text = "8", Size = buttonSize, Location = setButtonLocation 2 4, Font = buttonFont)
    let buttonNine = new Button(Text = "9", Size = buttonSize, Location = setButtonLocation 3 4, Font = buttonFont)
    let buttonMultiply = new Button(Text = "x", Size = buttonSize, Location = setButtonLocation 4 4, Font = buttonFont)

    //row 2
    let buttonOpenParenthesis = new Button(Text = "(", Size = buttonSize, Location = setButtonLocation 1 5, Font = buttonFont)
    let buttonCloseParenthesis = new Button(Text = ")", Size = buttonSize, Location = setButtonLocation 2 5, Font = buttonFont)
    let buttonFactorial = new Button(Text = "!", Size = buttonSize, Location = setButtonLocation 3 5, Font = buttonFont)
    let buttonDivision = new Button(Text = "/", Size = buttonSize, Location = setButtonLocation 4 5, Font = buttonFont)

    //row 1 (top Row)
    let buttonClear = new Button(Text = "C", Size = buttonSize, Location = setButtonLocation 4 6, Font = buttonFont)
    let buttonClearEverything = new Button(Text = "CE", Size = buttonSize, Location = setButtonLocation 3 6, Font = buttonFont)

    numbuttonArray <- [|buttonNegative; buttonZero; buttonOne; buttonTwo; 
    buttonThree; buttonFour; buttonFive; buttonSix;buttonSeven; buttonEight; buttonNine|]
    
    operationButtonArray <- [|buttonDot; buttonPlus; buttonMinus; buttonMultiply; buttonDivision; 
    buttonOpenParenthesis; buttonCloseParenthesis; buttonFactorial|]

    clearButtons <- [|buttonClear; buttonClearEverything|]

    form.Controls.AddRange(numbuttonArray) 
    form.Controls.AddRange(clearButtons)
    form.Controls.Add(buttonEquals)
    form.Controls.AddRange(operationButtonArray)

    
let createNumButtonEvents = 
    for button in numbuttonArray do 
        button.Click.Add(fun x ->
            if displayText.Length < 20 then //arbitrary limit on how many characters can be entered at a time
                displayText <- String.Concat(displayText, button.Text)
                labelDisplay.Text <- sprintf "%s" displayText
            )

//let createOperationButtonHandler = 
//    for button in operationButtonArray do 
//        match button.Name with
//        |"buttonDot" -> operationList <- List.append operationList ["."]  //not so sure about having buttonDot here
//        |"buttonPlus" -> operationList <- List.append operationList ["+"]
//        |"buttonMinus" -> operationList <- List.append operationList ["-"]
//        |"buttonMultiply" -> operationList <- List.append operationList ["x"]
//        |"buttonDivision" -> operationList <- List.append operationList ["/"]
//        |"buttonOpenParenthesis" -> operationList <- List.append operationList ["("]
//        |"buttonCloseParenthesis" -> operationList <- List.append operationList [")"]
//        |"buttonFactorial" -> operationList <- List.append operationList ["!"]

let createOperationButtonEvents = 
    for button in operationButtonArray do 
        button.Click.Add(fun x ->
            if displayText.Length < 20 then //arbitrary limit on how many characters can be entered at a time
                displayText <- String.Concat(displayText, button.Text)
                labelDisplay.Text <- sprintf "%s" displayText
            )

//TODO: Find out what's wrong with the match statements. I think I just need to have them do something at the end, but idk
//let createClearButtonEvents = 
//    for button in clearButtons do 
//        match button.Text with
//        |"C" ->
//            button.Click.Add(fun clear -> 
//                //displayText <- String.Empty // find a way to remove last element in list. No array.remove feelsbadman
//                labelDisplay.Text <- displayText
//                //remove the last element in the list. Put logic in to remove digits and symbols  
//                )
//        |"CE" ->
//            button.Click.Add(fun clearAll ->
//                displayText <- String.Empty
//                labelDisplay.Text <- displayText
//                operationList <- List.Empty
//                //TODO: I imagine eventually there will be an arugments list, empty that shit too 
//                )

let tempClearAllEvent = 
    clearButtons.[1].Click.Add(fun clearAll ->
        displayText <- String.Empty
        labelDisplay.Text <- displayText
        operationList <- List.empty
        )


form.Show()
