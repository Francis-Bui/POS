Public Class Form1

    'State Variables'
    Dim state As Integer = 0
    Dim confirm As Boolean = False
    Dim correctPayment As Boolean = False
    Dim purchaseNext As Boolean = False
    Dim reset As Boolean = False

    'Calculation Variables'
    Dim subtotal As Decimal = 0.0
    Dim tax As Decimal = 0
    Dim hst As Decimal = 0.13
    Dim total As Decimal = 0
    Dim prevSubtotal As Decimal = 0
    Dim prevCost As Decimal = 0

    'Memory Variables'
    Dim coneCost As Decimal = 0
    Dim scoopOneCost As Decimal = 0
    Dim scoopTwoCost As Decimal = 0
    Dim toppingCost As Decimal = 0
    Dim payment As Decimal = 0

    'Cone Pricing Variables'
    Dim cup As Decimal = 0.49
    Dim cone As Decimal = 0.99
    Dim chocolateCone As Decimal = 1.49

    'Icecream Pricing Variables'
    Dim vanilla As Decimal = 1.99
    Dim chocolate As Decimal = 1.99
    Dim cookiesCream As Decimal = 2.49
    Dim mint As Decimal = 2.49
    Dim cookieDough As Decimal = 2.49
    Dim pecan As Decimal = 2.49
    Dim birthday As Decimal = 2.49
    Dim strawberry As Decimal = 1.99

    'Topping Pricing Variables'
    Dim sprinkles As Decimal = 0.99
    Dim oreo As Decimal = 1.49
    Dim caramel As Decimal = 1.49

    'Button Visibility Updater'
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If state = 0 Then
            lblMenuType.Text = ("Choose a Cup/Cone")
            btnMenu1.BackColor = Color.Transparent
            btnMenu2.BackColor = Color.Transparent
            btnMenu3.BackColor = Color.Transparent
            btnMenu1.Text = Nothing
            btnMenu2.Text = Nothing
            btnMenu3.Text = Nothing
            btnMenu1.BackgroundImage = My.Resources.a_ConeA
            btnMenu2.BackgroundImage = My.Resources.a_ConeB
            btnMenu3.BackgroundImage = My.Resources.a_ConeC
            btnMenu4.Visible = False
            btnMenu5.Visible = False
            btnMenu6.Visible = False
            btnMenu7.Visible = False
            btnMenu8.Visible = False
            btnMenu9.Visible = False
            btnMenu10.Visible = False
            tbCash.Visible = False
        ElseIf state = 1 Or state = 2 Then
            lblMenuType.Text = ("Choose a Scoop!")
            btnMenu1.BackgroundImage = My.Resources.b_flavourA
            btnMenu2.BackgroundImage = My.Resources.b_flavourB
            btnMenu3.BackgroundImage = My.Resources.b_flavourC
            btnMenu4.Visible = True
            btnMenu5.Visible = True
            btnMenu6.Visible = True
            btnMenu7.Visible = True
            btnMenu8.Visible = True
            btnMenu9.Visible = True
            btnMenu10.Visible = True
        ElseIf state = 3 Then
            lblMenuType.Text = ("Choose a Topping!")
            btnMenu1.BackgroundImage = My.Resources.c_toppingA
            btnMenu2.BackgroundImage = My.Resources.c_toppingB
            btnMenu3.BackgroundImage = My.Resources.c_toppingC
            btnMenu1.Text = Nothing
            btnMenu2.Text = Nothing
            btnMenu3.Text = Nothing
            btnMenu4.Visible = False
            btnMenu5.Visible = False
            btnMenu6.Visible = False
            btnMenu7.Visible = False
            btnMenu8.Visible = False
        ElseIf state = 4 Then
            lblMenuType.Text = ("Choose a Payment Method")
            btnMenu1.BackgroundImage = Nothing
            btnMenu2.BackgroundImage = Nothing
            btnMenu3.BackgroundImage = Nothing
            btnMenu10.Visible = False
            btnMenu1.Text = ("Card")
            btnMenu2.Text = ("Cash")
            btnMenu3.Text = ("Confirm")
        ElseIf state = 5 Then
            btnMenu9.Visible = False
        End If

        If reset = True Then
            'Reset'
            state = 0
            pbPreviewCone.BackgroundImage = Nothing
            pbPreviewScoopOne.BackgroundImage = Nothing
            pbPreviewScoopTwo.BackgroundImage = Nothing
            pbPreviewTopping.BackgroundImage = Nothing
            lbReceipt.Items.Clear()
            subtotal = 0
            confirm = False
            correctPayment = False
            purchaseNext = False
            btnPurchase.BackColor = Color.Transparent
            tbCash.Text = Nothing
            'Setting reset to false runs this only once'
            reset = False
            lbReceipt.Items.Add("      Thank you for shopping at Ice Cream Social")
            lbReceipt.Items.Add("                       Outside")
            lbReceipt.Items.Add("                   727-427-2827")
            lbReceipt.Items.Add("")
            lbReceipt.Items.Add(Now)
            lbReceipt.Items.Add("")
            lbReceipt.Items.Add("-------------------------------------------------------------------------")
            lbReceipt.Items.Add("")
        End If

        tbSubtotal.Text = "$" & subtotal
        'Calculate Tax'
        tax = subtotal * hst
        tax = Math.Round(tax, 2)
        tbTax.Text = "$" & tax

        'Final Total'

        total = subtotal + tax
        tbTotal.Text = "$" & total

    End Sub

    Private Sub btnMenu1_Click(sender As System.Object, e As System.EventArgs) Handles btnMenu1.Click

        'Switch Case'
        If state = 0 Then
            subtotal = subtotal + cup
            lbReceipt.Items.Add("Cup $" & cup)
            pbPreviewCone.BackgroundImage = My.Resources.a_ConeA
            coneCost = cup
        ElseIf state = 1 Then
            subtotal = subtotal + vanilla
            lbReceipt.Items.Add("Vanilla $" & vanilla)
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourA
            scoopOneCost = vanilla
        ElseIf state = 2 Then
            subtotal = subtotal + vanilla
            lbReceipt.Items.Add("Vanilla $" & vanilla)
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourA
            scoopTwoCost = vanilla
        ElseIf state = 3 Then
            subtotal = subtotal + sprinkles
            lbReceipt.Items.Add("Sprinkles $" & sprinkles)
            pbPreviewTopping.BackgroundImage = My.Resources.c_toppingA
            toppingCost = sprinkles
        ElseIf state = 4 Or state >= 4 Then
            correctPayment = True
        End If

        'Increase State'
        state += 1

    End Sub

    Private Sub btnMenu1_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnMenu1.MouseHover

        'Positive Hover'
        If state = 0 Then
            pbPreviewCone.BackgroundImage = My.Resources.a_ConeA
            tbDisplay.Text = ("Cup $ --" & cup)
        ElseIf state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourA
            tbDisplay.Text = ("Vanilla $ --" & vanilla)
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourA
            tbDisplay.Text = ("Vanilla $ --" & vanilla)
        ElseIf state = 3 Then
            pbPreviewTopping.BackgroundImage = My.Resources.c_toppingA
            tbDisplay.Text = ("Sprinklers $ --" & sprinkles)
        End If

    End Sub

    Private Sub btnMenu1_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnMenu1.MouseLeave

        'Negative Hover'
        If state = 0 Then
            pbPreviewCone.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 1 Then
            pbPreviewScoopOne.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 3 Then
            pbPreviewTopping.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        End If

    End Sub

    Private Sub Form1_Load_1(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Initialize Timer'
        Timer1.Interval = 10
        Timer1.Start()

        'Receipt Formatting'
        lbReceipt.Items.Add("     Thank you for shopping at Ice Cream Social")
        lbReceipt.Items.Add("                           Outside")
        lbReceipt.Items.Add("                       727-427-2827")
        lbReceipt.Items.Add("")
        lbReceipt.Items.Add(Now)
        lbReceipt.Items.Add("")
        lbReceipt.Items.Add("-------------------------------------------------------------------------")
        lbReceipt.Items.Add("")

    End Sub

    Private Sub btnMenu2_Click(sender As System.Object, e As System.EventArgs) Handles btnMenu2.Click

        'Reset correct payment variable'
        correctPayment = False

        If state = 0 Then
            subtotal = subtotal + cone
            lbReceipt.Items.Add("Cone $" & cone)
            pbPreviewCone.BackgroundImage = My.Resources.a_ConeB
            coneCost = cone
        ElseIf state = 1 Then
            subtotal = subtotal + chocolate
            lbReceipt.Items.Add("Chocolate $" & chocolate)
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourB
            scoopOneCost = chocolate
        ElseIf state = 2 Then
            subtotal = subtotal + chocolate
            lbReceipt.Items.Add("Chocolate $" & chocolate)
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourB
            scoopTwoCost = chocolate
        ElseIf state = 3 Then
            subtotal = subtotal + oreo
            lbReceipt.Items.Add("Oreo $" & oreo)
            pbPreviewTopping.BackgroundImage = My.Resources.c_toppingB
            toppingCost = oreo
        ElseIf state = 4 Or state >= 4 Then
            tbCash.Visible = True
            tbDisplay.Text = ("Enter Amount")
        End If

        'Increase State'
        state += 1

    End Sub

    Private Sub btnMenu2_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnMenu2.MouseHover

        'Positive Hover'
        If state = 0 Then
            pbPreviewCone.BackgroundImage = My.Resources.a_ConeB
            tbDisplay.Text = ("Cone $ --" & cone)
        ElseIf state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourB
            tbDisplay.Text = ("Chocolate $ --" & chocolate)
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourB
            tbDisplay.Text = ("Chocolate $ --" & chocolate)
        ElseIf state = 3 Then
            pbPreviewTopping.BackgroundImage = My.Resources.c_toppingB
            tbDisplay.Text = ("Oreo Crumble$ --" & oreo)
        End If

    End Sub

    Private Sub btnMenu2_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnMenu2.MouseLeave

        'Negative Hover'
        If state = 0 Then
            pbPreviewCone.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 1 Then
            pbPreviewScoopOne.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 3 Then
            pbPreviewTopping.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        End If

    End Sub

    Private Sub btnMenu3_Click(sender As System.Object, e As System.EventArgs) Handles btnMenu3.Click

        If state = 0 Then
            subtotal = subtotal + chocolateCone
            lbReceipt.Items.Add("Chocolate Cone $" & chocolateCone)
            pbPreviewCone.BackgroundImage = My.Resources.a_ConeC
            coneCost = chocolateCone
        ElseIf state = 1 Then
            subtotal = subtotal + cookiesCream
            lbReceipt.Items.Add("Cookies and Cream $" & cookiesCream)
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourC
            scoopOneCost = cookiesCream
        ElseIf state = 2 Then
            subtotal = subtotal + cookiesCream
            lbReceipt.Items.Add("Cookies and Cream $" & cookiesCream)
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourC
            scoopTwoCost = cookiesCream
        ElseIf state = 3 Then
            subtotal = subtotal + oreo
            lbReceipt.Items.Add("Caramel Bits $" & caramel)
            pbPreviewTopping.BackgroundImage = My.Resources.c_toppingC
            toppingCost = oreo
        ElseIf state >= 4 And correctPayment = True Then
            confirm = True
            btnMenu3.BackColor = Color.Green
            btnPurchase.BackColor = Color.Green

            Try
                If tbCash.Text > total And correctPayment = True Then
                    lbReceipt.Items.Add("-------------------------------------------------------------------------")
                    lbReceipt.Items.Add("")
                    lbReceipt.Items.Add("Paid by cash")
                    lbReceipt.Items.Add("Change: $" & -total + tbCash.Text)
                    lbReceipt.Items.Add("")
                    lbReceipt.Items.Add("Subtotal: $" & subtotal)
                    lbReceipt.Items.Add("Tax: $" & tax)
                    lbReceipt.Items.Add("Total: $" & total)
                ElseIf tbCash.Text = Nothing And correctPayment = True Then
                    lbReceipt.Items.Add("Paid by card")
                    lbReceipt.Items.Add("")
                    lbReceipt.Items.Add("Subtotal: $" & subtotal)
                    lbReceipt.Items.Add("Tax: $" & tax)
                    lbReceipt.Items.Add("Total: $" & total)
                End If
            Catch ex As Exception
            End Try

        ElseIf state >= 4 And correctPayment = False Then
            tbDisplay.Text = ("Please select payment method")
        End If

        'Increase State'
        state += 1

    End Sub

    Private Sub btnMenu3_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnMenu3.MouseHover

        'Positive Hover'
        If state = 0 Then
            pbPreviewCone.BackgroundImage = My.Resources.a_ConeC
            tbDisplay.Text = ("Chocolate Cone $ --" & chocolateCone)
        ElseIf state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourC
            tbDisplay.Text = ("Cookies and Cream $ --" & cookiesCream)
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourC
            tbDisplay.Text = ("Cookies and Cream $ --" & cookiesCream)
        ElseIf state = 3 Then
            pbPreviewTopping.BackgroundImage = My.Resources.c_toppingC
            tbDisplay.Text = ("Caramel Bits $ --" & caramel)
        End If

    End Sub

    Private Sub btnMenu3_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnMenu3.MouseLeave

        'Negative Hover'
        If state = 0 Then
            pbPreviewCone.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 1 Then
            pbPreviewScoopOne.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 3 Then
            pbPreviewTopping.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        End If

    End Sub

    Private Sub btnMenu4_Click(sender As System.Object, e As System.EventArgs) Handles btnMenu4.Click

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourD
            scoopOneCost = mint
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourD
            scoopTwoCost = mint
        End If

        lbReceipt.Items.Add("Mint $" & mint)
        subtotal = subtotal + mint

        'Increase State'
        state += 1
    End Sub

    Private Sub btnMenu4_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnMenu4.MouseHover

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourD
            tbDisplay.Text = ("Mint $ --" & mint)
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourD
        End If

    End Sub

    Private Sub btnMenu4_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnMenu4.MouseLeave

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        End If

    End Sub

    Private Sub btnMenu5_Click(sender As System.Object, e As System.EventArgs) Handles btnMenu5.Click

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourE
            scoopOneCost = cookieDough
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourE
            scoopTwoCost = cookieDough
        End If

        lbReceipt.Items.Add("Chocolate Chip Cookie Dough $" & cookieDough)
        subtotal = subtotal + cookieDough

        'Increase State'
        state += 1
    End Sub

    Private Sub btnMenu5_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnMenu5.MouseHover

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourE
            tbDisplay.Text = ("Chocolate Chip Cookie Dough $ --" & cookieDough)
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourE
        End If

    End Sub

    Private Sub btnMenu5_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnMenu5.MouseLeave

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        End If

    End Sub

    Private Sub btnMenu6_Click(sender As System.Object, e As System.EventArgs) Handles btnMenu6.Click

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourF
            scoopOneCost = pecan
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourF
            scoopTwoCost = pecan
        End If

        lbReceipt.Items.Add("Butter Pecan $" & pecan)
        subtotal = subtotal + pecan

        'Increase State'
        state += 1
    End Sub

    Private Sub btnMenu6_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnMenu6.MouseHover

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourF
            tbDisplay.Text = ("Butter Pecan $ --" & pecan)
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourF
        End If

    End Sub

    Private Sub btnMenu6_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnMenu6.MouseLeave

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        End If

    End Sub

    Private Sub btnMenu7_Click(sender As System.Object, e As System.EventArgs) Handles btnMenu7.Click

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourG
            scoopOneCost = birthday
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourG
            scoopTwoCost = birthday
        End If

        lbReceipt.Items.Add("Birthday Cake $" & birthday)
        subtotal = subtotal + birthday

        'Increase State'
        state += 1
    End Sub

    Private Sub btnMenu7_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnMenu7.MouseHover

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourG
            tbDisplay.Text = ("Birthday Cake $ --" & birthday)
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourG
        End If

    End Sub

    Private Sub btnMenu7_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnMenu7.MouseLeave

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        End If

    End Sub

    Private Sub btnMenu8_Click(sender As System.Object, e As System.EventArgs) Handles btnMenu8.Click

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourH
            scoopOneCost = strawberry
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourH
            scoopTwoCost = strawberry
        End If

        lbReceipt.Items.Add("Strawberry $" & strawberry)
        subtotal = subtotal + strawberry

        'Increase State'
        state += 1
    End Sub

    Private Sub btnMenu8_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnMenu8.MouseHover

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.b_flavourH
            tbDisplay.Text = ("Strawberry $ --" & strawberry)
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.b_flavourH
        End If

    End Sub

    Private Sub btnMenu8_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnMenu8.MouseLeave

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        End If

    End Sub

    Private Sub btnMenu9_Click(sender As System.Object, e As System.EventArgs) Handles btnMenu9.Click

        'Undo Button // Moves back a state'
        If state = 1 Then
            pbPreviewCone.BackgroundImage = Nothing
            subtotal -= coneCost
            state -= 1
        ElseIf state = 2 Then
            state -= 1
            pbPreviewScoopOne.BackgroundImage = Nothing
            subtotal -= scoopOneCost
        ElseIf state = 3 Then
            state -= 1
            pbPreviewScoopTwo.BackgroundImage = Nothing
            subtotal -= scoopTwoCost
        ElseIf state = 4 Then
            state -= 1
            pbPreviewTopping.BackgroundImage = Nothing
            subtotal -= toppingCost
        End If

        'Removes previous line in reciept'
        lbReceipt.Items.RemoveAt(lbReceipt.Items.Count - 1)
    End Sub

    Private Sub btnMenu9_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnMenu9.MouseHover

        tbDisplay.Text = ("Undo")

    End Sub

    Private Sub btnMenu9_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnMenu9.MouseLeave

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        ElseIf state = 3 Then
            pbPreviewTopping.BackgroundImage = Nothing
            tbDisplay.Text = Nothing
        End If

    End Sub


    Private Sub btnMenu10_Click(sender As System.Object, e As System.EventArgs) Handles btnMenu10.Click

        'Skip Item'
        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.Skip1
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.Skip1
        ElseIf state = 3 Then
            pbPreviewTopping.BackgroundImage = My.Resources.Skip1
        End If

        state += 1
        lbReceipt.Items.Add("Skipped")

    End Sub

    Private Sub btnMenu10_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnMenu10.MouseHover

        If state = 1 Then
            pbPreviewScoopOne.BackgroundImage = My.Resources.Skip1
        ElseIf state = 2 Then
            pbPreviewScoopTwo.BackgroundImage = My.Resources.Skip1
        ElseIf state = 3 Then
            pbPreviewTopping.BackgroundImage = My.Resources.Skip1
        End If

        tbDisplay.Text = ("Skip")

    End Sub


    Private Sub btnPurchase_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchase.Click

        If confirm = True And correctPayment = True Then
            'checks if button has already been pressed'
            purchaseNext = True
            tbDisplay.Text = ("Thank you for shopping!")
        Elseif confirm = True And correctPayment = False Then
        tbDisplay.Text = ("Incorrect Payment!")
        ElseIf confirm = False And state >= 4 Then
            tbDisplay.Text = ("Please Confirm Payment")
        ElseIf state < 4 Then
            tbDisplay.Text = ("Please finish order")
        End If

        If purchaseNext = True Then
            reset = True
        End If

    End Sub

    Private Sub tbCash_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbCash.TextChanged

        'Set correct payment to true if the cash input is greater than the total.'
        Try

            If tbCash.Text >= total Then
                correctPayment = True
            End If

        Catch ex As Exception

        End Try

    End Sub

End Class
