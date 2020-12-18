Public Class MesadeEntradas_expedientes

    Private Sub Cargadedatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Refresh_general()
    End Sub

    Private Sub Refresh_general()
        Dim Columnasaocultar(5) As String
        Columnasaocultar(0) = "Clave_expediente"
        Columnasaocultar(1) = "Ordenpago"
        Columnasaocultar(2) = "CodInpIngreso"
        Columnasaocultar(3) = "Claveexpteprincipal"
        Columnasaocultar(4) = "clave_pedidofondo"
        Columnasaocultar(5) = "CodInpPago"
        Dim Columnascolor(4) As String
        '  Columnascolor(0) = "Total Asignado"
        Columnascolor(1) = ""
        Columnascolor(2) = ""
        ' Columnascolor(3) = "CodInpIngreso"
        '  Columnascolor(4) = "CodInpPago"
        'Control_expedientecontabilidad.Fechaingreso_datetimepicker.SelectedDate = Date.Now
        'Control_expedientecontabilidad.Organismo_textbox.Text = ""
        'Control_expedientecontabilidad.Numeroexpediente_textbox.Text = ""
        'Control_expedientecontabilidad.Detalleexpediente_textbox.Text = ""
        'Control_expedientecontabilidad.Montodelexpediente_textbox.Number = 0
        'Control_expedientecontabilidad.N_ordenpagocargo_textbox.Text = ""
        'Control_expedientecontabilidad.Year_ordenpagocargo_textbox.Value = Date.Now.Year
        'Control_expedientecontabilidad.Montodelexpediente_textbox.Number = 0
        'Control_expedientecontabilidad.Organismo_principal.Text = ""
        'Control_expedientecontabilidad.Numeroexpediente_principal.Text = ""
        'Control_expedientecontabilidad.Year_principal.Text = ""
        'Control_expedientecontabilidad.Year_textbox.Value = Date.Now.Year
        'Control_expedientecontabilidad.Grid_Expteprincipal.Visibility = Windows.Visibility.Hidden
        '        BusquedaWPF1.Cargadedatos("SELECT Expediente_N,DATE_FORMAT(Fecha,'%d/%m/%Y') as 'Fecha',Detalle,FORMAT(Monto,2, 'es_AR') AS Monto,Claveexpteprincipal,clave_pedidofondo,Clave_expediente,Ordenpago,pp_monto as 'Total Asignado',
        'CASE WHEN pp_monto>0 THEN
        ' FORMAT(b.pp_monto-Monto,2, 'es_AR') ELSE CASE WHEN pp_monto=0 THEN FORMAT(pp_monto,2, 'es_AR') ELSE 0 END END AS Asignado,CodInpIngreso,CodInpPago,ConCatenar(SUBSTRING( clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) )),
        'SUBSTRING( clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 2))) as 'Pedido Fondo N'
        'FROM
        '(Select * from Expediente)A
        'LEFT JOIN
        '(select Clave_expediente as 'Clave_expediente_pp',sum(Monto)as 'pp_monto' from partidapresupuestaria group by Clave_expediente)B
        'ON B.Clave_expediente_pp=A.Clave_expediente
        'LEFT JOIN
        '(select (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)) as 'Clave_expediente_dtD',CodInp as CodInpIngreso
        'from expediente_detalle where codInp=3 group by (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)))D
        'ON D.clave_expediente_dtD=A.clave_expediente
        'LEFT JOIN
        '(select (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)) as 'Clave_expediente_dtC',CodInp as CodInpPago
        'from expediente_detalle where codInp=1 group by (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)))C
        'ON C.Clave_expediente_dtC=A.clave_expediente", "", "", " Where (Detalle like @valorbusquedalike) or (expediente_N like @valorbusquedalike) ", Columnascolor, Columnasaocultar)
        '        BusquedaWPF1.Cargadedatos("SELECT Expediente_N,DATE_FORMAT(Fecha,'%d/%m/%Y') as 'Fecha',Detalle,FORMAT(Monto,2, 'es_AR') AS Monto,Claveexpteprincipal,clave_pedidofondo,Clave_expediente,Ordenpago,
        'Concat
        '( CONVERT
        '(SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo)),SIGNED),'/',
        'SUBSTRING( clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) -9)) as 'Pedido Fondo N',
        '(CASE WHEN ISNULL(CLAVE_PEDIDOFONDO) THEN 'ETAPA PREVENTIVA' ELSE (CASE WHEN ISNULL(EGRESOS) THEN 'ETAPA DEFINITIVA' ELSE ' ETAPA COMPROMISO DE PAGO' END) END) AS 'ETAPA'
        'FROM
        '(Select * from Expediente)A
        'LEFT JOIN
        '(select Clave_expediente as 'Clave_expediente_pp',sum(Monto)as 'pp_monto' from partidapresupuestaria group by Clave_expediente)B
        'ON B.Clave_expediente_pp=A.Clave_expediente
        'LEFT JOIN
        '(select (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)) as 'Clave_expediente_dtD',CodInp as CodInpIngreso
        'from expediente_detalle where codInp=3 group by (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)))D
        'ON D.clave_expediente_dtD=A.clave_expediente
        'LEFT JOIN
        '(select (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)) as 'Clave_expediente_dtC',CodInp as CodInpPago
        'from expediente_detalle where codInp=1 group by (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)))C
        'ON C.Clave_expediente_dtC=A.clave_expediente
        'LEFT JOIN
        '(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS INGRESOS, SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
        ' from expediente_detalle where (Cod_orden=4 or Cod_orden=9) and (CFdo=1 or CFdo=2 or CFdo=9) and (CodInp=3 or CodInp=4 or CodInp=9) GROUP BY Clave_expedientetrim)E
        'ON E.Clave_expedientetrim=A.Clave_expediente
        'left JOIN
        '(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS EGRESOS, SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
        ' from expediente_detalle where (Cod_orden=1 or Cod_orden=2 or Cod_orden=3 or Cod_orden=4 or Cod_orden=9) and (CFdo=1 or CFdo=2 or CFdo=9) and (CodInp=1 ) GROUP BY Clave_expedientetrim)F
        'ON F.Clave_expedientetrim=A.Clave_expediente
        'left JOIN
        '(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS RENDIDO,  SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
        ' from expediente_detalle where ( CodInp=2 ) GROUP BY Clave_expedientetrim) G
        'ON G.Clave_expedientetrim=A.Clave_expediente", "", "", " Where (Detalle like @valorbusquedalike) or (expediente_N like @valorbusquedalike)
        'order by CONVERT
        '(SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo)),SIGNED) desc ", Columnascolor, Columnasaocultar)
    End Sub

End Class