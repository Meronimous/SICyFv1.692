Imports System.Threading

Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI

Public Class Tesoreriageneral_webform
    Dim chromeoptions As New ChromeOptions()
    Dim PedidoFondo As PedidoFondos = Nothing
    Dim webexplorer As ChromeDriver = Nothing

    Public Sub New()
    End Sub

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
    Private _Url As String = "https://tesoreriageneral.com.ar/"
    Public Property Url() As String
        Get
            Return _Url
        End Get
        Set(ByVal value As String)
            _Url = value
        End Set
    End Property

    'usupubli
    'Salu9655
    Public Sub Ejecutarlogin()
        TGLogin()
    End Sub

    Private Sub TGLogin()
        chromeoptions.PageLoadStrategy = PageLoadStrategy.Eager
        chromeoptions.AddArguments("headless")
        chromeoptions.AddArguments("window-size=800x600")
        'Dim js As IJavaScriptExecutor = CType(webexplorer, IJavaScriptExecutor)
        'js.ExecuteScript("document.body.style.zoom='80%'")
        'webexplorer.ge("chrome://settings/")
        'driver.execute_script('chrome.settingsPrivate.setDefaultZoom(1.5);')
        Dim driverService = ChromeDriverService.CreateDefaultService()
        driverService.HideCommandPromptWindow = True
        webexplorer = New ChromeDriver(driverService, chromeoptions)
        webexplorer.Navigate.GoToUrl(_Url)
        Dim window As IWindow = webexplorer.Manage().Window
        Thread.Sleep(200)
        'window.Maximize()
        webexplorer.FindElementByXPath("/html/body/a[2]").Click()
        Thread.Sleep(100)
        webexplorer.FindElementByXPath("/html/body/table[4]/tbody/tr/td/div/form/table[1]/tbody/tr[1]/td[2]/input").SendKeys(_User)
        webexplorer.FindElementByXPath("/html/body/table[4]/tbody/tr/td/div/form/table[1]/tbody/tr[2]/td[2]/input").SendKeys(_Pwd)
        Thread.Sleep(100)
        webexplorer.FindElementByXPath("/html/body/table[4]/tbody/tr/td/div/form/table[2]/tbody/tr/td/div/input").Click()
    End Sub

    Public Sub MovimientosExpedientes(ByVal ped As TesoreriaGralPedidoFondo, ByVal Pedfondoespecial As Boolean)
        Dim tabs2 As List(Of String) = New List(Of String)(webexplorer.WindowHandles())
        webexplorer.SwitchTo().Window(tabs2(0))
        Elementoweb = webexplorer.FindElementByXPath("/html/body/table[4]/tbody/tr/td/form/input[3]")
        Elementoweb.SendKeys(Keys.Control + "a")
        If ped.NumeroPedido < 10 Then
            Elementoweb.SendKeys(ped.NumeroPedido.ToString("00"))
        Else
            Elementoweb.SendKeys(ped.NumeroPedido)
        End If
        If Pedfondoespecial Then
            Elementoweb.SendKeys("/n")
        End If
        Elementoweb.SendKeys("/")
        Elementoweb.SendKeys(ped.YearPedidoFondo.ToString.Substring(2, 2))
        webexplorer.FindElementByXPath("/html/body/table[4]/tbody/tr/td/form/center/input").Click()
        ' TablaMovimientosExpedientes()
        '/html/body/table[4]/tbody/tr/td/form/input[3]
        '/html/body/table[4]/tbody/tr/td/form/center/input
    End Sub

    Public Function TablaMovimientosExpedientes() As DataTable
        Dim TablaTemporal As DataTable = New DataTable
        Thread.Sleep(300)
        Dim tabs2 As List(Of String) = New List(Of String)(webexplorer.WindowHandles())
        webexplorer.SwitchTo().Window(tabs2(1))
        Dim Rows As Integer = 0
        Try
            TablaTemporal.Columns.Add(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[1]/td[1]")).Item(0).Text, System.Type.GetType("System.DateTime")) 'Fecha
            TablaTemporal.Columns.Add(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[1]/td[2]")).Item(0).Text, System.Type.GetType("System.Decimal")) 'Importe
            TablaTemporal.Columns.Add(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[1]/td[3]")).Item(0).Text, System.Type.GetType("System.Decimal")) 'Saldo
            TablaTemporal.Columns.Add(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[1]/td[4]")).Item(0).Text, System.Type.GetType("System.String")) 'Descripción
            TablaTemporal.Columns.Add(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[1]/td[5]")).Item(0).Text, System.Type.GetType("System.String")) 'Observaciones
            TablaTemporal.Rows.Add({
                                   webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[2]/td[1]")).Item(0).Text,
                                   webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[2]/td[2]")).Item(0).Text,
                webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[2]/td[3]")).Item(0).Text,
                webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[2]/td[4]")).Item(0).Text,
                webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[2]/td[5]")).Item(0).Text
            })
            ' MessageBox.Show(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[2]/td[3]")).Item(0).Text)
        Catch ex As Exception
        End Try
        webexplorer.Close()
        webexplorer.SwitchTo().Window(tabs2(0))
        webexplorer.Close()
        Return TablaTemporal
    End Function

    Public Function Converter_WebTGtoTesoreriaGralPedidoFondo(ByVal ped As TesoreriaGralPedidoFondo, Optional Especial As Boolean = False) As TesoreriaGralPedidoFondo
        MovimientosExpedientes(ped, Especial)
        Dim tablatemporal As New DataTable
        Thread.Sleep(10)
        Dim tabs2 As List(Of String) = New List(Of String)(webexplorer.WindowHandles())
        webexplorer.SwitchTo().Window(tabs2(1))
        Dim Rows As Integer = 0
        Try
            ' ped.NumeroPedido =  'Separar numero y anio
            'ped.YearPedidoFondo = CType(CType(Manipulaciondedatos.Divisordedosvariables(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/b[3]")).Item(0).Text), String())(1), Integer) + 2000 'separar numero y anio
            'ped.NroOrdenEntrega = webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/b[5]")).Item(0).Text 'Separar texto
            'ped.YearOrdenEntrega = webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/b[5]")).Item(0).Text 'Separar texto
            ' ped.MontoPedidoFondo = webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/b[5]")).Item(0).Text 'Separar texto
            tablatemporal.Columns.Add(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[1]/td[1]")).Item(0).Text, System.Type.GetType("System.DateTime")) 'Fecha
            tablatemporal.Columns.Add(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[1]/td[2]")).Item(0).Text, System.Type.GetType("System.Decimal")) 'Importe
            tablatemporal.Columns.Add(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[1]/td[3]")).Item(0).Text, System.Type.GetType("System.Decimal")) 'Saldo
            tablatemporal.Columns.Add(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[1]/td[4]")).Item(0).Text, System.Type.GetType("System.String")) 'Descripción
            tablatemporal.Columns.Add(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[1]/td[5]")).Item(0).Text, System.Type.GetType("System.String")) 'Observaciones
            For x = 0 To 25
                tablatemporal.Rows.Add({
                       webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[" & x + 2 & "]/td[1]")).Item(0).Text,
                       webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[" & x + 2 & "]/td[2]")).Item(0).Text,
    webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[" & x + 2 & "]/td[3]")).Item(0).Text,
    webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[" & x + 2 & "]/td[4]")).Item(0).Text,
    webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[" & x + 2 & "]/td[5]")).Item(0).Text
})
            Next
            ' MessageBox.Show(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[2]/td[3]")).Item(0).Text)
        Catch ex As Exception
            If tablatemporal.Rows.Count > 0 Then
                ped.Fecha = tablatemporal.Rows(0).Item(0)
                ped.Descripcion = tablatemporal.Rows(0).Item(3)
                ped.Saldo = tablatemporal.Rows(tablatemporal.Rows.Count - 1).Item(2)
                ped.MontoPedidoFondo = tablatemporal.Rows(0).Item(2)
            Else
                ped.Descripcion = "Sin Datos"
                ped.Saldo = -1
            End If
            '  MessageBox.Show(webexplorer.FindElements(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[2]/td[3]")).Item(0).Text)
        End Try
        webexplorer.SwitchTo().Window(tabs2(1)).Close()
        webexplorer.SwitchTo().Window(tabs2(0))
        Return ped
    End Function

    Public Function CloseWeb()
        webexplorer.Close()
    End Function

    Private Sub TesoConsultaMovimientosPedFondo()
        Elementoweb = webexplorer.FindElementByXPath("/html/body/table[4]/tbody/tr/td/form/input[3]")
        'Nro pedido fondo
        Elementoweb = webexplorer.FindElementByXPath("/html/body/table/tbody/tr/td/b[3]")
        'Origen
        Elementoweb = webexplorer.FindElementByXPath("/html/body/table/tbody/tr/td/b[4]")
        'Orden de entreega 'Expediente
        Elementoweb = webexplorer.FindElementByXPath("/html/body/table/tbody/tr/td/b[5]/text()[1]")
        'Ingresado
        Elementoweb = webexplorer.FindElementByXPath("/html/body/table/tbody/tr/td/b[5]/text()[2]")
    End Sub

    Private Function Esperarclick(ByVal Elements As String) As Double
        Dim finalizarbucle As Boolean = False
        Dim wait = New WebDriverWait(webexplorer, TimeSpan.FromMilliseconds(1100))
        Dim element As IWebElement = Nothing
        Dim stopwa As New Stopwatch
        stopwa.Start()
        While Not finalizarbucle
            Try
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Elements)))
                Thread.Sleep(300)
                finalizarbucle = True
            Catch ex As Exception
            End Try
        End While
        element = webexplorer.FindElementByXPath(Elements)
        element.Click()
        stopwa.Stop()
        Return stopwa.ElapsedMilliseconds
    End Function

End Class