# CLAUDE.md

Guía para Claude al trabajar en Comyths, un juego hecho con Godot.

## Contexto

- Motor: Godot 4.5+ con GDScript (no C#, salvo que se pida).
- El repositorio es un único proyecto de Godot; `project.godot` está en la raíz.
- El usuario habla español: responde, comenta y documenta en español. Los identificadores del código van en inglés.

## Convenciones de GDScript

Sigue la [guía de estilo oficial](https://docs.godotengine.org/en/stable/tutorials/scripting/gdscript/gdscript_styleguide.html):

- Indentación con tabulaciones.
- `snake_case` para archivos, funciones y variables; `PascalCase` para `class_name` y nodos; `CONSTANT_CASE` para constantes.
- Tipado estático siempre (`var speed: float = 300.0`, `func jump() -> void:`, `:=` cuando el tipo es obvio).
- Orden dentro de un script: `class_name`, `extends`, doc `##`, señales, enums, constantes, `@export`, variables, `@onready`, métodos built-in (`_ready`, `_process`...), métodos públicos, métodos privados (`_prefijo`).
- Señales en pasado (`died`, `health_changed`).
- Prefiere `@export` para valores ajustables desde el editor en lugar de números mágicos.
- Usa acciones del Input Map (`move_left`, `jump`...) en vez de teclas fijas.

## Escenas y archivos

- Una escena por entidad (`scenes/player.tscn` + `scripts/player.gd`).
- Estado global en `autoload/` y registrado en `project.godot` bajo `[autoload]`.
- Los `.tscn` y `.tres` son texto: edítalos con cuidado y mantén los `id` de recursos consistentes. Si un cambio es complejo, explica cómo hacerlo en el editor.
- No subas `.godot/` ni builds exportados (ya están en `.gitignore`).
- Los binarios (png, wav, ogg, ttf, glb...) van por Git LFS.

## Flujo de trabajo

- Godot no está instalado en el entorno de Claude por defecto: describe cómo probar cada cambio (qué escena abrir, qué tecla pulsar).
- Cambios pequeños y enfocados.
