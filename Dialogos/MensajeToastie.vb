Public Class MessageToastie
    Private _MessageTexto As String
    Public Property MessageTexto() As String
        Get
            Return _MessageTexto
        End Get
        Set(ByVal value As String)
            _MessageTexto = value
        End Set
    End Property
    Private _TituloMessage As String
    Public Property TituloMessage() As String
        Get
            Return _TituloMessage
        End Get
        Set(ByVal value As String)
            _TituloMessage = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub Message(Optional Tipo As String = "INFO")
        Dim MessageIcon As New NotifyIcon
        With MessageIcon
            .BalloonTipText = _MessageTexto
            .BalloonTipTitle = _TituloMessage
            Select Case Tipo
                Case Is = "INFO"
                    .BalloonTipIcon = ToolTipIcon.Info
                Case Is = "ERROR"
                    .BalloonTipIcon = ToolTipIcon.Error
            End Select
            .Icon = My.Resources.contaduria_logo_vect
        End With
        MessageIcon.Visible = True
        MessageIcon.ShowBalloonTip(1800)
        MessageIcon.Dispose()
    End Sub

    Public Shared Sub MessageSimple(ByVal Texto As String)
        Dim MessageIcon As New NotifyIcon
        With MessageIcon
            .BalloonTipText = Texto
            .BalloonTipTitle = ""
            .BalloonTipIcon = ToolTipIcon.Info
            .Icon = My.Resources.contaduria_logo_vect
        End With
        MessageIcon.Visible = True
        MessageIcon.ShowBalloonTip(1800)
        MessageIcon.Dispose()
    End Sub

    Public Shared Sub MessageErrorSimple(ByVal Texto As String)
        Dim MessageIcon As New NotifyIcon
        With MessageIcon
            .BalloonTipText = Texto
            .BalloonTipTitle = ""
            .BalloonTipIcon = ToolTipIcon.Error
            .Icon = My.Resources.contaduria_logo_vect
        End With
        MessageIcon.Visible = True
        MessageIcon.ShowBalloonTip(1800)
        MessageIcon.Dispose()
    End Sub

End Class