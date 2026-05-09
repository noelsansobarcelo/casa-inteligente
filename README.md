# Casa Inteligente — Soluciones de referencia

Repositorio con las soluciones de referencia del proyecto **Casa Inteligente** (DomòticaMallorca S.L.), desarrollado como hilo conductor del módulo **Programación (0485)** del 1.er curso del CFGS en Desarrollo de Aplicaciones Multiplataforma.

> **Uso interno del docente.** Este código no se comparte con el alumnado antes de las actividades; su finalidad es la corrección y la evaluación.

---

## Estructura del repositorio

```
casa-inteligente/
├── ud3-sprint1/            ← UD 3: Fundamentos de POO
│   └── CasaInteligente/
│       ├── Sensor.cs
│       ├── Luz.cs
│       ├── Termostato.cs
│       ├── Utilidades.cs
│       └── Program.cs
├── ud4-code-review/        ← UD 4: POO Avanzada y Refactorización
│   └── CasaInteligente/
│       ├── IControlable.cs
│       ├── DispositivoDomotico.cs
│       ├── Sensor.cs
│       ├── Luz.cs
│       ├── Termostato.cs
│       ├── PersianaMotoizada.cs
│       ├── PanelDeControl.cs
│       └── Program.cs
└── docs/
    ├── uml-ud3.md
    └── uml-ud4.md
```

---

## Diagrama UML — UD 3: El Prototipo Rígido

Arquitectura plana sin herencia. Cada clase es independiente; la interacción se produce cuando `Termostato` recibe un objeto `Sensor` en su método `Regular()`.

```mermaid
classDiagram
    class Sensor {
        -string tipo
        -string ubicacion
        -double valorActual
        -bool activo
        +Tipo : string
        +Ubicacion : string
        +ValorActual : double
        +Activo : bool
        +Sensor(tipo, ubicacion, valorInicial)
        +Sensor(tipo)
        +Leer() double
        +Activar() void
        +Desactivar() void
        +ObtenerEstado() string
    }

    class Luz {
        -string nombre
        -string ubicacion
        -int intensidad
        -bool encendida
        +Nombre : string
        +Ubicacion : string
        +Intensidad : int
        +Encendida : bool
        +Luz(nombre, ubicacion, intensidad)
        +Encender() void
        +Apagar() void
        +ObtenerEstado() string
    }

    class Termostato {
        -string ubicacion
        -double temperaturaObjetivo
        -bool calefaccionActiva
        +Ubicacion : string
        +TemperaturaObjetivo : double
        +CalefaccionActiva : bool
        +Termostato(ubicacion, tempObjetivo)
        +Regular(Sensor) void
        +ObtenerEstado() string
    }

    class Utilidades {
        <<static>>
        +CelsiusAFahrenheit(double) double
        +FahrenheitACelsius(double) double
        +LuxAPorcentaje(double) int
    }

    Termostato ..> Sensor : usa
```

---

## Diagrama UML — UD 4: La Evolución Flexible

Arquitectura refactorizada con herencia, clase abstracta, interfaz y polimorfismo. `Sensor` hereda pero no implementa `IControlable` (decisión de diseño coherente: un sensor no se "enciende"). `PanelDeControl` opera polimórficamente sobre cualquier `IControlable`.

