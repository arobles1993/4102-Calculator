////module DisplayCalculator =

//open System
//open System.Windows.Forms
//open System.Drawing
//open System.Web.Services.Description


////set up constants for all format methods
//let form = new Form()
//let numButtonWidth = 70
//let numButtonHeight = 50
//let buttonSize = Size(numButtonWidth, numButtonHeight)
//let buttonSpacing = 10
//let mutable displayText = ""
//let textDisplayHeight = 50  
//form.Text <- "Pocket Calculator"
//let width = (4 * numButtonWidth) + (5 * buttonSpacing)
//let height = (8 * buttonSpacing) + (5 * numButtonHeight) + textDisplayHeight
//form.ClientSize <- Size(width, height)
//let displayFont = new Font(FontFamily.GenericSansSerif, 16.f)
//let buttonFont = new Font("Calibri", 13.f)
//let mutable numbuttonArray:Control[] = [||]
//let mutable operationButtonArray:Control[] = [||]
//let mutable clearButtons:Control[] = [||]
//let mutable specialButtons:Control[] = [||]
//let mutable labelDisplay = new Label()
//let mutable operationList = List.empty


//let formatDisplay = 
//    let displayLocation = Point(buttonSpacing, buttonSpacing)
//    let displaySize = Size((width - 20),textDisplayHeight)
//    labelDisplay <- new Label(Text = displayText, Size = displaySize, TextAlign = System.Drawing.ContentAlignment.MiddleRight, Location = displayLocation, BackColor = Color.LightGray, Font = displayFont)
//    form.Controls.Add(labelDisplay)

//let setButtonLocation x y = 
//    let xValue = (buttonSpacing * x) + (numButtonWidth * (x - 1))
//    let yValue = height - (y * buttonSpacing) - (y * numButtonHeight)
//    Point (xValue, yValue)

//let compute(arguments:List<string>) = 
//    displayText <- String.Empty
//    let mutable answer = ""
//    printfn "I'm in the compute function with list:"
//    printfn "%A" arguments 
//    //convert strings to floats and perform matching on symbols to do the math
//    let number1 = float arguments.[0]
//    let number2 = float arguments.[2]
//    match arguments.[1] with 
//    | "+" -> labelDisplay.Text <- sprintf "%f" (number1 + number2)
//    | "-" -> labelDisplay.Text <- sprintf "%f" (number1 - number2)
//    | "/" -> labelDisplay.Text <- sprintf "%f" (number1 / number2)
//    | "^" -> labelDisplay.Text <- sprintf "%f" (number1 ** number2)
//    | "x" -> labelDisplay.Text <- sprintf "%f" (number1 * number2)
//    | _ -> labelDisplay.Text <- sprintf "%s" "Error"

//    answer <- labelDisplay.Text
//    operationList <- List.empty
    

//let disableNegative(buttonNegative:Control) = 
//    buttonNegative.Enabled <- false

//let disableDot(buttonDot:Control) = 
//    buttonDot.Enabled <- false

//let enableOpeartionButtons() = 
//    for button in operationButtonArray do 
//        button.Enabled <- true
//        printfn "%s is enabled" button.Name

//let enableSpecialButtons() = 
//    for button in specialButtons do 
//        button.Enabled <- true

//let formatButtons = 
//    //bottom row (row 6)
//    let buttonNegative = new Button(Text = "(-)", Size = buttonSize, Location = setButtonLocation 1 1, Font = buttonFont)
//    let buttonZero = new Button(Text = "0", Size = buttonSize, Location = setButtonLocation 2 1, Font = buttonFont)
//    let buttonDot = new Button(Text = ".", Size = buttonSize, Location = setButtonLocation 3 1, Font = buttonFont)
//    let buttonEquals = new Button(Text = "=", Size = buttonSize, Location = setButtonLocation 4 1, Font = buttonFont)
//    //create events for special case buttons
//    buttonEquals.Click.Add(fun evArgs -> 
//        operationList <- List.append operationList [labelDisplay.Text]
//        compute(operationList)
//        enableOpeartionButtons()
//        enableSpecialButtons()
//        )
//    buttonDot.Click.Add(fun x ->
//        printfn "Dot was pressed"
//        displayText <- String.Concat(displayText, buttonDot.Text)
//        labelDisplay.Text <- sprintf "%s" displayText
//        disableDot(buttonDot)
//        disableNegative(buttonNegative)
//        )
//    buttonNegative.Click.Add(fun x -> 
//        printfn "Negative was pressed"
//        displayText <- String.Concat(displayText, "-")
//        labelDisplay.Text <- sprintf "%s" displayText
//        disableNegative(buttonNegative)
//        )

