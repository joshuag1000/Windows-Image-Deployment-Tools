<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgressDialog
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
        TableLayoutPanel1 = New TableLayoutPanel()
        PictureBox1 = New PictureBox()
        ProgressBar1 = New ProgressBar()
        lblInfo = New Label()
        TableLayoutPanel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 70F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(PictureBox1, 0, 0)
        TableLayoutPanel1.Controls.Add(ProgressBar1, 1, 1)
        TableLayoutPanel1.Controls.Add(lblInfo, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(10, 10)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 27F))
        TableLayoutPanel1.Size = New Size(399, 50)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImageLayout = ImageLayout.None
        PictureBox1.Dock = DockStyle.Fill
        PictureBox1.Location = New Point(3, 3)
        PictureBox1.Name = "PictureBox1"
        TableLayoutPanel1.SetRowSpan(PictureBox1, 2)
        PictureBox1.Size = New Size(64, 44)
        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Dock = DockStyle.Fill
        ProgressBar1.Location = New Point(73, 23)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(323, 24)
        ProgressBar1.TabIndex = 1
        ' 
        ' lblInfo
        ' 
        lblInfo.AutoSize = True
        lblInfo.Dock = DockStyle.Fill
        lblInfo.Location = New Point(73, 0)
        lblInfo.Name = "lblInfo"
        lblInfo.Size = New Size(323, 20)
        lblInfo.TabIndex = 2
        lblInfo.Text = "Label1"
        lblInfo.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ProgressDialog
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(419, 70)
        ControlBox = False
        Controls.Add(TableLayoutPanel1)
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(408, 109)
        Name = "ProgressDialog"
        Padding = New Padding(10)
        ShowIcon = False
        ShowInTaskbar = False
        Text = "Progress..."
        TopMost = True
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lblInfo As Label
End Class
