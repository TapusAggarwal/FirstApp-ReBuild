﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockEntry
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChangeListenerPhNoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListenOnceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductFP = New FirstApp.UserControl1()
        Me.SaleFP = New FirstApp.UserControl1()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PurchaseFP = New FirstApp.UserControl1()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SaveBT = New FontAwesome.Sharp.IconButton()
        Me.ListeningStatusPanel = New System.Windows.Forms.Panel()
        Me.ImageBox = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ListeningStatusPanel.SuspendLayout()
        CType(Me.ImageBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeListenerPhNoToolStripMenuItem, Me.ListenOnceToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(259, 68)
        '
        'ChangeListenerPhNoToolStripMenuItem
        '
        Me.ChangeListenerPhNoToolStripMenuItem.Name = "ChangeListenerPhNoToolStripMenuItem"
        Me.ChangeListenerPhNoToolStripMenuItem.Size = New System.Drawing.Size(258, 32)
        Me.ChangeListenerPhNoToolStripMenuItem.Text = "Change Listener PhNo"
        '
        'ListenOnceToolStripMenuItem
        '
        Me.ListenOnceToolStripMenuItem.Name = "ListenOnceToolStripMenuItem"
        Me.ListenOnceToolStripMenuItem.Size = New System.Drawing.Size(258, 32)
        Me.ListenOnceToolStripMenuItem.Text = "Listen Once"
        '
        'ProductFP
        '
        Me.ProductFP.AllowDrop = True
        Me.ProductFP.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ProductFP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ProductFP.Dock = System.Windows.Forms.DockStyle.Left
        Me.ProductFP.Location = New System.Drawing.Point(555, 0)
        Me.ProductFP.Name = "ProductFP"
        Me.ProductFP.Size = New System.Drawing.Size(555, 726)
        Me.ProductFP.TabIndex = 305
        Me.ProductFP.Title = "Product Attr."
        '
        'SaleFP
        '
        Me.SaleFP.AllowDrop = True
        Me.SaleFP.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.SaleFP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SaleFP.Dock = System.Windows.Forms.DockStyle.Left
        Me.SaleFP.Location = New System.Drawing.Point(1110, 0)
        Me.SaleFP.Name = "SaleFP"
        Me.SaleFP.Size = New System.Drawing.Size(555, 726)
        Me.SaleFP.TabIndex = 306
        Me.SaleFP.Title = "Sale Attr."
        Me.SaleFP.Visible = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.SaleFP)
        Me.Panel1.Controls.Add(Me.ProductFP)
        Me.Panel1.Controls.Add(Me.PurchaseFP)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(259, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1665, 726)
        Me.Panel1.TabIndex = 320
        '
        'PurchaseFP
        '
        Me.PurchaseFP.AllowDrop = True
        Me.PurchaseFP.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.PurchaseFP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PurchaseFP.Dock = System.Windows.Forms.DockStyle.Left
        Me.PurchaseFP.Location = New System.Drawing.Point(0, 0)
        Me.PurchaseFP.Name = "PurchaseFP"
        Me.PurchaseFP.Size = New System.Drawing.Size(555, 726)
        Me.PurchaseFP.TabIndex = 304
        Me.PurchaseFP.Title = "Puchase Attr."
        Me.PurchaseFP.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SaveBT)
        Me.Panel2.Controls.Add(Me.ListeningStatusPanel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(259, 726)
        Me.Panel2.TabIndex = 322
        '
        'SaveBT
        '
        Me.SaveBT.AutoSize = True
        Me.SaveBT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SaveBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.SaveBT.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SaveBT.FlatAppearance.BorderSize = 0
        Me.SaveBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveBT.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveBT.ForeColor = System.Drawing.Color.MediumPurple
        Me.SaveBT.IconChar = FontAwesome.Sharp.IconChar.SignInAlt
        Me.SaveBT.IconColor = System.Drawing.Color.White
        Me.SaveBT.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.SaveBT.IconSize = 45
        Me.SaveBT.Location = New System.Drawing.Point(0, 675)
        Me.SaveBT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SaveBT.Name = "SaveBT"
        Me.SaveBT.Size = New System.Drawing.Size(259, 51)
        Me.SaveBT.TabIndex = 322
        Me.SaveBT.Text = "Save"
        Me.SaveBT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SaveBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.SaveBT.UseVisualStyleBackColor = False
        '
        'ListeningStatusPanel
        '
        Me.ListeningStatusPanel.BackColor = System.Drawing.Color.Red
        Me.ListeningStatusPanel.Controls.Add(Me.ImageBox)
        Me.ListeningStatusPanel.Location = New System.Drawing.Point(3, 3)
        Me.ListeningStatusPanel.Name = "ListeningStatusPanel"
        Me.ListeningStatusPanel.Size = New System.Drawing.Size(256, 426)
        Me.ListeningStatusPanel.TabIndex = 323
        '
        'ImageBox
        '
        Me.ImageBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ImageBox.Image = Global.FirstApp.My.Resources.Resources.addSign
        Me.ImageBox.Location = New System.Drawing.Point(3, 3)
        Me.ImageBox.Name = "ImageBox"
        Me.ImageBox.Size = New System.Drawing.Size(250, 420)
        Me.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImageBox.TabIndex = 290
        Me.ImageBox.TabStop = False
        '
        'StockEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1924, 726)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "StockEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "StockEntry"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ListeningStatusPanel.ResumeLayout(False)
        CType(Me.ImageBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ChangeListenerPhNoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListenOnceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductFP As UserControl1
    Friend WithEvents SaleFP As UserControl1
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents SaveBT As FontAwesome.Sharp.IconButton
    Friend WithEvents ListeningStatusPanel As Panel
    Friend WithEvents ImageBox As PictureBox
    Friend WithEvents PurchaseFP As UserControl1
End Class