//    //next row up (row 5)
//    let buttonOne = new Button(Text = "1", Size = buttonSize, Location = setButtonLocation 1 2, Font = buttonFont)
//    let buttonTwo = new Button(Text = "2", Size = buttonSize, Location = setButtonLocation 2 2, Font = buttonFont)
//    let buttonThree = new Button(Text = "3", Size = buttonSize, Location = setButtonLocation 3 2, Font = buttonFont)
//    let buttonPlus = new Button(Text = "+", Size = buttonSize, Location = setButtonLocation 4 2, Font = buttonFont)

//    //row 4
//    let buttonFour = new Button(Text = "4", Size = buttonSize, Location = setButtonLocation 1 3, Font = buttonFont)
//    let buttonFive = new Button(Text = "5", Size = buttonSize, Location = setButtonLocation 2 3, Font = buttonFont)
//    let buttonSix = new Button(Text = "6", Size = buttonSize, Location = setButtonLocation 3 3, Font = buttonFont)
//    let buttonMinus = new Button(Text = "-", Size = buttonSize, Location = setButtonLocation 4 3, Font = buttonFont)

//    //row 3
//    let buttonSeven = new Button(Text = "7", Size = buttonSize, Location = setButtonLocation 1 4, Font = buttonFont)
//    let buttonEight = new Button(Text = "8", Size = buttonSize, Location = setButtonLocation 2 4, Font = buttonFont)
//    let buttonNine = new Button(Text = "9", Size = buttonSize, Location = setButtonLocation 3 4, Font = buttonFont)
//    let buttonMultiply = new Button(Text = "x", Size = buttonSize, Location = setButtonLocation 4 4, Font = buttonFont)

//    //row 2 (top row)
//    let buttonDivision = new Button(Text = "/", Size = buttonSize, Location = setButtonLocation 4 5, Font = buttonFont)
//    let buttonClearEverything = new Button(Text = "Clear", Size = Size(buttonSize.Width *2 + buttonSpacing, buttonSize.Height), Location = setButtonLocation 1 5, Font = buttonFont)
//    let buttonPower = new Button(Text = "^", Size = buttonSize, Location = setButtonLocation 3 5, Font = buttonFont)

//    //add buttons to arrays and 
//    numbuttonArray <- [|buttonZero; buttonOne; buttonTwo; buttonThree; buttonFour; buttonFive; buttonSix;buttonSeven; buttonEight; buttonNine|]
//    operationButtonArray <- [|buttonPlus; buttonMinus; buttonMultiply; buttonDivision; buttonPower|]
//    clearButtons <- [|buttonClearEverything|]
//    specialButtons <- [|buttonNegative; buttonDot|]

//    //add buttons to the form
//    form.Controls.AddRange(numbuttonArray) 
//    form.Controls.AddRange(clearButtons)
//    form.Controls.Add(buttonEquals)
//    form.Controls.AddRange(operationButtonArray)
//    form.Controls.AddRange(specialButtons)

//let disableOperationButtons() = 
//    for button in operationButtonArray do 
//        button.Enabled <- false
//        printfn "%s is disabled" button.Name
       
//let createNumButtonEvents = 
//    for button in numbuttonArray do 
//        button.Click.Add(fun x ->
//            if displayText.Length < 15 then 
//                displayText <- String.Concat(displayText, button.Text)
//                labelDisplay.Text <- sprintf "%s" displayText
//            ) 

//let createOperationButtonEvents = 
//    for button in operationButtonArray do 
//        button.Click.Add(fun x ->
//            operationList <- List.append operationList [labelDisplay.Text]
//            operationList <- List.append operationList [button.Text]
//            displayText <- String.Empty
//            labelDisplay.Text <- displayText
//            disableOperationButtons()
//            enableSpecialButtons()
//            printfn "%A" operationList
//            )
    
//let createClearButtonEvents = 
//    for button in clearButtons do 
//        button.Click.Add(fun clearAll ->
//            displayText <- String.Empty
//            labelDisplay.Text <- displayText
//            operationList <- List.Empty
//            enableOpeartionButtons()
//            enableSpecialButtons()
//            printfn "%A" operationList
//            )


//form.Show()
