# Comyths

Videojuego hecho con [Godot 4](https://godotengine.org/) y GDScript.

## Estructura

```
comyths/
├── project.godot     # Proyecto de Godot (ábrelo desde el editor)
├── scenes/           # Escenas .tscn
├── scripts/          # Scripts .gd
├── autoload/         # Singletons globales (GameManager, Audio...)
├── assets/
│   ├── sprites/
│   ├── music/
│   ├── sfx/
│   └── fonts/
├── CLAUDE.md         # Convenciones para Claude
├── .gitignore        # Ignora .godot/, builds y archivos del sistema
└── .gitattributes    # Finales de línea LF y Git LFS para binarios
```

## Primeros pasos

1. Instala [Godot 4.5](https://godotengine.org/download) (o más reciente) y [Git LFS](https://git-lfs.com/).
2. Clona el repositorio:
   ```bash
   git lfs install
   git clone https://github.com/nicksiuxs/comyths.git
   ```
3. En Godot, pulsa **Importar** y selecciona `comyths/project.godot`.
4. Pulsa **F5** para ejecutar. Mueve el cuadrado azul con **WASD**.

## Assets y Git LFS

Imágenes, audio, fuentes y modelos 3D se guardan con Git LFS (ver `.gitattributes`) para que el repositorio no crezca demasiado. Ejecuta `git lfs install` una vez en tu equipo antes de clonar.
