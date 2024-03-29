﻿Public Class ShortCustomerSearch
    Private Const MaxLimit As Integer = 6
    Public HideCustomerID As Integer = -1

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NameTB.Select()
    End Sub

    Private Async Sub ShowResults(Limit As Integer)
        Dim T_List = Nothing

        Dim newSearchRecord As Integer() = Nothing

        Dim InitalName As String = NameTB.Text
        Dim InitalPhNo As String = PhNoTB.Text
        Dim InitalKittyNo As String = KittyNoTB.Text

        If NameTB.TextLength Then
            newSearchRecord = Customer.SearchByName(NameTB.Text)
            KittyNoTB.Clear()
            PhNoTB.Clear()
        ElseIf PhNoTB.TextLength Then
            newSearchRecord = Customer.SearchByPhNo(InitalPhNo)
        ElseIf KittyNoTB.TextLength Then
            KittyMode1.Checked = True
            T_List = Customer.ListOF_KittyModeControl(IDs:=Customer.SearchByKittyNo(InitalKittyNo, Limit), isKittyID:=True)
        End If

        If newSearchRecord Is Nothing Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()
        Else
            If Not KittyMode1.Checked Then
                T_List = Customer.ListOF_ActiveKittyControl(IDs:=newSearchRecord, MaxLimit:=Limit)
            Else
                T_List = Customer.ListOF_KittyModeControl(IDs:=newSearchRecord, MaxLimit:=Limit)
                If T_List Is Nothing OrElse T_List.count = 0 Then
                    Dim _temp = Customer.ListOF_ActiveKittyControl(IDs:=newSearchRecord, MaxLimit:=Limit)
                    If _temp IsNot Nothing AndAlso _temp.Count > 0 Then
                        KittyMode1.Checked = False
                        Exit Sub
                    End If
                End If
            End If
        End If

        FlowLayoutPanel1.Controls.Clear()

        If T_List IsNot Nothing AndAlso T_List.Count Then
            Dim res = Await Task.WhenAll(T_List)
            FlowLayoutPanel1.Visible = False
            FlowLayoutPanel1.Controls.Clear()
            If NameTB.Text = InitalName And PhNoTB.Text = InitalPhNo And KittyNoTB.Text = InitalKittyNo Then
                For Each i In res
                    FlowLayoutPanel1.Controls.Add(i)
                    Try
                        Dim x As KittyModeControl = i
                        AddHandler x.DetailsButton_Clicked, AddressOf ControlButton_Clicked
                        x.DetailsButton.Text = "Select"
                        If HideCustomerID <> -1 AndAlso x.CoustID = HideCustomerID Then
                            x.Enabled = False
                        End If
                    Catch ex As Exception
                        Dim x As ActiveKittyControl = i
                        AddHandler x.DetailsButton_Clicked, AddressOf ControlButton_Clicked
                        x.DetailsButton.Text = "Select"
                        If HideCustomerID <> -1 AndAlso x.CoustID = HideCustomerID Then
                            x.Enabled = False
                        End If
                    End Try
                Next
                FlowLayoutPanel1.Visible = True
                GC.Collect()
            End If
        End If
    End Sub

    Public Event CustomerClicked(CustomerID As Integer, KittyID As Integer)

    Private Sub ControlButton_Clicked(CustomerID As Integer, Optional KittyID As Integer = -1)
        RaiseEvent CustomerClicked(CustomerID, KittyID)
    End Sub

    Private Sub SearchTextBoxes_TextChanged(sender As TextBox, e As EventArgs) Handles NameTB.TextChanged, PhNoTB.TextChanged, KittyNoTB.TextChanged

        If sender.TextLength = 0 Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()
        Else
            ShowResults(6)
        End If

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles PhNoTB.KeyDown, KittyNoTB.KeyDown, NameTB.KeyDown
        If e.KeyCode = Keys.Enter Then
            FindCoustmerButton_Click(FindCoustmerButton, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{Tab}")
        ElseIf e.KeyCode = Keys.Down Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub KittyNoTB_TextChanged(sender As TextBox, e As EventArgs) Handles KittyNoTB.TextChanged, PhNoTB.TextChanged

        If Not IsNumeric(sender.Text) Then
            Dim temp_var As String = sender.Text
            If temp_var.Length Then
                NameTB.Text = temp_var
                NameTB.Select()
                SendKeys.Send("{End}")
            End If
            sender.Clear()
        Else
            NameTB.Clear()
            If sender Is PhNoTB Then
                KittyNoTB.Clear()
            Else
                PhNoTB.Clear()
            End If
        End If

    End Sub

    Private Sub FindCoustmerButton_Click(sender As Object, e As EventArgs) Handles FindCoustmerButton.Click
        ShowResults(-1)
    End Sub

    Private Sub KittyMode1_CheckedChanged(sender As Object, e As EventArgs) Handles KittyMode1.CheckedChanged
        FindCoustmerButton_Click(FindCoustmerButton, EventArgs.Empty)
        NameTB.Select()
    End Sub

End Class