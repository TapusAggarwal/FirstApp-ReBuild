﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AttributeControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AttrIconBT = New FontAwesome.Sharp.IconButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UsedButton = New FontAwesome.Sharp.IconButton()
        Me.DefValueLB = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'AttrIconBT
        '
        Me.AttrIconBT.AutoSize = True
        Me.AttrIconBT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AttrIconBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.AttrIconBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.AttrIconBT.FlatAppearance.BorderSize = 0
        Me.AttrIconBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.AttrIconBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.AttrIconBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AttrIconBT.Font = New System.Drawing.Font("Century Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AttrIconBT.ForeColor = System.Drawing.Color.MediumPurple
        Me.AttrIconBT.IconChar = FontAwesome.Sharp.IconChar.CheckSquare
        Me.AttrIconBT.IconColor = System.Drawing.Color.White
        Me.AttrIconBT.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.AttrIconBT.IconSize = 45
        Me.AttrIconBT.Location = New System.Drawing.Point(4, 5)
        Me.AttrIconBT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AttrIconBT.Name = "AttrIconBT"
        Me.AttrIconBT.Size = New System.Drawing.Size(51, 51)
        Me.AttrIconBT.TabIndex = 278
        Me.AttrIconBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AttrIconBT.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Schoolbook", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MediumPurple
        Me.Label1.Location = New System.Drawing.Point(3, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 27)
        Me.Label1.TabIndex = 279
        Me.Label1.Text = "Def. Val:"
        '
        'UsedButton
        '
        Me.UsedButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UsedButton.AutoSize = True
        Me.UsedButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UsedButton.BackColor = System.Drawing.Color.Transparent
        Me.UsedButton.FlatAppearance.BorderSize = 0
        Me.UsedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.UsedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow
        Me.UsedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UsedButton.IconChar = FontAwesome.Sharp.IconChar.HandPointer
        Me.UsedButton.IconColor = System.Drawing.Color.Goldenrod
        Me.UsedButton.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.UsedButton.IconSize = 45
        Me.UsedButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.UsedButton.Location = New System.Drawing.Point(45, 6)
        Me.UsedButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UsedButton.Name = "UsedButton"
        Me.UsedButton.Size = New System.Drawing.Size(51, 51)
        Me.UsedButton.TabIndex = 280
        Me.UsedButton.UseVisualStyleBackColor = False
        '
        'DefValueLB
        '
        Me.DefValueLB.AutoSize = True
        Me.DefValueLB.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DefValueLB.ForeColor = System.Drawing.Color.AliceBlue
        Me.DefValueLB.Location = New System.Drawing.Point(96, 64)
        Me.DefValueLB.Name = "DefValueLB"
        Me.DefValueLB.Size = New System.Drawing.Size(0, 28)
        Me.DefValueLB.TabIndex = 281
        '
        'AttributeControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Controls.Add(Me.DefValueLB)
        Me.Controls.Add(Me.UsedButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AttrIconBT)
        Me.Name = "AttributeControl"
        Me.Size = New System.Drawing.Size(101, 103)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AttrIconBT As FontAwesome.Sharp.IconButton
    Friend WithEvents DefValueLB As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents UsedButton As FontAwesome.Sharp.IconButton
End Class