```mermaid
classDiagram
    class IControlable {
        <<interface>>
        +Encender() void
        +Apagar() void
        +EstaEncendido() bool
    }

    class DispositivoDomotico {
        <<abstract>>
        #string nombre
        #string ubicacion
        #bool activo
        +Nombre : string
        +Ubicacion : string
        +Activo : bool
        #DispositivoDomotico(nombre, ubicacion)
        +ObtenerEstado() string*
        +RealizarAccion() void
    }

    class Sensor {
        -double valorActual
        -string unidad
        +ValorActual : double
        +Unidad : string
        +Sensor(nombre, ubicacion, valor, unidad)
        +Leer() double
        +ObtenerEstado() string
    }

    class Luz {
        -int intensidad
        -bool encendida
        +Intensidad : int
        +Luz(nombre, ubicacion, intensidad)
        +Encender() void
        +Apagar() void
        +EstaEncendido() bool
        +ObtenerEstado() string
    }

    class Termostato {
        -double temperaturaObjetivo
        -bool calefaccionActiva
        +TemperaturaObjetivo : double
        +Termostato(nombre, ubicacion, tempObj)
        +Encender() void
        +Apagar() void
        +EstaEncendido() bool
        +Regular(Sensor) void
        +ObtenerEstado() string
    }

    class PersianaMotoizada {
        -int porcentajeApertura
        -bool motorActivo
        +PorcentajeApertura : int
        +PersianaMotoizada(nombre, ubicacion)
        +Encender() void
        +Apagar() void
        +EstaEncendido() bool
        +ObtenerEstado() string
    }

    class PanelDeControl {
        -List~IControlable~ dispositivos
        +PanelDeControl()
        +Registrar(IControlable) void
        +EncenderTodos() void
        +ApagarTodos() void
        +MostrarEstado() void
    }

    DispositivoDomotico <|-- Sensor
    DispositivoDomotico <|-- Luz
    DispositivoDomotico <|-- Termostato
    DispositivoDomotico <|-- PersianaMotoizada
    IControlable <|.. Luz
    IControlable <|.. Termostato
    IControlable <|.. PersianaMotoizada
    PanelDeControl o-- IControlable : gestiona
    Termostato ..> Sensor : consulta
```

---

## Salida esperada por consola

### UD 3

```
=== ESTADO DEL SISTEMA ===
[Temperatura] Salón: 23 (ACTIVO)
[Temperatura] Dormitorio: 21 (ACTIVO)
[Humedad] Jardín: 65 (ACTIVO)
[Movimiento] Sin asignar: 0 (ACTIVO)
[Luz] Principal (Salón): ENCENDIDA al 80%
[Luz] Exterior (Jardín): ENCENDIDA al 50%
[Termostato] Salón: Objetivo 22 C (EN ESPERA)
Temperatura salón: 73,4 F
```

### UD 4

```
=== ENCENDIENDO TODOS LOS DISPOSITIVOS ===
[Luz] Principal (Salón): ENCENDIDA al 80%
[Luz] Exterior (Jardín): ENCENDIDA al 50%
[Termostato] Calefacción (Salón): Obj. 22 C (CALENTANDO)
[Persiana] Veneciana (Salón): 100% abierta

=== REGULANDO TERMOSTATO ===
[Termostato] Calefacción (Salón): Obj. 22 C (CALENTANDO)

=== ESTADO DE SENSORES ===
[Sensor] Temp. Salón (Salón): 19,5 °C
[Sensor] Humedad (Jardín): 65 %

=== APAGANDO TODO ===
[Luz] Principal (Salón): APAGADA
[Luz] Exterior (Jardín): APAGADA
[Termostato] Calefacción (Salón): Obj. 22 C (EN ESPERA)
[Persiana] Veneciana (Salón): 0% abierta
```

---

## Evolución entre UD 3 y UD 4

| Aspecto | UD 3 (Prototipo Rígido) | UD 4 (Evolución Flexible) |
|---|---|---|
| Herencia | No hay. Clases independientes. | `DispositivoDomotico` como superclase abstracta. |
| Interfaces | No hay. | `IControlable` define el contrato de actuadores. |
| Polimorfismo | No hay. Cada objeto se gestiona individualmente. | `PanelDeControl` opera sobre `List<IControlable>`. |
| Extensibilidad | Añadir un dispositivo obliga a modificar `Program`. | `PersianaMotoizada` se añade sin tocar código existente. |
| Control de versiones | Google Workspace. | GitHub con flujo GitHub Flow (ramas, PR, Code Review). |

---

## Tecnologías

- **Lenguaje:** C# (.NET)
- **IDE:** Visual Studio / Visual Studio Code
- **Modelado UML:** Draw.io / Mermaid
- **Control de versiones:** Git + GitHub

---

## Licencia

Material didáctico de uso interno. CIFP Francesc de Borja Moll, Palma de Mallorca.

---

Autor: [Noel Sansó](https://github.com/noelsansobarcelo)
