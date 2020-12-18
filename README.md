# SICYF ![ ](https://safi.misiones.gob.ar/images/contaduria.png)
 
### Sistema Integrado Contable y Financiero
El objetivo del sistema es contener todos los procesos necesarios de los Servicios Administrativos de la Contaduría General de la Provincia de Misiones, es un software de nivel TPS/MIS
que proveerá información a un sistema DSS en el futuro.

### Tecnología utilizada.
* [Vb.Net](https://docs.microsoft.com/en-us/dotnet/visual-basic/) - Visual Basic is an object-oriented programming language 
* [.NET Framework 4.7.1](https://www.microsoft.com/en-us/p/net-framework-features/9wzdncrdfwx0?activetab=pivot:overviewtab) software framework developed by Microsoft
* [MySQL](https://www.mysql.com/) - Relational Database Management System
>La primer fase será una aplicación de escritorio basado en VB.net (esto es debido a que existe personal además del programador inicial que conoce este lenguaje y puede >colaborar en el desarrollo en el futuro)
>dirigido a .Net Framework 4.7.1
con una base de datos MySQL en replicación Master Master (al momento del inicio del desarrollo varios Servicios Administrativos no cuentan con Internet).

### Features
   - General
   - Todos los usuarios tienen un rol personalizado a las tareas que realizan.
	  - Un usuario Administrador se encarga de determinar los permisos que se le otorgan a traves de una GUI
	- Todas las tablas visibles se pueden exportar a:
	  - Excel
	  - Pdf Formato Horizontal
	  - Pdf Formato Vertical
	  - Copiar a Portapapeles
	- Todos los documentos generados tienen la opción de colocar los sellos del personal a cargo 
		-Autoselección basado en la asistencia del mismo.

  - ##### Departamento de Suministros
	- Carga de Expedientes
	  - Carga de proveedores en los expedientes
	- Creación y generación de Ordenes de Provisión (PDF)
	  - Control interno de los items que componen la misma
	
    
  - ##### Departamento de Contabilidad 
	- Carga de Expedientes
	  - Carga de proveedores en los expedientes
	- Creación y generación de Ordenes de pago (PDF)
	  - Distintos tipos de formatos para diversas ordenes de pago
	  - Formato adaptado a las necesidades de control.
  
  - ##### Departamento de Tesorería
	- Carga de Expedientes
	  - Carga de proveedores en los expedientes
	- Creación de Pedidos de fondos
	  - Transmisión de Datos a la Tesorería General de la Provincia de Misiones
	- Registro de movimientos con restricciones basados en la existencia de un pedido de fondos, el ingreso existente en el mismo, el proveedor asignado en el mismo
	  - Calculo y registro de retenciones
	  - Generación de certificados de retenciones (PDF)
	- Registro de recibos de parte de los proveedores (reportes para la asistencia de los mismos)
	  - Adecuación al principio de que los expedientes deben contener toda la información correspondiente a sus transferencias, pagos y retenciones.
	- Carga de Movimientos Bancarios
	  - Formato CSV, XLSX 
	  - Carga de Movimientos en SAFI
	  - Formato XLSX
	- Conciliación automática basado en los movimientos de libro y los movimientos bancarios.
	- Evaluación discriminada por expedientes, Nro de transacción.
	- Reporte de:
	  - Conciliación (varios tipos)
	  - Movimientos (ingresos, Egresos)
	  - Retenciones
	  - Pedidos de Fondos por día
	  - Relacionados con banco en forma directa.
### Installation
El programa requiere la instalación del [.Net Framework 4.7.1](https://www.microsoft.com/es-es/download/details.aspx?id=56116) y luego de ello ejecutar el archivo [setup.exe].

### Credits
> Servicio Administrativo de Salud Publica
> Direccion General de Auditoria.
> Tesoreria General Provincia de Misiones
> Tribunal de Cuentas Provincia de Misiones
