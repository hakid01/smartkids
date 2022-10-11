# Manual de usuario

## Esquema de funcionamiento

![Resumen][resumen]

## Pantalla principal

A continuación vemos una imagen de la pantalla principal del juego.

![Pantalla principal][main_screen]

En esta pantalla podemos diferenciar **2 tipos de botones**:

* Botones que ejecutan una **acción en la misma pantalla**.
  * [Perfiles](#panel-de-gestión-de-perfiles) ![Botón perfiles][btn_perfil]
  * [Ajustes](#panel-de-ajustes-de-volumen) ![Botón ajustes][btn_settings]
  * [Información](#panel-de-información) ![Botón información][btn_info]
  * [Ayuda](#panel-de-ayuda) ![Botón ayuda][btn_help]
  * [Compartir](#panel-para-compartir-la-aplicación) ![Botón compartir][btn_share]

Estos botones despliegan un panel con las opciones correspondientes. Cuando un panel está desplegado solo se podrá interactuar con dicho panel y con el botón que lo activó, que también servirá para cerrarlo.

* Botones que nos hacen **abandonar la pantalla actual**.
  * [Pantalla de juegos](#pantalla-de-selección-de-juego) ![Botón juegos][btn_games]
  * [Pantalla bloqueo de juegos](#pantalla-de-bloqueo-de-juegos) ![Botón de bloqueo][btn_block]
  * Salir ![Botón salir][btn_quit]

### Panel captcha

Hay un panel especial en la aplicación, el panel captcha, que se despliega cuando se intenta acceder al panel de gestión de perfiles, al panel de ajuste de volumen y al panel de bloqueo de juegos. 

Su función es **bloquear** el **acceso** **de** los **niños** a estos paneles. Configurar los perfiles y las diferentes opciones será una tarea que tendrá que realizar otra persona.

El panel captcha consiste en una operación matemática aleatoria sencilla (suma o resta). Si se introduce la respuesta correcta nos lleva al panel deseado, si no, nos devuelve a la pantalla de inicio.

![Panel captcha][captcha]

### Panel de gestión de perfiles

Para acceder al panel de gestión de perfiles pulsaremos el botón ![Botón perfil][btn_perfil].

![Selección de perfiles][perfil_panel]

En el **panel superior** podremos elegir uno de los *6 perfiles* disponibles.

En el **panel inferior** podremos asignarle un *nombre*, un *color* y un *avatar*. En la parte inferior tenemos tres botones. El primero empezando por la izquierda ![Borrar perfil][btn_delete] es el botón de borrar perfil, esto nos cargará de nuevo el perfil por defecto. En la zona de la derecha tenemos los botones de guardar ![Guardar][btn_acept] y cancelar ![Candelar][btn_cancel] los cambios realizados.

### Panel de ajustes de volumen

Para abrir el panel de ajustes de volumen pulsaremos el botón ![Botón ajustes][btn_settings]

![Ajustes de volumen][settings_panel]

Nos encontramos dos sliders, con los que podemos controlar el volumen de la **música** y el volumen de los **efectos de sonido**.

Además tenemos dos botones, uno para aceptar los cambios y el otro para cancelar y cerrar el panel sin guardar estas modificaciones.

### Panel de información

Podemos desplegar el panel de información por medio del botón ![Botón información][btn_info]

Aquí veremos **información** relativa al **proyecto**: el *nombre*, la *versión* y el *autor*.

![Información del proyecto][info_panel]

### Panel de ayuda

Para ver el panel de ayuda haremos click sobre el botón ![Botón ayuda][btn_help]

Este panel nos muestra una pequeña **guía** de como funciona la **aplicación**. De un modo visual y sencillo entenderemos para que sirven cada uno de los botones.

![Ayuda][help_panel]

### Panel para compartir la aplicación

Mediante el botón ![Botón compartir][btn_share] accionaremos la función para compartir la aplicación a traves de nuestras redes sociales.

![Compartir][share_panel]

## Pantalla de bloqueo de juegos

Si pulsamos el botón ![Botón de bloqueo][btn_block] saldremos de la pantalla inicial, y se cargará una pantalla donde visualizaremos todos los juegos que contiene la aplicación. 

Aquí podremos bloquear los **juegos** que queramos que **no** sean **accesibles** para el perfil que esté seleccionado en ese momento. Para bloquear o desbloquear los juegos basta con pulsar sobre la imagen de cada uno de ellos. 

Si la imagen está oscurecida, significa que el juego está bloqueado. Podemos ver un ejemplo en la siguiente imagen.

![Pantalla de bloqueo de juegos][block_panel]

Los **botones** situados en la parte inferior de la pantalla nos permitirán: 

* Bloquear todos los juegos ![Botón bloquear todo][btn_x]
* Desbloquear todos los juegos ![Botón desbloquear todo][btn_reset]
* Volver a la pantalla inicial ![Botón volver][btn_back]

## Pantalla de selección de juego

Accederemos a la pantalla de selección de juego desde la pantalla inicial por medio del botón ![Botón juegos][btn_games]

En ella solo nos aparecerán los **juegos** que **no** estén **bloqueados** en el perfil actual. La siguiente imagen, en convinación con la imagen de la pantalla de bloqueo, nos sirve como ejemplo de este funcionanmiento.

![Pantalla de selección de juego][games_panel]

Pulsaremos sobre una de las imagenes disponibles y accederemos a ese juego.

El botón situado en la parte inferior nos lleva de vuelta a la pantalla inicial.

## Juegos

A todos los juegos se accederán desde la pantalla de selección de juego. Solo se tendrá acceso a los juegos no bloqueados. Cada perfil tendrá disponibles sus propios juegos.

### ABC

Juego para practicar la **escritura** de las **letras** del abecedario.

Dibujaremos líneas arrastrando el dedo sobre la pantalla.

![Juego ABC][abc]

**Partes del juego**:

* **Panel superior**: panel de selección de colores.
* **Panel central**: lienzo donde para dibujar, con sombra de letra para que sirva de guía.
* **Botones inferiores**: 
  * ![Botón volver][btn_cancel] Botón para volver a la pantalla de selección de juego.
  * ![Botón limpiar][btn_reset] Botón para eliminar todas las líneas de la pantalla.
  * ![Botón anterior][btn_back] Botón para ir a la letra anterior.
  * ![Botón selección letra][btn_letter] Botón que abre una panel tipo spinner para seleccionar una letra concreta.
  * ![Botón siguiente][btn_next] Botón para ir a la letra siguiente.

### 123

Juego para practicar la **escritura** de los **números** del 0 al 9. 

Dibujaremos líneas arrastrando el dedo sobre la pantalla.

![Juego 123][123]

**Partes del juego**:

* **Panel superior**: panel de selección de colores.
* **Panel central**: lienzo donde para dibujar, con sombra de letra para que sirva de guía.
* **Botones inferiores**: 
  * ![Botón volver][btn_cancel] Botón para volver a la pantalla de selección de juego.
  * ![Botón limpiar][btn_reset] Botón para eliminar todas las líneas de la pantalla.
  * ![Botón anterior][btn_back] Botón para ir a la letra anterior.
  * ![Botón selección número][btn_numbers] Botón que abre una panel tipo spinner para seleccionar un número concreto.
  * ![Botón siguiente][btn_next] Botón para ir a la letra siguiente.

### Counting

Juego para practicar la asociación de la grafía de un número con un grupo de elementos que represente su valor.

![Juego de contar][counting]

**Partes del juego**:

* **Panel principal**: compuesto por un número en la parte superior y varios botones debajo. Cada botón contiene un número diferente de elementos. 
* **Botones inferiores**: 
  * ![Botón volver][btn_cancel] Botón para volver a la pantalla de selección de juego.
  * ![Botón selección número][btn_numbers2] Botón que abre una panel tipo spinner para seleccionar el número más alto que aparezca para contar. Rango de número máximo disponible 4-9.
  * ![Botón siguiente][btn_next] Botón para generar un nuevo número aleatorio entre el 1 y el número elegido, y los botones correspondientes con una única solución.

**Objetivo**: pulsar el botón que contenga el mismo número de elementos que indica el número de la parte superior. 

Si se pulsa la opción correcta se colorearán los items del botón pulsado de color verde y sonará un sonido de acierto, por el contrario si se pulsa una opción incorrecta se colorearán los items del botón pulsado de color rojo y sonará un sonido de error. Con este efecto buscamos dar **feedback** al usuario para que entienda si ha acertado o no.

[//]: # (Enlaces a imagenes)

[resumen]:doc/img/mockups/resumen.png "Resumen"

[main_screen]:doc/img/mockups/00_pantalla_inicial.png "Pantalla principal"
[captcha]:doc/img/mockups/01_captcha.png "Captcha"
[perfil_panel]:doc/img/mockups/04_perfil.png "Selección de perfiles"
[settings_panel]:doc/img/mockups/05_settings.png "Ajustes de volumen"
[info_panel]:doc/img/mockups/03_info.png "Información del proyecto"
[help_panel]:doc/img/mockups/02_help.png "Ayuda"
[share_panel]:doc/img/mockups/06_share.png "Compartir"

[block_panel]:doc/img/mockups/07_block_games.png "Pantalla de bloqueo de juegos"
[games_panel]:doc/img/mockups/08_games.png "Pantalla de selección de juego"

[abc]:doc/img/mockups/09_abc.png "Juego ABC"
[123]:doc/img/mockups/10_123.png "Juego 123"
[counting]:doc/img/mockups/11_count.png "Juego de contar"

[btn_perfil]:doc/img/mockups/perfil.png "Botón perfiles"
[btn_settings]:doc/img/mockups/settings.png "Botón ajustes"
[btn_info]:doc/img/mockups/info.png "Botón información"
[btn_help]:doc/img/mockups/help.png "Botón ayuda"
[btn_share]:doc/img/mockups/share.png "Botón compartir"

[btn_games]:doc/img/mockups/games.png "Botón juegos"
[btn_block]:doc/img/mockups/block.png "Botón de bloqueo"
[btn_quit]:doc/img/mockups/quit.png "Botón salir"

[btn_acept]:doc/img/mockups/aceptar.png "Botón guardar"
[btn_cancel]:doc/img/mockups/cancelar.png "Botón cancelar"
[btn_delete]:doc/img/mockups/delete.png "Botón eliminar"
[btn_x]:doc/img/mockups/x.png "Botón bloquear todo"
[btn_reset]:doc/img/mockups/reset.png "Botón desbloquear todo"
[btn_back]:doc/img/mockups/back.png "Botón volver"
[btn_next]:doc/img/mockups/next.png "Botón siguiente"
[btn_letter]:doc/img/mockups/letter.png "Botón selección letra"
[btn_numbers]:doc/img/mockups/numbers.png "Botón selección número"
[btn_numbers2]:doc/img/mockups/numbers2.png "Botón selección número"
