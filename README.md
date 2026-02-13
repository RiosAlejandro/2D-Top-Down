#Juego 2D top-Down - Portafolio Project

##Overview

    Prototipo 2D desarrollado en Unity como proyecto de portafolio.
    Enfocado en la arquitectura modular, la gestión de escenas (Splash, Menú, Opciones, Intro, Nivel,
    Win) y la implementación de un sistema de interacción desacoplado mediante eventos e interfaces.

##Gameplay Mechanics

    Movimiento del jugador mediante Rigidbody2D.

    Sistema de iluminación dinámica utilizando URP 2D Renderer.

    Linterna direccional controlada según el vector de movimiento.

    Objetos interactuables mediante interfaz IInteractable.

    Condición de victoria al activar todas las lámparas del nivel.

    Gestión de estados del juego (Menú, Gameplay, Victoria).


##Technical Architecture

GameManager

    Implementación del patrón Singletonn
    Control centralizado del estado del juego
    Navegación entre escenas
    Gestión de condición de victoria

IInteractable

    Sistema de interacción basado en interfaz
    Permite agregar nuevos objetos interactuables sin modificar el código del jugador

PlayerController

    Gestión de input (WASD)
    Movimiento físico con Rigidbody2D
    Control de parámetros de animación

FlashLightController

    Control de rotación de Spot Light 2D
    Sincronización con la dirección de movimiento del jugador

PlayerInteraction

    Comunicación desacoplada con objetos interactuables

EnergyCore

    Activación de Spot Light 2D
    Notificación al GameManager mediante evento al encenderse

Controladores de Escena

    SplashController: Control de duración y transición inicial.
    MenuController: Navegación entre escenas (Jugar, Tutorial, Salir).
    TutorialController: Gestión de escena tutorial.
    IntroController: Sistema narrativo con texto progresivo acumulativo.
    WinController: Gestión de pantalla de victoria y transición retardada.


##Render e Iluminación

    Uso de URP 2D Renderer.
    Spot Light 2D para linterna del jugador.
    Global Light 2D para ambientación general.
    Configuración por capas para interacción selectiva de luces.

##Audio Design

Actualmente en desarrollo.

AudioMixer:

    Grupos:

        Music
        SFX

Snapshots:

    Background: .
    Effect: .


##Challenges & Solutions

    Problema: 
    Solución: 

    Problema: 
    Solución: 
    Resultado: 

## Learnings

    


##Controls

    Movimiento Plataforma: A-W-S-D
    Interactuar: E
    Avanzar texto narrativo: Space
