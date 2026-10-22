class_name Player
extends CharacterBody2D
## Jugador de ejemplo: se mueve en 8 direcciones con WASD.

@export var speed: float = 300.0


func _physics_process(_delta: float) -> void:
	var direction := Input.get_vector("move_left", "move_right", "move_up", "move_down")
	velocity = direction * speed
	move_and_slide()
