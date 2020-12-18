Public Class dialogo_login
    ' TODO: Insert code to perform custom authentication using the provided username and password
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).
    ' The custom principal can then be attached to the current thread's principal as follows:
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication.
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.
    Private User_ As String = ""
    Public Property User() As String
        Get
            Return User_
        End Get
        Set(ByVal value As String)
            User_ = value
        End Set
    End Property
    Private Pwd_ As String = ""
    Public Property Pwd() As String
        Get
            Return Pwd_
        End Get
        Set(ByVal value As String)
            Pwd_ = value
        End Set
    End Property

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class