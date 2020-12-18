Public Class Textboxextended_mero
    Inherits System.Windows.Forms.TextBox

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyDown(e)
        Select Case e.KeyData
            Case Keys.Enter
                SendKeys.Send("{TAB}")
                e.Handled = True
            Case Keys.Back
                If Me.TabIndex > 0 And Me.Text = "" Then
                    SendKeys.Send("+{TAB}")
                    e.Handled = True
                ElseIf Me.TabIndex > 0 Then
                    SendKeys.Send("+{TAB}")
                    e.Handled = True
                End If
            Case Else
        End Select
    End Sub

End Class