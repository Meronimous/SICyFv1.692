Imports Newtonsoft.Json

Imports RestSharp

Public Class Informatica_Servidor
    Dim datosservidor_datatable As New DataTable

    Private Sub Informatica_Servidor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Informatica_Servidor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Show status;", datosservidor_datatable, "Informatica_Servidor_Shown")
        For x = 0 To datosservidor_datatable.Columns.Count - 1
        Next
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Backup_Bd.Click
        Informatica_Backup.Main()
    End Sub

    Private Sub PRUEBAAPITESO_Click(sender As Object, e As EventArgs) Handles PRUEBAAPITESO.Click
        ' ApiNuevo()
    End Sub

    Private Function gettoken() As String
        Dim token As String = ""
        Dim respuesta As New TesoreriaRespuestaApi
        Dim client As New RestClient("https://apiteso.ddns.net")
        Dim request As New RestRequest("token", Method.POST)
        request.RequestFormat = DataFormat.Json
        request.AddJsonBody(("{""usuario"": ""api_teso"",""clave"": ""Teso2019xTe"" }"))
        token = respuesta.Consultar_Token_Vigente()
        If IsNothing(token) Then
            Dim response = client.Execute(request)
            respuesta = JsonConvert.DeserializeObject(Of TesoreriaRespuestaApi)(response.Content)
            token = respuesta.token
            respuesta.InsertarToken(respuesta)
            If Not token.Length > 0 Then
            End If
        End If
        Return token
    End Function

    Public Sub ApiNuevo(ByVal pf As PedidoFondos)
        Dim pftesgral As New TesoreriaPedidofondo
        Dim client As New RestClient("https://apiteso.ddns.net")
        Dim token As String = gettoken()
        Dim MontoEnviado As Decimal = 0
        Dim request As New RestRequest("pf/nuevo", Method.POST)
        request.RequestFormat = DataFormat.Json
        request.AddHeader("Authorization", String.Format("Bearer {0}", token))
        pftesgral.PF = pf.N_PedidoFondo & "/" & pf.YearPedidoFondo.ToString.Substring(2, 2)
        pftesgral.Origen = 10
        pftesgral.Orden_Entrega = 9999
        pftesgral.Ejercicio = pf.YearPedidoFondo.ToString.Substring(2, 2)
        pftesgral.Expediente = 9999
        pftesgral.Fecha = pf.Fecha_Pedido.Date.ToString("yyyy-MM-dd")
        pftesgral.Cuenta = pf.Cuenta_PedidoFondo.ToString.Substring(5, 9) & "/" & pf.Cuenta_PedidoFondo.ToString.Substring(pf.Cuenta_PedidoFondo.ToString.Length - 1, 1)
        pftesgral.Observaciones = pf.Descripcion
        Dim detail As New Detalle
        For Each row As DataRow In pf.Datospartidas_datatable.Rows
            detail = New Detalle
            If IsDBNull(row.Item("pdappal")) Then
                detail.partida = 9999
                detail.Monto = row.Item("monto")
            Else
                If pf.Haberes Then
                    detail.partida = row.Item("pdappal") & row.Item("pdapcial")
                    If IsDBNull(row.Item("MONTOHABERES")) Then
                        detail.Monto = row.Item("IMPORTE")
                    Else
                        detail.Monto = row.Item("MONTOHABERES")
                    End If
                Else
                    detail.partida = row.Item("pdappal") & row.Item("pdapcial")
                    If Not IsDBNull(row.Item("IMPORTE")) Then
                        detail.Monto = row.Item("IMPORTE")
                    Else
                        detail.Monto = row.Item("Monto")
                    End If
                    'If IsDBNull(row.Item("IMPORTE_ACTARECEPCION")) Then
                    '    detail.monto = row.Item("IMPORTE")
                    'Else
                    '    detail.monto = row.Item("IMPORTE_ACTARECEPCION")
                    'End If
                End If
            End If
            MontoEnviado += detail.Monto
            'en el caso de que sea un pedido de fondos de haberes, debe enviar un cuit como 99
            'detail.proveed_razonsoc = row.Item("proveedor")
            If pf.Haberes Then
                detail.Proveed_Cuit = "99"
                If IsDBNull(row.Item("MONTOHABERES")) Then
                    detail.Proveed_Razonsoc = row.Item("PROVEEDOR")
                Else
                    detail.Proveed_Razonsoc = row.Item("DETALLEHABERES")
                End If
            Else
                detail.Proveed_Cuit = row.Item("CUIT").ToString.Replace("-", "")
                detail.Proveed_Razonsoc = row.Item("PROVEEDOR")
            End If
            detail.Expdte_Gral = CType(Split(row.Item("Expediente_N").ToString, "-").Skip(1).FirstOrDefault, String)
            detail.Org = CType(Split(row.Item("Expediente_N").ToString, "-").FirstOrDefault, String)
            pftesgral.Detalle.Add(detail)
        Next
        request.AddParameter("application/json", JsonConvert.SerializeObject(pftesgral), ParameterType.RequestBody)
        Dim response = client.Execute(request)
        Dim MessageIcon As New MessageToastie
        If MontoEnviado = pf.Monto_pedidofondo Then
            If response.IsSuccessful Then
                With MessageIcon
                    .TituloMessage = "Evaluación pedidos de fondo " & pf.N_PedidoFondo & "/" & pf.YearPedidoFondo
                    .MessageTexto = "agregado en Tesorería Gral" & "(" & MontoEnviado.ToString("C2") & ")" & response.StatusDescription
                End With
                MessageIcon.Message()
            Else
                ApiEditar(pf, pftesgral, request, MontoEnviado, token)
            End If
        Else
            With MessageIcon
                .TituloMessage = "Evaluación pedidos de fondo " & pf.N_PedidoFondo & "/" & pf.YearPedidoFondo
                .MessageTexto = "Inconsistencia en Pedido de Fondos, no sera enviado " & "(" & MontoEnviado.ToString("C2") & ") " & pf.Monto_pedidofondo
            End With
            MessageIcon.Message()
        End If
    End Sub

    Public Sub ApiNuevo2(ByVal pf As PedidoFondos)
        Dim pftesgral As New TesoreriaPedidofondo
        Dim client As New RestClient("https://apiteso.ddns.net")
        Dim token As String = gettoken()
        Dim MontoEnviado As Decimal = 0
        pftesgral.PF = pf.N_PedidoFondo & "/" & pf.YearPedidoFondo.ToString.Substring(2, 2)
        pftesgral.Origen = 10
        pftesgral.Orden_Entrega = 9999
        pftesgral.Ejercicio = pf.YearPedidoFondo.ToString.Substring(2, 2)
        pftesgral.Expediente = 9999
        pftesgral.Fecha = pf.Fecha_Pedido.Date.ToString("yyyy-MM-dd")
        pftesgral.Cuenta = pf.Cuenta_PedidoFondo.ToString.Substring(5, 9) & "/" & pf.Cuenta_PedidoFondo.ToString.Substring(pf.Cuenta_PedidoFondo.ToString.Length - 1, 1)
        pftesgral.Observaciones = pf.Descripcion
        Dim detail As New Detalle
        For Each row As DataRow In pf.Datospartidas_datatable.Rows
            detail = New Detalle
            If IsDBNull(row.Item("pdappal")) Then
                detail.partida = 9999
                detail.Monto = row.Item("monto")
            Else
                If pf.Haberes Then
                    detail.partida = row.Item("pdappal") & row.Item("pdapcial")
                    If IsDBNull(row.Item("MONTOHABERES")) Then
                        detail.Monto = row.Item("IMPORTE")
                    Else
                        detail.Monto = row.Item("MONTOHABERES")
                    End If
                Else
                    detail.partida = row.Item("pdappal") & row.Item("pdapcial")
                    If Not IsDBNull(row.Item("IMPORTE")) Then
                        detail.Monto = row.Item("IMPORTE")
                    Else
                        detail.Monto = row.Item("Monto")
                    End If
                End If
            End If
            MontoEnviado += detail.Monto
            'en el caso de que sea un pedido de fondos de haberes, debe enviar un cuit como 99
            'detail.proveed_razonsoc = row.Item("proveedor")
            If pf.Haberes Then
                detail.Proveed_Cuit = "99"
                If IsDBNull(row.Item("MONTOHABERES")) Then
                    detail.Proveed_Razonsoc = row.Item("PROVEEDOR")
                Else
                    detail.Proveed_Razonsoc = row.Item("DETALLEHABERES")
                End If
            Else
                detail.Proveed_Cuit = row.Item("CUIT").ToString.Replace("-", "")
                detail.Proveed_Razonsoc = row.Item("PROVEEDOR")
            End If
            detail.Expdte_Gral = CType(Split(row.Item("Expediente_N").ToString, "-").Skip(1).FirstOrDefault, String)
            detail.Org = CType(Split(row.Item("Expediente_N").ToString, "-").FirstOrDefault, String)
            pftesgral.Detalle.Add(detail)
        Next
        Dim MessageIcon As New MessageToastie
        If MontoEnviado = pf.Monto_pedidofondo Then
            If ApiEnviarFunction(pftesgral, "pf/nuevo", token) Then
                With MessageIcon
                    .TituloMessage = "Evaluación pedidos de fondo " & pf.N_PedidoFondo & "/" & pf.YearPedidoFondo
                    .MessageTexto = "agregado en Tesorería Gral" & "(" & MontoEnviado.ToString("C2") & ")"
                End With
            Else
                If ApiEnviarFunction(pftesgral, "pf/editar", token) Then
                    With MessageIcon
                        .TituloMessage = "Evaluación pedidos de fondo " & pf.N_PedidoFondo & "/" & pf.YearPedidoFondo
                        .MessageTexto = "Editado en Tesorería Gral" & "(" & MontoEnviado.ToString("C2") & ")"
                    End With
                Else
                    With MessageIcon
                        .TituloMessage = "Error " & pf.N_PedidoFondo & "/" & pf.YearPedidoFondo
                        .MessageTexto = "Editado en Tesorería Gral" & "(" & MontoEnviado.ToString("C2") & ")"
                    End With
                End If
            End If
        Else
            With MessageIcon
                .TituloMessage = "Evaluación pedidos de fondo " & pf.N_PedidoFondo & "/" & pf.YearPedidoFondo
                .MessageTexto = "Inconsistencia en Pedido de Fondos, no sera enviado " & "(" & MontoEnviado.ToString("C2") & ") " & pf.Monto_pedidofondo
            End With
        End If
        MessageIcon.Message()
    End Sub

    Public Sub ApiEditar(ByVal pf As PedidoFondos, pftesgral As TesoreriaPedidofondo, ByVal Request As RestRequest, ByVal MontoEnviado As Decimal, Optional token As String = "")
        'Dim pftesgral As New TesoreriaPedidofondo
        Dim client As New RestClient("https://apiteso.ddns.net")
        Request.Resource = "pf/editar"
        Request.AddParameter("application/json", JsonConvert.SerializeObject(pf), ParameterType.RequestBody)
        'MessageBox.Show(request.Parameters(1).Value.ToString)
        Dim response = client.Execute(Request)
        Dim MessageIcon As New MessageToastie
        With MessageIcon
            .TituloMessage = "Evaluación pedidos de fondo " & pf.N_PedidoFondo & "/" & pf.YearPedidoFondo
        End With
        If response.IsSuccessful Then
            MessageIcon.MessageTexto = "Editado en Tesorería Gral" & "(" & MontoEnviado.ToString("C2") & ")" & response.StatusDescription
        Else
            MessageIcon.MessageTexto = "Error " & response.StatusDescription & vbCrLf & Request.Body.Value.ToString
        End If
        If My.Computer.Name.ToUpper = "MERONETBOOK" Then
            Inicio.Label_EJERCICIOFINANCIERO.Text = "Editado en Tesorería Gral" & "(" & ")" & response.StatusDescription
        End If
        MessageIcon.Message()
    End Sub

    Public Function ApiEnviarFunction(pftesgral As TesoreriaPedidofondo, Resourcerequest As String, Optional token As String = "") As Boolean
        Dim client As New RestClient("https://apiteso.ddns.net")
        Dim request As New RestRequest(Resourcerequest, Method.POST)
        With request
            .RequestFormat = DataFormat.Json
            .AddHeader("Authorization", String.Format("Bearer {0}", token))
            .AddParameter("application/json", JsonConvert.SerializeObject(pftesgral), ParameterType.RequestBody)
        End With
        Dim response = client.Execute(request)
        Return response.IsSuccessful
    End Function

End Class