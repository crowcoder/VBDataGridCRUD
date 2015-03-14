<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.FruitGridView = New System.Windows.Forms.DataGridView()
        Me.colFruitName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFruitColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFruitGrowsOn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colFruitIsYummy = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblUpdate = New System.Windows.Forms.Label()
        CType(Me.FruitGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FruitGridView
        '
        Me.FruitGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FruitGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFruitName, Me.colFruitColor, Me.colFruitGrowsOn, Me.colFruitIsYummy})
        Me.FruitGridView.Location = New System.Drawing.Point(12, 28)
        Me.FruitGridView.Name = "FruitGridView"
        Me.FruitGridView.Size = New System.Drawing.Size(427, 204)
        Me.FruitGridView.TabIndex = 0
        '
        'colFruitName
        '
        Me.colFruitName.HeaderText = "Fruit Name"
        Me.colFruitName.Name = "colFruitName"
        '
        'colFruitColor
        '
        Me.colFruitColor.HeaderText = "Fruit Color"
        Me.colFruitColor.Name = "colFruitColor"
        '
        'colFruitGrowsOn
        '
        Me.colFruitGrowsOn.HeaderText = "Grows On"
        Me.colFruitGrowsOn.Name = "colFruitGrowsOn"
        '
        'colFruitIsYummy
        '
        Me.colFruitIsYummy.HeaderText = "FruitIsYummy"
        Me.colFruitIsYummy.Name = "colFruitIsYummy"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 249)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(427, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblUpdate
        '
        Me.lblUpdate.AutoSize = True
        Me.lblUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblUpdate.Location = New System.Drawing.Point(12, 279)
        Me.lblUpdate.Name = "lblUpdate"
        Me.lblUpdate.Size = New System.Drawing.Size(166, 20)
        Me.lblUpdate.TabIndex = 2
        Me.lblUpdate.Text = "Update Successful!"
        Me.lblUpdate.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 308)
        Me.Controls.Add(Me.lblUpdate)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.FruitGridView)
        Me.Name = "Form1"
        Me.Text = "Contrived DataGrid Example in VB.Net"
        CType(Me.FruitGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FruitGridView As System.Windows.Forms.DataGridView
    Friend WithEvents colFruitName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFruitColor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFruitGrowsOn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colFruitIsYummy As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblUpdate As System.Windows.Forms.Label

End Class
