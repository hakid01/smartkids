# Proyecto fin de ciclo

![Smart Kids][smartkids]

## Descripción

Aplicación android **gratuita** desarrollada con Unity.

Esta aplicación consta de varios **minijuegos** orientados a que los más pequeños puedan aprovechar el uso de las nuevas tecnologías para seguir desarrollandose en aspectos como la **escritura**, el **cálculo** o la **lógica**. 

Hay disponibles 6 perfiles para configurar de forma totalmente independiente. En ellos podremos selección un *nickname*, un *avatar* y un *color* para el avatar. Además el control de *volumen* va asocioado a cada perfil.

Se da la posibilidad de seleccionar, de entre todos los juegos disponibles, aquellos que se consideren más interesantes para cada niña o niño. Después de esta selección, en la pantalla de juegos solo se mostrarán los juegos que sean de su interés.

Desde el primer momento están disponibles todos los juegos, sin que sea necesario superar o completar unos para conseguir el acceso a los demás.

## Instalación / Puesta en marcha

La aplicación estará disponible en el Play Store, por lo que simplemente hay que buscarla y hacer click en instalar.

**Busqueda** en Google Play Store:

![Buscar aplicación][buscar]  

**Instalación**:

![Instalar aplicación][instalar]

## Uso

En la siguiente imagen se muestra un esquema-resumen de las funcionalidades que tiene la aplicación.

![Resumen][resumen]

Para una mayor comprensión del uso de la interfaz de usuario, se recomienda leer el [Manual de usuario][doc_manual].

## Sobre el autor

Me llamo Eri, soy ingeriero de caminos y actualmente me encuentro envuelto en un proceso de reconversión hacia un perfil profesional de desarrollo de software. 

Me encantan los retos y aprender cosas nuevas, me llama mucho la idea de enfocarme en el desarrollo blockchain. 

Me adapto bien tanto a situaciones de trabajo en equipo como a trabajo individual. 

Busco mejorar día a día tanto a nivel personal como profesional. 

## Índice

1. [Idea][doc_idea]
2. [Diseño][doc_deseño]
3. [Implantación][doc_implantacion]
4. [Manual de usuario][doc_manual]
5. [Despliegue][doc_despliegue]
6. [Política de privacidad][doc_privacidad]

## Guía de contribución

### Añadir juego nuevo

La forma más sencilla de contribuir en este proyecto es crear nuevos juegos para que el catálogo disponible incremente de forma progresiva. 

Pasos a seguir:

1. Crear escena nueva. En ella desarrollaremos el minijuego.
2. Añadir la nueva escena en el menu File > Build Settings > Scenes in Build. (Drag and drop).
3. Crear nuevo ScriptableObject de la clase GamesData en Resourcer/ScriptableObjects.
4. Crear un sprite para la portada del juego y añadirlo en Sprites/Games.
5. Asignar el sprite al campo Game Sprite del ScriptableObject.
6. Escribir el nombre del juego, y el nombre de la escena en los campos Game Name y Scene Name del ScriptableObject.

Con estos pasos, al lanzar el juego ya se podría acceder al nuevo minijuego desde la pantalla de games. También estará disponible en la pantalla de bloqueo de juegos.

### Diseño de la interfaz de usuario

Rediseño de elementos de la interfaz gráfica como los botones, los avatares, los sprites de los botones de cada juego, la imagen inicial de Smart Kids, etc.

### Música y sonidos

Aporte de música y efectos de sonido para botones, eventos de fallo, eventos de acierto, etc.

## Links

Recopilación de documentación y recursos empleados durante el desarrollo del proyecto.

### Software

* Motor de videojuegos: [Unity][unity]
* Diseño: [Affinity Designer][affinity]
* Planificación: [Project Libre][project]
* Emulador android: [LDPlayer][ldplayer]

### Documentación oficial

* [C#][doc_c#]
* [Visual Studio][visual_studio]
* [Unity Scripting API][unity_doc]

### Recursos

* [Soft Mask for GUI][ui_soft_mask].
* Música: [Amigos para Siempre][music] de [FiftySouns][fiftysounds].
* Tipografías: 
  * [Fira Code][fira_code]
  * [Balsamiq Sans][balsamiq]
  * [Luckiest Guy][luckiest_guy]

### Canales de YouTube

* [Coco Code][coco]
* [Indierama][indierama]
* [SpeedTutor][speedtutor]
* [Unity Institute][unityinstitute]
* [Brackeys][brackeys]
* [Zotov][zotov]


[//]: # (Enlaces a documentos)

[doc_idea]:doc/templates/1_idea.md
[doc_deseño]:doc/templates/2_deseño.md
[doc_implantacion]:doc/templates/3_implantacion.md
[doc_manual]:doc/templates/4_manual_usuario.md
[doc_despliegue]:doc/templates/5_despliegue.md
[doc_privacidad]:doc/templates/6_politica_privacidad.md

[//]: # (Software utilizado)

[unity]:https://unity.com
[affinity]:https://affinity.serif.com
[project]:https://www.projectlibre.com
[ldplayer]:https://es.ldplayer.net
 
[//]: # (Recursos)

[ui_soft_mask]:https://github.com/mob-sakai/SoftMaskForUGUI.git
[music]:https://www.fiftysounds.com/es/musica-libre-de-derechos/amigos-para-siempre.html
[fiftysounds]:https://www.fiftysounds.com
[fira_code]:https://fonts.google.com/specimen/Fira+Code
[balsamiq]:https://fonts.google.com/specimen/Balsamiq+Sans
[luckiest_guy]:https://fonts.google.com/specimen/Luckiest+Guy

[//]: # (Canales de youtube)

[coco]: https://www.youtube.com/c/CocoCode
[indierama]: https://www.youtube.com/c/Indierama
[speedtutor]: https://www.youtube.com/c/SpeedTutor
[unityinstitute]: https://www.youtube.com/c/UnityInstitute
[brackeys]: https://www.youtube.com/c/Brackeys
[zotov]: https://www.youtube.com/c/AlexanderZotov

[//]: # (Documentación)

[doc_c#]:https://docs.microsoft.com/es-es/dotnet/csharp/
[visual_studio]:https://docs.microsoft.com/es-es/visualstudio/ide/
[unity_doc]:https://docs.unity3d.com/ScriptReference/index.html

[smartkids]:doc/img/smartkids.png "Smart Kids"
[resumen]:doc/img/mockups/resumen.png "Resumen"
[buscar]:doc/img/buscar.png "Buscar aplicación"
[instalar]:doc/img/instalar.png "Instalar aplicación"