Imports System.Globalization
Imports System.Threading

Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI

''' <summary>
''' Clase implementada el 23/08/2020 con motivo del lanzamiento del sistema SAFI en la página https://safi.misiones.gob.ar,
''' forma parte de las mejoras tendientes a facilitar la carga en el sistema de registro oficial, la automatización viene dada
''' por la libreria selenium y complementada con el google drive v84
'''
''' </summary>
Public Class Safi_webform
    Dim chromeoptions As New ChromeOptions
    Dim webexplorer As New ChromeDriver()
    Dim window As IWindow = webexplorer.Manage().Window
    'Propiedades
    Private _User As String
    Public Property User() As String
        Get
            Return _User
        End Get
        Set(ByVal value As String)
            _User = value
        End Set
    End Property
    Private _Pwd As String
    Public Property PWD() As String
        Get
            Return _Pwd
        End Get
        Set(ByVal value As String)
            _Pwd = value
        End Set
    End Property
    Private _Url As String = "https://safi.misiones.gob.ar/"
    Public Property Url() As String
        Get
            Return _Url
        End Get
        Set(ByVal value As String)
            _Url = value
        End Set
    End Property

    Public Sub Ejecutarlogin()
        SAFI_Login()
    End Sub

    Private Sub SAFI_Login()
        chromeoptions.PageLoadStrategy = PageLoadStrategy.Eager
        'En la parte de automatización aún existen problemas con las pantallas con un alto menor a 800 pixeles, ya que los menus superiores de la página se ocultan en una resolución menor.
        'chromeoptions.AddArguments("headless")
        'chromeoptions.AddArguments("window-size=800x600")
        Thread.Sleep(200)
        window.Maximize()
        webexplorer.Navigate.GoToUrl(_Url)
        webexplorer.FindElementByXPath("/html/body/div[2]/div/div[1]/div/form/div[2]/span/span[1]/input").SendKeys(_User)
        webexplorer.FindElementByXPath("/html/body/div[2]/div/div[1]/div/form/div[3]/span/span[1]/input").SendKeys(_Pwd)
        Thread.Sleep(100)
        webexplorer.FindElementByXPath("/html/body/div[2]/div/div[1]/div/form/div[4]/div/span/button").Click()
    End Sub

    Public Sub Iranuevomovimiento()
        Esperar("/html/body/div/div[1]/div[2]/div/div/div/form/ul/div/div/div/ul/li[4]/a/span/span[2]")
        webexplorer.FindElementByXPath("/html/body/div/div[1]/div[2]/div/div/div/form/ul/div/div/div/ul/li[4]/a/span/span[2]").Click()
        webexplorer.FindElementByXPath("/html/body/div/div[1]/div[2]/div/div/div/form/ul/div/div/div/ul/li[4]/a/span/span[2]").Click()
        NuevoMovimiento()
    End Sub

    Private Sub NuevoMovimiento()
        Esperar("/html/body/div/div[2]/form/div/div[2]/table/tbody/tr/td[2]/span/div/span/span/a")
        webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div/div[2]/table/tbody/tr/td[2]/span/div/span/span/a").Click()
    End Sub

    Private Sub CancelarMovimiento()
        Esperar("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[20]/td[2]/table/tbody/tr/td[3]/div/span/button")
        For x = 0 To 2
            Thread.Sleep(300)
            Try
                webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[20]/td[2]/table/tbody/tr/td[3]/div/span/button").Click()
            Catch ex As Exception
            End Try
        Next
    End Sub

    Public Sub GuardarIrNuevoFormulario()
        Esperar("/html/body/div/div[2]/form/div[1]/div[2]/div/div/span/button")
        webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/div/div/span/button").Click()
        Esperar("/html/body/div/div[2]/form/div/div[2]/table/tbody/tr/td[2]/span/div/span/span/a")
        webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div/div[2]/table/tbody/tr/td[2]/span/div/span/span/a").Click()
    End Sub

    Public Sub Close()
        webexplorer.Close()
    End Sub

    Private Sub CargaDatos(ByVal Mov As nuevomovimiento_safi)
        Dim ElementoWeb As IWebElement
        Dim Wait = New WebDriverWait(webexplorer, TimeSpan.FromMilliseconds(1300))
        Thread.Sleep(900)
        Esperarclick("/html/body/div/div[2]/form/div[1]/div[1]/div/div/span[1]")
        'Cuenta Bancaria:
        Cuentabancaria(Mov)
        'Código de Expediente:
        Codigoexpediente(Mov)
        'Año
        Anio(Mov)
        Thread.Sleep(150)
        'Correlativo:
        Correlativo(Mov)
        Thread.Sleep(100)
        'Codigo de orden
        Cargarcodigoorden(Mov)
        Thread.Sleep(100)
        'Nro. Orden:
        Nroorden(Mov)
        Thread.Sleep(100)
        'Nro. Pedido de Fondo:
        Nropedidofondo(Mov)
        Thread.Sleep(100)
        'Nro.Comprobante
        Nrocomprobante(Mov)
        Thread.Sleep(100)
        'Importe:
        Importe(Mov)
        Thread.Sleep(100)
        'Clase de Fondo
        CargarClasefondo(Mov)
        Thread.Sleep(100)
        'Nro. Entrega de Fondo:
        Nroentregafondo(Mov)
        Thread.Sleep(100)
        'Descripción
        Descripcion(Mov)
        Thread.Sleep(100)
        'Fecha de Comprobante
        Fechadecomprobante(Mov)
        Thread.Sleep(100)
        'Codigo de imputación
        CargarCodigoimputacion(Mov)
        Thread.Sleep(120)
    End Sub

    Private Sub Cuentabancaria(ByVal Mov As nuevomovimiento_safi)
        'Cuenta Bancaria:
        Thread.Sleep(30)
        Dropdownselect("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[2]/td[2]/span/select", Mov.Cuentabancaria)
    End Sub

    Private Sub Cargarcodigoorden(ByVal Mov As nuevomovimiento_safi)
        'Codigo de orden
        Thread.Sleep(200)
        Dropdownselect("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[4]/td[2]/span/select", , Mov.codorden)
        Thread.Sleep(300)
        Dropdownselect("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[4]/td[2]/span/select", , Mov.codorden)
    End Sub

    Private Sub CargarClasefondo(ByVal Mov As nuevomovimiento_safi)
        'Clase de Fondo
        Thread.Sleep(300)
        Dropdownselect("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[5]/td[2]/span/select", , Mov.clasefondo)
        Thread.Sleep(300)
    End Sub

    Private Sub CargarCodigoimputacion(ByVal Mov As nuevomovimiento_safi)
        'Codigo de imputación
        Thread.Sleep(400)
        Dropdownselect("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[6]/td[2]/span/select", , Mov.codinp)
        Thread.Sleep(300)
    End Sub

    Private Sub Nroorden(ByVal Mov As nuevomovimiento_safi)
        'Nro. Orden:
        Thread.Sleep(30)
        Elementoweb = webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[7]/td[2]/span/span[1]/input")
        Elementoweb.SendKeys(Mov.Nroorden.ToString)
    End Sub

    Private Sub Nropedidofondo(ByVal Mov As nuevomovimiento_safi)
        'Nro. Pedido de Fondo:
        Thread.Sleep(30)
        Elementoweb = webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[8]/td[2]/span/span[1]/input")
        Elementoweb.SendKeys(Mov.Nropedidofondo.ToString)
    End Sub

    Private Sub Nroentregafondo(ByVal Mov As nuevomovimiento_safi)
        'Nro. Entrega de Fondo:
        Thread.Sleep(30)
        Elementoweb = webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[9]/td[2]/span/span[1]/input")
        Elementoweb.SendKeys(Mov.Nroentregafondo.ToString)
    End Sub

    Private Sub Codigoexpediente(ByVal Mov As nuevomovimiento_safi)
        ''Código de Expediente:
        'Dropdownselect("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[11]/td[2]/div/span[1]/div/div/span[1]/input", Mov.Codigoexpediente.ToString)
        Thread.Sleep(30)
        Elementoweb = webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[11]/td[2]/div/span[1]/div/div/span[1]/input")
        Elementoweb.SendKeys(Keys.Control + "a")
        Elementoweb.SendKeys(Mov.Codigoexpediente.ToString)
        Thread.Sleep(50)
    End Sub

    Private Sub Correlativo(ByVal Mov As nuevomovimiento_safi)
        'Correlativo:
        Thread.Sleep(30)
        Elementoweb = webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[12]/td[2]/span/span[1]/input")
        Elementoweb.SendKeys(Keys.Home)
        Elementoweb.SendKeys(Keys.Control + "a")
        'Elementoweb.SendKeys(Mov.Correlativo)
        'Elementoweb.SendKeys(Keys.Home)
        'Elementoweb.SendKeys(Keys.Control + "a")
        Elementoweb.SendKeys(Mov.Correlativo)
    End Sub

    Private Sub Anio(ByVal Mov As nuevomovimiento_safi)
        'Año:
        Thread.Sleep(30)
        Elementoweb = webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[13]/td[2]/span/span[1]/input")
        Elementoweb.SendKeys(Mov.Anio)
    End Sub

    Private Sub Nrocomprobante(ByVal Mov As nuevomovimiento_safi)
        'Nro. Comprobante:
        Thread.Sleep(30)
        Elementoweb = webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[15]/td[2]/span/span[1]/input")
        Elementoweb.SendKeys(Mov.Nrocomprobante)
    End Sub

    Private Sub Fechadecomprobante(ByVal Mov As nuevomovimiento_safi)
        'Fecha de Comprobante
        Elementoweb = webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[16]/td[2]/span/input")
        'Elementoweb.Click()
        Thread.Sleep(30)
        Elementoweb.SendKeys(Keys.Home)
        'Elementoweb.SendKeys(Keys.Control + "a")
        Elementoweb.SendKeys(Mov.Fechadecomprobante.ToString.Replace("/", ""))
    End Sub

    Private Sub Descripcion(ByVal Mov As nuevomovimiento_safi)
        'Descripción:
        Thread.Sleep(30)
        Elementoweb = webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[17]/td[2]/span/span[1]/input")
        Elementoweb.SendKeys(Mov.Descripcion.ToString)
    End Sub

    Private Sub Importe(ByVal Mov As nuevomovimiento_safi)
        'Importe:
        Thread.Sleep(30)
        Elementoweb = webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[18]/td[2]/span/span[1]/input")
        Elementoweb.SendKeys(Mov.Importe.ToString("F2", CultureInfo.InvariantCulture))
    End Sub

    Private Sub Boton_guardar(ByVal Mov As nuevomovimiento_safi)
        'Verificar los datos Guardados
        If verificarCarga(Mov) Then
            'Guardar y crear otro
            Elementoweb = webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[20]/td[2]/table/tbody/tr/td[1]/div/span/button")
            Elementoweb.Click()
            'VerificarErroresPosteriores
            If verificarCarga(Mov) Then
            Else
                CargaDatos(Mov)
            End If
        Else
            'En caso de que al hacer click en el boton de guardar cambie alguno de los datos.
            CancelarMovimiento()
            NuevoMovimiento()
            CargaDatos(Mov)
        End If
    End Sub

    Private Function Verificar_dropdown(ByVal Xpath As String, ByVal ValorExaminado As String) As Boolean
        Dim Resultado As Boolean = True
        Try
            Dim Elementoweb As IWebElement = webexplorer.FindElementByXPath(Xpath)
            Dim se As SelectElement = New SelectElement(Elementoweb)
            If se.SelectedOption.Text.ToString.Contains(ValorExaminado) Then
                Resultado = True
            Else
                Resultado = False
            End If
        Catch ex As Exception
            Resultado = False
        End Try
        Return Resultado
    End Function

    Private Function Verificar_Elemento(ByVal Xpath As String, ByVal ValorExaminado As String) As Boolean
        Dim Resultado As Boolean = True
        Try
            Dim Elementoweb As IWebElement = webexplorer.FindElementByXPath(Xpath)
            If Elementoweb.Text.ToString = ValorExaminado Then
                Resultado = True
            Else
                Resultado = False
            End If
        Catch ex As Exception
            Resultado = False
        End Try
        Return Resultado
    End Function

    Private Function verificarCarga(ByVal Mov As nuevomovimiento_safi) As Boolean
        Dim resultado As Boolean = True
        Dim Elementoweb As IWebElement
        'Cuenta Bancaria:
        resultado = Verificar_dropdown("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[2]/td[2]/span/select", Mov.Cuentabancaria)
        'Nro. Orden:
        resultado = Verificar_Elemento("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[7]/td[2]/span/span[1]/input", Mov.Nroorden.ToString)
        'Codigo de orden
        resultado = Verificar_dropdown("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[4]/td[2]/span/select", Mov.codorden)
        'Nro. Pedido de Fondo:
        resultado = Verificar_Elemento("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[8]/td[2]/span/span[1]/input", Mov.Nropedidofondo.ToString)
        'Nro. Entrega de Fondo:
        resultado = Verificar_Elemento("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[9]/td[2]/span/span[1]/input", Mov.Nroentregafondo.ToString)
        'Código de Expediente:
        resultado = Verificar_Elemento("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[11]/td[2]/div/span[1]/div/div/span[1]/input", Mov.Codigoexpediente.ToString)
        'Correlativo:
        resultado = Verificar_Elemento("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[12]/td[2]/span/span[1]/input", Mov.Correlativo)
        'Año:
        resultado = Verificar_Elemento("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[13]/td[2]/span/span[1]/input", Mov.Anio)
        'Nro. Comprobante:
        resultado = Verificar_Elemento("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[15]/td[2]/span/span[1]/input", Mov.Nrocomprobante)
        'Fecha de Comprobante
        resultado = Verificar_Elemento("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[16]/td[2]/span/input", Mov.Fechadecomprobante.ToString.Replace("/", ""))
        'Descripción:
        resultado = Verificar_Elemento("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[17]/td[2]/span/span[1]/input", Mov.Descripcion.ToString)
        'Importe:
        resultado = Verificar_Elemento("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[18]/td[2]/span/span[1]/input", Mov.Importe.ToString("F2", CultureInfo.InvariantCulture))
        'Codigo de imputación
        resultado = Verificar_dropdown("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[6]/td[2]/span/select", Mov.codinp)
        Return resultado
    End Function

    Private Sub Dropdownselect(ByVal Xpath As String, Optional selecttext As String = "", Optional selectvalue As String = "", Optional selectindex As Integer = vbNull)
        Esperarclick(Xpath)
        'webexplorer.FindElementByXPath(Xpath).Click()
        Thread.Sleep(800)
        Dim Elementoweb As IWebElement = webexplorer.FindElementByXPath(Xpath)
        Dim FinalizarBucle As Boolean = False
        cargado = False
        Dim wait = New WebDriverWait(webexplorer, TimeSpan.FromMilliseconds(800))
        Dim element
        '
        While Not FinalizarBucle
            Try
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webexplorer.FindElementByXPath(Xpath)))
                FinalizarBucle = True
            Catch ex As Exception
            End Try
        End While
        Dim se As SelectElement = New SelectElement(Elementoweb)
        'se.SelectByIndex(0)
        Dim lista As New List(Of IWebElement)
        Dim options
        While Not cargado
            Try
                lista = se.Options.ToList
                Try
                    If selecttext.Length > 0 Then
                        se.SelectByText(selecttext, True)
                        options = Elementoweb.FindElements(By.TagName("option")).Where(Function(opt) opt.Text = selecttext)
                        ' options.Single().Click()
                    ElseIf selectvalue.Length > 0 Then
                        se.SelectByValue(selectvalue)
                        'options = ELEMENTOWEB.FindElements(By.TagName("option")).Where(Function(opt) opt.GetCssValue = selectvalue)
                    ElseIf selectindex >= 0 Then
                        'webexplorer.FindElementByXPath("/html/body/div/div[2]/form/div[1]/div[2]/table/tbody/tr[4]/td[2]/span/select/option[" & selectoptions & "]").Click()
                        se.SelectByIndex(selectindex)
                    End If
                Catch ex As Exception
                    Thread.Sleep(200)
                    se.SelectByIndex(0)
                    cargado = True
                End Try
                cargado = True
            Catch ex As Exception
                cargado = False
                wait = New WebDriverWait(webexplorer, TimeSpan.FromMilliseconds(600))
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webexplorer.FindElementByXPath(Xpath)))
                '
            End Try
        End While
        'element.Click()
        'ELEMENTOWEB.SendKeys(Keys.Tab)
        'webexplorer.FindElement(By.XPath(Xpath)).SendKeys(Keys.Tab)
    End Sub

    Private Function Esperar(ByVal Elements As String) As Double
        Dim finalizarbucle As Boolean = False
        Dim wait = New WebDriverWait(webexplorer, TimeSpan.FromMilliseconds(1200))
        Dim element
        Dim stopwa As New Stopwatch
        stopwa.Start()
        While Not finalizarbucle
            Try
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(Elements)))
                finalizarbucle = True
            Catch ex As Exception
            End Try
        End While
        stopwa.Stop()
        Return stopwa.ElapsedMilliseconds
    End Function

    Private Function Esperarclick(ByVal Elements As String) As Double
        Dim finalizarbucle As Boolean = False
        Dim wait = New WebDriverWait(webexplorer, TimeSpan.FromMilliseconds(1800))
        Dim element As IWebElement = Nothing
        Dim stopwa As New Stopwatch
        stopwa.Start()
        While Not finalizarbucle
            Try
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Elements)))
                Thread.Sleep(1400)
                finalizarbucle = True
            Catch ex As Exception
            End Try
        End While
        element = webexplorer.FindElementByXPath(Elements)
        element.Click()
        stopwa.Stop()
        Return stopwa.ElapsedMilliseconds
    End Function

    Public Sub Cargarnuevomovimientov2(ByVal Mov As nuevomovimiento_safi)
        Thread.Sleep(800)
        CargaDatos(Mov)
        'Correcto
        For x = 0 To 1
            Thread.Sleep(350)
            Boton_guardar(Mov)
        Next
        ''------------TESTING---------------------
        ''Solamente a los efectos del Testing
        'MetodopararealizarTesting()
    End Sub

    Private Sub MetodopararealizarTesting()
        Thread.Sleep(800)
        CancelarMovimiento()
    End Sub

End Class

Public Class nuevomovimiento_safi
    Public Ejercicio As Integer
    Public Cuentabancaria As String
    Public codorden As Integer
    Public clasefondo As Integer
    Public codinp As Integer
    Public Nroorden As Integer
    Public Nropedidofondo As Integer
    Public Nroentregafondo As Integer
    Public Codigoexpediente As Integer
    Public Correlativo As Integer
    Public Anio As Integer
    Public Nrocomprobante As Double
    Public Fechadecomprobante As String
    Public Descripcion As String
    Public Importe As Decimal
End Class