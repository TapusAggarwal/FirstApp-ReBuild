﻿Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports Newtonsoft
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports WebSocket4Net

Public Class StockEntry

    Public Property CurrentItem As Item
    Public Property StockID As Integer = -1
    Dim _huids As New List(Of String)

    Private Sub StockEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        KeyPreview = True

        If CurrentItem.ItemID < 0 Then Exit Sub

        TextBox1.Text = CurrentItem.ItemID

        For Each _attribute In CurrentItem.Attributes
            Dim x As New AttributeStockControl With {
                .CurrentAttribute = _attribute,
                .Name = _attribute.Name
            }

            If _attribute.Attr_Ctg = Item.AttributeCategory.Purchase_Type Then
                PurchaseFP.AddControl(x)
                PurchaseFP.AutoReSize()
            ElseIf _attribute.Attr_Ctg = Item.AttributeCategory.Product_Type Then
                ProductFP.AddControl(x)
                ProductFP.AutoReSize()
            Else
                SaleFP.AddControl(x)
                SaleFP.AutoReSize()
            End If

            If _attribute.Name = "Huid No" Then

                Dim dr As OleDb.OleDbDataReader = DataReader("Select * From Stock_Data")
                While dr.Read
                    Dim _jsonObject As JObject = JsonConvert.DeserializeObject(Of JObject)(dr("Item_Data"))
                    Dim id As Integer = dr("ID")

                    If id = StockID Then
                        Continue While
                    End If

                    If _jsonObject.ContainsKey("15") Then
                        Dim _list As List(Of String) = _jsonObject("15").ToString.Split(",").ToList
                        _list.Remove("")
                        If _list.Count > 0 Then
                            _huids.AddRange(_list)
                        End If
                    End If
                End While

                _huids = _huids.Select(Function(str) str.Trim()).ToList()

                AddHandler KeyDown, Sub(_sender As Object, _e As KeyEventArgs)
                                        If _e.KeyCode = Keys.I AndAlso _e.Control = True Then
                                            Dim f = x.DefaultValueTB.Text
                                            Dim Fm As New HUID_Checker
                                            Fm.SearchTB.Select()
                                            _e.Handled = True
                                            AddHandler Fm.HuidSelected, Sub(_status, _huid)

                                                                            If _huids.Contains(_huid.Trim) Then
                                                                                MessageBox.Show("This HUID No. Is Already Used For An Item Before.", "Duplication Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                                Exit Sub
                                                                            End If

                                                                            If _status Then
                                                                                Dim _text As String = x.EnteredData
                                                                                If _text = _attribute.DefaultValue Then _text = ""
                                                                                Dim _list As List(Of String) = _text.Split(",").ToList
                                                                                _list.Remove("")
                                                                                _list.Add(_huid)
                                                                                Fm.Close()
                                                                                If _list.Count = 1 Then
                                                                                    x.DefaultValueTB.Text = _huid
                                                                                Else
                                                                                    x.DefaultValueTB.Text = String.Join(",", _list)
                                                                                End If
                                                                            End If
                                                                        End Sub
                                            Fm.ShowDialog()
                                        End If
                                    End Sub
            End If

        Next

        For Each _attribute In CurrentItem.Attributes
            If Not _attribute.IsFormula Then Continue For

            Dim DependentAttributes As List(Of Item.Item_Attribute) = _attribute.DependsUpon(CurrentItem)

            For Each i In DependentAttributes
                Dim _control As AttributeStockControl = Panel1.Controls.Find(i.Name, True)(0)
                AddHandler _control.DefaultValueTB.TextChanged,
                    Sub(_sender As Object, _e As EventArgs)
                        If CType(_sender, TextBox).Text = "" Then Exit Sub
                        Dim formula As String = _attribute.DefaultValue

                        For Each _attr In DependentAttributes
                            Dim _cntrl As AttributeStockControl = Panel1.Controls.Find(_attr.Name, True)(0)
                            Dim _enteredData As String = _cntrl.EnteredData
                            If _enteredData = "" Then _enteredData = 0
                            formula = formula.Replace($"{{{_attr.Name}}}", _enteredData)
                        Next

                        Try
                            Dim equation As String = formula
                            Dim result As String = CDbl(New DataTable().Compute(equation, Nothing))

                            Dim _ruleControl As AttributeStockControl = Panel1.Controls.Find(_attribute.Name, True)(0)

                            _ruleControl.DefaultValueTB.Text = result
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub
            Next

        Next

        ListenerStatus()

        'PurchaseFP.Visible = False
        'SaleFP.Visible = False

        previousImage = ImageBox.Image

        If StockID <> -1 Then
            Dim dr As OleDb.OleDbDataReader = DataReader($"Select img_path,Item_Data From Stock_Data Where ID={StockID}")
            Dim x As New Dictionary(Of Integer, String)
            While dr.Read
                x = JsonConvert.DeserializeObject(Of Dictionary(Of Integer, String))(dr(1))
                If Not IsDBNull(dr(0)) Then
                    ImageBox.ImageLocation = dr(0)
                End If
            End While

            For Each id In x.Keys
                Dim f As Item.Item_Attribute = CurrentItem.Attributes.Where(Function(g) g.ID = id)(0)
                Dim _cntrl As AttributeStockControl = Panel1.Controls.Find(f.Name, True)(0)
                Select Case f.DataType
                    Case Item.DataType.Boolean_Type

                        If x(id) = "True" Then
                            _cntrl.TrueChB.Checked = True
                        Else
                            _cntrl.FalseChB.Checked = True
                        End If


                    Case Item.DataType.List_Type

                        _cntrl.ListValues.SelectedIndex = _cntrl.ListValues.FindStringExact(x(id).Split("`")(0))


                    Case Item.DataType.Integer_Type

                        _cntrl.DefaultValueTB.Text = x(id)


                    Case Item.DataType.String_Type

                        _cntrl.DefaultValueTB.Text = x(id)

                    Case Item.DataType.Date_Type

                        _cntrl.DateTimePicker1.Value = x(id)
                End Select
            Next

            SaveBT.Text = "Update"

        End If

    End Sub

    Dim fm As Frame = Nothing

    Async Sub ListenerStatus()
        For Each _form As Form In Application.OpenForms
            If TypeOf _form IsNot Frame Then Continue For
            fm = _form
            Exit For
        Next

        Dim req As WebRequest = WebRequest.Create($"http://{My.Settings.connection_url}?purpose=phno_listeners")
        req.Method = "POST"
        req.Timeout = 3000
        Try
            Using request As WebResponse = Await req.GetResponseAsync
                Using reader As New StreamReader(request.GetResponseStream)
                    Dim response As String = Await reader.ReadToEndAsync

                    If response.Trim.Length = 0 Then Exit Sub
                    ListeningStatusPanel.BackColor = Color.FromArgb(0, 64, 0)

                    If WebSocket Is Nothing OrElse Not WebSocket.State = WebSocketState.Open Then
                        Await fm?.StartServer(False)
                    End If

                    RemoveHandler fm.NewMessage_Socket, AddressOf UpdateImage
                    AddHandler fm.NewMessage_Socket, AddressOf UpdateImage

                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Dim _currentImageIndex As Integer = -1

    Public Sub UpdateImage()
        Cursor = Cursors.AppStarting
        Dim req As WebRequest = WebRequest.Create($"http://{My.Settings.connection_url}?purpose=latest_images")
        req.Method = "POST"

        ' Get the response and extract the base64 encoded string
        Dim response As WebResponse = req.GetResponse()
        Dim streamReader As New StreamReader(response.GetResponseStream())
        Dim base64String As String = streamReader.ReadToEnd()

        If base64String = "" Then Exit Sub

        ' Convert the base64 encoded string to a byte array
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)

        ' Convert the byte array to an image
        Using memoryStream As New MemoryStream(imageBytes)
            Dim image As Image = Image.FromStream(memoryStream)
            If ImageBox.IsHandleCreated Then
                ImageBox.Invoke(Sub()
                                    ImageBox.Image = New Bitmap(image)
                                End Sub)
            End If
            ' Do something with the image, such as display it
        End Using
        Cursor = Cursors.Default
    End Sub

    'Private Sub Panel1_SizeChanged(sender As Object, e As EventArgs) Handles Panel1.SizeChanged
    '    Size = New Point(SaleFP.Size.Width + ListeningStatusPanel.Size.Width + 40, Size.Height)
    'End Sub
    Private previousImage As Image

    Private Sub SaveBT_Click_1(sender As Object, e As EventArgs) Handles SaveBT.Click

        If MessageBox.Show("Are You Sure You Want To Save This Item.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If


        Dim x As New Dictionary(Of Integer, String)

        For Each _attr In CurrentItem.Attributes
            If _attr.IsFormula Then Continue For
            Dim _cntrl As AttributeStockControl = Panel1.Controls.Find(_attr.Name, True)(0)
            Dim _enteredData = _cntrl.EnteredData
            If _attr.DataType = Item.DataType.List_Type Then
                If _enteredData <> _attr.DefaultValue.Split("`")(0) Then
                    x.Add(_attr.ID, _enteredData)
                End If
                Continue For

            End If

            If _enteredData <> _attr.DefaultValue Then
                x.Add(_attr.ID, _enteredData)
            End If

        Next

        Dim _str = Json.JsonConvert.SerializeObject(x)

        If x.ContainsKey(15) Then
            If _huids.Contains(x(15)) Then
                MessageBox.Show("This HUID No. Is Already Used For An Item Before.", "Duplication Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        If StockID > 0 Then
            SqlCommand($"UPDATE Stock_Data SET Ctg_ID='{CurrentItem.ItemID}',Item_Data='{_str}',entry_time='{Now}' WHERE ID={StockID}")
        Else
            SqlCommand($"Insert INTO Stock_Data (Ctg_ID,Item_Data,entry_time) VALUES ('{CurrentItem.ItemID}','{_str}','{Now}')")

            Dim dr As OleDb.OleDbDataReader = DataReader("Select MAX(ID) FROM Stock_Data")
            Dim _int As Integer = -1
            While dr.Read
                _int = If(IsDBNull(dr(0)), -1, dr(0))
            End While

            If _int = -1 Then Exit Sub
            StockID = _int
            SaveBT.Text = "Update"
        End If

        If Not ImageBox.Image.Equals(previousImage) Then
            ImageBox.Image.Save($"{My.Settings.StockImages_Path}\stock_images\img{StockID}.jpg")
        End If

        SqlCommand($"UPDATE Stock_Data SET img_path='{$"{My.Settings.StockImages_Path}\stock_images\img{StockID}.jpg"}' WHERE ID={StockID}")

        Dispose()
        For Each _form As Form In Application.OpenForms
            If TypeOf _form IsNot MainStockPage Then Continue For
            CType(_form, MainStockPage).Focus()
            CType(_form, MainStockPage).StockEntryBT.PerformClick()
            Exit For
        Next



    End Sub

    Private Sub ReloadImgBT_Click(sender As Object, e As EventArgs) Handles ReloadImgBT.Click
        _currentImageIndex = -1
        UpdateImage()
    End Sub

    'Private Sub NextImgButton_Click(sender As Object, e As EventArgs) Handles NextImgButton.Click
    '    If _currentImageIndex < -1 Then
    '        _currentImageIndex += 1
    '        UpdateImage()
    '        BackImgButton.Enabled = True
    '    Else
    '        NextImgButton.Enabled = False
    '        _currentImageIndex = -1
    '    End If
    'End Sub

    Private Sub StockEntry_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        RemoveHandler fm.NewMessage_Socket, AddressOf UpdateImage
        Dispose()
    End Sub


    'Private Sub BackImgButton_Click(sender As Object, e As EventArgs) Handles BackImgButton.Click
    '    _currentImageIndex += 1
    '    If Not UpdateImage() Then BackImgButton.Enabled = False
    '    NextImgButton.Enabled = True
    'End Sub

End Class