shader_type canvas_item;

uniform uvec2 gridSize= uvec2(10,10);

uniform vec4 borderColor : source_color = vec4(0.27, 0.27, 0.27, 1.0);
uniform vec4 deadColor : source_color = vec4(0.12, 0.12, 0.12, 1.0);
uniform vec4 aliveColor : source_color = vec4(1.0, 0.92, 0.23, 1.0);

void vertex() {
	// Called for every vertex the material is visible on.
}

void fragment() {
	COLOR = borderColor;
}

//void light() {
	// Called for every pixel for every light affecting the CanvasItem.
	// Uncomment to replace the default light processing function with this one.
//}
