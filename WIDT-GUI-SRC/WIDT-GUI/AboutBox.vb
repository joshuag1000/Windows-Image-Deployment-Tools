﻿Public NotInheritable Class AboutBox

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Me.Text = String.Format("About {0}", My.Application.Info.ProductName)

        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version: {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = "Copyright: " & My.Application.Info.Copyright
        Me.LabelCompanyName.Text = "Author: " & My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
