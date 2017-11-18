module CalculatorUI

open System
open System.Windows.Forms
open System.Drawing 
open System.Windows.Forms.VisualStyles
 

type public CreateForm() = 
    inherit Form()
    
    let form = new Form()
    let height = 400
    let width = 300
    let numButtonWidth = 50
    let numButtonHeight = 50
    let buttonSpacing = 15
    let mutable displayText = "0"
    let textDisplayHeight = 100//going with 100 for now 
    //etc

    member this.initializeDisplay = 
        form.Text <- "Pocket Calculator"
        let width = (4 * numButtonWidth) + (5 * buttonSpacing)
        let height = (8 * buttonSpacing) + (5 * numButtonHeight) + textDisplayHeight
        form.ClientSize <- Size(width, height)
        let displayLocation = Point(buttonSpacing, buttonSpacing)
        let displaySize = Size((width - 30),textDisplayHeight)
        let labelDisplay = new Label(Text = displayText, Size = displaySize, TextAlign = System.Drawing.ContentAlignment.MiddleRight, Location = displayLocation)
        form.Controls.Add(labelDisplay)
        

    //member public this.DisplayForm(isInitialized:bool) = 
    //    match isInitialized with 
    //    | true -> form.Show()
    //    | false -> //do nothing for now i guess



//form.Controls.Add label1

