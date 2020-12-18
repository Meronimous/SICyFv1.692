Imports iTextSharp

Public Class Impresion
    Public hoja As text.Rectangle
    Public tamaniofuente As Single
    Public tamaniofuentetablas As Single
    Public tamaniofuentetitulos As Single
    Public decimales As Integer
    Public marginleft As Single
    Public marginright As Single
    Public margintop As Single
    Public marginbottom As Single
    Public tipofuente As iTextSharp.text.Font
    Public fecha As DateTime
    Public Sello_direccion As New Sello
    Public Sello_Tesoreria As New Sello
    Public Sello_Contabilidad As New Sello
    Public Sello_Suministros As New Sello
    Public Sello_Delegadofiscal As New Sello

    Public Sub New()
        hoja = text.PageSize.LEGAL
        tamaniofuente = 8
        tamaniofuentetablas = 8
        tamaniofuentetitulos = 10
        decimales = 2
        marginleft = 40
        marginright = 30
        margintop = 20
        marginbottom = 30
        tipofuente = text.FontFactory.GetFont("Segoe UI", tamaniofuente, text.Font.NORMAL)
        fecha = Date.Now
        'dirección
        Sello_direccion.SelloDepartamento = "Director"
        Sello_direccion.FechaSello = Date.Now
        Sello_direccion.Nombre_sello = ""
        Sello_direccion.Cargo = "Director"
        'tesoreria
        Sello_Tesoreria.SelloDepartamento = "Tesorero"
        Sello_Tesoreria.FechaSello = Date.Now
        Sello_Tesoreria.Nombre_sello = ""
        Sello_Tesoreria.Cargo = "Tesorero"
        'contabilidad
        Sello_Contabilidad.SelloDepartamento = "Contabilidad"
        Sello_Contabilidad.FechaSello = Date.Now
        Sello_Contabilidad.Nombre_sello = ""
        Sello_Contabilidad.Cargo = "Jefe  Depto Contabilidad"
        'suministros
        Sello_Suministros.SelloDepartamento = "Suministros"
        Sello_Suministros.FechaSello = Date.Now
        Sello_Suministros.Nombre_sello = ""
        Sello_Suministros.Cargo = "Jefe Depto Suministros"
        'delegado fiscal
        Sello_Delegadofiscal.SelloDepartamento = "Delegado Fiscal"
        Sello_Delegadofiscal.FechaSello = Date.Now
        Sello_Delegadofiscal.Nombre_sello = ""
        Sello_Delegadofiscal.Cargo = "Delegado Fiscal"
    End Sub

    Public Sub cargartodoslossellos()
        Sello_direccion = cargarsello(Sello_direccion.SelloDepartamento, Sello_direccion.FechaSello)
        Sello_Tesoreria = cargarsello(Sello_Tesoreria.SelloDepartamento, Sello_Tesoreria.FechaSello)
        Sello_Contabilidad = cargarsello(Sello_Contabilidad.SelloDepartamento, Sello_Contabilidad.FechaSello)
        Sello_Suministros = cargarsello(Sello_Suministros.SelloDepartamento, Sello_Suministros.FechaSello)
        Sello_Delegadofiscal = cargarsello(Sello_Delegadofiscal.SelloDepartamento, Sello_Delegadofiscal.FechaSello)
    End Sub

    Public Shared Function cargarsello(ByVal departamento As String, ByVal fecha As Date) As Sello
        Dim Sello_datatable As New DataTable
        Dim sello_retornar As New Sello
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@departamento", departamento)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@fecha", fecha)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Nombre_sello,Cargo,
case when isnull(causa) then 'Presente' else Causa END as 'Estado',
case when isnull(causa) then orden else Orden+99 END as Orden
 from
(Select * from contaduria_usuarios.sellos where Departamento=@departamento)A
left JOIN
(select * from personal.presentismo2 where @fecha between SD and ED )B
ON A.Documento=B.documento
order by orden asc",
                             Sello_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        sello_retornar.Nombre_sello = Sello_datatable.Rows(0).Item(0)
        sello_retornar.Cargo = Sello_datatable.Rows(0).Item(1)
        sello_retornar.FechaSello = fecha
        sello_retornar.SelloDepartamento = departamento
        'sello_retornar.Sellofuentetamanio
        Return sello_retornar
    End Function

End Class

Public Class Sello
    Public SelloDepartamento As String
    Public FechaSello As Date
    Public Sellofuentetamanio As Single
    Public Nombre_sello As String
    Public Cargo As String

    Public Sub New()
        SelloDepartamento = ""
        FechaSello = Date.Now
        Sellofuentetamanio = 10
        Nombre_sello = ""
        Cargo = ""
    End Sub

End Class