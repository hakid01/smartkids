# Despliegue de la aplicación

## Configuración para generar el archivo Android App Bundle desde Unity

### Configuración inicial necesaria para desarrollar el proyecto para Android

Una vez creado el proyecto y abierto en Unity, debemos configurar las siguientes opciones a las que accedemos desde los botones de la barra de herramientas.

![Barra de herramientas Unity][toolbar]

* Edit -> Preferences -> External tools -> seleccionar **SDK**, **NDK**, **JDK** y **Gradel**.

![External tools][ext_tools]

* File -> Build Settings -> seleccionar **Android** y click en **switch plartorm**. Después podremos hacer click en build y tendremos una apk para probar en nuestro telefono.

![Build settings][build_settings]

* Edit -> Project Settings -> Editor: Assets **serialization** -> Mode : **Force text**. 

![Serialization][serialization]

* Edit -> Project Settings -> **Version Control**: Mode : **Visible Meta Files**. 

![Version Control][version_control]

### Configuración necesaria para exportar para publicar en Play Store de Google

Para publicar una aplicación en Google Play Store, es necesario crear un archivo .aab con unas características específicas. A continuación mostramos como configurar Unity para generar este archivo.

* File -> Build Settings -> seleccionar "**Build App Bundle (Google Play)**".

![App Bundle][aab]

* File -> Build Settings -> **Player Settings**.

![Player Settings][player_settings]
  
Se nos abre una ventana en la que en la columna izquierda seleccionaremos "**Player**", y a la derecha "**Other Settings**". Es este menú tendremos que fijarnos en dos cosas:

![Other Settings][other_settings]

* Configurar la exportación de la **app** en **64 bits**: Configuration -> Target Architectures -> **ARM64**.

![64 bits][arm64]

* Tener en cuenta **versión del bundle**: Identification -> **Bundle Version Code**.

![Bundle Version Code][bundle_version]

Es importante diferenciar entre "bundle version code" y "version" porque si intentas subir un nuevo bundle a Google Play Console, debes asegurarte de que número del "bundle version code" no coincide con ningún bundle subido anteriormente.

## Crear cuenta de desarrollador

Podemos crear nuestra cuenta de desarrollador [aquí][google_console].

Necesitaremos iniciar sesicón con una cuenta de google, que se vinculará a nuestra cuenta de desarrollador.

Rellenaremos los campos de datos personales y aceptaremos los términos y condiciones antes de que nos redirijan a la ventana de pago.

Para registrarnos como desarrolladores es necesario hacer un pago único de 25$.

Una vez realizado el pago podremos empezar con el proceso de registro de nuestra app.

## Registro de la aplicación

En la web de [Google Play Console][google_console], desplegamos el menú lateral izquierdo y seleccionanmos "Todas las aplicaciones". Después clicamos el botón azul "Crear aplicación".

![Crear aplicación][crear_app]

En la siguiente pantalla nos encontraremos un formulario con campos de información general de nuestra aplicación, además de unas declaraciones que tendremos que aceptar antes de seguir con el registro.

![Detalles aplicación][detalles_app]
![Declaraciones][declaraciones]

Cubiertos estos datos, pulsamos en el botón azul "**Crear aplicación**" situado en la parte inferior derecha de la pantalla.

## Configuración de la aplicación

En el menu lateral izquierdo, seleccionamos "Panel de control", y aquí nos vamos a la sección "**configura tu aplicación**".

![Configuración][config]

Deplegamos el menu de tareas y vamos completando una a una.

En el apartado de "**Contenido y audiencia objetivo**", si queremos seleccionar una audiencia **menor de 13 años**, necesitaremos añadir una **política de privacidad**. Para ello, seleccionamos "Contenido de la aplicación" en el panel lateral izquierdo, y ahí nos mostrará la opción necesaria para crear nuestra política de privacidad.

![Política de privacidad][privacidad]


## Publica tu aplicación

Primero deberemos seleccionar en que países queremos que esté disponible.

Después seleccionamos crear un **nuevo lanzamiento**.

![Crear lanzamiento][lanzamiento]

A continuación pulsamos sobre "**crear nueva versión**".

![Crear version][new_version]

Ahora tendremos una nueva pantalla donde subir **bundle** de la aplicación, y un apartado para detalles como el nombre de la versión, y notas de la versión para los usuarios.

![Subir bundle][bundle]

Después de cubrir estos datos, pulsamos el botón azul "Revisar versión", situadio en la esquina inferior derecha de la pantalla.

Si la versión no contiene errores, podremos **publicar** la **versión**.

![Iniciar lanzamiento][start_launch]

Por último tendremos que esperar a la **revisión** por parte de **google** para poder ver nuestra aplicación en el Play Store.

![Revisión de google][review]

[//]: # (Enlaces a imagenes)

[google_console]: https://play.google.com/console/u/0/signup

[toolbar]:/doc/img/config_unity/00_herramientas.png "Barra de herramientas Unity"
[ext_tools]:/doc/img/config_unity/01_ext_tools.png "External tools"
[build_settings]:/doc/img/config_unity/02_build_settings.png "Build settings"
[serialization]:/doc/img/config_unity/03_serialization.png "Serialization"
[version_control]:/doc/img/config_unity/04_vc.png "Version Control"
[aab]:/doc/img/config_unity/05_aab.png "App Bundle"
[player_settings]:/doc/img/config_unity/06_player_settings.png "Player Settings"
[other_settings]:/doc/img/config_unity/07_other_settings.png "Other Settings"
[arm64]:/doc/img/config_unity/08_64.png "Other Settings"
[bundle_version]:/doc/img/config_unity/09_bundle_version.png "Bundle Version Code"

[crear_app]:/doc/img/registro_app/00_crear_app.png "Crear aplicación"
[detalles_app]:/doc/img/registro_app/01_detalles_app.png "Detalles aplicación"
[declaraciones]:/doc/img/registro_app/02_declaraciones.png "Declaraciones"
[config]:/doc/img/registro_app/03_configuracion_app.png "Configuración"
[config_tareas]:/doc/img/registro_app/04_config_tareas.png "Tareas de Configuración"
[privacidad]:/doc/img/registro_app/05_crear_privacidad.png "Política de privacidad"
[lanzamiento]:/doc/img/registro_app/06_crear_lanzamiento.png "Crear lanzamiento"
[new_version]:/doc/img/registro_app/07_crear_nueva_version.png "Crear nueva versión"
[bundle]:/doc/img/registro_app/08_bundle.png "Subir bundle"
[start_launch]:/doc/img/registro_app/09_iniciar_lanzamiento.png "Iniciar lanzamiento"
[review]:/doc/img/registro_app/10_revision.png "Revisión google"
