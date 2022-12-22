# Documentacion - Descarga CFDI Web Service
***
Programa que realiza descarga de CFDIs del web service que proporciona el SAT.
***
# sw.descargamasiva - Solución
***
## Proyecto - DescargaWebService
***
**Índice**   
1. [Recursos](#id1)
2. [Funcionamiento](#id2)


***
### - Recursos <a name="id1"></a>
***
    -- Carpeta - Archivo_Peticiones : Dentro de esta carpeta se almacenan los archivos XML de peticiones de cada RFC. Si no existe se crea automaticamente.

    -- Carpeta - Archivos PFX : Dentro de esta carpeta se deben colocar los archivos PFX de cada uno de los RFC. La carpeta debe estar en la misma ruta del archivo .exe, dentro de la carpeta Recursos/Archivos PFX.

    -- Carpeta - LogErrores : Dentro de esta carpeta se almacenan los archivos txt de errores, se crea un archivo por dia. Si no existe se crea automaticamente.

    -- Carpeta - Peticiones Descargadas : Dentro de esta carpeta se guardaran los archivos de las peticiones que hayan sido exitosos. La carpeta se genera automaticamente.

### - Funcionamiento <a name="id2"></a>

-- El sistema realiza la descarga de CFDIs Emitidos. Los dias a descargar son 4, contando la fecha actual, el rango de descarga es predeterminada de las 00:00:00 horas a las 23:59:59. En el caso de ser exitoso las peticiones quedarian como se muestran a continuacion:  
Ejemplo:  
* Peticion fechaHoy - fechaInicio=2022-12-20 horaInicio=00:00:00 fechaFin=2022-12-20 horaFin=23:59:59
* Peticion fechaAyer - fechaInicio=2022-12-19 horaInicio=00:00:00 fechaFin=2022-12-19 horaFin=23:59:59
* Peticion fechaAntier - fechaInicio=2022-12-18 horaInicio=00:00:00 fechaFin=2022-12-18 horaFin=23:59:59
* Peticion fechaAnteAntier - fechaInicio=2022-12-17 horaInicio=00:00:00 fechaFin=2022-12-17 horaFin=23:59:59

--En el caso de que sea rechazada una peticion, al repetirse la peticion, la hora inicial puede variar, debido a que ya existen peticiones con la misma fecha, y el incremento es de 1 segundo por cantidad de registros de peticiones con las mismas fechas.  
Ejemplo:  
* Peticion fechaHoy - fechaInicio=2022-12-20 horaInicio=00:00:00 fechaFin=2022-12-20 horaFin=23:59:59  
Suponiendo que esta peticion haya sido rechazada, como ya existe 1 peticion con la misma fecha como registro, se va incrementar un segundo a la horaInicio y la nueva peticion de la misma fecha quedaria como se muestra a continuacion:  
* Peticion fechaHoy - fechaInicio=2022-12-20 horaInicio=00:00:01 fechaFin=2022-12-20 horaFin=23:59:59

-- La descarga de CFDIs contempla 4 dias por lo siguiente:
* 72 horas es el tiempo maximo para que un CFDI sea timbrado por el SAT. Por lo cual se contempla 3 dias atras a partir de la fecha actual.
* Se toma en cuenta la fecha actual, para descargar los CFDIs del dia tambien.
    
-- La ruta de Descarga de los paquetes .Zip, es la misma ubicacion desde la cual se ejecuta el sistema (En la ubicacion donde se haya colocado el ejecutable del programa). Con la variacion de que se encuentra dentro de la carpeta Recursos/Peticiones Descargadas.

-- El nombre para la descarga de los paquetes .zip, se compone de: RFC_LOTE 2022MESDIA_Fecha Peticion.zip
Ejemplo de archivo descargado:
DPA060116FH3_LOTE 20221217_Fecha 2022-12-17.zip

-- El sistema esta programado para ejecutarse a las 18:00:00 horas, con la condicion de que la hora actual sea menor a esta hora. En caso de que la hora actual sea mayor a las 18:00 horas, se programa una nueva hora ejecucion, agregando 1 minuto a la hora actual.
Ejemplo:
Hora Ejecucion = 18:00:00
Hora Actual = 18:30:00
La nueva hora de ejecucion seria a las 18:31:00.

-- El sistema cuenta con 3 timer, empleandose de la siguiente manera:
* tmrHora : Se utiliza para recuperar la hora del sistema, y activar el evento clic del boton btnIniciar, cuando la hora actual sea igual a las 18:00:00, puede haber una excepcion como se menciono en el funcionamiento anterior.
* tmrTemporizador : Se inicializa un temporizador de 59 minutos 59 segundos, cuando llega a 0 activa el evento clic del boton btnIniciar, para hacer las peticiones. Solo se activa cuando no se completan las peticiones del dia.
* tmrDescargaPaquetes : Se inicializa un temporizador de 30 minutos, cuando llega a 0 activa el evento clic del boton btnDescarga, para la descarga de las peticiones, en caso de no ser exitoso, se reprograma a otros 30 minutos, hasta que se descarguen todas las peticiones del dia.

-- btnIniciar (Boton Iniciar Peticiones): Se habilita en base a las validaciones que existen en en el tmrHora y el temporizador de 59 minutos 59 segundos controlados por el timer tmrTemporizador. Se encarga de hacer las peticiones diaras (4 peticiones), de todos los RFC registrados en el comboBox cboEmpresas.

-- Para realizar las peticiones, debe existir el archivo PFX para el RFC correspondiente, en caso de no ser asi, imprimira un mensaje en el Log de errores con la ubicacion a donde debe ser colocada el archivo PFX. Solo se haran peticiones de los RFC que cuenten con archivo PFX, y que esten vigentes.

-- Solo estan permitidas 4 peticiones en el dia (FechaHoy, FechaAyer, FechaAntier, FechaAnteAntier), siempre y cuando las 4 peticiones sean exitosas hasta las descarga. En caso de ser rechazada una peticion, existe la posibilidad de que se pueda repetir esa peticion con la misma fecha, pero la hora inicial cambiaria, como se explico en una funcion anterior.

-- Al activar el evento click del boton btnIniciar, se inician las peticiones, si las peticiones se completan correctamente, se habilita el timer tmrDescargaPaquetes. En caso de no completarse las peticiones se habilita el timer tmrTemporizador.

-- btnDescarga (Boton Descarga Paquetes): Se habilita al finalizar el temporizador de 30 minutos controlado por el timer tmrDescargaPaquetes, se recorre el comboBox cboEmpresas, y se busca el archivo XML de peticiones correspondientes a cada RFC, se recorre el archivo XML y se busca aquellas peticiones que esten pendientes de descargar. Si la descarga es exitosa, el timer tmrDescargaPaquetes se deshabilita. En caso contrario se reprograma como se explico anteriormente.

-- Para las peticiones que sean rechadazas, se pueden volver a descargar con el mismo rango de fecha inicial y fecha final. Siempre y cuando se realicen las peticiones el mismo dia.
Ejemplo:
Peticion id="9dbb471d-50e0-4715-a904-98cfa2b99e70" descargada="0" tipo="Recibidas" fechaInicial="2022-12-12" HoraInicial="00:00:00" fechaFinal="2022-12-12" HoraFinal="23:59:59" ClaveLote="20221214" estadoSolicitud="Rechazado"
Como podemos observar, la peticion anterior fue rechazada, al realizar las peticiones de nuevo, quedaria de la siguiente manera:  
Peticion id="8139e0b5-f9d7-4604-9c70-aef8c3f1c11b" descargada="0" tipo="Recibidas" fechaInicial="2022-12-12" HoraInicial="00:00:01" fechaFinal="2022-12-12" HoraFinal="23:59:59" ClaveLote="20221214" estadoSolicitud="Solicitud Aceptada"  
La nueva peticion queda con el mismo rango de fecha, sin embargo es diferente en la HoraInicial, ya que se le agrega 1 segundo, debido a que ya existe una peticion con el mismo rango, el incremento puede variar de acuerdo al numero de registros que existen, como ya se explico anteriormente.  
Al realizar una nueva peticion de la anterior que fue rechazada, se actualizara su estado a "Rechazado-1".Quedando de la siguiente manera:  
Peticion id="2a860dfe-8b8c-4d25-8afa-a1f474a637f7" descargada="0" tipo="Recibidas" fechaInicial="2022-12-19" HoraInicial="00:00:01" fechaFinal="2022-12-19" HoraFinal="23:59:59" ClaveLote="20221222" estadoSolicitud="Rechazado-1"  

-- El Log errores es almacenada diariamente en un archivo txt, se guardan automaticamente despues de imprimirse en el txtLogEr. El nombre del archivo comprende de Log Errores_dia-mes-año. Se almacenan en Recursos/LogErrores.

-- Cuenta con un apartado para descarga de Metadata, se tiene que seleccionar el RFC del comboBox, se debe elegir el rango de fechas a consultar y se debe hacer uso de los botones que se muestran en esa seccion (Boton Crear Peticion Metadata y Boton Descarga Metadata).