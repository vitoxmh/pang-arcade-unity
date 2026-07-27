# Pang - Arcade Unity

Recreación del clásico juego de arcade **Pang** (también conocido como *Buster Bros.*) desarrollado en **Unity 2019.4 LTS**. El jugador navega por plataformas y escaleras, disparando hacia arriba con flechas, anzuelos o pistolas para explotar pelotas rebotantes que se dividen en pelotas más pequeñas al ser impactadas.

---

## Tabla de contenidos

- [Características](#características)
- [Requisitos](#requisitos)
- [Instalación](#instalación)
- [Jugar](#jugar)
- [Controles](#controles)
- [Estructura del proyecto](#estructura-del-proyecto)
- [Flujo del juego](#flujo-del-juego)
- [Sistema de armas](#sistema-de-armas)
- [Power-ups](#power-ups)
- [Sistema de puntuación](#sistema-de-puntuación)
- [Arquitectura del código](#arquitectura-del-código)
- [Scripts principales](#scripts-principales)
- [Configuración](#configuración)
- [Known Issues](#known-issues)
- [Changelog](#changelog)
- [Créditos](#créditos)

---

## Características

- **39 niveles de juego** organizados en 13 países con 3 etapas cada uno
- **Sistema de mapa mundial** con transiciones animadas entre países (avión)
- **3 tipos de armas**: Cadena (Flecha), Anzuelo y Pistola (Bala)
- **4 tamaños de pelotas** que se dividen al ser impactadas, con rebotes naturales y variados
- **8 tipos de power-ups**: Escudo, Reloj (congelar), Reloj de arena (ralentizar), Dinamita (destruir todas), Vida extra, Cambio de arma
- **Sistema de combos** de puntuación (hasta 15x combo)
- **Sistema de monedas/créditos** estilo arcade (insertar moneda para jugar)
- **Pantalla de continue** con cuenta regresiva
- **Hi-Score** persistente guardado con PlayerPrefs
- **Música temática** por ubicación real (Monte Fuji, Barcelona, Templo Esmeralda, Angkor Wat, Australia, Taj Mahal, Leningrado, París, Londres)
- **Efectos de sonido** para explosiones, disparos, recogida de items, etc.
- **Animaciones** de personaje, pelotas, transiciones de escena e items

---

## Requisitos

| Componente | Versión mínima |
|---|---|
| **Unity Editor** | 2019.4.12f1 (LTS) |
| **.NET Framework** | 4.7.1 |
| **.NET Standard** | 2.0 |
| **Plataforma** | Windows (Standalone) |

### Paquetes de Unity requeridos

- `com.unity.2d.animation` 5.0.5
- `com.unity.2d.pixel-perfect` 4.0.1
- `com.unity.2d.sprite` 1.0.0
- `com.unity.2d.spriteshape` 5.1.2
- `com.unity.2d.tilemap` 1.0.0
- `com.unity.textmeshpro` 3.0.6
- `com.unity.timeline` 1.4.8
- `com.unity.test-framework` 1.1.26
- `com.unity.ugui` 1.0.0

---

## Instalación

1. Clona el repositorio:

```bash
git clone https://github.com/vitoxmh/pang-arcade-unity.git
```

2. Abre el proyecto con **Unity 2019.4.12f1** o superior.

3. Si Unity te solicita actualizar los paquetes o la versión del editor, acepta la actualización.

4. Una vez cargado el proyecto, abre la escena inicial:
   ```
   Assets/Scenes/Start.unity
   ```

---

## Jugar

1. Abre el proyecto en el editor de Unity.
2. Abre la escena `Assets/Scenes/Start.unity`.
3. Pulsa el botón **Play** en el editor.
4. Presiona **F5** para insertar moneda (crédito).
5. Presiona **Enter** para comenzar.

También puedes construir el ejecutable desde **File > Build Settings** seleccionando la plataforma **Windows Standalone**.

---

## Controles

| Acción | Tecla |
|---|---|
| Mover izquierda | Flecha izquierda |
| Mover derecha | Flecha derecha |
| Subir escalera | Flecha arriba |
| Bajar escalera | Flecha abajo |
| Disparar | **E** |
| Insertar moneda (debug) | **F5** |
| Iniciar juego / Confirmar | **Enter** |
| Selección en mapa | Flechas izquierda/derecha |

---

## Estructura del proyecto

```
pang-unity/
├── Assets/
│   ├── Animation/              # Controladores y clips de animación
│   │   ├── Arm/                #   Animaciones de armas
│   │   ├── Ball/               #   Animaciones de explosión de pelotas
│   │   ├── ChangeStage/        #   Animaciones de transición de etapa
│   │   ├── Inicio/             #   Animaciones de pantalla de inicio
│   │   ├── Item/               #   Animaciones de power-ups
│   │   ├── Map/                #   Animaciones del mapa
│   │   ├── player/             #   Animaciones del jugador
│   │   └── Stage/              #   Animaciones de etapa
│   ├── Fonts/                  # Fuentes estilo arcade (ARCADE_I, ARCADE_N, ARCADE_R, Digital)
│   ├── Mask/                   # Máscaras de sprite
│   ├── Materials/              # Materiales de física (Ball, plataformas) y fondo
│   ├── Music/                  # 17 pistas de música (MP3)
│   ├── Prefabs/                # Prefabs del juego
│   │   ├── Arms/               #   Prefabs de armas (Arrow, Hook, bullet, explosiones)
│   │   ├── Balls/              #   Prefabs de pelotas (Azul, Verde, Rojo)
│   │   ├── DontDeestroy/       #   Objetos persistentes entre escenas
│   │   ├── Item/               #   Prefabs de power-ups (8 tipos)
│   │   ├── Manager/            #   Prefabs de sistemas de gestión (10 managers)
│   │   ├── Stage/              #   Prefabs de elementos de escena (bloques, escaleras, plataformas)
│   │   └── UI/                 #   Prefabs de interfaz (Continue, GameOver, Ready, Lifes)
│   ├── Resources/              # Recursos cargados en tiempo de ejecución
│   │   └── Sprites/            #   Sprites de flechas, pelotas, jugador, estrellas
│   ├── Scenes/                 # 50 escenas de Unity
│   │   ├── Base/               #   Escenas plantilla
│   │   ├── Start.unity         #   Pantalla de título
│   │   ├── Map.unity           #   Mapa mundial
│   │   ├── MapChange.unity     #   Transición entre países
│   │   ├── ChangeStage.unity   #   Transición entre etapas
│   │   ├── End.unity           #   Pantalla de fin
│   │   ├── Selection.unity     #   Pantalla de selección
│   │   └── 1-1.unity ~ 13-39.unity  # 39 escenas de juego
│   ├── Script/                 # Scripts C# del juego (42 archivos)
│   │   ├── Manager/            #   Scripts de gestión (Singletons)
│   │   ├── Stage/              #   Lógica de escenarios
│   │   ├── Start/              #   Scripts de pantalla de inicio
│   │   ├── ChangeStage/        #   Scripts de transición de etapa
│   │   ├── Map/                #   Scripts del sistema de mapa
│   │   ├── arm/                #   Scripts de sistema de armas
│   │   └── poweUp/             #   Scripts de power-ups
│   ├── Sound/                  # 16 efectos de sonido (MP3/WAV)
│   └── sprite/                 # Assets de sprite adicionales
├── Packages/                   # Configuración del Package Manager
│   ├── manifest.json           #   Dependencias de paquetes
│   └── packages-lock.json      #   Versiones bloqueadas
├── ProjectSettings/            # Configuración del proyecto Unity
├── pang-unity.sln              # Archivo de solución Visual Studio
└── Assembly-CSharp.csproj      # Archivo de proyecto C#
```

---

## Flujo del juego

```
┌──────────────┐
│  Start.unity │  ← Pantalla de título (insertar moneda + PUSH START)
└──────┬───────┘
       │ Enter
       ▼
┌──────────────┐
│  Map.unity   │  ← Mapa mundial (seleccionar país con flechas)
└──────┬───────┘
       │ Seleccionar país
       ▼
┌──────────────┐
│  X-Y.unity   │  ← Nivel de juego (ej: 1-1, 2-5, 13-39)
└──────┬───────┘
       │
       ├──▶ Etapa completada
       │
       ▼
┌──────────────────┐
│  ChangeStage.unity│  ← Bonus de etapa (bonus pelotas + bonus tiempo)
└──────┬───────────┘
       │
       ├──▶ Siguiente etapa del mismo país → vuelve a X-Y.unity
       │
       └──▶ Última etapa del país
            │
            ▼
       ┌────────────────┐
       │ MapChange.unity │  ← Transición animada (avión) a siguiente país
       └───────┬────────┘
               │
               └──▶ vuelve a Map.unity (siguiente país desbloqueado)

       ── Si el jugador pierde todas las vidas ──▶ Game Over → Start.unity
       ── Si completa los 13 países ──────────────▶ End.unity (pantalla final)
```

---

## Sistema de armas

| Arma | Descripción | Comportamiento |
|---|---|---|
| **Flecha (Arrow)** | Cadena que sube | Sube en línea recta, se retira al llegar al tope. Genera eslabones de cadena animados. |
| **Anzuelo (Hook)** | Cadena con ancla | Sube y se engancha al techo con animación de ancla. Genera puntuación por cada pelota impactada. |
| **Pistola (Gun)** | Bala disparada | Proyectil que sube y se destruye al impactar. |

El arma actual se rastrea mediante el singleton `CurrentShotItem` y se puede cambiar mediante power-ups de tipo `typeArms`.

---

## Power-ups

Los power-ups aparecen al destruir bloques destructibles o al recoger items que caen de las pelotas.

| Item | Efecto |
|---|---|
| **Cambio de arma** | Cambia el tipo de arma actual (Flecha ↔ Anzuelo ↔ Pistola) |
| **Dinamita** | Destruye todas las pelotas en pantalla |
| **Reloj (Freeze)** | Congela todas las pelotas temporalmente |
| **Reloj de arena (Slow)** | Ralentiza el movimiento de todas las pelotas |
| **Vida extra** | Otorga una vida adicional al jugador |
| **Escudo** | Protege al jugador: se destruye al contactar con una pelota |
| **Contador de disparos** | Aumenta la cantidad de disparos simultáneos permitidos |

---

## Sistema de puntuación

- **Combo**: Cada pelota destruida sin que el jugador toque el suelo incrementa el multiplicador de combo (hasta **15x**).
- Al tocar el suelo, el combo se reinicia.
- **Bonus de etapa**: Al completar una etapa se calcula:
  - **Bonus de pelotas**: Pelotas restantes en pantalla
  - **Bonus de tiempo**: Tiempo restante en el reloj
- **Hi-Score**: Se guarda de forma persistente usando `PlayerPrefs` con la clave `"hi"`.

---

## Arquitectura del código

El proyecto sigue un patrón **Singleton** extensamente. Cada manager es accesible globalmente a través de una estática `Instance`.

### Managers persistentes (DontDestroyOnLoad)

| Manager | Clase | Propósito |
|---|---|---|
| `ConfigGame` | `ConfigGame` | Configuración global: vidas, nombres de etapas y países |
| `MusicManager` | `MusicManager` | Reproducción de música de fondo (16 pistas) |
| `SoundManager` | `SoundManager` | Reproducción de efectos de sonido (13 efectos) |
| `ManagerCoin` | `ManagerCoin` | Sistema de monedas/créditos estilo arcade |
| `PlayManager` | `PlayManager` | Rastreo de si el juego está activo |

### Managers por escena

| Manager | Clase | Propósito |
|---|---|---|
| `GameManager` | `GameManager` | Bucle principal: tiempo, inicio/fin de etapa, congelar/descongelar, respawn |
| `BallManager` | `BallManager` | Control de pelotas: congelar, ralentizar, destruir todas |
| `LifeManager` | `LifeManager` | Sistema de vidas, continue con cuenta regresiva, game over |
| `ManagerScore` | `ManagerScore` | Puntuación, sistema de combo, hi-score |
| `ManagerStage` | `ManagerStage` | Progresión de etapas, array de nombres de etapas |
| `ItemManager` | `ItemManager` | Generación de power-ups (específicos o aleatorios) |
| `MapManager` | `MapManager` | Mapa mundial, selección de país, temporizador |

---

## Scripts principales

### Núcleo del juego

| Archivo | Clase | Descripción |
|---|---|---|
| `Assets/Script/Manager/GameManager.cs` | `GameManager` | Controla el bucle principal del juego |
| `Assets/Script/Manager/PlayerController.cs` | `PlayerController` | Movimiento, disparo, colisiones y muerte del jugador |
| `Assets/Script/Ball.cs` | `Ball` | Comportamiento de pelotas: movimiento, rebote mejorado con variación aleatoria, división, estados |
| `Assets/Script/ConfigGame.cs` | `ConfigGame` | Configuración global del juego |
| `Assets/Script/Manager/MusicManager.cs` | `MusicManager` | Sistema de audio musical |
| `Assets/Script/Manager/SoundManager.cs` | `SoundManager` | Sistema de efectos de sonido |

### Armas

| Archivo | Clase | Descripción |
|---|---|---|
| `Assets/Script/arm.cs` | `arm` | Cadena/flecha: movimiento ascendente, eslabones |
| `Assets/Script/arm/chainGancho.cs` | `chainGancho` | Anzuelo con animación de ancla en el techo |
| `Assets/Script/arm/gun.cs` | `gun` | Pistola/bala: proyectil ascendente |
| `Assets/Script/arm/chain.cs` | `chain` | Segmento de cadena: crece hacia abajo |
| `Assets/Script/arm/CurrentShotItem.cs` | `CurrentShotItem` | Rastreo y visualización del arma actual |

### Power-ups

| Archivo | Clase | Descripción |
|---|---|---|
| `Assets/Script/poweUp/item.cs` | `item` | Comportamiento genérico de power-up |
| `Assets/Script/poweUp/typeArms.cs` | `typeArms` | Cambio de tipo de arma al recoger item |
| `Assets/Script/poweUp/shield.cs` | `shield` | Escudo protector: se destruye al impactar con pelota |

### Escenarios y transiciones

| Archivo | Clase | Descripción |
|---|---|---|
| `Assets/Script/Stage/infoStage.cs` | `infoStage` | Configuración por etapa: nombre, país, música, tiempo |
| `Assets/Script/Stage/block.cs` | `block` | Bloque destructible que puede soltar items |
| `Assets/Script/ChangeStage/changeStage.cs` | `changeStage` | Pantalla de etapa completada con bonus |
| `Assets/Script/Map/MapManager.cs` | `MapManager` | Sistema de mapa y selección de país |
| `Assets/Script/Avion.cs` | `Avion` | Transición animada de avión entre países |

### Interfaz y sistema arcade

| Archivo | Clase | Descripción |
|---|---|---|
| `Assets/Script/Start/StarGame.cs` | `StarGame` | Pantalla de título con sistema de monedas |
| `Assets/Script/Manager/LifeManager.cs` | `LifeManager` | Sistema de vidas y continue |
| `Assets/Script/Manager/ManagerScore.cs` | `ManagerScore` | Puntuación y combo |
| `Assets/Script/Manager/ManagerCoin.cs` | `ManagerCoin` | Sistema de monedas/créditos |
| `Assets/Script/Stage/EndGame.cs` | `EndGame` | Pantalla de fin con puntuación final |

---

## Configuración

### Variables globales (`ConfigGame.cs`)

- **Vidas iniciales**: Configurables desde el Inspector de Unity
- **Nombres de etapas**: Array de strings con los 39 nombres de etapas
- **Nombres de países**: Array de strings con los 13 nombres de países

### Configuración por etapa (`infoStage.cs`)

Cada escena de juego tiene un componente `infoStage` configurado con:

- **Nombre de la etapa**: Identificador de la etapa
- **País**: País al que pertenece
- **Música**: Pista de audio reproducida durante la etapa
- **Tiempo**: Límite de tiempo para completar la etapa
- **Fin de país**: Indica si es la última etapa de un país

### Hi-Score

- Se almacena en `PlayerPrefs` con la clave `"hi"`
- Se carga al iniciar y se actualiza cada vez que se supera

---

## Known Issues

- No existe archivo `.gitignore`, por lo que carpetas generadas por Unity (`Library/`, `obj/`, `.vs/`, `UserSettings/`) están rastreadas en el repositorio.
- No existe archivo de licencia.
- No hay tests unitarios implementados a pesar de que el paquete `com.unity.test-framework` está incluido.
- Los comentarios del código y nombres de algunas variables están en español.

---

## Changelog

### Mejoras en el rebote de pelotas (Ball.cs)

El sistema de rebote fue mejorado para ofrecer una experiencia más natural y dinámica:

- **Variación aleatoria en la altura de rebote**: Cada rebote tiene una variación de ±0.3 en la fuerza vertical, evitando trayectorias predecibles y repetitivas.
- **Velocidad horizontal dinámica**: Al rebotar, la velocidad horizontal se ajusta con un boost aleatorio de 0.9x a 1.5x, creando arcos más naturales.
- **Rebote del suelo mejorado**: La velocidad al tocar el suelo pasó de -1.0 a -2.5 (normal) y de -0.5 a -1.5 (slow), haciendo que las bolas se muevan más dinámicamente después de tocar el piso.
- **Caída con variación**: La velocidad de caída también incluye una ligera variación aleatoria.

**Valores de rebote por tamaño de pelota:**

| Tamaño | BallBounce | SpeedBall | Score |
|---|---|---|---|
| 0 (Grande) | 11.5 | 1.0 | 50 |
| 1 | 9.5 | 0.8 | 100 |
| 2 | 7.0 | 0.7 | 150 |
| 3 (Pequeña) | 6.0 | 0.5 | 200 |

**Tags de colisión soportados:** `piso`, `block`, `Wall`, `ladderTop`, `blockVertical`, `arma`, `shield`

---

## Créditos

- **Desarrollador**: [vitoxmh](https://github.com/vitoxmh)
- **Repositorio**: [pang-arcade-unity](https://github.com/vitoxmh/pang-arcade-unity)
- **Juego original**: Pang / Buster Bros. - Kaneko, 1989
- **Motor**: Unity 2019.4.12f1 LTS
- **Lenguaje**: C#
