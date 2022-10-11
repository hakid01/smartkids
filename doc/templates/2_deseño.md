# Fase de diseño

## Planificación del proyecto 

La planificación de las tareas del proyecto y la duración de cada una de ellas, se ha realizado con la ayuda del programa [Project Libre][project].

A continuación se muestra el resultado de la planificación en forma de diagrama de Gantt.

![Diagrama de Gantt][gantt].

## Casos de uso

![Diagrama de casos de uso][casos_uso]

## Deseño de interfaz de usuario

Antes de empezar el desarrollo del código de la aplicación, desde mi punto de vista, se debe tener muy claro los objetivos y funcionalidades que se quieren implementar. Personalmente lo que más me ayuda a tener todo claro y bien organizado es realizar el diseño de la interfaz de usuario lo más completo posible, imaginando que hace cada botón, y como los usuarios pueden recorrer toda la aplicación.

Para ello empiezo eligiendo una **paleta de colores** que me parezca acorde con el resultado que busco en función del público objetivo. Después empiezo con el diseño de la **pantalla principal** y todos sus elementos (correspondientes a la funcionalidades que queremos implementar o que nos llevan a zonas donde podemos acceder a ellas). A partir de aquí imagino que haría cada botón, si me llevaría a una **pantalla nueva**, si sería mejor un **desplegable**, etc. Y así voy desarrollando, sin escribir aún nada de código, toda la aplicación.

A continuación muestro todos estos elementos que me ayudan a la hora de organizarme (y escribir código modular) y no olvidar ninguna funcionalidad.

### Paleta de colores

![Paleta de colores][paleta]

### Imagenes de los avatares disponibles

La siguiente imagen muestra los **8 avatares** y los **8 colores** disponibles para elegir en el menú de configuración de perfil. 

Las imágenes y los colores se pueden mezclar al gusto del usuario.

![Avatares disponibles][avatar]

### Mockups de las pantallas de la aplicación

![Pantallas de la app][screens]

### Tipografías utilizadas

* [Fira Code][fira_code]
* [Balsamiq Sans][balsamiq]
* [Luckiest Guy][luckiest_guy]

### Explicación del uso de la interfaz de usuario

Para la comprensión del uso de la interfaz de usuario, se recomienda leer el [Manual de usuario][doc_manual].

En la siguiente imagen se muestra un esquema-resumen de las funcionalidades que tiene la aplicación.

![Resumen][resumen]

## Diagrama de Base de Datos

Se trata de una aplicación que prácticamente no recoge datos. Los únicos datos que se guardan son los de configuración de cada perfil creado por los usuarios (hasta un máximo de 6 perfiles). Estos perfiles contienen datos como ajustes de volumen, nombre, avatar y juegos seleccionados.

Para el guardado y la posterior carga de los datos se utiliza un archivo JSON. Las siguientes imagenes muestran dos archivos de guardado, el de la izquierda con datos de usuarios, el de la derecha con los datos que se crean por defecto cuando no existe el JSON o si el archivo no se puede abrir correctamente.

![datos guardados][data] ![datos por defecto][data_default]

La **estructura** del archivo **JSON** donde se guardan los datos de configuración es la siguiente:

* Se guarda un **array** con los **6 perfiles** disponibles.
* **Cada perfil** tiene los siguientes datos:
  * *_nickname*: string
  * *_avatar*: string (hace referencia a un sprite guardado en la carpeta Resources)
  * *_color*: objeto que contiene 4 float (r, g, b, a), cuyo valor oscila entre 0 y 1.
  * *_sfxVolume*: float, valor entre 0 y 1.
  * *_musicVolume*: float, valor entre 0 y 1.
  * *_blockedGames*: array de strings, cada string representa un juego.
  * *_isSelected*: bool, indica cual es el perfil seleccionado.

[//]: # (Enlaces a documentos)

[doc_manual]:doc/templates/4_manual_usuario.md

[//]: # (Enlaces a imagenes)

[gantt]:/doc/img/gantt.png

[casos_uso]:doc/img/diseno/casos_uso.png "Diagrama de casos de uso"

[paleta]:doc/img/diseno/paleta.png "Paleta de colores"

[avatar]:doc/img/diseno/avatares.png "Avatares disponibles"

[screens]:doc/img/diseno/screens.png "Pantallas de la app"

[resumen]:doc/img/mockups/resumen.png "Resumen"

[data]:doc/img/diseno/json_ejemplo.png "JSON datos guardados"
[data_default]:doc/img/diseno/json_default.png "JSON datos por defecto"

[//]: # (Enlaces a tipografías)

[fira_code]:https://fonts.google.com/specimen/Fira+Code
[balsamiq]:https://fonts.google.com/specimen/Balsamiq+Sans
[luckiest_guy]:https://fonts.google.com/specimen/Luckiest+Guy